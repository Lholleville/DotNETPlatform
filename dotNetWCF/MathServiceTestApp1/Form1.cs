using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathServiceTestApp1.Mathservice1;

namespace MathServiceTestApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathserviceClient loClient = new MathserviceClient();
            Int32 loNum1 = Convert.ToInt32(txtNum1.Text.Trim());
            Int32 loNum2 = Convert.ToInt32(txtNum2.Text.Trim());

            if (cboOperation.Text == "Add")
            {
                txtResult.Text = loClient.Add(loNum1, loNum2).ToString();
            }
            else if (cboOperation.Text == "Subtract")
            {
                txtResult.Text = loClient.Subtract(loNum1, loNum2).ToString();
            }
            else if (cboOperation.Text == "Multiply")
            {
                txtResult.Text = loClient.Multiply(loNum1, loNum2).ToString();
            }
            else
            {
                txtResult.Text = loClient.Divide(loNum1, loNum2).ToString();
            }
        }
    }
}
