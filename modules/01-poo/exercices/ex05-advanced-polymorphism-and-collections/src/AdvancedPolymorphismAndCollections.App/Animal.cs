using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPolymorphismAndCollections.App
{
    internal abstract class Animal
    {
        public string Name {  get; set; }

        public int Age { get; set;}

        public Animal(string name, int age)
        {
            Name = name; 
            Age = age;
        }

        public abstract void Crier();

        public void Presenter()
        {
            Console.WriteLine($"{Name}, {Age}ans");
        }
    }
}
