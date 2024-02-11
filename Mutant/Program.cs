using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mutant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Mutant> mutants = new List<Mutant>();
            Mutant mutant = new Mutant();
            mutants.Add(mutant);

            Map map = new Map(mutants);

            while(true)
            {
                Console.Clear();
                Console.SetCursorPosition(0,0);
                foreach(Mutant mutantInList in mutants)
                {
                    mutantInList.Life(map);
                }
                map.DisplayMap();
                Thread.Sleep(50);
            }


            Console.ReadLine();
        }
    }
}
