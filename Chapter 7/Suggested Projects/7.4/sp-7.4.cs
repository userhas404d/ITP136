/** 
C# for Artists
Suggested Project

Chapter: 7
Project: 4
 **/

using System;
public class CircleArea {
    public static void Main(){

        char cont = 'y';
        double PI = 3.1415926535897931;

        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("-------==:Simple Circle Area Calculator:==--------");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("Enter the radius of a circle to calculate its area.");
        Console.WriteLine("--------------------------------------------------");

        while(cont.Equals('y')){
            try{
                Console.Write("\nRadius: ");
                string str_radius = Console.ReadLine();
                double radius = Convert.ToDouble(str_radius);
                double area = PI * Math.Pow(radius,2);
                Console.WriteLine("\nArea: "+area);
                cont = PromptContinue();
            } catch(System.FormatException){
                Console.WriteLine("\nError: Radius must be an integer or double.");
                cont = PromptContinue();
            }
        }


    }

    public static char PromptContinue(){
        char cont = 'y';
        try{
            Console.Write("\nContinue? y/n [y]: ");
            cont = char.ToLower(Console.ReadLine()[0]);
        } catch(IndexOutOfRangeException){
            cont = 'y';
        }//end try/catch
        return cont;
    }

 }
