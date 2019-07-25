
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace FuncGeneratorGenetic
{
    // Fabric to create compilable individuals 
    static class IndividCreater
    {
        // Program code text
        static string sProgramCodeFinal;

        // Needs for calling compiler
        static CSharpCodeProvider provider = new CSharpCodeProvider();
        static CompilerParameters parameters = new CompilerParameters();

        // Parameters of the function
        static object[] InvokeParams = new object[2];

        static Random rnd = new Random();

        // Constructor
        static IndividCreater()
        {
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
        }

        // Creates individual with random gene, that is compiled successfully
        //public static Individ CreateIndivid()
        //{
        //    Individ ind = new Individ();

        //    CompilerResults results = null;

        //    // Loop until compiled
        //    while (true)
        //    {
        //        // Get code sample with randomly built function
        //        sProgramCodeFinal = ProgramText.GetProgramCode(ind.Gene);

        //        // Try to compile
        //        results = provider.CompileAssemblyFromSource(parameters, sProgramCodeFinal);
        //        if (results.Errors.HasErrors)
        //        {
        //            ind = new Individ();
        //            continue;
        //        }

        //        break;
        //    }

        //    // Get access to the compiled function
        //    Assembly assembly = results.CompiledAssembly;
        //    Type program = assembly.GetType("Program.WorkingClass");
        //    MethodInfo main = program.GetMethod("F");

        //    int[] f_results = new int[TrainingDataBack.a_array.Length];

        //    // Calculate function values with training data
        //    for (int itry = 0; itry < TrainingDataBack.a_array.Length; itry++)
        //    {
        //        InvokeParams[0] = TrainingDataBack.a_array[itry];
        //        InvokeParams[1] = TrainingDataBack.b_array[itry];
        //        f_results[itry] = Convert.ToInt32(main.Invoke(null, InvokeParams));
        //    }

        //    // Calculate deviation with the training data at the place
        //    ind.CalculateDeviation(f_results);

        //    return ind;
        //}

        // // Creates individual with two parent's genes and possible mutation
        public static Individ CreateIndivid(Individ i1 = null, Individ i2 = null, bool mutate = true)
        {
            Individ ind = new Individ(i1, i2, mutate);

            CompilerResults results = null;

            // Loop until compiled
            while (true)
            {
                // Get code sample with randomly built function
                sProgramCodeFinal = ProgramText.GetProgramCode(ind.Gene);

                // Try to compile
                results = provider.CompileAssemblyFromSource(parameters, sProgramCodeFinal);
                if (results.Errors.HasErrors)
                {
                    ind = new Individ(i1, i2, true);
                    continue;
                }

                break;
            }

            // Get access to the compiled function
            Assembly assembly = results.CompiledAssembly;
            Type program = assembly.GetType("Program.WorkingClass");
            MethodInfo main = program.GetMethod("F");

            int[] f_results = new int[TrainingDataBack.a_array.Length];

            // Calculate function values with training data
            for (int itry = 0; itry < TrainingDataBack.a_array.Length; itry++)
            {
                InvokeParams[0] = TrainingDataBack.a_array[itry];
                InvokeParams[1] = TrainingDataBack.b_array[itry];
                f_results[itry] = Convert.ToInt32(main.Invoke(null, InvokeParams));
            }

            ind.CalculateDeviation(f_results);

            return ind;
        }
    }
}
