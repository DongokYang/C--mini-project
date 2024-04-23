/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-04-10
 */
using Business.Dongok.Yang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp.Dongok.Yang
{
    internal class AddOptionForm: ACE.BIT.ADEV.Forms.AddOptionForm
    {
        // Defines the addedoption to store created option.
        public VehicleOption AddedOption;
        // Constructor for the AddOptionForm class
        public AddOptionForm()
        {
            // Initialize the form with a VehicleQuote object and configure UI elements.
            StartPosition = FormStartPosition.CenterParent;

            /* EVENT HANDLERS */
            // Register event handlers for add and cancel button.
            btnAdd.Click += btnAdd_Click;
            btnCancel.Click += btnCancel_Click;

            /* ANNUAL INTEREST RATE NUMERIC UPDOWN */
            // Configure the numeric up-down control for annual interest.
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 100;
            nudQuantity.ReadOnly = true;

            /* ERRORPROVIDER */
            // Configure errorProvider for input validation.
            errorProvider.SetIconPadding(txtDescription, 3);
            errorProvider.SetIconPadding(txtUnitPrice, 3); 
            errorProvider.SetIconPadding(nudQuantity, 3);
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        /// <summary>
        /// Handles the Click event of the Add button.
        /// Validates the user inputs for description and unit price. If there is issue, show error provider.
        /// creates a new VehicleOption Only if all validation is passed.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Clear previously existing error messages
            errorProvider.Clear();

            // isValid is used to check validty of input.
            bool isValid = true;

            //Check whether txtDescription is null value.
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                // if it only contains whitespace, set error
                errorProvider.SetError(txtDescription, "Description is a required input.");
                isValid = false;
            }
            decimal unitPrice;
            //Check whether txtUnitPrice is decimal value.
            if (!decimal.TryParse(txtUnitPrice.Text, out unitPrice) || unitPrice < 0)
            {
                // if it is not decimal value, set error
                errorProvider.SetError(txtUnitPrice, "Unit price is a required numeric input");
                isValid = false;
            }

            // If all inputs are valid, create a new vehicle Option.
            if (isValid)
            {
                AddedOption = new VehicleOption(txtDescription.Text, unitPrice, (int)nudQuantity.Value);
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        /// <summary>
        /// Handles the Click event of the Cancel button.
        /// Close the form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// This method returns the newly created option.
        /// It allows external classes to retrieve the created VehicleOption.
        /// </summary>
        public VehicleOption option_Return()
        {
            return AddedOption;
        }
    }
}
