
using System;
using System.Text;

namespace FuncGeneratorGenetic
{
    // Class composing code of the program
    static class ProgramText
    {
        // First part of program code
        static string ProgramCodeHeader =
                        //"using System;\n" +
                        //"\n" +
                        "namespace Program\n" +
                        "{\n" +
                        "    public class WorkingClass\n" +
                        "    {\n" +
                        "        public static int F(int x, int y)\n" +
                        "        {\n" +
                        "            ";

        // Last part of program code
        static string ProgramCodeFooter =
                        "\n" +
                        "        }\n" +
                        "    }\n" +
                        "}";

        // Alphabet of operations
        public static char[] OAlphabet = { '-', '+', '*', '/' };

        // Alphabet of values / variables
        public static char[] VAlphabet = { 'x', 'y', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        // Random number generator
        static Random rnd = new Random();

        // Get code for program with random code of function
        public static string GetProgramCode(byte[] gene)
        {
            StringBuilder sb = new StringBuilder(16);

            sb.Append(ProgramCodeHeader);
            sb.Append(@"return ");
            GetFunctionCode(sb, gene);
            sb.Append(';');
            sb.Append(ProgramCodeFooter);

            return sb.ToString();
        }

        // Get code for function according to the gene
        public static void GetFunctionCode(StringBuilder sb, byte[] gene)
        {
            sb.Append(' ');
            sb.Append(VAlphabet[gene[0]]);
            sb.Append(' ');
            sb.Append(OAlphabet[gene[1]]);
            sb.Append(' ');
            sb.Append(VAlphabet[gene[2]]);
            sb.Append(' ');
            sb.Append(OAlphabet[gene[3]]);
            sb.Append(' ');
            sb.Append(VAlphabet[gene[4]]);
            sb.Append(' ');
            sb.Append(OAlphabet[gene[5]]);
            sb.Append(' ');
            sb.Append(VAlphabet[gene[6]]);
            sb.Append(' ');
            sb.Append(OAlphabet[gene[7]]);
            sb.Append(' ');
            sb.Append(VAlphabet[gene[8]]);
        }
    }
}
