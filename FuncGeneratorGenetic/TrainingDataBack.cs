﻿
namespace FuncGeneratorGenetic
{
    // Training Data
    static class TrainingDataBack
    {
        // Test contains set of training data
        // 9 values of input values a and b, and 
        // 9 output values
        // The data are equal to function f = a*a + 5*b + 9;

        public static int[] a_array = { 38, 4, 51, 12, 6, 20, 25, 3, 40 };
        public static int[] b_array = { 2, 11, 7, 32, 21, 38, 43, 19, 34 };
        public static int[] f_array = { 1463, 80, 2645, 313, 150, 599, 849, 113, 1779 };

        public static int DataSize = 9;
    }
}
