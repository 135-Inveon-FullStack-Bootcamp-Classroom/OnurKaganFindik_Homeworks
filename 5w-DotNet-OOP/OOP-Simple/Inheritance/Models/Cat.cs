using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    public class Cat : Pet
    {
        private readonly string[] hobbies = { "Koltuk kenarlarını tırmalamak.", "Top ile oynamak", " Hareketli küçük şeyleri avlamak " };
        public void Hobby()
        {
            Random rnd = new Random();
            Console.WriteLine($"Hobi: {hobbies[rnd.Next(hobbies.Length)]}");
        }
        public override void Speak()
        {

            string name = GetName() == null ? "Ad belirtilmemiş" : GetName();
            int life = GetLifeExpentancy();

            Console.WriteLine($"{name}({this.GetType().Name}) isimli hayvan tahmini {life} yıl kadar yaşayabilir.");
        }

        public override void Species()
        {
                string[] species = { " Siyam", "Tekir", "Maine Coon", "Munchkin" };

                Random rnd = new Random();
                Console.WriteLine($"Tür: {species[rnd.Next(species.Length)]}");
        }
    }
}
