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
    {//dichiarazione delle variabili utilizzate per il funzionamento del gioco
        public static bool accessoEseguito=false;//variabile che segna se l'accesso è avvenuto
        public static string salvataggioID = "";//stringa per il salvataggio su file
        public static string lb4;//stringa per il testo di label4
        public static bool variabileControlloInserimenti=false;//variabile per il controllo degli inserimenti di username e password
        public static int rigaGiocatore=0;//variabile che tiene conto della riga corrispondente all'ID dell'utente nell'array degli elementi ordinati
        public static int righeFile;//variabile corrispondente al numero di righe del file
        public static int punteggio=0;//variabile utilizzata per il caricamento del punteggio dell'utente dal file
        public static string[,] elementiFileOrdinati;//array multidimensionale in cui vengono inseriti ID e punteggi
        public static string carattereDivisore = ":";
        static string file = "0:::";//stringa utilizzata al primo salvataggio su file
        static string username="";
        static string password = "";
        public static bool letturaFileEseguita=false;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.form1.Show();//viene mostrato il form1 
            this.Hide();//il form corrente viene nascosto
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;//non viene definitamente chiuso il form ma solo nascosto
            this.Hide();//il form corrente viene nascosto
            Form1.form1.Show();//viene mostrato il form1
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;//la variabile username assume il valore del testo di textbox1
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;//la variabile password assume il valore del testo di textbox2
        }

        private void eseguiRegistrati_Click(object sender, EventArgs e)//viene eseguito in seguito al click del pulsante registrati
        {
            controlloInserimenti();//viene chiamata la funzione per il controllo del rimepimento delle textbox
            int controlloUnicitàID = 0;//variabile per il controllo 
            if (variabileControlloInserimenti == true)//se la funzione controlloinserimenti non rivela problemi esegue le seguenti operazioni 
            {
                for (int j = 0; j < righeFile; j++)//ciclo for che controlla che non vi sia un altro ID con lo stesso username
                {
                    if (username == elementiFileOrdinati[j, 0])
                    {
                        controlloUnicitàID = 1;
                        lb4 = "spiacenti username già esistente";
                        textBox1.Clear();
                    }
                }
                if (controlloUnicitàID == 0)//se non vengono riscontrati problemi esegue le seguenti operazioni 
                {
                    righeFile++;//aumenta di 1 il numero delle righe del file
                    string[,] arrayDiSalvataggio = new string[righeFile, 3];//array utilizzato per il salvataggio su File
                    for (int i = 0; i < righeFile; i++)//ciclo che inserisce i valori nell'array di salvataggio
                    {
                        if (i == 0)//se i=0, quindi si sta lavorando della prima riga dell'array, salva il nuovo ID con punteggio=0
                        {
                            arrayDiSalvataggio[i, 0] = username + carattereDivisore;
                            arrayDiSalvataggio[i, 1] = password + carattereDivisore;
                            arrayDiSalvataggio[i, 2] = punteggio + carattereDivisore + "\n";                                
                        }
                        else if (i >= 1)//dopodichè inserirà quelli già presenti nel file
                        {
                            for (int j = 0; j < 3; j++)//ciclo che permette di variare colonna
                            {
                                if (i == (righeFile - 1) && j == 2)//se si tratta dell'ultimo elemento del file non viene aggiunto il carattere divisore
                                {
                                    arrayDiSalvataggio[i, j] = elementiFileOrdinati[i - 1, j];
                                }
                                else//in caso contrario si
                                {
                                    arrayDiSalvataggio[i, j] = elementiFileOrdinati[i - 1, j] + carattereDivisore;
                                }
                            }
                        }
                    }
                    int variabileDiControllo = 0;
                    for (int i = 0; i < righeFile; i++)//ciclo che inserisce i valori dell'array di salvataggio nella stringa utilizzata per la scrittura su file
                    {
                        if (variabileDiControllo == 0)//inserisce come primo valore il numero di righe del file
                        {
                            salvataggioID = Convert.ToString(righeFile) + carattereDivisore;
                            variabileDiControllo = 1;
                        }
                        for (int j = 0; j < 3; j++)//dopodichè inserisce gli ID e punteggi
                        {
                            salvataggioID = salvataggioID + arrayDiSalvataggio[i, j];
                        }
                        //salvataggioID = salvataggioID + "\n";//dopo ogni ID e punteggio va a capo per salvare il successivo
                    }
                    File.WriteAllText(@"C:\Users\Asus\Desktop\IDePunteggi", salvataggioID);//esegue la scrittura su file
                    salvataggioID = "";//svuota la stringa salvataggioID
                    rigaGiocatore = 0;//rigagiocatore assume il valore 0 poichè l'ID dell'utente appena rigistrato si trova nalla prima riga dell'array
                    accessoEseguito = true;//l'utente è loggato
                    lb4 = "registrazione eseguita, BENVENUTO "+username;
                    acquisizioneFile();//il programma riacquisisce il file con le modifiche applicate
                }            
            }
        }

        private void eseguiAccesso_Click(object sender, EventArgs e)//viene eseguito in seguito al click del pulsante accedi
        {
            controlloInserimenti();//viene chiamata la funzione per il controllo del rimepimento delle textbox
            bool variabileDiControllo = false;
            if (variabileControlloInserimenti==true)//se la funzione controlloinserimenti non rivela problemi esegue le seguenti operazioni 
            {
                for (int j = 0; j < righeFile; j++)//ciclo for che controlla se nel file è presente l'ID indicato
                {
                    if (username == elementiFileOrdinati[j, 0] && password == elementiFileOrdinati[j, 1] || "\n" + username == elementiFileOrdinati[j, 0] && password == elementiFileOrdinati[j, 1])//se l'ID è presente esegue le seguenti operazioni
                    {
                        variabileDiControllo = true;
                        punteggio = Convert.ToInt32(elementiFileOrdinati[j, 2]);//converte in intero il punteggio
                        rigaGiocatore = j;//"salva" la riga del giocatore 
                        accessoEseguito = true;//l'utente è loggato
                        lb4 = "BENVENUTO " + username;
                    }
                }
                if (variabileDiControllo == false)//se l'ID non è presente lo segnala
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
        private static void acquisizioneFile()//funzione che gestisce l'eventuale creazione e caricamento di dati presenti su file nel programma
        {
            try
            {
                file = File.ReadAllText(@"C:\Users\Asus\Desktop\IDePunteggi");//il programma prova a leggere il file
            }
            catch (FileNotFoundException)//in caso si verifichi l'eccezione in cui non viene trovato il file il programma ne creerà uno 
            {
                MessageBox.Show("ERRORE: il file che contiene gli ID non è stato trovato. Il gioco ne creerà uno per te");
                File.WriteAllText(@"C:\Users\Asus\Desktop\IDePunteggi", file); 
                MessageBox.Show("Il file è stato creato con successo.");
            }
            catch (IOException)//Se si verifica questo errore, cioè errore di lettura, esegue le operazioni seguenti.
            {
                MessageBox.Show("ERRORE: si è verificato un errore durante la lettura dei file. Prova ad aprilo di nuovo.");
                Environment.Exit(0);
            }
            string[] elementiFileDaOrdinare = file.Split(carattereDivisore);//gli elementi presenti su file vengono inseriti nell'array 
            righeFile = Convert.ToInt32(elementiFileDaOrdinare[0]);//la variabile righefile assume il valore del primo elemento dell'array elementiFileDaOrdinare(infatti questa cella contiene il numero delle righe)
            elementiFileOrdinati = new string[righeFile, 3];//viene modificata la lunghezza dell'array
            int n1 = 1; //Si inizializza la variabile necessaria per l'estrazione del contenuto dell'array monodimensionale elementi.
            for (int i = 0; i < righeFile; i++) //Inserisce nell'array multidimensionale elementiFileOrdinati il contenuto dell'array monodimensionale elementiFileDaOrdinare, 
            {                                   
                for (int j = 0; j < 3; j++)
                {
                    elementiFileOrdinati[i, j] = elementiFileDaOrdinare[n1];
                    n1++;
                }
            }
            letturaFileEseguita = true;
        }
        public void posizioneEContenutoLB4()//funzione che riposiziona label4 in base alla lunghezza del testo, in modo che risulti sempre centrata
        {
            label4.Text = lb4;
            label4.Top = label1.Bottom + label4.Height;
            label4.Left = (this.Width / 2) - (label4.Width / 2);
        }
        private void controlloInserimenti()//funzione che controlla che textbox1 e 2 non siano vuote
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
        private void gestioneColori()//funzione che modifica il backcolor dei pulsanti logout e partita in modo 
        {                            //che sia più facile per l'utente capire se al momento sono cliccabili o no
            if (accessoEseguito == true)//se l'utente è loggato esegue questo
            {
                logout.BackColor = Color.Red;
                partita.BackColor = Color.White;
            }
            else if (accessoEseguito == false)//se l'utente non è loggato esegue questo
            {
                logout.BackColor = Color.Maroon;
                partita.BackColor = Color.Gray;
            }
        }

        private void partita_Click(object sender, EventArgs e)//funzione che permette, se l'utente è loggato, di andare al form 
        {                                                      //per la partita senza passare per la schermata home 
            if (accessoEseguito == true)
            {
                Form1.form3.Show();
                this.Hide();
            }
        }

        private void logout_Click(object sender, EventArgs e)//funzione che esegue il logout
        {
            if (accessoEseguito == true)//se l'utente risulta loggato esegue le seguenti operazioni
            {
                lb4 = "";//svuota label4
                punteggio = 0;//porta il punteggio a 0
                rigaGiocatore = righeFile;//assegna alla variabile righegiocatore il valore di righefile poichè non corrisponte a nesun ID(l'ultimo ID è presente nella riga dell' array numero righefile-1)
                username = "";//svuota username e password
                password = "";
                textBox1.Clear();//pulisce le textbox
                textBox2.Clear();
                accessoEseguito = false;//porta accessoeseguito a false per indicare che nessun utente è loggato
            }
        }

        private void timer_Tick(object sender, EventArgs e)//il timer in questo form serve per svolgere alcune operazioni in tempo reale in base alle azioni dell'utente
        {
            gestioneColori();
            posizioneEContenutoLB4();
        }
    }
}
