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
    public partial class MDIMainForm : Form
    {
        public MDIMainForm()
        {
            InitializeComponent();
        }

        CreateForm objCreateForm = null;
        ViewForm objViewForm = null;
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objCreateForm == null)
            {
                objCreateForm = new CreateForm();
                objCreateForm.FormClosed += objCreateForm_FormClosed;
                if (objViewForm != null) objViewForm.Close();
                objCreateForm.Show();
            }
            else
            {
                if (objViewForm != null) objViewForm.Close();
                objCreateForm.Activate();
            }
        }

        void objCreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objCreateForm = null;
        }

        private void viewUpdateDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objViewForm == null)
            {
                objViewForm = new ViewForm();
                objViewForm.FormClosed += objViewForm_FormClosed;
                if(objCreateForm != null) objCreateForm.Close();
                objViewForm.Show();
            }
            else
            {
                if (objCreateForm != null)  objCreateForm.Close();
                objViewForm.Activate();

            }
        }

        void objViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objViewForm = null;
        }

        private void MDIMainForm_Load(object sender, EventArgs e) 
        {
            
        }
        private void operationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
