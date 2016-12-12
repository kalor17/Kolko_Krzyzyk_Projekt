using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolko_Krzyzyk
{
    class Gra
    {
        public bool ruch;
        public int ileRuchow;
        public int[] plansza;
        public bool czy_komputer = true;

        public Gra()
        {
            ruch = true;
            ileRuchow = 0;
            plansza = new int[9];
            for (int i = 0; i < 9; i++)
                plansza[i]=i+3;  //wstawienie do planszy losowych liczb różnych od 1 i 2
        }

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
    }
}
