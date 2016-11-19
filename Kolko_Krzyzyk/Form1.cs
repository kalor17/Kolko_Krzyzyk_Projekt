﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolko_Krzyzyk
{
    public partial class Form1 : Form
    {
        Gra gra = new Gra();

        public Form1()
        {
            InitializeComponent();
    
        }

    

        
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Karol W", "O programie");
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NowaGra();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string nazwa = b.Name;
            int liczba = (int)Char.GetNumericValue(nazwa[1]);

            if ((g1.Text == "Gracz 1") || (g2.Text == "Gracz 2"))
            {
                MessageBox.Show("Przed rozpoczęciem gry podaj nazwę graczy.\nKomputer (dla Gracza 2) oznacza grę z Komputerem");
            }
            else
            {
                if (b.Text == "")
                {
                    if (gra.ruch)
                    {
                        b.Text = "X";
                        gra.plansza[liczba - 1] = 1;
                        gra.ruch = !gra.ruch;
                    }
                    else
                    {
                        b.Text = "O";
                        gra.ruch = !gra.ruch;
                        gra.plansza[liczba - 1] = 2;
                    }

                    gra.ileRuchow++;

                    Wygrana();

                   
                }
            }
            if ((!gra.ruch) && (gra.czy_komputer))
            {
                komputer_ruch();
            }
        }

        private void komputer_ruch()
        {
            /*
             Kolejność:
             1. Wygraj gre
             2. Zablokuj Xasd
             3. Wstaw w róg
             4. Wstaw w wolne miejsce
             */

            Button ruch = null;
            ruch = wygraj_zablokuj("O");
            if (ruch == null)
            {
                ruch=wygraj_zablokuj("X");
                if (ruch==null)
                {
                    ruch=wstaw_rog();
                    if (ruch == null)
                    {
                        ruch=wolne_miejsce();
                    }
                }
            }
            if (ruch!=null) ruch.PerformClick();
        }

        private Button wygraj_zablokuj(string s)
        {
            // Szukanie poziomo
            if ((P1.Text == s) && (P2.Text == s) && (P3.Text == "")) return P3;
            if ((P1.Text == s) && (P3.Text == s) && (P2.Text == "")) return P2;
            if ((P3.Text == s) && (P2.Text == s) && (P1.Text == "")) return P1;

            if ((P4.Text == s) && (P5.Text == s) && (P6.Text == "")) return P6;
            if ((P4.Text == s) && (P6.Text == s) && (P5.Text == "")) return P5;
            if ((P6.Text == s) && (P5.Text == s) && (P4.Text == "")) return P4;

            if ((P7.Text == s) && (P8.Text == s) && (P9.Text == "")) return P9;
            if ((P7.Text == s) && (P9.Text == s) && (P8.Text == "")) return P8;
            if ((P9.Text == s) && (P8.Text == s) && (P7.Text == "")) return P7;

            //Szukanie pionowo
            if ((P1.Text == s) && (P4.Text == s) && (P7.Text == "")) return P7;
            if ((P1.Text == s) && (P7.Text == s) && (P4.Text == "")) return P4;
            if ((P7.Text == s) && (P4.Text == s) && (P1.Text == "")) return P1;

            if ((P2.Text == s) && (P5.Text == s) && (P8.Text == "")) return P8;
            if ((P2.Text == s) && (P8.Text == s) && (P5.Text == "")) return P5;
            if ((P8.Text == s) && (P5.Text == s) && (P2.Text == "")) return P2;

            if ((P3.Text == s) && (P6.Text == s) && (P9.Text == "")) return P9;
            if ((P3.Text == s) && (P9.Text == s) && (P6.Text == "")) return P6;
            if ((P9.Text == s) && (P6.Text == s) && (P3.Text == "")) return P3;

            //Szukanie ukosne
            if ((P1.Text == s) && (P5.Text == s) && (P9.Text == "")) return P9;
            if ((P1.Text == s) && (P9.Text == s) && (P5.Text == "")) return P5;
            if ((P9.Text == s) && (P5.Text == s) && (P1.Text == "")) return P1;

            if ((P3.Text == s) && (P5.Text == s) && (P7.Text == "")) return P7;
            if ((P3.Text == s) && (P7.Text == s) && (P5.Text == "")) return P5;
            if ((P7.Text == s) && (P5.Text == s) && (P3.Text == "")) return P3;

            return null;
        }
        private Button wstaw_rog()
        {
            if (P1.Text == "O")
            {
                if (P3.Text == "") return P3;
                if (P7.Text == "") return P7;
                if (P9.Text == "") return P9;
                
            }
            if (P3.Text == "O")
            {
                if (P1.Text == "") return P1;
                if (P7.Text == "") return P7;
                if (P9.Text == "") return P9;

            }
            if (P7.Text == "O")
            {
                if (P3.Text == "") return P3;
                if (P1.Text == "") return P1;
                if (P9.Text == "") return P9;

            }
            if (P9.Text == "O")
            {
                if (P3.Text == "") return P3;
                if (P7.Text == "") return P7;
                if (P1.Text == "") return P1;

            }
            if (P1.Text == "") return P1;
            if (P3.Text == "") return P3;
            if (P7.Text == "") return P7;
            if (P9.Text == "") return P9;
            return null;
        }
        private Button wolne_miejsce()
        {
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if
            return null;
        }

        private void Wygrana()
        {
            if (gra.CzyWygrana())
            {
                String wygrany = "";
                if (gra.ruch)
                {
                    wygrany = g2.Text;
                    o_licznik.Text = (Int32.Parse(o_licznik.Text) + 1).ToString();
                }
                else
                {
                    wygrany = g1.Text;
                    x_licznik.Text = (Int32.Parse(x_licznik.Text) + 1).ToString();
                }

                MessageBox.Show(wygrany + " wygrał!");
                blokowaniePrzyciskow();
            }
            else
            {
                if (gra.ileRuchow == 9)
                {
                    MessageBox.Show("Remis", "aaa");
                    remis_licznik.Text = (Int32.Parse(remis_licznik.Text) + 1).ToString();
                }
            }
        }

        private void blokowaniePrzyciskow()
        {
            P1.Enabled = false;
            P9.Enabled = false;
            P2.Enabled = false;
            P3.Enabled = false;
            P4.Enabled = false;
            P5.Enabled = false;
            P6.Enabled = false;
            P7.Enabled = false;
            P8.Enabled = false;
        }


        private void NowaGra()
        {
            gra.ruch = true;
            int i;
            for (i = 0; i < 9; i++) gra.plansza[i] = i + 3;
            gra.ileRuchow = 0;
            P1.Enabled = true;
            P2.Enabled = true;
            P3.Enabled = true;
            P4.Enabled = true;
            P5.Enabled = true;
            P6.Enabled = true;
            P7.Enabled = true;
            P8.Enabled = true;
            P9.Enabled = true;
            P1.Text = "";
            P2.Text = "";
            P3.Text = "";
            P4.Text = "";
            P5.Text = "";
            P6.Text = "";
            P7.Text = "";
            P8.Text = "";
            P9.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void reset_licznik_Click(object sender, EventArgs e)
        {
            o_licznik.Text = "0";
            x_licznik.Text = "0";
            remis_licznik.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graczVsKomputerToolStripMenuItem.PerformClick();
        }

        protected void g2_TextChanged(object sender, EventArgs e)
        {
            if (g2.Text.ToUpper() == "KOMPUTER")
                gra.czy_komputer = true;
            else
                gra.czy_komputer = false;
        }

        protected void graczVsKomputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g1.Text = "Gracz 1";
            g2.Text = "Komputer";
        }

        

        
        
    }
}
