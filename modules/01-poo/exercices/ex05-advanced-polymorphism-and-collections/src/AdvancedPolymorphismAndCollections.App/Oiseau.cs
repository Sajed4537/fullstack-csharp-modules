using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPolymorphismAndCollections.App
{
    internal class Oiseau : Animal, IVolant
    {
        public Oiseau(string name, int age) : base(name, age)
        {
        }

        public override void Crier()
        {
            Console.WriteLine("Cui-cui!");
        }

        public void Voler()
        {
            Console.WriteLine("L'oiseau vole dans le ciel.");
        }
    }
}
