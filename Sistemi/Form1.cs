using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Sistemi
{
    public partial class Finestra22F : Form
    {
        public Finestra22F()
        {
            InitializeComponent();
        }

        void Calcoli (int host, int sottoreti, ref int somma)
        {

            // CALCOLI prendiamo il numero di host, e facciamo log 2 di n host = numero di bit necessari

            int host_necessari = Convert.ToInt32(Math.Ceiling(Math.Log(host, 2)));
            int sotto_necessari = Convert.ToInt32(Math.Ceiling(Math.Log(sottoreti, 2)));

            somma = host_necessari + sotto_necessari;
        }


        void Subnet (int bit_sotto,char classe, ref string subnet)
        {

            int n = bit_sotto;
            string indirizzo = "";

            // calcolo n

            for (int i = 0; i < n; i++)
            {
                indirizzo += "1";
            }

            for (int i = n; i < 8; i++)
            {
                indirizzo += "0";
            }

            double valore = 0;
            int elevazione = 7;

            for (int i = 0; i < indirizzo.Length; i++)
            {
                int bit = Convert.ToInt32(indirizzo[i]);

                if (indirizzo[i] == '1')
                {
                    valore += Math.Pow(2, elevazione);
                }

                elevazione--;
            }

            // subnet in base alla classe

            if (classe == 'a')
            {
                subnet = $"255.{valore}.0.0";
            }
            if (classe == 'b')
            {
                subnet = $"255.255.{valore}.0";
            }
            if (classe == 'c')
            {
                subnet = $"255.255.255.{valore}";
            }

        }

        // click sul bottone aggiungi
        private void add_ip_Click(object sender, EventArgs e)
        {
            bool errore = false;
            int provanumero = 0;
            int host = 0;
            int sottoreti = 0;
            int somma = 0;
            string indirizzo = "";
            char classe = 'p';
            string subnet = "";

            // quesito 

            string titolo_input = "SISTEMISTICA22F", esempio = "800", frase = "Inserisci il numero di sottoreti desiderato";
            object input_sistemi = Interaction.InputBox(frase, titolo_input, esempio);

            // controllo input corretto

            if (!int.TryParse((string)input_sistemi, out provanumero))
            {
                MessageBox.Show("Errore nell'aggiunta del numero di sottoreti", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errore = true;
            }
            else
            {
                sottoreti = Convert.ToInt32(input_sistemi);
            }

            // se controllo riuslta corretto, chiede il nmero di host altrimenti ferma da errore

            if (errore == false)
            {
                // quesito 

                titolo_input = "SISTEMISTICA22F"; esempio = "3"; frase = "Inserisci il numero di host desiderato";
                input_sistemi = Interaction.InputBox(frase, titolo_input, esempio);

                // controllo input corretto

                if (!int.TryParse((string)input_sistemi, out provanumero))
                {
                    MessageBox.Show("Errore nell'aggiunta del numero di host", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errore = true;
                }
                else
                {
                    host = Convert.ToInt32(input_sistemi);

                    // rendo visibile i label con le informazioni

                    // dichiarazione della classe

                    Calcoli(host, sottoreti, ref somma);

                    if (somma <= 8) // classe c
                    {
                        MessageBox.Show("L'indirizzo è di classe C");
                        indirizzo = "192.168.0.0";
                        classe = 'c';
                    }
                    if (somma > 8 && somma >= 16) // classe b
                    {
                        MessageBox.Show("L'indirizzo è di classe B");
                        indirizzo = "172.16.0.0";
                        classe = 'b';
                    }
                    if (somma > 16 && somma >= 24) // classe a
                    {
                        MessageBox.Show("L'indirizzo è di classe A");
                        indirizzo = "10.0.0.0";
                        classe = 'a';
                    }
                    if (somma > 24) // non esiste
                    {
                        MessageBox.Show("Non esiste una classe per questo contesto");
                        errore = true;
                    }

                    // se la classe esiste

                    int sotto_necessari = Convert.ToInt32(Math.Ceiling(Math.Log(sottoreti, 2)));

                    Subnet(sotto_necessari, classe, ref subnet);

                    MessageBox.Show(subnet);
                }
            }
            else
            {
                errore = false;
            }

        }
    }
}
