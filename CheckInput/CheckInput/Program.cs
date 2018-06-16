using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInput
{
    abstract class Building
    {
        protected string name;
        private void SetFoundation() { Console.WriteLine("Foundation set."); }
        private void SetWalls() { Console.WriteLine("Walls set."); }
        private void SetRoof() { Console.WriteLine("Roof set."); }
        protected abstract void SetWindows();
        protected abstract void SetDoors();
        protected abstract void SpecialFunc();

        public void Build()
        {
            Console.WriteLine(name);
            SetFoundation();
            SetWalls();
            SetRoof();
            SetWindows();
            SetDoors();
            SpecialFunc();
            Console.WriteLine();
        }
    }

    class Castle : Building
    {
        public Castle()
        {
            name = "Castle";
        }
        protected override void SetWindows()
        {
            Console.WriteLine("Old windows set.");
        }
        protected override void SetDoors()
        {
            Console.WriteLine("Old doors set.");
        }
        protected override void SpecialFunc()
        {
            Console.WriteLine("Special: Count Dracula live in the castle.");
        }
    }

    class Skyscaper: Building
    {
        public Skyscaper()
        {
            name = "Skyskaper";
        }
        protected override void SetWindows()
        {
            Console.WriteLine("New technological windows set.");
        }
        protected override void SetDoors()
        {
            Console.WriteLine("New technological doors set.");
        }
        protected override void SpecialFunc()
        {
            Console.WriteLine("Special: The highest building in your town!");
        }
    }

    class House : Building
    {
        public House()
        {
            name = "House";
        }
        protected override void SetWindows()
        {
            Console.WriteLine("Common windows set.");
        }
        protected override void SetDoors()
        {
            Console.WriteLine("Common doors set.");
        }
        protected override void SpecialFunc()
        {
            Console.WriteLine("Special: You have a place for habitation now.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Building[] buildings =  { new Castle(), new Skyscaper(), new House() };
            for (int i = 0; i < 3; i++)
            {
                buildings[i].Build();
            }
            Console.ReadLine();
        }
    }
}
