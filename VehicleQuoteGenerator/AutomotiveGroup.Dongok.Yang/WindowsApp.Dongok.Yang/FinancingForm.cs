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
using ACE.BIT.ADEV.Finance;

namespace WindowsApp.Dongok.Yang
{
    internal class FinancingForm : ACE.BIT.ADEV.Forms.FinancingForm
    {
        // Defines the currentQuote to store vehiclequote being processed.
        private VehicleQuote currentQuote;
        // Constructor for the FinancingForm class
        public FinancingForm(VehicleQuote currentQuote)
        {
            /* FINANCING FORM */
            // Set form properties such as start position and defines currentQuote.
            this.currentQuote = currentQuote;
            StartPosition = FormStartPosition.CenterParent;

            /* QUOTED PRICE LABEL */
            // Display the quoted price in the label using the CalculateAmountDue method.
            lblQuotedPrice.Text = currentQuote.CalculateAmountDue().ToString("C2");

            /* LOAN TERM COMBO BOX */
            // Populate the loan term combo box with loan terms.
            cboLoanTerm.Items.AddRange(new object[] { 3, 4, 5, 6, 7 });
            cboLoanTerm.SelectedItem = 5;

            /* ANNUAL INTEREST RATE NUMERIC UPDOWN */
            // Configure the numeric up-down control for annual interest.
            nudAnnualInterestRate.Minimum = 0;
            nudAnnualInterestRate.Maximum = 25;
            nudAnnualInterestRate.Increment = 0.25M;
            nudAnnualInterestRate.DecimalPlaces = 2;
            nudAnnualInterestRate.Value = 3.00M;

            /* MONTHLY PAYMENT CALCULATION */
            // Calculate and display the initial monthly payment.
            decimal monthlyInterestRate = nudAnnualInterestRate.Value/100/12; 
            int loanTermMonth = (int)cboLoanTerm.SelectedItem *12;
            decimal QuotedPrice = currentQuote.CalculateAmountDue();

            decimal monthlyPayment = Financial.GetPayment(monthlyInterestRate, loanTermMonth, QuotedPrice) ;
            txtMonthlyPayment.Text = monthlyPayment.ToString("C2");

            /* EVENT HANDLERS */
            // Register event handlers for changes in the annual interest rate and loan term selections.
            nudAnnualInterestRate.ValueChanged += FinancingFormInput_Changed;
            cboLoanTerm.SelectedIndexChanged += FinancingFormInput_Changed;
        }

        /// <summary>
        /// Handles the Changed event of the nudAnnualInterestRate numeric up down or cboLoanTerm combo box control.
        /// This eventhandler calculate and update the monthly payment when annual interest rate is changed.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void FinancingFormInput_Changed(object sender, EventArgs e)
        {
            decimal monthlyInterestRate = nudAnnualInterestRate.Value / 100 / 12;
            int loanTermMonth = (int)cboLoanTerm.SelectedItem * 12;
            decimal QuotedPrice = currentQuote.CalculateAmountDue();

            decimal monthlyPayment = Financial.GetPayment(monthlyInterestRate, loanTermMonth, QuotedPrice);
            txtMonthlyPayment.Text = monthlyPayment.ToString("C2");
        }
    }
}
