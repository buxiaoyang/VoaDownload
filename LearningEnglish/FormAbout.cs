using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VOA
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Change the color of the link text by setting LinkVisited 
                // to true.
                linkLabel1.LinkVisited = true;
                //Call the Process.Start method to open the default browser 
                //with a URL:
                //System.Diagnostics.Process.Start("http://www.baidu.com");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Unable to open link that was clicked.");
            }
        }
    }
}