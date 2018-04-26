using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekHunter
{
    public partial class Register : Form
    {
        private DatabaseConnection _sqlConn;
        private DataTable _skillsDT;
        private DataTable _candidateSkillsDT;

        //This constructor is used to Register a Candidate
        public Register()
        {
            InitializeComponent();
            OnLoadInit();
            PopulateSkillsListBox();
        }

        //This constructor is used to Update a Candidate's Details using the same form
        public Register(Candidate selectedCandidate)
        {
            InitializeComponent();
            registerPageHeaderLabel.Text = "Update Candidate Information";
            OnLoadInit();
            GetCandidateSkills(selectedCandidate.GetId());
            PopulateSkillsListBox();
            PreLoadTextFields(selectedCandidate);
            emailTextBox.Enabled = false;
        }

        private void GetCandidateSkills(String id)
        {
            string query = "select * from Candidate_Skills where Candidate_id = @candidateId order by Skill_id asc;";
            SQLiteParameter[] parameters = new SQLiteParameter[1];
            parameters[0] = new SQLiteParameter("@candidateId", id);

            _candidateSkillsDT = _sqlConn.SelectQuery(query, parameters);
        }

        private void PreLoadTextFields(Candidate selectedCandidate)
        {
            firstNameTextBox.Text = selectedCandidate.GetFname();
            lastNameTextBox.Text = selectedCandidate.GetLname();
            emailTextBox.Text = selectedCandidate.GetEmail();
        }

        private void OnLoadInit()
        {
            try
            {
                _sqlConn = new DatabaseConnection();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error " + exception.Message);
            }
        }

        private void PopulateSkillsListBox()
        {
            GetData getData = new GetData(_sqlConn);
            _skillsDT = getData.GetSkillsInfo();
            PopulateView populateView = new PopulateView();

            if (_candidateSkillsDT == null)
            {
                populateView.PopulateCheckedListBox(_skillsDT, skillsCheckedListBox, "name");

            }else
            {
                populateView.PopulateCheckedListBox(_skillsDT, skillsCheckedListBox, "name", _candidateSkillsDT, "Skill_id");
            }
            
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //Sanitise user input and Validate input
            InputValidation inputValidation = new InputValidation();
            string fNameText = inputValidation.Validate(firstNameTextBox.Text, 2, 25);
            string lNameText = inputValidation.Validate(lastNameTextBox.Text, 2, 25);
            string emailText = inputValidation.Validate(emailTextBox.Text, 5, 40);

            if (fNameText != null && lNameText != null && emailText != null && inputValidation.EmailValidate(emailText))
            {
                try
                {
                    //Storing the parameters
                    SQLiteParameter[] parameters = new SQLiteParameter[3];
                    parameters[0] = new SQLiteParameter("@fname", fNameText);
                    parameters[1] = new SQLiteParameter("@lname", lNameText);
                    parameters[2] = new SQLiteParameter("@email", emailText);

                    SQLiteParameter[] emailParameter = new SQLiteParameter[1];
                    emailParameter[0] = new SQLiteParameter("@email", emailText);

                    //Check if candidate already exists
                    string query = "select * from Candidate where emailaddress == @email;";
                    DataTable resultDT = _sqlConn.SelectQuery(query, emailParameter);
                    if (resultDT.Rows.Count != 1)
                    {
                        query = "insert into Candidate values (NULL, @fname, @lname, @email);";
                        int candidateQueryResult = _sqlConn.InsertQuery(query, parameters);

                        //Check if it only affected 1 row
                        if (candidateQueryResult == 1) 
                        {
                            //This happens only if atleast one skill is selected
                            if (skillsCheckedListBox.CheckedItems.Count != 0)
                            {
                                //Get Candidate ID to process Skills
                                query = "select * from Candidate where emailaddress == @email;";
                                DataTable candidDT = _sqlConn.SelectQuery(query, emailParameter);

                                if (candidDT == null)
                                {
                                    MessageBox.Show("PROBLEM");
                                    this.Close();
                                }

                                string candidateId = candidDT.Rows[0]["Candidate_Id"].ToString();
                                UpdateCandidateSkillsOnDB(candidateId);
                            }
                            
                            //Close current form and refresh previous form
                            MessageBox.Show("Registered a new Candidiate");
                            this.Close();
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Candidate already exists, do you want to update details?", "Ask User", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string candidateId = resultDT.Rows[0]["Candidate_Id"].ToString();

                            SQLiteParameter[] candidateParameter = new SQLiteParameter[1];
                            candidateParameter[0] = new SQLiteParameter("@candidateId", candidateId);

                            //Update Query
                            query = "Update Candidate set FirstName = @fname, LastName = @lname, EmailAddress = @email where Candidate_Id = '" + candidateId + "';";
                            int updateCandidateQueryResult = _sqlConn.InsertQuery(query, parameters);

                            query = "Delete from Candidate_Skills where Candidate_Id = @candidateID;";
                            _sqlConn.InsertQuery(query, candidateParameter);
                            
                            UpdateCandidateSkillsOnDB(candidateId);

                            if (updateCandidateQueryResult == 1) {
                                MessageBox.Show("Update Candidate.");
                                this.Close();
                            }
                        }
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error " + exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Please type in valid information");
            }
        }

        public int UpdateCandidateSkillsOnDB(string candidateId)
        {
            string query;
            int skillsQueryResult = 0;

            foreach (int index in skillsCheckedListBox.CheckedIndices)
            {
                query = "insert into Candidate_Skills values (NULL, @candidateId, @skillId);";
                SQLiteParameter[] candidSkillsParams = new SQLiteParameter[2];
                candidSkillsParams[0] = new SQLiteParameter("@candidateId", candidateId);
                //Refer Checked index with SkillsDataTable Index
                candidSkillsParams[1] = new SQLiteParameter("@skillId", _skillsDT.Rows[index]["Skill_id"]);

                skillsQueryResult = _sqlConn.InsertQuery(query, candidSkillsParams);
            }

            return skillsQueryResult;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearTextFields();
        }

        //Clear Text input fields and Checked skills
        private void ClearTextFields()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            emailTextBox.Clear();
            skillsCheckedListBox.ClearSelected();
            foreach (int index in skillsCheckedListBox.CheckedIndices) { skillsCheckedListBox.SetItemChecked(index, false); }
        }
    }
}
