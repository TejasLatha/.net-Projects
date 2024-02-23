using LabWinform.DBManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWinform
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
            loadDataToGrid();
        }
        private void loadDataToGrid()
        {
            gridStudent.DataSource = clsDBOperations.getStudentDetails();
            this.gridStudent.Columns["slno"].Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = gridStudent.CurrentCell.RowIndex;
            DataGridViewRow row = gridStudent.Rows[rowIndex];
            int slno = Convert.ToInt32(row.Cells[0].Value);
            string name = (row.Cells[2].Value).ToString();
            var confirmResult = MessageBox.Show("Are you sure to delete " + name + "'s record.?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                int result = clsDBOperations.deleteStudentDetails(slno);
                if(result == 1)
                {
                    MessageBox.Show(name + "'s record deleted","Information");
                    loadDataToGrid();
                }

            }
            else
            {
                // If 'No', do something here.
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowIndex = gridStudent.CurrentCell.RowIndex;
            DataGridViewRow row = gridStudent.Rows[rowIndex];
            int slno = Convert.ToInt32(row.Cells[0].Value);
            CreateForm objectCreateForm = new CreateForm(slno);
            objectCreateForm.Show();
            this.Close();
            
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
