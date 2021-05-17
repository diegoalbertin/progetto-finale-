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
    public partial class Form2 : Form
    {
        public static bool accessoEseguito=false;
        public static string salvataggioID = "";
        public static string lb4;
        public static bool variabileControlloInserimenti=false;
        public static int rigaGiocatore=0;
        public static int righeFile;
        public static int punteggio=0;
        public static string[,] elementiFileOrdinati;
        public static string carattereDivisore = ":";
        static string file = "0:::";
        static string username="";
        static string password = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form1.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1.form1.Show();
            e.Cancel = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void eseguiRegistrati_Click(object sender, EventArgs e)
        {
            controlloInserimenti();
            int controlloUnicitàID = 0;
            if (variabileControlloInserimenti == true)
            {
                for (int j = 0; j < righeFile; j++)
                {
                    if (username == elementiFileOrdinati[j, 0])
                    {
                        controlloUnicitàID = 1;
                        lb4 = "spiacenti username già esistente";
                        textBox1.Clear();
                    }
                }
                if (controlloUnicitàID == 0)
                {
                    righeFile++;
                    string[,] arrayDiSalvataggio = new string[righeFile, 3];
                    for (int i = 0; i < righeFile; i++)
                    {
                        if (i == 0)
                        {
                            arrayDiSalvataggio[i, 0] = username + carattereDivisore;
                            arrayDiSalvataggio[i, 1] = password + carattereDivisore;
                            arrayDiSalvataggio[i, 2] = punteggio + carattereDivisore + "\n";                                
                        }
                        else if (i >= 1)
                            {
                            for (int j = 0; j < 3; j++)
                            {
                                if (i == (righeFile - 1) && j == 2)
                                {
                                    arrayDiSalvataggio[i, j] = elementiFileOrdinati[i - 1, j];
                                }
                                else
                                {
                                    arrayDiSalvataggio[i, j] = elementiFileOrdinati[i - 1, j] + carattereDivisore;
                                }
                            }
                        }
                    }
                    int variabileDiControllo = 0;
                    for (int i = 0; i < righeFile; i++)
                    {
                        if (variabileDiControllo == 0)
                        {
                            salvataggioID = Convert.ToString(righeFile) + carattereDivisore;
                            variabileDiControllo = 1;
                        }
                        for (int j = 0; j < 3; j++)
                        {
                            salvataggioID = salvataggioID + arrayDiSalvataggio[i, j];
                        }
                        salvataggioID = salvataggioID + "\n";
                    }
                    File.WriteAllText(@"C:\Users\Asus\source\repos\IDePunteggi", salvataggioID);
                    salvataggioID = "";
                    rigaGiocatore = 0;
                    accessoEseguito = true;
                    lb4 = "registrazione eseguita, BENVENUTO "+username;
                    acquisizioneFile();
                }            
            }
        }

        private void eseguiAccesso_Click(object sender, EventArgs e)
        {
            controlloInserimenti();
            int variabileDiControllo = 0;
            if (variabileControlloInserimenti==true)
            {
                for (int j = 0; j < righeFile; j++)
                {
                    if (username == elementiFileOrdinati[j, 0] && password == elementiFileOrdinati[j, 1] || "\n" + username == elementiFileOrdinati[j, 0] && password == elementiFileOrdinati[j, 1])
                    {
                        variabileDiControllo = 1;
                        punteggio = Convert.ToInt32(elementiFileOrdinati[j, 2]);
                        rigaGiocatore = j;
                        accessoEseguito = true;
                        lb4 = "BENVENUTO " + username;
                    }
                }
                if (variabileDiControllo == 0)
                {
                    lb4 = "username o password errati";
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            acquisizioneFile();
        }
        private static void acquisizioneFile()
        {
            try
            {
                file = File.ReadAllText(@"C:\Users\Asus\source\repos\IDePunteggi");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("ERRORE: il file che contiene gli ID non è stato trovato. Il gioco ne creerà uno per te");
                File.WriteAllText(@"C:\Users\Asus\source\repos\IDePunteggi", file); 
                MessageBox.Show("Il file è stato creato con successo.");
            }
            catch (IOException)//Se si verifica questo errore, cioè errore di lettura, esegue le operazioni seguenti.
            {
                MessageBox.Show("ERRORE: si è verificato un errore durante la lettura dei file. Premi un tasto qualsiasi per chiudere il programma e prova ad aprilo di nuovo.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            string[] elementiFileDaOrdinare = file.Split(carattereDivisore);
            righeFile = Convert.ToInt32(elementiFileDaOrdinare[0]);
            elementiFileOrdinati = new string[righeFile, 3];
            int n1 = 1; //Si inizializza la variabile necessaria per l'estrazione del contenuto dell'array monodimensionale elementi.
            for (int i = 0; i < righeFile; i++) //Inserisce nell'array multidimensionale il contenuto dell'array monodimensionale elementiNuoveInVendita, 
            {                                   
                for (int j = 0; j < 3; j++)
                {
                    elementiFileOrdinati[i, j] = elementiFileDaOrdinare[n1];
                    n1++;
                }
            }
        }
        public void posizioneEContenutoLB4()
        {
            label4.Text = lb4;
            label4.Top = label1.Bottom + label4.Height;
            label4.Left = (this.Width / 2) - (label4.Width / 2);
        }
        private void controlloInserimenti()
        {
            if (username == "" && password == "")
            {
                lb4 = "non hai inserito username e password";
                variabileControlloInserimenti = false;
                textBox1.Focus();
            }
            else if (username == "")
            {
                lb4="non hai inserito uno username";
                variabileControlloInserimenti = false;
                textBox1.Focus();
            }
            else if (password == "")
            {
                lb4 = "non hai inserito una password";
                variabileControlloInserimenti = false;
                textBox2.Focus();
            }
            else if (username != "" && password != "")
            {
                variabileControlloInserimenti = true;
            }
        }
        private void gestioneColori()
        {
            if (accessoEseguito == true)
            {
                logout.BackColor = Color.Red;
                partita.BackColor = Color.White;
            }
            else if (accessoEseguito == false)
            {
                logout.BackColor = Color.Maroon;
                partita.BackColor = Color.Gray;
            }
        }

        private void partita_Click(object sender, EventArgs e)
        {
            if (accessoEseguito == true)
            {
                Form1.form3.Show();
                this.Hide();
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (accessoEseguito == true)
            {
                lb4 = "";
                punteggio = 0;
                rigaGiocatore = righeFile;
                username = "";
                password = "";
                textBox1.Clear();
                textBox2.Clear();
                accessoEseguito = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gestioneColori();
            posizioneEContenutoLB4();
        }
    }
}
