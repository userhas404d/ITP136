/*

Single-Dimensional Arrays: Write a program that reverses the order of text entered on the command
line. This will require the use of the Main() method’s string array.

 */

using System; 

public class ReverseArray {
    public static void Main(String[] args){
        // iterate over the args array in reverse
        for(int x=args.Length - 1; x >= 0; x--){
            // capture each string arg into a separate char array and reverse it
            char[] rev_string = args[x].ToCharArray();
            Array.Reverse(rev_string);
            Console.Write(rev_string);
            // only add a space if there is more than one element left
            if(x < args.Length + 1){
                Console.Write(" ");
            } // end if
        } // end foreach
    } // end main
} // end class