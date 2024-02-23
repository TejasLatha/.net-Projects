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
    public partial class CreateForm : Form
    {
        int slnoForUpdateFunction = 0;
        public CreateForm()
        {
            InitializeComponent();
            doLoadingWork();
        }
        public CreateForm(int slno)
        {
            InitializeComponent();
            doLoadingWork();
            btnSave.Visible = false;
            loadControlsWithDataToUpdate(slno);
            btnUpdate.Visible = true;
            slnoForUpdateFunction = slno;

        }
        public void doLoadingWork()
        {
            ddlDegree.DataSource = clsDBOperations.getDegreeDetails();
            ddlDegree.DisplayMember = "DEGREENAME";
            ddlDegree.ValueMember = "DEGREEID";
            rbtFemale.Checked = true;
        }
        public void loadControlsWithDataToUpdate(int slno)

        {
            DataTable dt = new DataTable();
            dt = clsDBOperations.getStudentDetails();
            DataRow[] dr = dt.Select("Slno = " + slno);
            foreach(DataRow row in dr)
            {
                txtUSN.Text = row["USN"].ToString();
                txtName.Text = row["Name"].ToString();
                txtCollegeName.Text = row["CollegeName"].ToString();
                string ddlValue = Convert.ToString(row["Degree"]);
                int id;
                if (ddlValue.Equals("BCA"))
                    id = 1;
                else if (ddlValue.Equals("BSC(CS)"))
                   id = 2;
                else if (ddlValue.Equals("BE(CS)"))
                   id = 3;
                else 
                    id = 0;
                ddlDegree.SelectedValue = id; 
                string rbtValue = row["Gender"].ToString();
                if(rbtValue.Equals("Male"))
                    rbtMale.Checked = true;
                else if(rbtValue.Equals("FeMale"))
                     rbtFemale.Checked = true;
                else if(rbtValue.Equals("Other"))
                    rbtOther.Checked = true;
                else
                     rbtFemale.Checked = true;
                string vacinated = row["ISCVACINATED"].ToString();
                if (vacinated.Equals("Yes"))
                    chkCovid.Checked = true;
                else
                    chkCovid.Checked = false; 
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            int rbtValue = 0;
            
            try
            {


                if (validate())
                {
                    
                    clsStudent ObjectclsStudent = new clsStudent();
                    ObjectclsStudent.usn = txtUSN.Text;
                    ObjectclsStudent.name = txtName.Text;
                    ObjectclsStudent.collegeName = txtCollegeName.Text;
                    ObjectclsStudent.degree = Convert.ToInt32(ddlDegree.SelectedValue);
                    if (rbtMale.Checked)
                        rbtValue = 1;
                    else if (rbtFemale.Checked)
                        rbtValue = 2;
                    else if (rbtOther.Checked)
                        rbtValue = 3;
                    ObjectclsStudent.gender = rbtValue;
                    ObjectclsStudent.isCovidVacinated = (chkCovid.Checked ? 1 : 0);
                    result = clsDBOperations.insertStudentDetails(ObjectclsStudent);

                }
            }
            catch(Exception exec)
            {
                {
                    MessageBox.Show(exec.ToString(), "Alert");
                }
            }
            finally
            {
                if(result==1)
                {
                    MessageBox.Show("Data inserted successfully", "Information");
                }   
            }
            
        }
        private bool validate()
        {
            bool isValidated = true;
             if(String.IsNullOrEmpty(txtUSN.Text))
             {
                 MessageBox.Show("Enter USN", "Alert");
                 isValidated = false;
             }
             else if(String.IsNullOrEmpty(txtName.Text))
             {
                 MessageBox.Show("Enter name", "Alert");
                 isValidated = false;
                 
             }
             else if (String.IsNullOrEmpty(txtCollegeName.Text))
             {
                 MessageBox.Show("Enter college Name and address", "Alert");
                 isValidated = false;
             }
             else if (Convert.ToInt32(ddlDegree.SelectedValue) == 0)
             {
                 MessageBox.Show("Select Degree", "Alert");
                 isValidated = false;
             }
           
             return isValidated;
        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int result = 0;
            int rbtValue = 0;

            try
            {
                if (validate())
                {

                    clsStudent ObjectclsStudent = new clsStudent();
                    ObjectclsStudent.slno = slnoForUpdateFunction;
                    ObjectclsStudent.usn = txtUSN.Text;
                    ObjectclsStudent.name = txtName.Text;
                    ObjectclsStudent.collegeName = txtCollegeName.Text;
                    ObjectclsStudent.degree = Convert.ToInt32(ddlDegree.SelectedValue);
                    if (rbtMale.Checked)
                        rbtValue = 1;
                    else if (rbtFemale.Checked)
                        rbtValue = 2;
                    else if (rbtOther.Checked)
                        rbtValue = 3;
                    ObjectclsStudent.gender = rbtValue;
                    ObjectclsStudent.isCovidVacinated = (chkCovid.Checked ? 1 : 0);
                    result = clsDBOperations.updateStudentDetails(ObjectclsStudent);

                }
            }
            catch (Exception exec)
            {
                {
                    MessageBox.Show(exec.ToString(), "Alert");
                }
            }
            finally
            {
                if (result == 1)
                {
                    MessageBox.Show("Data updated successfully", "Information");
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUSN_TextChanged(object sender, EventArgs e)
        {
            
        }

       
    }
}
