using Inheritance.Models;
using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Bird bird = new Bird();
            bird.SetName("Kırpık");
            bird.SetLifeExpectancy(6);
            bird.Species();
            bird.Speak();

            //----------------------------------------------
            Console.WriteLine();
            Cat cat = new Cat();
            cat.SetName("Mışık");
            cat.SetLifeExpectancy(7);
            cat.Hobby();
            cat.Species();
            cat.Speak();

            //----------------------------------------------
            Console.WriteLine();
            Dog dog = new Dog();
            dog.SetName("Çomar");
            dog.SetLifeExpectancy(15);
            dog.Species();
            dog.Speak();

        }
    }
}
