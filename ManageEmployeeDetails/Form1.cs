using ManageEmployeeDetails.Interface;
using ManageEmployeeDetails.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageEmployeeDetails.Common;

namespace ManageEmployeeDetails
{
    public partial class Form1 : Form
    {
        public readonly IApiHelper apiService;
        public Form1(IApiHelper service)
        {
            InitializeComponent();
            apiService = service;
            apiService.SetUpHttpClient();            
        }
        private async void btnGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await apiService.ClientGetRequest();
                gvUser.DataSource = res.Data;
                MessageBox.Show(res.ToString(), Constant.MessageBoxCaption);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Request Exception :" + ex.Message, Constant.MessageBoxCaption);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var res = Validation();
                if(res == "Success")
                {
                    var obj = GetUserDetails();
                    var result = apiService.ClientPostRequest(obj);
                    MessageBox.Show(result.ToString(), Constant.MessageBoxCaption);
                }
                else
                {
                    MessageBox.Show(res, Constant.MessageBoxCaption); 
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Exception :" + ex.Message, Constant.MessageBoxCaption);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {           
            int ID = Convert.ToInt32(textBox1.Text);
            var result = apiService.ClientDeleteRequest(ID);
            MessageBox.Show(result.ToString(), Constant.MessageBoxCaption);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Exception :" + ex.Message, Constant.MessageBoxCaption);
            }
        }
        private void gvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = gvUser.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[4].Value.ToString();
            var txt = selectedRow.Cells[3].Value.ToString();
            if (txt == Constant.EmployeeGender)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }

            }
            catch(Exception)
            {
                throw;
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var data = (List<User>)gvUser.DataSource;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("EmailID");
                dt.Columns.Add("Gender");
                dt.Columns.Add("Status");
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        var dr = dt.NewRow();
                        dr["ID"] = item.ID;
                        dr["Name"] = item.Name;
                        dr["EmailID"] = item.Email;
                        dr["Gender"] = item.Gender;
                        dr["Status"] = item.Status;
                        dt.Rows.Add(dr);
                    }
                    string filename = Constant.FilePath;
                    dt.ToCSV(filename);
                    MessageBox.Show("Exported Csv Successfully...!", Constant.MessageBoxCaption);
                }

                else
                {
                    MessageBox.Show("No data found...!", Constant.MessageBoxCaption);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export Exception :" + ex.Message, Constant.MessageBoxCaption);
            }
        }

        private string Validation()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return Constant.EmployeeIDError;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                return Constant.EmployeeNameError;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                return Constant.EmployeeEmailError;
            }          
            else if(radioButton2.Checked == false && radioButton3.Checked == false)
            {
                return Constant.EmployeeGenderError;
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                return Constant.EmployeeStatusError;
            }
            else
            {
                return ("Success");
            }

        }
        private User GetUserDetails()
        {
            var obj = new User();
            obj.ID = Convert.ToInt32(textBox1.Text);
            obj.Name = textBox2.Text;
            obj.Email = textBox3.Text;
            if (radioButton2.Checked)
            {
                obj.Gender = "Male";
            }
            else
            {
                obj.Gender = "FeMale";
            }
            obj.Status = textBox4.Text;
            return obj;
        }
    }
}
