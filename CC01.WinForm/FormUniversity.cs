using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.WinForm
{
    public partial class FormUniversity : Form
    {

        private Action callBack;
        private University oldUniversity;

        public FormUniversity()
        {
            InitializeComponent();
        }
        public FormUniversity(Action callBack) : this()
        {
            this.callBack = callBack;
        }

        public FormUniversity(University university, Action callBack) : this(callBack)
        {
            this.oldUniversity = university;
            txtName.Text = oldUniversity.Nom;
            txtLieu.Text = oldUniversity.Lieu;
            txtAdresse.Text = oldUniversity.Adresse;
            txtTelephone.Text = oldUniversity.Telephone.ToString();
            if (oldUniversity.Logo != null)
                pictureBox.Image = Image.FromStream(new MemoryStream((int)oldUniversity.Logo));
        }


        private void FormUniversity_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                University newUniversity = new University
                (
                    txtName.Text.ToUpper(),
                    txtLieu.Text,
                    txtAdresse.Text,
                    long.Parse(txtTelephone.Text),
                    !string.IsNullOrEmpty(pictureBox.ImageLocation) ? File.ReadAllBytes(pictureBox.ImageLocation) : 
                    this.oldUniversity?.Logo
                );

                University university = new University(ConfigurationManager.AppSettings["DbFolder"]);

                if (this.oldUniversity == null)
                    university.CreateUniversity(newUniversity);
                else
                    university.EditUniversity(oldUniversity, newUniversity);

                MessageBox.Show
                (
                    "Save done !",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();


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

        private void pictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox.ImageLocation = ofd.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
