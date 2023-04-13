using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _firstService = new BankTransferService();
            var creditCardService = new CreditCardService();
            var payPalService = new PayPalService();

            _firstService.SetNext(creditCardService).SetNext(payPalService);
        }

        private PaymentService _firstService;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int amount))
            {
                MessageBox.Show("Неправильна сума платежу");
                return;
            }
            _firstService.Handle(amount);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(button1,null);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {

                    return;
                }
                e.Handled = true;
            }
        }
    }
}
