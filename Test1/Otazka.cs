using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Otazka
    {
        public string Text;
        private Moznost[] moznosti;
        public Moznost[] Moznosti
        {
            get
            {
                return moznosti;
            }
            set
            {
                moznosti = value;
            }
        }

        public Moznost[] Odpovede;

        public void VypisOtazku()
        {
            Console.WriteLine();
            Console.WriteLine(Text);
            Console.WriteLine("----------------");

            foreach (Moznost m in moznosti)

            {
                Console.WriteLine(m.Text);
            }
        }
    }

    class SingleOtazka : Otazka
    {

    }
    class MultipleOtazka : Otazka
    {

    }
}
