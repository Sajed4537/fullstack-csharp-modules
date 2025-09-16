using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPolymorphismAndCollections.App
{
    internal class Chien : Animal
    {
        public Chien(string name, int age) : base(name, age)
        {
        }

        public override void Crier()
        {
            Console.WriteLine("Ouaf!");
        }
    }
}
