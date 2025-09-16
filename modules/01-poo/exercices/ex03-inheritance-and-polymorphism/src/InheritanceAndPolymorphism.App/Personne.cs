using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism.App
{
    internal class Personne
    {
        public int Id { get; set; }

        private string _name = "Nom inconnue";
        public string Name
        {
            get => _name;
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Vous devez avoir un nom !");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private int _age = 1;

        public int Age
        {
            get => _age;
            set
            {
                if (value > 1)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Attention ! l'âge ne peut pas être négatif ou égale à 0.");
                }
            }
        }

        public Personne(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public void Afficher()
        {
            Console.WriteLine($"Id: {Id} - Nom: {Name} - Age: {Age}");
        }

        public virtual void Presenter()
        {
            Console.WriteLine($"Son nom est {Name} et son âge est de {Age}ans");
        }
    }
}
