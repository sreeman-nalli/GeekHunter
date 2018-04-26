using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeekHunter
{
    class PopulateView
    {
        public PopulateView() { }

        public void PopulateCheckedListBox(DataTable dataTable, CheckedListBox listBox, string text)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                listBox.Items.Add(row[text]);
            }
        }

        public void PopulateCheckedListBox(DataTable dataTable, CheckedListBox listBox, string text, DataTable checkedDataTable, string checkedField)
        {
            int checkedBoxesCount = checkedDataTable.Rows.Count;
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                Boolean isChecked = false;
                if (i < checkedBoxesCount && checkedDataTable.Rows[i][checkedField].Equals(row[checkedField]))
                {
                    isChecked = true;
                    i++;
                }
                listBox.Items.Add(row[text], isChecked);

            }
        }
    }
}
