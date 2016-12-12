using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolko_Krzyzyk
{
    class Gra
    {
        private bool ruch;
        private int ileRuchow;
        private int[] plansza;
        private bool czy_komputer = true;

        public Gra()
        {
            ruch = true;
            ileRuchow = 0;
            plansza = new int[9];
            for (int i = 0; i < 9; i++)
                plansza[i]=i+3;  //wstawienie do planszy losowych liczb różnych od 1 i 2
        }
        #region Sprawdzanie wygranych
        public bool CzyWygrana()
        {
            bool a = false;
            //Sprawdzanie poziomoa
            if ((plansza[0]== plansza[1]) && (plansza[1]==plansza[2])) a=true;
            else
            if ((plansza[3] == plansza[4]) && (plansza[4] == plansza[5])) a = true;
            else
            if ((plansza[6] == plansza[7]) && (plansza[7] == plansza[8])) a = true;
            else

            //Sprawdzanie pionowo
            if ((plansza[0] == plansza[3]) && (plansza[3] == plansza[6])) a = true;
            else
            if ((plansza[1] == plansza[4]) && (plansza[4] == plansza[7])) a = true;
            else
            if ((plansza[2] == plansza[5]) && (plansza[5] == plansza[8])) a = true;
            else

            //Sprawdzanie przekątnych
            if ((plansza[0] == plansza[4]) && (plansza[4] == plansza[8])) a = true;
            else
            if ((plansza[6] == plansza[4]) && (plansza[4] == plansza[2])) a = true;
            
            
            return a;
        }
        #endregion

        #region Warunek malowania
        public string Malowanie()
        {
            string a = "r";
            //Sprawdzanie poziomoa
            if ((plansza[0]== plansza[1]) && (plansza[1]==plansza[2])) a="po1";
            else
            if ((plansza[3] == plansza[4]) && (plansza[4] == plansza[5])) a = "po2";
            else
            if ((plansza[6] == plansza[7]) && (plansza[7] == plansza[8])) a = "po3";
            else

            //Sprawdzanie pionowo
            if ((plansza[0] == plansza[3]) && (plansza[3] == plansza[6])) a = "pi1";
            else
            if ((plansza[1] == plansza[4]) && (plansza[4] == plansza[7])) a = "pi2";
            else
            if ((plansza[2] == plansza[5]) && (plansza[5] == plansza[8])) a = "pi3";
            else

            //Sprawdzanie przekątnych
            if ((plansza[0] == plansza[4]) && (plansza[4] == plansza[8])) a = "pr1";
            else
            if ((plansza[6] == plansza[4]) && (plansza[4] == plansza[2])) a = "pr2";
            return a;
        
        }
        #endregion
        #region Operacje na zmiennych
        public int getIleRuchow()
        {
            return ileRuchow;
        }

        public void zwiekszRuch()
        {
            this.ileRuchow++;
        }
        public void zerujRuch()
        {
            this.ileRuchow = 0;
        }

        public bool getRuch()
        {
            return ruch;
        }

        public void zmienRuch()
        {
            this.ruch = !ruch;
        }

        public void ustawRuch(bool ruch)
        {
            this.ruch = ruch;
        }

        public bool getRuchKomputer()
        {
            return czy_komputer;
        }

        public void setRuchKomputer(bool czy_komputer)
        {
            this.czy_komputer = czy_komputer;
        }

        public void setPlansza(int liczba, int wartosc)
        {
            this.plansza[liczba] = wartosc;
        }
#endregion
    }
}
