using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Quiz
    {
        private Otazka[] otazky;
        public Quiz()
        {
            otazky = new Otazka[2];
            DBOtazok db = new DBOtazok();
            Random r = new Random();
            ArrayList vybraneCisla = new ArrayList();

            for (int i = 0; i < 2; i++)

            {
                int index;
                do
                {
                    index = r.Next(3);
                }

                while (vybraneCisla.Contains(index));

                otazky[i] = (Otazka)db.Otazky[index];
                vybraneCisla.Add(index);

            }
        }
        public void SpustQuiz()
        {
            foreach (Otazka o in otazky)
            {
                string uzivOdpoved;
                int[] poleUzivIndexov;
                o.VypisOtazku();

                do
                {
                    uzivOdpoved = Console.ReadLine();
                }
                while (!skontrolujVstup(uzivOdpoved, o, out poleUzivIndexov));
                o.Odpovede = new Moznost[poleUzivIndexov.Length];
                for (int i = 0; i<poleUzivIndexov.Length;i++)
                {

                    o.Odpovede[i] = o.Moznosti[poleUzivIndexov[i] - 1];

                }
            }
            int body = 0;
            foreach (Otazka o in otazky)
            {
                body += o.VyhodnotOtazku();
            }
            Console.WriteLine("Dostali ste{0}", body);

            Console.ReadLine();
        }

        private bool skontrolujVstup(string uzivVstup, Otazka otazka, out int[] poleIndexu)
        {
            poleIndexu = null;
            int index;
            if (otazka is SingleOtazka)
            {
                bool res = jeCisloAJeVindexe(uzivVstup, otazka, out index);
                poleIndexu = new int[] { index };
                if (!res) Console.WriteLine("Zly vstup");
                return res;
            }
            
            else
            {
                string[] poleOdpovediUzivatela = uzivVstup.Split(' ');
                poleIndexu = new int[poleOdpovediUzivatela.Length];
                for(int i = 0;i<poleOdpovediUzivatela.Length;i++)
                {
                    if (!jeCisloAJeVindexe(poleOdpovediUzivatela[i], otazka, out index)) return false;
                    poleIndexu[i] = index;
                }

                return true;

            }
        }

        private bool jeCisloAJeVindexe(string uzivatelskeCislo, Otazka otazka, out int index)
        {
           
            bool jeCislo = int.TryParse(uzivatelskeCislo, out index);

            if (!jeCislo)
            {
                return false;
            }
            else
            {
                return (index > 0 && index < otazka.Moznosti.Length+1);
            }
        }
    }

}
