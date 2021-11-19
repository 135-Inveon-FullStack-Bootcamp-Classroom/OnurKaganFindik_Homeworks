using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    public class Dog : Pet
    {
        public override void Speak()
        {
            string name = GetName() == null ? "Ad belirtilmemiş" : GetName();
            int life = GetLifeExpentancy();

            Console.WriteLine($"{name}({this.GetType().Name}) isimli hayvan tahmini {life} yıl kadar yaşayabilir.");
        }
    }
}
