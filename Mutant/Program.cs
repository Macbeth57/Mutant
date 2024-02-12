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
            Mutant mutant1 = new Mutant();
            Thread.Sleep(10);
            Mutant mutant2 = new Mutant();
            Thread.Sleep(10);
            Mutant mutant3 = new Mutant();
            mutants.Add(mutant1);
            mutants.Add(mutant2);
            mutants.Add(mutant3);


            Map map = new Map(mutants);

            while(true)
            {
                int debugMutant = 1;
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
