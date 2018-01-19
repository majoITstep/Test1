﻿using System;
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

        public virtual void VypisOtazku()
        {
            Console.WriteLine();
            Console.WriteLine(Text);
            Console.WriteLine("----------------");

            foreach (Moznost m in moznosti)

            {
                Console.WriteLine(m.Text);
            }
        }

        public virtual int VyhodnotOtazku()
        {
            return 0;
        }
    }

    class SingleOtazka : Otazka
    {
        public override int VyhodnotOtazku()
        {
            
            for (int i=0; i < Odpovede.Length; i++)
            {

                if (this.Odpovede[i].Spravnost) return 1;
            }

            return 0;
        }

        public override void VypisOtazku()
        {
            Console.WriteLine("Single choice");
            base.VypisOtazku();
        }
    }
    class MultipleOtazka : Otazka
    {
        public override int VyhodnotOtazku()
        {
            int Body = 0;
            for (int i = 0; i < Odpovede.Length; i++)
            {

                if (this.Odpovede[i].Spravnost) Body++;
                else Body--;
            }
            return Body;
            
        }
        public override void VypisOtazku()
        {
            Console.WriteLine("Multiple choice");
            base.VypisOtazku();
        }
    }

}
