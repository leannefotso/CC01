using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.WinForm
{
    public partial class FormStudent : Form
    {
        private Action callBack;
        private Student oldStudent;

        public object ConfigurationManager { get; private set; }

        public FormStudent()
        {
            InitializeComponent();
        }
        public FormStudent(Action callBack) : this()
        {
            this.callBack = callBack;
        }
        public FormStudent(Student student, Action callBack) : this(callBack)
        {
            this.oldStudent = student;
            txtUniversity.Text = oldStudent.University;
            txtName.Text = oldStudent.Name;
            txtFullName.Text = oldStudent.FullName;
            txtDateNaissance.Text = oldStudent.DateNaissance;
            txtEmail.Text = oldStudent.Email;
            txtMatricule.Text = (oldStudent.Matricule).ToString();
            if (oldStudent.Picture != null)
                pictureBox.Image = Image.FromStream(new MemoryStream(student.Picture));

        }
        private void lblDateNaissance_Click(object sender, EventArgs e)
        {

        }

        private void txtDateNaissance_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Student newStudent = new Student
                (
                    txtUniversity.Text.ToUpper(),
                    txtName.Text,
                    txtFullName.Text,
                    txtEmail.Text,
                    txtDateNaissance.Text,
                    long.Parse(txtMatricule.Text),
                    !string.IsNullOrEmpty(pictureBox.ImageLocation) ? File.ReadAllBytes(pictureBox.ImageLocation) :
                    this.oldStudent?.Picture
                );

                Student productBLO = new Student(ConfigurationManager.AppSettings["DbFolder"]);

                if (this.oldStudent == null)
                    productBLO.CreateStudent(newStudent);
                else
                    productBLO.EditStudent(oldStudent, newStudent);

                MessageBox.Show
                (
                    "Save done !",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (callBack != null)
                    callBack();

                if (oldStudent != null)
                    Close();

                txtUniversity.Clear();
                txtName.Clear();
                txtFullName.Clear();
                txtDateNaissance.Clear();
                txtMatricule.Clear();
                txtEmail.Clear();

            }
            catch (TypingException ex)
            {
                MessageBox.Show
               (
                   ex.Message,
                   "Typing error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show
               (
                   ex.Message,
                   "Duplicate error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show
               (
                   ex.Message,
                   "Not found error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            catch (Exception ex)
            {
                ex.WriteToFile();
                MessageBox.Show
               (
                   "An error occurred! Please try again later.",
                   "Erreur",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
               );
            }
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
