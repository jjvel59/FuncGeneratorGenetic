
using System;

namespace FuncGeneratorGenetic
{
    // The population individual for genetic algorithm
    class Individ
    {
        // Gene for building the formula
        public byte[] Gene;
        private int genSize = 9;
        // Deviation from testing results
        public int Deviation;

        // Random number generator
        static Random rnd = new Random();

        //// Creates Individ with random gene
        //public Individ()
        //{
        //    Gene = new byte[genSize];

        //    NuevoGen();
        //    while (!genContVar())
        //        NuevoGen();

        //    Deviation = int.MaxValue;
        //}

        
       

        // Creates Individ with random gene
        public Individ(Individ i1, Individ i2, bool mutate)
        {
            Gene = new byte[genSize];

            if (i1 == null)
                NuevoGen();
            else
                NuevoGen(i1, i2, mutate);
            
            Deviation = int.MaxValue;
        }

        private bool genContVar()
        {
            return Array.Exists(Gene, element => element == 0)
                     && Array.Exists(Gene, element => element == 1);
        }

        private void NuevoGen()
        {
            Gene[0] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);
            Gene[1] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);
            Gene[2] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);
            Gene[3] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);
            Gene[4] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);
            Gene[5] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);
            Gene[6] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);
            Gene[7] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);
            Gene[8] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);
        }

        private void NuevoGen(Individ i1, Individ i2, bool mutate)
        {
            // Randomly use gene from one of the parent 
            for (int i = 0; i < Gene.Length; i++)
                Gene[i] = (rnd.Next(0, 2) == 0 ? i1.Gene[i] : i2.Gene[i]);

            if (mutate)
            {
                // value should be between 0 and 10
                int variability = 2;

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[0] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[1] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[2] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[3] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[4] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[5] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[6] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[7] = (byte)rnd.Next(0, ProgramText.OAlphabet.Length);

                if (rnd.Next(0, 12 - variability) == 0)
                    Gene[8] = (byte)rnd.Next(0, ProgramText.VAlphabet.Length);
            }
        }

        // Calculate Deviation as a maximal distance between
        // training and actual results
        public void CalculateDeviation(int[] results)
        {
            int d = 0;

            for (int i = 0; i < TrainingData.DataSize; i++)
            {
                int d2 = Math.Abs(TrainingData.f_array[i] - results[i]);
                if (d < d2)
                    d = d2;
            }

            Deviation = d;
        }

    }
}
