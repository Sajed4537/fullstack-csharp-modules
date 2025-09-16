using System;

namespace AdvancedPolymorphismAndCollections.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Chien("Berger alemand", 2),
                new Chat("Siamois", 1),
                new Oiseau("Peruche", 3)
            };

            foreach (Animal animal in animals)
            {
                animal.Presenter();
                animal.Crier();

                if (animal is IVolant volant)
                {
                    volant.Voler();
                }
            }
        }
    }
}