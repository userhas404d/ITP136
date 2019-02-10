/** 
C# for Artists
Skill Building Exercise

Chapter: 7
Exercise: 2
 **/


using System;

public class Test {
    static void Main(String[] args) {
        string name_1 = args[0];
        string name_2 = args[1];

        Console.WriteLine("--------------------------------------------------");
        if(name_1 == name_2){
          Console.WriteLine("`"+name_1+ " == " + name_2 + "` evaluated to TRUE");
          Console.WriteLine("--------------------------------------------------");
          Console.WriteLine(name_1+ " are equal " + name_2);
        } else{
            Console.WriteLine("`"+name_1+ " == " + name_2 + "` evaluated to FALSE");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("\nname_1: "+name_1);
            Console.WriteLine("name_2: "+name_2);
            Console.WriteLine("\n"+name_1+ " is not equal " + name_2);
        }
    }
}