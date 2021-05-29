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
        public bool goLeft;//dichiarazione delle variabili utilizzate per il movimento del personaggio
        public bool goRight;
        Random randX = new Random();//dichiarazione dei random utilizzati per il posizionamento degli asteroidi
        Random randY = new Random();
        int asteroidiPersi = 0;//dichiarazione delle variabili utilizzate per il funzionamento del gioco
        int livello;
        int punteggioPartita = 0;
        int[] velocità = new int[5] { 8, 10, 12, 15, 17 };// array contenente le varie velocità degli asteroidi
        int variabileControlloAggiornamentoLivello = 0;
        public Form3()
        {
            InitializeComponent();           
        }

        private void keyIsDown(object sender, KeyEventArgs e)//evento generato quando viene premuto un tasto
        {
            if (e.KeyCode == Keys.Left)//se si tratta della freccia sinistra porta goLeft a true
            {
                goLeft = true;
            }
            else if (e.KeyCode == Keys.Right)//se si tratta della freccia destra porta goRight a true
            {
                goRight = true;
            }
        }
        private void keyIsUp(object sender, KeyEventArgs e)//evento generato quando viene rilasciato un tasto
        {
            if (e.KeyCode == Keys.Left)//se si tratta della freccia sinistra porta goLeft a false
            {
                goLeft = false;
            }
            else if (e.KeyCode == Keys.Right)//se si tratta della freccia destra porta goRight a false
            {
                goRight = false;
            }
        }

        private void restart()//funzione che permette di far ripartire il gioco
        {
            foreach (Control x in this.Controls)//x è il tag dato agli asteroidi, tramite questi due cicli il programma va a modificare le coordinate solo di questi
            {
                if (x is PictureBox && (string)x.Tag == "asteroide")
                {
                    x.Top = randY.Next(80, 300) * -1;
                    x.Left = randY.Next(5, this.ClientSize.Width - x.Width);
                }
            }
            label3.Text = "vite:" + 5;//5 è il numero massimo di vite
            astronauta.Left = this.ClientSize.Width / 2 - astronauta.Width / 2;//posiziona il personaggio astronauta a metà del form
            punteggioPartita = 0;//all'inizio della partita le varie variabili valgono 0
            livello = 0;
            asteroidiPersi = 0;
            goLeft = false;//inizialmente goLeft e goRight sono false perchè il personaggio è fermo
            goRight = false;
            pictureBox5.Visible = false;//picturbox esplosione resa non visibile
            gameTimer.Start();//viene fatto partire il timer così che inizi il gioco
        }

        private void mainGameTimerEvent(object sender, EventArgs e)//timer
        {
            astronauta.Image = Properties.Resources.astronauta;
            label1.Text = "punteggio: "+"\n" + punteggioPartita;//viene inserito nella label il punteggio momentaneo del giocatore
            if (goLeft == true && astronauta.Left > 0)//cicli if che permettono il movimento del personaggio
            {
                astronauta.Left -= 15;
            }
            if (goRight == true && astronauta.Left + astronauta.Width < this.ClientSize.Width)
            {
                astronauta.Left += 15;
            }

            foreach (Control x in this.Controls)//x è il tag dato agli asteroidi, tramite questi due cicli il programma va a lavorare su questi
            {
                if (x is PictureBox && (string)x.Tag == "asteroide")
                {
                    x.Top += velocità[livello];//gli asteroidi vengono fatti scendere verso il basso dello schermo
                    if (x.Top + x.Height > this.ClientSize.Height)//ciclo if per il caso in cui gli astoridi si trovino più in basso della fine dello schermo
                    {                                               //quindi vengono mancati dall'utente
                        astronauta.Image = Properties.Resources.collisione;//al personaggio viene assegnata l'immagine collisione
                        asteroidiPersi += 1;//viene incrementato il numero di asteroidi persi
                        x.Top = randY.Next(80, 300) * -1;//l'asteroide viene riposizionato
                        x.Left = randY.Next(5, this.ClientSize.Width - x.Width);
                    }
                    if (astronauta.Bounds.IntersectsWith(x.Bounds))//ciclo if nel caso in cui il giocatore "prende" un asteroide
                    {
                        punteggioPartita += 10;//viene aumentato il punteggio
                        x.Top = randY.Next(80, 300) * -1;//l'asteroide viene riposizionato
                        x.Left = randY.Next(5, this.ClientSize.Width - x.Width);
                    }
                }
            }
            label3.Text = "vite:" + (5 - asteroidiPersi);//viene visualizzato nell'apposita label il numero di vite rimanenti 

            if (punteggioPartita < 100)//cicli if per la scelta del livello in base al punteggio del giocatore e per l'eventuale ripristino delle vite
            {
                livello = 0;
                variabileControlloAggiornamentoLivello = 1;
            }
            else if (punteggioPartita >= 100 && punteggioPartita < 200 && variabileControlloAggiornamentoLivello == 1)
            {
                livello = 1;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 2;
            }
            else if (punteggioPartita >= 200 && punteggioPartita < 300 && variabileControlloAggiornamentoLivello == 2)
            {
                livello = 2;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 3;
            }
            else if (punteggioPartita >= 300 && punteggioPartita < 400 && variabileControlloAggiornamentoLivello == 3)
            {
                livello = 3;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 4;
            }
            else if (punteggioPartita >= 400 && variabileControlloAggiornamentoLivello == 4)
            {
                livello = 4;
                asteroidiPersi = 0;
                variabileControlloAggiornamentoLivello = 5;
            }

            if (asteroidiPersi == 5)//ciclo if per il caso in cui l'utente manchi 5 asteroide, quindi raggiunga le 0 vite
            {
                gameTimer.Stop();//viene fermato il timer e quindi il gioco
                pictureBox4.Visible = true;//vengono mostrate le picturbox per il restart e per tornare alla home
                pictureBox6.Visible = true;
                pictureBox5.Visible = true;//viene mostrata la picturbox con l'immagine esplosione e viene posizionata sopra al personaggio
                pictureBox5.Location = astronauta.Location;
                if (Form2.accessoEseguito==true)//ciclo if per il caso in cui l'utente sia loggato
                {
                    if (punteggioPartita > Form2.punteggio)//se il punteggio della partita è maggiore del punteggio precedentemente salvato su file
                    {
                        Form2.elementiFileOrdinati[Form2.rigaGiocatore, 2] = Convert.ToString(punteggioPartita);//viene scambiato il punteggio nell'array ordinato utilizzato per il salvataggio
                        Form2.punteggio = punteggioPartita;
                        ordinamentoID_Punteggi();
                        salvataggio();//viene chiamata la funzione salvatggio
                    }
                }
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;//non viene definitamente chiuso il form ma solo nascosto
            this.Hide();
            Form1.form1.Show();//viene mostrato il form1 
        }

        private void salvataggio()
        {
            string salvataggio = "";//viene dichiarata la stringa per il salvataggio su file
            string[,] arrayDiSalvataggio = new string[Form2.righeFile, 3];//viene dichiarato l'array di tipo string per la memorizzazione ordinata di ID e punteggi con i caratteri divisori
            for (int i = 0; i < Form2.righeFile; i++)                     //tramite i seguenti cicli for 
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == (Form2.righeFile - 1) && j == 2)//se si tratta dell'ultimo elemento del file non viene aggiunto il carattere divisore
                    {
                        arrayDiSalvataggio[i, j] = Form2.elementiFileOrdinati[i, j];
                    }
                    else//in caso contrario si
                    {
                        arrayDiSalvataggio[i, j] = Form2.elementiFileOrdinati[i, j] + Form2.carattereDivisore;
                    }
                }
            }
            int variabileDiControllo = 0;
            for (int i = 0; i < Form2.righeFile; i++)//ciclo for per il salvataggio nella stringa di salvataggio
            {
                if (variabileDiControllo == 0)//il primo valore che deve essere salvato su file è il numero delle righe delfile 
                {
                    salvataggio = Convert.ToString(Form2.righeFile) + Form2.carattereDivisore;
                    variabileDiControllo = 1;
                }
                for (int j = 0; j < 3; j++)//vengono salvati gli ID e punteggi corrispondenti
                {
                    salvataggio = salvataggio + arrayDiSalvataggio[i, j];
                }
                //salvataggio = salvataggio + "\n";//dopo il salvataggio di un ID e punteggio il programma va a capo per salvare il successivo
            }
            File.WriteAllText(@"C:\Users\Asus\Desktop\IDePunteggi", salvataggio);//viene salvato il tutto su file
            salvataggio = "";//viene svuotata la variabile stringa
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            gameTimer.Stop();//alla prima visualizzazione del form il timer deve essere momentaneamente disattivato
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            restart();//viene chiamata la funzione che fa partire il gioco
            pictureBox4.Visible = false; //vengono nascoste picturbox per il restart e per tornare alla home
            pictureBox6.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1.form1.Show();//viene mostrato il form1 
            this.Hide();//il form corrente viene nascosto
        }
        private void ordinamentoID_Punteggi()
        {
            for (int i = 0; i < Form2.righeFile - 1; i++)
            {
                // Trova il minimo nel subarray da ordinare
                int indice_min = i;
                int primoElementoComparazione;
                int secondoElementoComparazione;
                for (int j = i + 1; j < Form2.righeFile; j++)
                {
                    primoElementoComparazione = Convert.ToInt32(Form2.elementiFileOrdinati[j, 2]);
                    secondoElementoComparazione = Convert.ToInt32(Form2.elementiFileOrdinati[indice_min, 2]);
                    // Confronto per trovare un nuovo minimo
                    if (primoElementoComparazione< secondoElementoComparazione)
                    {
                        indice_min = j; // Salvo l'indice del nuovo minimo
                    }
                }

                // Scambia il minimo trovato con il primo elemento
                swap( indice_min, i);
            }
        }
        private void swap(int a, int b)
        {
            string tempPunteggio = Form2.elementiFileOrdinati[a,2];
            Form2.elementiFileOrdinati[a, 2] = Form2.elementiFileOrdinati[b, 2];
            Form2.elementiFileOrdinati[b, 2] = tempPunteggio;
            string tempPassword = Form2.elementiFileOrdinati[a, 1];
            Form2.elementiFileOrdinati[a, 1] = Form2.elementiFileOrdinati[b, 1];
            Form2.elementiFileOrdinati[b, 1] = tempPassword;
            string tempUsername = Form2.elementiFileOrdinati[a, 0];
            Form2.elementiFileOrdinati[a, 0] = Form2.elementiFileOrdinati[b, 0];
            Form2.elementiFileOrdinati[b, 0] = tempUsername;
        }
    }
}
