
using System;
using System.Diagnostics;

namespace FuncGeneratorGenetic
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Population p = new Population();
            int g = 1;

            while(true)
            {
                Console.WriteLine("Genaration:{0}  Distance:{1}", g, p.BestIndivid.Deviation);
                Console.WriteLine(ProgramText.GetProgramCode(p.BestIndivid.Gene));
                p.LiveCycle();
                g++;

                // Check if the solution is found
                if (p.BestIndivid.Deviation == 0)
                    break;
            }

            watch.Stop();

            Console.WriteLine("Genaration:{0}  Distance:{1}", g, p.BestIndivid.Deviation);
            Console.WriteLine("Elapsed time {0} seconds", watch.ElapsedMilliseconds / 1000);
            Console.WriteLine("The following code was built:");
            Console.WriteLine(ProgramText.GetProgramCode(p.BestIndivid.Gene));
            Console.ReadLine();
        }
    }
}
