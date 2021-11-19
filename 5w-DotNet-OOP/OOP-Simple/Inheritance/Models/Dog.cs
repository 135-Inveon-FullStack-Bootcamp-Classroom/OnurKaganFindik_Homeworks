using System;

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
        public override void Species()
        {
            string[] species = { " Buldog", "Labrador", "Golden", "Kaniş" };

            Random rnd = new Random();
            Console.WriteLine($"Tür: {species[rnd.Next(species.Length)]}");
        }
    }
}
