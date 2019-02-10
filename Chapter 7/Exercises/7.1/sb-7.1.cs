/** 
C# for Artists
Skill Building Exercise

Chapter: 7
Exercise: 1
 **/

using System;

public class Test {
    static void Main(String[] args) {
         
        //declare vars
        int int_i = 0;
        int int_j = 0;
        int int_k = 0;
        int int_l = 0;
        int int_sum = 0;

        //simple input sanitation/validation
        if(args.Length < 4){
            Console.WriteLine("Array cannot contain more than four elements.");
            return;
        }
        else{
            foreach(String element in args){
                try {
                        //populate int_sum with summation of input args
                        int_sum += Convert.ToInt32(element);
                   }catch(System.FormatException){
                       Console.WriteLine("\nError encountered with element " + "'" + element + "'");
                       Console.WriteLine("All arguments must be integers \n");
                       return;
                    } //end catch
            } //end foreach

            //assign vars
            int_i = Convert.ToInt32(args[0]);
            int_j = Convert.ToInt32(args[1]);
            int_k = Convert.ToInt32(args[2]);
            int_l = Convert.ToInt32(args[3]);

            string all_vars = @"" + "\nValue of all variables: \n" +
                "\n    int_i = "+ args[0] +
                "\n    int_j = "+ args[1] +
                "\n    int_k = "+ args[2] +
                "\n    int_l = "+ args[3] +
                "\n"; 
            
            Console.WriteLine("Evaluating..");
            Console.WriteLine("--------------------------------------------------");
            //if statements
            if(int_i > int_j){
                Console.WriteLine("`"+int_i+" > "+int_j+"` evaluated to true.");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(int_i +" is less than "+int_j);
                Console.WriteLine("--------------------------------------------------");
            }

            if((int_i + int_j) <= int_k){
                Console.WriteLine("`("+int_i+" + "+int_j+") <= "+int_k+"` evaluated to true.");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(all_vars);
                Console.WriteLine("\nSum of all variables: "+ int_sum + "\n");
                Console.WriteLine("--------------------------------------------------");
            }

            if(int_k == int_l){
                Console.WriteLine("`"+int_k+" == "+int_l+"` evaluated to true.");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(int_k + " is equal to " + int_l);
                Console.WriteLine("--------------------------------------------------");
            }

            if((int_k != int_i) && (int_j > 25)){
                Console.WriteLine("`("+int_k +" != " +int_i+" ) && ( "+int_j+" > 25)` evaluated to true.");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(all_vars);
                Console.WriteLine("--------------------------------------------------");
            }

            if((((++int_j) & (--int_l)) > 0)){
                Console.WriteLine("(((++"+int_j+") & (--"+int_l+")) > 0) evaluated to true.");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(all_vars);
                Console.WriteLine("--------------------------------------------------");
            }


        } // end else
    } // end Main()
} // end Test class