using System;
using System.Collections.Generic;
using System.Linq;

namespace Объединение_войск
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barracks barracks = new Barracks();

            barracks.Work();
        }
    }

    class Soldier
    {
        public Soldier(string name) 
        { 
            Name = name;
        }

        public string Name { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine(Name);
        }
    }

    class Barracks
    {
        private List<Soldier> _partie1;
        private List<Soldier> _partie2;

        public Barracks()
        {
            _partie1 = Create();
            _partie2 = Create();
        }

        public void Work()
        {
            Console.WriteLine("Группы до объединения");
            ShowInfo(_partie1);

            Console.WriteLine();
            ShowInfo(_partie2);

            Console.WriteLine();
            Console.WriteLine("Объединенная группа\n");
            UniteParties();

        }

        private void UniteParties()
        {
            var unitedPatie = _partie2.Where(soldier => soldier.Name.StartsWith("Б")).Union(_partie1);

            foreach (Soldier soldier in unitedPatie)
            {
                Console.WriteLine(soldier.Name);
            }
        }

        private List<Soldier> Create()
        {
            List<Soldier> soldiers = new List<Soldier>()
            {
                new Soldier("Азбукин"),
                new Soldier("Беляев"),
                new Soldier("Белогоров"),
                new Soldier("Коклюшкин"),
                new Soldier("Топилин"),
            };

            return soldiers;
        }

        private void ShowInfo(List<Soldier> partie)
        {
            foreach(Soldier soldier in partie)
            {
                Console.WriteLine(soldier.Name);
            }
        }
    }
}
