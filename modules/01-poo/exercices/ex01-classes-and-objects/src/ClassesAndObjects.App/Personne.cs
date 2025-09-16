using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects.App
{
    internal class Personne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Personne(int  id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void Afficher()
        {
            Console.WriteLine($"Id: {Id} - Nom: {Name} - Age: {Age}");
        }
    }
}
