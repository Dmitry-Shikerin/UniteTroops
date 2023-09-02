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
            _partie1 = CreateFirstPartie();
            _partie2 = CreateSecondPartie();
        }

        public void Work()
        {
            Console.WriteLine("Группы до объединения");
            ShowInfo(_partie1);
            Console.WriteLine();

            ShowInfo(_partie2);
            Console.WriteLine();

            UniteParties();

            Console.WriteLine("Группы после объединения\n");
            ShowInfo(_partie1);

            Console.WriteLine();
            ShowInfo(_partie2);

        }

        private void UniteParties()
        {
            _partie2 = _partie1.Where(soldier => soldier.Name.StartsWith("Б")).Union(_partie2).ToList();
            _partie1 = _partie1.Except(_partie2).ToList();
        }

        private List<Soldier> CreateFirstPartie()
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

        private List<Soldier> CreateSecondPartie()
        {
            List<Soldier> soldiers = new List<Soldier>()
            {
                new Soldier("Алексеев"),
                new Soldier("Беляшов"),
                new Soldier("Белов"),
                new Soldier("Кошкин"),
                new Soldier("Топников"),
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
