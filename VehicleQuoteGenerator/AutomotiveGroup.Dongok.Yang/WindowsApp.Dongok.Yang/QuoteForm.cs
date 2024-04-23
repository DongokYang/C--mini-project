/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-04-10
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.BIT.ADEV.Forms;
using Business.Dongok.Yang;

namespace WindowsApp.Dongok.Yang
{
    internal class QuoteForm : ACE.BIT.ADEV.Forms.QuoteForm
    {
        // Defines the constant tax rate applied to the vehicle sale price.
        private const decimal taxRate = 0.12m;
        // Defines the current quote being processed.
        private VehicleQuote currentQuote;

        /// <summary>
        /// Initializes a new instance of the QuoteForm class. 
        /// It sets up the form, initializes UI components, and binds event handlers.
        /// </summary>
        public QuoteForm()
        {
            /* FORM */
            // Set form properties such as title and start position.
            Text = "Vehicle Quote - Dongok Yang";
            StartPosition = FormStartPosition.CenterScreen;

            // Display the tax rate based on the constant taxRate.
            lblTaxRate.Text = $"Tax ({taxRate:P2}):";

            /* TRADE IN VALUE NUMERICUPDOWN */
            // Configure the trade-in value numeric up-down control.
            nudTradeInValue.Minimum = 0;
            nudTradeInValue.Maximum = 1000000;
            nudTradeInValue.DecimalPlaces = 2;
            nudTradeInValue.Increment = 500;
            nudTradeInValue.Value = 0;
            nudTradeInValue.Enabled = false;
            
            /* ERRORPROVIDER */
            // Configure errorProvider for input validation.
            errorProvider.SetIconPadding(txtSalePrice, 3);
            errorProvider.SetIconPadding(txtTotalOptions, 3);
            errorProvider.SetIconPadding(txtSubtotal, 3);

            /* EVENT LINKING */
            // Link menu item events to their respective event handlers.
            // Menu item click events
            mnuNew.Click += MnuNew_Click;
            mnuExit.Click += MnuExit_Click;
            mnuAddOption.Click += MnuAddOption_Click;
            mnuRemoveOption.Click += MnuRemoveOption_Click;
            mnuFinancing.Click += MnuFinancing_Click;
            mnuAbout.Click += MnuAbout_Click;

            // Button click events
            btnAddOption.Click += MnuAddOption_Click;
            btnRemoveOption.Click += MnuRemoveOption_Click;

            // ComboBox and NumericUpDown changed event
            cboVehicle.SelectedIndexChanged += cboVehicle_Changed;
            nudTradeInValue.ValueChanged += nudTradeInValue_Changed;


            /* COMBOBOX VEHICLE */
            // Populate the vehicle selection combo box with predefined vehicles.
            // List of predefined vehicles that will be used to make combo box.
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle(2024, "Kona", "Hyundai", PaintColor.Blue, 5000),
                new Vehicle(2023, "Civic", "Honda", PaintColor.Red, 22000),
                new Vehicle(2024, "Model 3", "Tesla", PaintColor.Navy, 54000),
                new Vehicle(2022, "CX-5", "Mazda", PaintColor.Green, 23000),
                new Vehicle(2023, "Forester", "Subaru", PaintColor.Orange, 24000),
                new Vehicle(2024, "Corolla", "Toyota", PaintColor.Yellow, 21000),
                new Vehicle(2023, "F-150", "Ford", PaintColor.Purple, 29000),
                new Vehicle(2022, "Cherokee", "Jeep", PaintColor.Blue, 26000),
                new Vehicle(2023, "Impala", "Chevrolet", PaintColor.Red, 27000),
                new Vehicle(2024, "Q5", "Audi", PaintColor.Green, 43000)
            };
            // Iterates through each Vehicle object and adds them to the ComboBox.
            foreach (var vehicle in vehicles)
            {
                cboVehicle.Items.Add(vehicle);
            }
            cboVehicle.SelectedIndex = -1;
            cboVehicle.Focus();

            /*INITIALIZING UI SETTING*/
            // Initially disable certain UI elements until they are applicable.
            mnuAddOption.Enabled = false;
            mnuRemoveOption.Enabled = false;

            btnAddOption.Enabled = false;
            btnRemoveOption.Enabled = false;
            mnuFinancing.Enabled = false;

            // Clear all text fields initially.
            txtAmountDue.Text = "";
            txtSalePrice.Text = "";
            txtSubtotal.Text = "";
            txtTax.Text = "";
            txtTotal.Text = "";
            txtTotalOptions.Text = "";

            // Reset the current quote.
            currentQuote = null;
        }

        /// <summary>
        /// Handles the Click event of the New menu item.
        /// Prompts the user to select "Yes" or "No" to confirm if they want to clear the current quote.
        /// If the user selects "yes", reset the form to initial state. Otherwise, nothing will happen.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuNew_Click(object sender, EventArgs e)
        {
            // message that will appear when user click New button.
            const string warningMessage = "The current quote will be lost. Continue?";
            // check whether current quote is null.
            if (currentQuote != null)
            {
                DialogResult result = MessageBox.Show(warningMessage, "New Quote", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                // if user click "Yes" button, execute ResetQuoteForm.
                if (result == DialogResult.Yes)
                {
                    ResetQuoteForm();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Exit menu item.
        /// Closes the application when the Exit menu item is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the Add Option menu item.
        /// Opens the Add Option form which enables user to add new vehicle options to list.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuAddOption_Click(object sender, EventArgs e)
        {
            AddOptionForm addOptionForm = new AddOptionForm();
            addOptionForm.FormClosed += MnuAddOption_Closed; 
            addOptionForm.ShowDialog(); 
        }
        /// <summary>
        /// Handles the Closed event of the AddOptionForm.
        /// Adds the new vehicle option returned from the AddOptionForm to the current quote and updates the quote form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuAddOption_Closed(object sender, EventArgs e)
        {
            // Convert the sender to AddOptionForm type
            AddOptionForm form = (AddOptionForm)sender;
            // Get created vehicle option from the form 
            VehicleOption newVehicleOption = form.option_Return(); 
            // Check if there is a created vehicle option.
            if (newVehicleOption != null)
            {
                // Add new vehicleoption to the displayed list and current quote.
                lstVehicleOptions.Items.Add(newVehicleOption); 
                currentQuote.AddVehicleOption(newVehicleOption); 
                // update the form to reflect changes.
                UpdateQuoteForm();
            }
        }

        /// <summary>
        /// Handles the Click event of the Remove Option menu item.
        /// Removes the selected vehicle option from the current option list.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuRemoveOption_Click(object sender, EventArgs e)
        {
            // Get the index of the selected.
            int selectedIndex = lstVehicleOptions.SelectedIndex;

            // check If there is selected index.
            if (selectedIndex != -1)
            {
                // change the form of selected item to remove it from current quote.
                VehicleOption selectedOption = (VehicleOption)lstVehicleOptions.SelectedItem;

                // Remove the selected item from the UI list.
                lstVehicleOptions.Items.RemoveAt(selectedIndex);

                // Remove the selected vehicle option from the current quote.
                currentQuote.RemoveVehicleOption(selectedOption);

                // Update the UI.
                UpdateQuoteForm();
            }
        }

        /// <summary>
        /// Handles the Click event of the Financing menu item.
        /// Opens the FinancingForm to calculate and display financing options
        /// for the current quote if it exists.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuFinancing_Click(object sender, EventArgs e)
        {
            // check whether current quote is null.
            if (currentQuote != null)
            {
                // Create a new instance of the FinancingForm
                FinancingForm financingForm = new FinancingForm(currentQuote);

                // Display the FinancingForm as a modal dialog box.
                financingForm.ShowDialog();
            }
        }


        /// <summary>
        /// Handles the Click event of the About menu item.
        /// Opens the AboutForm to display information about the application.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void MnuAbout_Click(object sender, EventArgs e)
        {
            // Create a new instance of the AboutForm.
            AboutForm aboutform = new AboutForm();

            // Display the AboutForm as a modal dialog box.
            aboutform.ShowDialog();
        }

        /// <summary>
        /// Handles the Changed event of the cboVehicle ComboBox.
        /// This event handler updates the form based on the selected vehicle.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void cboVehicle_Changed(object sender, EventArgs e)
        {
            // check whether there is a selected index.
            if (cboVehicle.SelectedIndex == -1)
            {
                // If no vehicle is selected, reset the form.
                ResetQuoteForm();
            }
            else
            {
                // If a vehicle is selected, enable menu items and button, and numeric up down control.
                mnuFinancing.Enabled = true;
                mnuAddOption.Enabled = true;
                mnuRemoveOption.Enabled = true;

                btnAddOption.Enabled = true;
                btnRemoveOption.Enabled = true;
                nudTradeInValue.Enabled = true;

                // Retrieve the selected Vehicle object from the ComboBox
                Vehicle newVehicle = cboVehicle.SelectedItem as Vehicle;

                // Create or update new VehicleQuote object for the newly selected vehicle.
                if (currentQuote == null)
                {
                    currentQuote = new VehicleQuote(newVehicle, taxRate);
                }
                else
                {
                    currentQuote.Vehicle = newVehicle;
                }

                txtSalePrice.Text = $"{currentQuote.SalePrice:C2}";
                // Update or set the form to reflect new quote details.
                UpdateQuoteForm();

                // Update or set the maximum value for the Trade-In Value.
                nudTradeInValue.Maximum = currentQuote.SalePrice;
            }
        }


        /// <summary>
        /// Handles the ValueChanged event of the nudTradeInValue numeric up-down control.
        /// It updates the trade-in value of the quote, and calculate the amount due based on trade-in value.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void nudTradeInValue_Changed(object sender, EventArgs e)
        {
            // check whether current quote is null.
            if (currentQuote != null)
            {
                // Update the TradeInValue with the selected value.
                currentQuote.TradeInValue = nudTradeInValue.Value;

                // update the amount due by calculaating again with the new trade-in value.
                txtAmountDue.Text = $"{currentQuote.CalculateAmountDue():C2}";
            }
        }


        /// <summary>
        /// Resets the quote form to its initial state.
        /// It disables menu and button options as well
        /// </summary>
        private void ResetQuoteForm()
        {
            // Unselect the currently chosen vehicle.
            cboVehicle.SelectedIndex = -1;
            cboVehicle.Focus();

            // Clear text fields.
            txtAmountDue.Text = "";
            txtSalePrice.Text = "";
            txtSubtotal.Text = "";
            txtTax.Text = "";
            txtTotal.Text = "";
            txtTotalOptions.Text = "";

            // Clear the current quote.
            currentQuote = null;

            // Clear options list.
            lstVehicleOptions.Items.Clear();

            // Disable menu and button options.
            mnuAddOption.Enabled = false;
            mnuRemoveOption.Enabled = false;
            btnAddOption.Enabled = false;
            btnRemoveOption.Enabled = false;
            mnuFinancing.Enabled = false;

            // Reset the trade-in value to 0.
            nudTradeInValue.Value = 0;
        }

        /// <summary>
        /// Updates the text boxes with the details of the current quote.
        /// </summary>
        private void UpdateQuoteForm()
        {
            // Update text boxes with the current quote details
            txtTotalOptions.Text = $"{currentQuote.GetVehicleQuoteSum():N2}";
            txtSubtotal.Text = $"{currentQuote.GetVehicleQuoteSubtotal():C2}";
            txtTax.Text = $"{currentQuote.CalculateTax():N2}";
            txtTotal.Text = $"{currentQuote.CalculateTotal():C2}";
            txtAmountDue.Text = $"{currentQuote.CalculateAmountDue():C2}";
        }
    }
}
