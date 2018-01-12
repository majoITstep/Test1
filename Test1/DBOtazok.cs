using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class DBOtazok
    {
        public DBOtazok()
        {
            SingleOtazka o = new SingleOtazka();
            o.Text = "Kolko je 1+1?";
            o.Moznosti = new Moznost[]

                {
                    new Moznost ("Vysledok je 2",true),
                    new Moznost ("Vysledok je 3",false),
                    new Moznost ("Vysledok je 1",false)

                };

            Otazky.Add(o);

            o = new SingleOtazka();
            o.Text = "Kolko je 2+1?";
            o.Moznosti = new Moznost[]

                {
                    new Moznost ("Vysledok je 2",false),
                    new Moznost ("Vysledok je 3",true),
                    new Moznost ("Vysledok je 1",false)

                };

            Otazky.Add(o);

            MultipleOtazka m = new MultipleOtazka();
            m.Text = "Ktory je operacny system?";
            m.Moznosti = new Moznost[]

                {
                    new Moznost("OS Z",false),
                    new Moznost("OS X",true),
                    new Moznost("Windows",true)

                };

            Otazky.Add(m);
        }
        

        public ArrayList Otazky = new ArrayList();
        
           
        
    }
}
