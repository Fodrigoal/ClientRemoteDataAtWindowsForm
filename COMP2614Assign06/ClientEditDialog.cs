using BusinessLib.Business;
using BusinessLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP2614Assign06
{
    public partial class ClientEditDialog : Form
    {
    
        public ClientViewModel ClientVM { get; set; }   

        public ClientEditDialog()
        {
            InitializeComponent();
        }

        private void ClientEditDialog_Load(object sender, EventArgs e)
        {
            setBindings();
        }

        private void setBindings()
        {
            maskedTextBoxClientCode.DataBindings.Add("Text", ClientVM, "ClientCode");
            textBoxCompanyName.DataBindings.Add("Text", ClientVM, "CompanyName");
            textBoxAddress1.DataBindings.Add("Text", ClientVM, "Address1");
            textBoxAddress2.DataBindings.Add("Text", ClientVM, "Address2");
            textBoxCity.DataBindings.Add("Text", ClientVM, "City");
            maskedTextBoxProvince.DataBindings.Add("Text", ClientVM, "Province");
            maskedTextBoxPostalCode.DataBindings.Add("Text", ClientVM, "PostalCode");
            textBoxYTDSales.DataBindings.Add("Text", ClientVM, "YTDSales");
            textBoxNotes.DataBindings.Add("Text", ClientVM, "Notes");
            checkBoxCreditHold.DataBindings.Add("Checked", ClientVM, "CreditHold");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Client client = ClientVM.GetDisplayClient();

            string errorMessage;

            errorProvider.SetError(buttonOk, ""); // clear errors 

            int affected = ClientValidation.UpdateClient(client);

            if (affected > 0)
            {
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                if (affected == 0)
                {
                    errorMessage = "No DB changes were made";
                }
                else
                {
                    errorMessage = ClientValidation.ErrorMessage;
                }

                errorProvider.SetError(buttonOk, errorMessage);
            }

        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }   
}
