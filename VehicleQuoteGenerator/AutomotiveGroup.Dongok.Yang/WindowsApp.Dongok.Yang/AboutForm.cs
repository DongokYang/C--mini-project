/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-03-19
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp.Dongok.Yang
{
    // The AboutForm class provides an information about the application.
    public partial class AboutForm : Form
    {
        // Constructor for the AboutForm.
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the Load event of the AboutForm. 
        /// It is executed when Aboutform is loaded, setting the form's start position to center
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void AboutForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            Text = "About Vehicle Quote - Dongok Yang ";
        }

        /// <summary>
        /// Handles the LinkClicked event of the copyright link label.
        /// Opens the URL in the default web browser to credit the creator of the logo image.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void linklblCopyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.com/free-icon/new-car_4544556?term=car+money&page=1&position=2&origin=search&related_id=4544556");
        }

        /// <summary>
        /// Handles the Click event of the OK button. This method closes the AboutForm
        /// when the user clicks the OK button, Close the form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
