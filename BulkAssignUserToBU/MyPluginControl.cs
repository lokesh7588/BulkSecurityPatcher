using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;

namespace BulkAssignUserToBU
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        EntityCollection entityCollection = new EntityCollection();
        EntityCollection businessUnitCollection = new EntityCollection();
        private void setEntityOptionsetValue(string entity)
        {
            string fetchXml = string.Empty ;
            if (entity == "team")
            {
                var fetchData = new
                {
                    isdefault = "0"
                };
                fetchXml = $@"
                            <fetch>
                              <entity name='team'>
                                <filter>
                                  <condition attribute='isdefault' operator='eq' value='{fetchData.isdefault/*0*/}'/>
                                </filter>
                              </entity>
                            </fetch>";

                
            }
            else if (entity == "businessunit")
            {
                fetchXml = $@"
                            <fetch>
                              <entity name='businessunit'>
                              </entity>
                            </fetch>";
            }
            
            entityCollection = Service.RetrieveMultiple(new FetchExpression(fetchXml));
            TeamBusinessUnitSelectionOptionset.Items.Clear();
            foreach (Entity team in entityCollection.Entities)
            {
                string RecordName = team.Attributes["name"].ToString();
               
                TeamBusinessUnitSelectionOptionset.Items.Add(team.Attributes["name"].ToString());

            }
            // throw new NotImplementedException();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = string.Empty;
            //if (TeamBusinessUnitSelectionOptionset.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Please select Valid Action","Error");
            //}// setOptionsetValue();

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileLocationTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void Form_Drag(object sender, DragEventArgs e)
        {
            ResultTextBox.Text = string.Empty;
            e.Effect = DragDropEffects.All;

            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (FileList.Length > 1)
            {
                MessageBox.Show("Multiple files are not allowed");
                return;
            }

            var ext = System.IO.Path.GetExtension(FileList[0]);

            if (ext != ".csv")
            {
                MessageBox.Show("Invalid File Type Please provide file with format (.csv)");
                return;
            }

            FileLocationTextBox.Text = FileList[0].ToString();
            if (TeamBusinessUnitSelectionOptionset.SelectedIndex == -1)
            { } 
            MessageBox.Show("Imported Sucesssfully");

        }

        Guid EntityToBeassign = new Guid();
        Guid teamToBeassign = new Guid();
        private void BusinessUnitSelectionOptionset_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedTeam = TeamBusinessUnitSelectionOptionset.SelectedItem.ToString();
            foreach (Entity team in entityCollection.Entities)
            {
                string TeamName = team.Attributes["name"].ToString();
                if (SelectedTeam == TeamName && SelectedTeam != null && TeamName != null)
                {
                    EntityToBeassign = team.Id;

                    // MessageBox.Show(teamToBeassign.ToString());
                }
            }
        }

        private void ImportAndAddButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = string.Empty;
            if (TeamBusinessUnitSelectionOptionset.SelectedIndex == -1)//Nothing selected
            {
                MessageBox.Show("Please select Team ", "Error");
                return;
            }
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;


            progressBar1.Value = 10;
            

            List<ProcessCSV> listA = new List<ProcessCSV>();

            string Location = FileLocationTextBox.Text;
            using (var reader = new System.IO.StreamReader(Location))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    listA.Add(new ProcessCSV { emailuser = values[0] });
                    progressBar1.Value = 20;
                }

                progressBar1.Value = 30;
            }



            string text = string.Empty;
            int userCount = 0;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            EntityCollection UserEmails = new EntityCollection();

            var fetchXml = "<fetch>"
                              + "<entity name='systemuser'>"
                                + "<filter>"
                                 + "<condition attribute='domainname' operator='in'>";

            foreach (ProcessCSV email in listA)
            {

                userCount++;

                progressBar1.Value = 40;

                if (userCount > 200)
                {
                    MessageBox.Show("This tool can process only first 200 Records");
                    //System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Hello this is an Alert")</SCRIPT>");
                    goto BreakLoop;
                }
                fetchXml += "<value>" + email.emailuser + "</value>";
            }



        BreakLoop:

            //timer1.Interval = userCount;

            fetchXml += "</condition>"
                                + "</filter>"
                             + "</entity>"
                            + "</fetch> ";

            EntityCollection userCollection = new EntityCollection();
            try
            {
                userCollection = Service.RetrieveMultiple(new FetchExpression(fetchXml));
            }
            catch (Exception ex)
            {
                progressBar1.Value = 10;
                throw new InvalidPluginExecutionException(ex.Message + "As you have provided Invalid CSV file");
            }

            try
            {
                progressBar1.Value = 50;
                // MessageBox.Show(userCollection.Entities.Count.ToString());

                string ResultedString = "Below Users are Added Sucessfully to " + TeamBusinessUnitSelectionOptionset.Text + " " + System.Environment.NewLine;
                Guid[] members = new Guid[userCollection.Entities.Count];

                if (AssignmentcomboBox.SelectedIndex == 0)
                {
                    if (checkbox == true && userCollection.Entities.Count > 0)
                    {
                        progressBar1.Value = 70;
                        // Instantiate QueryExpression QEsystemuser
                        var QEsystemuser = new QueryExpression("systemuser");

                        // Add columns to QEsystemuser.ColumnSet
                        QEsystemuser.ColumnSet.AddColumns("systemuserid");

                        // Add link-entity QEsystemuser_teammembership
                        var QEsystemuser_teammembership = QEsystemuser.AddLink("teammembership", "systemuserid", "systemuserid");

                        // Define filter QEsystemuser_teammembership.LinkCriteria
                        QEsystemuser_teammembership.LinkCriteria.AddCondition("teamid", ConditionOperator.Equal, teamToBeassign);


                        EntityCollection usersToBeremoveCollection = Service.RetrieveMultiple(QEsystemuser);

                        Guid[] removeMembers = new Guid[usersToBeremoveCollection.Entities.Count];
                        for (int i = 0; i < usersToBeremoveCollection.Entities.Count; i++)
                        {
                            removeMembers[i] = (Guid)usersToBeremoveCollection.Entities[i].Attributes["systemuserid"];


                        }


                        // Create the AddMembersTeamRequest object.
                        RemoveMembersTeamRequest addRequest2 = new RemoveMembersTeamRequest();


                        // Set the AddMembersTeamRequest TeamID property to the object ID of 
                        // an existing team.
                        addRequest2.TeamId = EntityToBeassign;

                        // Set the AddMembersTeamRequest MemberIds property to an 
                        // array of GUIDs that contains the object IDs of one or more system users.
                        addRequest2.MemberIds = removeMembers;

                        // Execute the request.
                        Service.Execute(addRequest2);

                    }



                    //timer1.Start();

                    if (userCount == userCollection.Entities.Count || userCount == 201)
                    {
                        for (int i = 0; i < userCollection.Entities.Count; i++)
                        {
                            progressBar1.Value = 60;

                            //MessageBox.Show(userCollection.Entities[i].Id.ToString());
                            members[i] = (Guid)userCollection.Entities[i].Attributes["systemuserid"];
                            //MessageBox.Show(i.ToString());


                            ResultedString += (userCollection.Entities[i].Attributes["fullname"]).ToString().ToUpper() + "" + System.Environment.NewLine;

                            // textBox1.Text += (Guid)userCollection.Entities[i].Attributes["systemuserid"];
                        }
                        if (EntityToBeassign != Guid.Empty && members.Length != 0)
                        {

                            progressBar1.Value = 90;
                            // Create the AddMembersTeamRequest object.
                            AddMembersTeamRequest addRequest = new AddMembersTeamRequest();

                            // Set the AddMembersTeamRequest TeamID property to the object ID of 
                            // an existing team.

                            addRequest.TeamId = EntityToBeassign;

                            // Set the AddMembersTeamRequest MemberIds property to an 
                            // array of GUIDs that contains the object IDs of one or more system users.
                            addRequest.MemberIds = members;

                            // Execute the request.
                            Service.Execute(addRequest);

                            progressBar1.Value = 100;
                            ResultTextBox.Text = ResultedString;
                            MessageBox.Show("Task completed Sucessfully", "sucess");
                            // progressBar1.ForeColor = Color.Black;

                        }

                    }
                    else
                    {
                        progressBar1.Value = 10;
                        MessageBox.Show("Task Could Not Be completed (Please check csv file)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //progressBar1.ForeColor= Color.Black;

                    }
                }
                else
                {
                    if (userCount == userCollection.Entities.Count || userCount == 201)
                    {
                        if (EntityToBeassign != Guid.Empty && members.Length != 0)
                        {


                            foreach (Entity user in userCollection.Entities)
                            {
                                progressBar1.Value = 90;
                                SetBusinessSystemUserRequest changeUserBURequest = new SetBusinessSystemUserRequest();
                                changeUserBURequest.BusinessId = EntityToBeassign;
                                changeUserBURequest.UserId = user.Id;
                                changeUserBURequest.ReassignPrincipal = new EntityReference("systemuser", user.Id);
                                Service.Execute(changeUserBURequest);
                            }
                            for (int i = 0; i < userCollection.Entities.Count; i++)
                            {
                                progressBar1.Value = 60;

                                //MessageBox.Show(userCollection.Entities[i].Id.ToString());
                                members[i] = (Guid)userCollection.Entities[i].Attributes["systemuserid"];
                                //MessageBox.Show(i.ToString());


                                ResultedString += (userCollection.Entities[i].Attributes["fullname"]).ToString().ToUpper() + "" + System.Environment.NewLine;
                               
                            }
                            progressBar1.Value = 100;
                            ResultTextBox.Text = ResultedString;
                            MessageBox.Show("Task completed Sucessfully", "sucess");
                            // progressBar1.ForeColor = Color.Black;

                        }
                        

                    }
                    else
                    {
                        progressBar1.Value = 10;
                        MessageBox.Show("Task Could Not Be completed (Please check csv file)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //progressBar1.ForeColor= Color.Black;

                    }

                }
                
                //timer1.Start();
               

                // MessageBox.Show("TaskCompleted total "+userCount+" users are added to "+TeamSelectorOptionset.Text);




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dynamisity.com");
        }

        private void tsbAboutUs_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dynamisity.com");
        }

        private void tsbDownload_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dynamisity.com");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResultTextBox.Clear();
            FileLocationTextBox.Clear();
            progressBar1.Value = 0;
            if (AssignmentcomboBox.SelectedIndex == 0)
            {
                TeamBusinessUnitSelectionOptionset.Text = "Select Team";
                string entityName = "team";
                setEntityOptionsetValue(entityName);
                RemoveExistingcheckBox1.Show();
                
            }
            else if(AssignmentcomboBox.SelectedIndex == 1)
            {
                TeamBusinessUnitSelectionOptionset.Text = "Select BU";
                string entityName = "businessunit";
                setEntityOptionsetValue(entityName);
                RemoveExistingcheckBox1.Hide();
            }
        }
        private bool checkbox = false;
        private void RemoveExistingcheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkbox = true;
        }
    }
}