using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter6_Assignment5 // Elizabeth Jaimes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        //variable declaration for the price of services and totals
        const double oilChange = 26.00;
        const double lubeJob = 18.00;
        const double radiatorFlush = 30.00;
        const double transmissionFlush = 80.00;
        const double inspection = 15.00;
        const double mufflerReplace = 100.00;
        const double tireRotate = 20.00;
        const double partsLabor = 20.00;
        double total = 0.00;
        double tax;
        double partsInput=0.00;
        double laborInput =0.00;


        // this will calculate total of services selected by user
        private void btnCalculate_Click(object sender, EventArgs e)
        {

            TotalCharges();
            label10.Text = total.ToString();
            label7.Text = (total - partsInput-tax).ToString();
            label8.Text = partsInput.ToString();
            label9.Text = tax.ToString();
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;

        }
        // this will clear all fields when clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearFees();
        }
        //exit button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = 0.00.ToString();
            textBox2.Text = 0.00.ToString();
        }

        // returns total charges for an oil change &| lube job if any 
        private double OilLubeCharges()
        {
            if (checkBox1.Checked)
            {
                total = oilChange;
            }
            if (checkBox2.Checked)
            {
                total = lubeJob;
            }
            if ((!checkBox1.Checked) && (!checkBox2.Checked))
            {
                total = 0.0;
            }
            if ((checkBox1.Checked) && (checkBox2.Checked))
            {
                total = oilChange + lubeJob;
            }
            return total;

        }

        ////returns total charges for radiator flush &| transmission flush if any
        private double FlushCharges()
        {
            if (checkBox3.Checked)
            {
                total = radiatorFlush;
            }
            if (checkBox4.Checked)
            {
                total = transmissionFlush;
            }
            if ((!checkBox3.Checked) && (!checkBox4.Checked))
            {
                total = 0.0;
            }
            if ((checkBox3.Checked) && (checkBox4.Checked))
            {
                total = radiatorFlush + transmissionFlush;
            }
            return total;
        }



        ////returns total charges for an inspection, muffler replacement, &| tire rotation if any
        private double MisCharges ()
        {
            {
                if (checkBox5.Checked)
                {
                    total = inspection;
                }
                if (checkBox6.Checked)
                {
                    total = mufflerReplace;
                }
                if (checkBox7.Checked)
                {
                    total = tireRotate;
                }
                if ((!checkBox5.Checked) && (!checkBox6.Checked) && (!checkBox7.Checked))
                {
                    total = 0.0;
                }
                if ((checkBox5.Checked) && (checkBox6.Checked) && (checkBox7.Checked))
                {
                    total = inspection + mufflerReplace + tireRotate;
                }
                return total;
            }
        }


       

        ////returns total charges for other services ("parts and labor") if any
        private double OtherCharges ()
        {
         partsInput = double.Parse(textBox1.Text);
         laborInput = double.Parse(textBox2.Text);
            return partsInput + laborInput;
        }



        /////returns sales tax, if any. sales tax is 6% only on parts
        private double TaxCharges ()
        {
            tax = partsInput * (.06);
            return tax;
        }



        ////returns total charges
        private double TotalCharges ()
        {
            total = OilLubeCharges() + FlushCharges() + MisCharges() + OtherCharges() + TaxCharges();
            return total;
        }


        ////clear any checkboxes for oil change and lube job 
        private void ClearOilLube ()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        ////clear checkboxes for radiator and transmission flush
       private void ClearFlushes ()
        {
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        ////clear misc checkboxes (inspection,muffler, and tire rotation
        private void ClearMisc()
        {
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        ////clears parts and labor
        private void ClearOther()
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }

        ////clear labels that display the output summary
        private void ClearFees()
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
        }



    }
}
