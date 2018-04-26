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
    public partial class Home : Form
    {
        private DatabaseConnection _sqlConn;
        private GetData _getData;
        private DataTable _skillsDT;

        public object DataControlRowType { get; private set; }

        public Home()
        {
            InitializeComponent();
            
            try
            {
                _sqlConn = new DatabaseConnection();
                _getData = new GetData(_sqlConn);
                CandidatesGridView();
                PopulateFilter();

            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nError " + e.Message + "\n\n");
            }

        }

        private void PopulateFilter()
        {
            _skillsDT = _getData.GetSkillsInfo();
            PopulateView populateView = new PopulateView();
            populateView.PopulateCheckedListBox(_skillsDT, filterCheckedListBox, "name");
        }

        private void DisplayData(DataTable dataTable)
        {
            try
            {
                //Clear Previous Table
                loadingGridView.Columns.Clear();

                //Add new DataTable to Gridview
                homeGridVieBindingSource.DataSource = dataTable;
                loadingGridView.DataSource = homeGridVieBindingSource;
                
            }catch (NullReferenceException e)
            {
                MessageBox.Show("This Table is empty");
                Console.WriteLine(e.Message);
            }
        }

        

        private void CandidatesGridView()
        {
            DisplayData(_getData.GetCandidatesInfo());
        }

        private void SkillsGridView()
        {
            DisplayData(_getData.GetSkillsInfo());
        }

        private void UpdateAfterChildFormIsClosed(object sender, FormClosedEventArgs e)
        {
            CandidatesGridView();
            FilterDisplay();
        }

        private void candidatesBtn_Click(object sender, EventArgs e)
        {
            CandidatesGridView();
        }

        private void registerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register regForm = new Register();
            regForm.FormClosed += new FormClosedEventHandler(UpdateAfterChildFormIsClosed);
            regForm.Show();
        }
        
        private void loadingGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView) sender;
            if (dataGridView == null) { return; }
            else
            {
                int index = dataGridView.CurrentRow.Index;
                DataGridViewRow selectedRow = dataGridView.Rows[index];


                DialogResult dialogResult = MessageBox.Show("Do you want to edit Candidate: " + selectedRow.Cells["FirstName"].Value.ToString(), "Ask User", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Creates a Candidate Object and passes it to the form
                    Register regForm = new Register(
                        new Candidate(
                            selectedRow.Cells["Candidate_Id"].Value.ToString(),
                            selectedRow.Cells["FirstName"].Value.ToString(),
                            selectedRow.Cells["LastName"].Value.ToString(),
                            selectedRow.Cells["EmailAddress"].Value.ToString()));
                    regForm.FormClosed += new FormClosedEventHandler(UpdateAfterChildFormIsClosed);
                    regForm.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
                
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            FilterDisplay();
        }

        private void FilterDisplay()
        {
            int selectedBoxesCount = filterCheckedListBox.CheckedIndices.Count;
            if (selectedBoxesCount > 0)
            {
                string filters = "";

                int count = 0;

                foreach (int index in filterCheckedListBox.CheckedIndices)
                {
                    filters += " Skill_Id = " + _skillsDT.Rows[index]["Skill_Id"];
                    count++;
                    if (count < selectedBoxesCount)
                    {
                        filters += " OR";
                    }
                }
                DisplayData(_getData.GetFilteredCandidates(filters));
            }
            else
            {
                CandidatesGridView();
            }
        }
    }
}