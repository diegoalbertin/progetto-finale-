using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace astronaut_adventures
{
    public partial class Form1 : Form
    {
        public static int controlloAccedi=0;
        public static int controlloRegistrati=0;
        public static Form1 form1 = new Form1();
        public static Form2 form2 = new Form2();
        public static Form3 form3 = new Form3();
        public static Form4 form4 = new Form4();

        public Form1()
        {
            InitializeComponent();

        }

        private void partitaVelocebtn_Click(object sender, EventArgs e)
        {
            form3.Show();
            this.Hide();
        }
        private void aiutobtn_Click(object sender, EventArgs e)
        {
            form4.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void accedioregistrati_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            partitaVelocebtn.Left = (this.Width / 2) - (partitaVelocebtn.Width / 2);
            accedioregistrati.Left = (this.Width / 2) - (accedioregistrati.Width / 2);
            aiutobtn.Left = (this.Width / 2) - (aiutobtn.Width / 2);
        }
    }
}
