using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace astronaut_adventures
{
    public partial class Form3 : Form
    {
        public bool goLeft;
        public bool goRight;
        Random randX = new Random();
        Random randY = new Random();
        int asteroidiPersi = 0;
        int[] velocità = new int[5] { 8, 10, 12, 15, 17 };
        int livello;
        int punteggioPartita = 0;
        public Form3()
        {
            InitializeComponent();           
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }

        private void restart()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "asteroide")
                {
                    x.Top = randY.Next(80, 300) * -1;
                    x.Left = randY.Next(5, this.ClientSize.Width - x.Width);
                }
            }
            label3.Text = "vite:" + 5;
            astronauta.Left = this.ClientSize.Width / 2 - astronauta.Width / 2;
            punteggioPartita = 200;
            livello = 0;
            asteroidiPersi = 0;
            goLeft = false;
            goRight = false;
            gameTimer.Start();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            astronauta.Image = Properties.Resources.astronauta;
            label1.Text = "punteggio: "+"\n" + punteggioPartita;
            if (goLeft == true && astronauta.Left > 0)
            {
                astronauta.Left -= 15;
            }
            if (goRight == true && astronauta.Left + astronauta.Width < this.ClientSize.Width)
            {
                astronauta.Left += 15;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "asteroide")
                {
                    x.Top += velocità[livello];
                    if (x.Top + x.Height > this.ClientSize.Height)
                    {
                        astronauta.Image = Properties.Resources.collisione;
                        asteroidiPersi += 1;
                        label3.Text = "vite:" + (5 - asteroidiPersi);
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randY.Next(5, this.ClientSize.Width - x.Width);//l'immagine collisione resta l'immagine del personaggio anche dopo la collisi
                    }
                    if (astronauta.Bounds.IntersectsWith(x.Bounds))
                    {
                        punteggioPartita += 10;
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randY.Next(5, this.ClientSize.Width - x.Width);
                    }
                }
            }           
            int variabileControlloAggiornamentoLivello = 0;
            if (punteggioPartita < 100)
            {
                livello = 0;
            }
            else if (punteggioPartita >= 100 && punteggioPartita < 200 && variabileControlloAggiornamentoLivello == 0)
            {
                livello = 1;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 1;
            }
            else if (punteggioPartita >= 200 && punteggioPartita < 300 && variabileControlloAggiornamentoLivello == 1)
            {
                livello = 2;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 2;
            }
            else if (punteggioPartita >= 300 && punteggioPartita < 400 && variabileControlloAggiornamentoLivello == 2)
            {
                livello = 3;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 3;
            }
            else if (punteggioPartita >= 400 && variabileControlloAggiornamentoLivello == 3)
            {
                livello = 4;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 4;
            }

            if (asteroidiPersi == 5)
            {
                gameTimer.Stop();
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox5.Location = astronauta.Location;
                if (Form2.accessoEseguito==true)
                {
                    if (punteggioPartita > Form2.punteggio)
                    {
                        Form2.elementiFileOrdinati[Form2.rigaGiocatore, 2] = Convert.ToString(punteggioPartita);
                        salvataggio();
                    }
                }
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Form1.form1.Show();
        }

        private void salvataggio()
        {
            string salvataggio = "";
            string[,] arrayDiSalvataggio = new string[Form2.righeFile, 3];
            for (int i = 0; i < Form2.righeFile; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == (Form2.righeFile - 1) && j == 2)
                    {
                        arrayDiSalvataggio[i, j] = Form2.elementiFileOrdinati[i, j];
                    }
                    else
                    {
                        arrayDiSalvataggio[i, j] = Form2.elementiFileOrdinati[i, j] + Form2.carattereDivisore;
                    }
                }
            }
            int variabileDiControllo = 0;
            for (int i = 0; i < Form2.righeFile; i++)
            {
                if (variabileDiControllo == 0)
                {
                    salvataggio = Convert.ToString(Form2.righeFile) + Form2.carattereDivisore;
                    variabileDiControllo = 1;
                }
                for (int j = 0; j < 3; j++)
                {
                    salvataggio = salvataggio + arrayDiSalvataggio[i, j];
                }
                salvataggio = salvataggio + "\n";
            }
            File.WriteAllText(@"C:\Users\Asus\source\repos\IDePunteggi", salvataggio);
            salvataggio = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.form1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            restart();
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1.form1.Show();
            this.Hide();
        }
    }
}
