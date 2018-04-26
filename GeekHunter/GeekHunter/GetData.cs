using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter
{
    class GetData
    {
        private DatabaseConnection _sqlConn;
        public GetData(DatabaseConnection conn)
        {
            _sqlConn = conn;
        }

        public DataTable GetCandidatesInfo()
        {
            DataTable candidatesResult = null;
            try
            {
                //Query for Candidates Info
                string query = "select * from Candidate";
                candidatesResult = _sqlConn.SelectQuery(query, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return candidatesResult;

        }

        public DataTable GetSkillsInfo()
        {
            DataTable skills_result = null;
            try
            {
                //Query for Skills Info
                string query = "select * from Skill";
                skills_result = _sqlConn.SelectQuery(query, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return skills_result;
        }

        public DataTable GetAllInformationOfCandidates()
        {
            DataTable candidatesResult = null;
            try
            {
                string query = "select C.*, CS.Name as Skill "
                + " from Candidate C left join "
                    + " ( select Skill.Name, Candidate_Skills.Candidate_Id "
                    + " from Skill inner join Candidate_Skills  on Skill.Skill_Id = Candidate_Skills.Skill_Id) "
                + " CS on C.Candidate_Id = CS.Candidate_Id; ";
                
                candidatesResult = _sqlConn.SelectQuery(query, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return candidatesResult;
        }

        public DataTable GetFilteredCandidates (string filters)
        {

            DataTable candidatesResult = null;
            try
            {
                string query = "select C.* from Candidate C "
                               +" inner join "
                                   + " ( select distinct(Candidate_id) from Candidate_Skills "
                                   + " where " + filters + " ) "
                               + " CS on C.Candidate_Id = CS.Candidate_Id; ";

                candidatesResult = _sqlConn.SelectQuery(query, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return candidatesResult;
        }
        
    }
}