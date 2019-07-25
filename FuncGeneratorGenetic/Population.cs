
using System;

namespace FuncGeneratorGenetic
{
    // Create population of compiled individuals
    class Population
    {
        Individ[] Individuals;

        // Number of individuals who will create new population (parents)
        public const int size_main = 10;

        // Number of individuals created from parents
        public const int size_other = size_main * size_main;

        public Population()
        {
            // Create array for entire population
            Individuals = new Individ[size_main + size_other];

            // Create compileable individuals
            for(int i = 0; i < Individuals.Length; i++)
            {
                Individuals[i] = IndividCreater.CreateIndivid();
            }

            // Sortinf individuals for further selection top as parents
            // and rest to delete and replace by new generation
            Array.Sort<Individ>(Individuals, IndividComparizon);
        }

        // Create new generation
        public void LiveCycle()
        {           
            Repopulate();
            Array.Sort<Individ>(Individuals, IndividComparizon);
        }

        // Create new generation from the parents
        void Repopulate()
        {
            int pos = size_main;

            for (int i1 = 0; i1 < size_main; i1++)
                for (int i2 = 0; i2 < size_main; i2++)
                {
                    Individuals[pos] = IndividCreater.CreateIndivid(Individuals[i1], Individuals[i2], i1 == i2);
                    pos++;
                }
        }

        // Individ who is the most close to the solution 
        public Individ BestIndivid
        {
            get
            {
                return Individuals[0];
            }
        }

        // For sorting by deviation from training results
        static int IndividComparizon(Individ i1, Individ i2)
        {
            if (i1.Deviation < i2.Deviation)
                return -1;
            else
            if (i1.Deviation > i2.Deviation)
                return 1;
            else
                return 0;
        }
    }
}
