using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekHunter
{
    public class Candidate
    {
        private string _id;
        private string _fname;
        private string _lName;
        private string _email;

        public Candidate(string id, string fName, string lName, string email)
        {
            _id = id;
            _fname = fName;
            _lName = lName;
            _email = email;
        }

        public Candidate (Candidate candidate)
        {
            _id = candidate._id;
            _fname = candidate._fname;
            _lName = candidate._lName;
            _email = candidate._email;
        }

        public string GetId() { return _id; }
        public string GetFname() { return _fname; }
        public string GetLname() { return _lName; }
        public string GetEmail() { return _email; }
    }
}
