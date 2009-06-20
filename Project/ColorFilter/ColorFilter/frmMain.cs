using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ColorFilter
{
    public partial class frmMain : Form
    {
        private MainController m_MainController;
                
        public frmMain()
        {
            InitializeComponent();

            m_MainController = MainController.GetController();
            this.LoadFilterCombo();
            this.LoadInitialImage();
        }
        private void LoadInitialImage()
        {
            string initialFile = Path.Combine(Directory.GetCurrentDirectory(), @"Images\farbkreis.jpg");

            pbxImage.ImageLocation = initialFile;
            this.LoadImage(initialFile);
        }

        private void LoadFilterCombo()
        {
            cbxFilter.Items.Clear();
            
            foreach(Filter item in Enum.GetValues(typeof(Filter)))
            {
                cbxFilter.Items.Add(item);
            }

            cbxFilter.SelectedIndex = 0;
        }


        private void btnOpenFileDlg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Multiselect = false;
            //TODO: Initial directory
            openDlg.InitialDirectory = Path.GetDirectoryName(txtPath.Text);

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.LoadImage(openDlg.FileName);
            }
        }

        private void LoadImage(string filename)
        {
            txtPath.Text = filename;
            this.ShowImage(filename);
            m_MainController.LoadImage(filename);
        }

        private void ShowImage(string filename)
        {
            pbxImage.Load(filename);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string filename = m_MainController.GetFilteredImage((Filter)cbxFilter.SelectedItem);
            this.ShowImage(filename);
        }

        private void pbxImage_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }

        private void pbxImage_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pbxImage_MouseClick(object sender, MouseEventArgs e)
        {
            txtTurnX.Text = e.X.ToString();
            txtTurnY.Text = e.Y.ToString();
        }

        private void btnTurn_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtTurnX.Text);
            int y = Convert.ToInt32(txtTurnY.Text);
            int angle = Convert.ToInt32(txtAngle.Text);
            int height = Convert.ToInt32(txtHeight.Text);
            int width = Convert.ToInt32(txtWidth.Text);

            string filename = m_MainController.TurnAndSaveToTempFile(x, y, angle, height,width, this.cbxCorrection.Checked);
            this.ShowImage(filename);
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            m_MainController.DetectObject(txtObjectName.Text);
        }

 




    }
}
