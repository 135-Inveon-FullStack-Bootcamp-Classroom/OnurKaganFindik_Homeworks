using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    public class Pet
    {
        //Variables are encapsulated so they cannot be accessed from the other classes.
        private string name;
        private int lifeExpectancy;

        public Pet()
        {

        }

        //This constructor is used to initialize variables.
        public Pet(string _name, int _life)
        {
            _name = name;
            lifeExpectancy = _life;
        }

        //Methods are not encapsulated so they can be accessed from other classes.
        public string GetName()
        {
            return name;
        }

        public void SetName(string _name)
        {
            name = _name;
        }

        public int GetLifeExpentancy()
        {
            return lifeExpectancy;
        }

        public void SetLifeExpectancy(int life)
        {
            lifeExpectancy = life;
        }

        //marked "virtual" key so that this method can override in other classes
        public virtual void Speak()

        {
            Console.WriteLine($"{name} isimli hayvanın tahmini yaşama ömrü {lifeExpectancy} yıldır.");
        }

    }
}
