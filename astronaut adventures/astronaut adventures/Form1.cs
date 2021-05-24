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
        public static bool visibilitàDataGridView = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;//al caricamento del form l'elemento datagridview1 è nascosto
        }

        private void mostraClassifica_Click(object sender, EventArgs e)
        {

            if (Form2.letturaFileEseguita == true)//quando l'utente clicca il pulsante viene eseguito un primo controllo per verificare il caricamento di un file di ID e punteggi
            {
                if (visibilitàDataGridView == false)//un secondo controllo per veirficare la visibilità della tabella 
                {
                    dataGridView1.ColumnCount = 0;//la tabella viene svuotata
                    dataGridView1.ColumnCount = 3;//vengono create 3 colonne con le seguenti intestazioni
                    dataGridView1.Columns[0].HeaderText = "posizione";
                    dataGridView1.Columns[1].HeaderText = "username";
                    dataGridView1.Columns[2].HeaderText = "punteggio";
                    mostraClassifica.Text = "nascondi classifica";
                    if (Form2.righeFile >= 3)//vengono create le nuove righe contenenti i dati
                    {
                        dataGridView1.Rows.Add("1°", Form2.elementiFileOrdinati[Form2.righeFile - 1, 0], Form2.elementiFileOrdinati[Form2.righeFile - 1, 2]);
                        dataGridView1.Rows.Add("2°", Form2.elementiFileOrdinati[Form2.righeFile - 2, 0], Form2.elementiFileOrdinati[Form2.righeFile - 2, 2]);
                        dataGridView1.Rows.Add("3°", Form2.elementiFileOrdinati[Form2.righeFile - 3, 0], Form2.elementiFileOrdinati[Form2.righeFile - 3, 2]);
                    }
                    else if (Form2.righeFile == 2)
                    {
                        dataGridView1.Rows.Add("1°", Form2.elementiFileOrdinati[Form2.righeFile - 1, 0], Form2.elementiFileOrdinati[Form2.righeFile - 1, 2]);
                        dataGridView1.Rows.Add("2°", Form2.elementiFileOrdinati[Form2.righeFile - 2, 0], Form2.elementiFileOrdinati[Form2.righeFile - 2, 2]);
                    }
                    else if (Form2.righeFile == 1)
                    {
                        dataGridView1.Rows.Add("1°", Form2.elementiFileOrdinati[Form2.righeFile - 1, 0], Form2.elementiFileOrdinati[Form2.righeFile - 1, 2]);
                    }
                    visibilitàDataGridView = true;
                    dataGridView1.Visible = true;
                    dataGridView1.Left = this.ClientSize.Width / 2 - dataGridView1.Width / 2;
                    dataGridView1.Top = 130;
                }
                else
                {
                    dataGridView1.Visible = false;
                    visibilitàDataGridView = false;
                    mostraClassifica.Text = "mostra classifica";
                }
            }
            else
            {
                MessageBox.Show("non è stato caricato alcun file, prova a aprire la schermata 'accedi o registrati'");
            }
        }
    }
}
