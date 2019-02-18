/*  

Single-Dimensional Arrays: Write a program that lets you create a single-dimensional array of integers
of different sizes at program runtime using command-line inputs.

*/

using System;

public class Test {
    static void Main(String[] args) {

        int arr_len = args.Length;
        int[] my_arr = new int[arr_len];
        Console.WriteLine("Array length: "+ arr_len);
        for (int x=0; x < arr_len; x++){
            try {
                int arr_value = Convert.ToInt32(args[x]);
                my_arr[x] = arr_value;
                }catch(System.FormatException){
                    Console.WriteLine("Arguments must be an integers.");
                    return;
                } // end catch
            } // end foreach
        for(int x=0; x < arr_len; x++){
            Console.Write(my_arr[x]);
            // don't add a comma after the last element in the array.
            if(x < arr_len - 1){
                Console.Write(" , ");
            } // end if
        } // end for
    } // end Main
} // end class