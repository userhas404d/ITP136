/** 
C# for Artists
Suggested Project

Chapter: 7
Project: 2
 **/

using System;

public class RandomGuesser {
    public static void Main(){

        //generate random number between 1 and 100
        Random rnd = new Random();
        int int_random_num = rnd.Next(1, 100);
        int int_total_guesses = 1;
        //set default guess to a number not within the random range
        int int_guess = 0;
        char cont = 'y';
 
        while(cont.Equals('y')){
            try{
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("Guess a number between 1 and 100");
                //Console.WriteLine("Random Number: "+int_random_num);
                //Console.WriteLine("Guess Count: "+int_total_guesses);
                Console.WriteLine("--------------------------------------------------");
                while(int_guess != int_random_num){
                    if(int_total_guesses < 11){
                        Console.Write("Guess: ");
                        string str_guess = Console.ReadLine();
                        int_guess = Convert.ToInt32(str_guess);
                        if(int_guess > 100){
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("WAY too high. The number is between 1 and 100");
                            Console.WriteLine("--------------------------------------------------");
                            int_total_guesses += 1;
                        } else if(int_guess <= 0){
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("WAY too low. The number is between 1 and 100");
                            Console.WriteLine("--------------------------------------------------");
                            int_total_guesses += 1;
                        } else if(int_guess > int_random_num){
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("Too high.");
                            Console.WriteLine("--------------------------------------------------");
                            int_total_guesses += 1;
                        } else if(int_guess < int_random_num){
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("Too low.");
                            Console.WriteLine("--------------------------------------------------");
                            int_total_guesses += 1;
                        } 
                    } else {
                            Console.WriteLine("That's 10 guesses with no answer :( Keep playing?");
                            cont = PromptContinue();
                        }

                }//end continue check
            if(int_guess == int_random_num){
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("That's right!");
                Console.WriteLine("\nTotal Guesses: "+int_total_guesses);
                Console.WriteLine("--------------------------------------------------");
                if(PromptContinue().Equals('y')){
                    Main();
                }else {
                    return;
                }
            }
            }catch(System.FormatException){
                Console.WriteLine("\nError: Guess must be an integer.");
                cont = PromptContinue();
            }//end try/catch
        } // end guess check while loop
        

       // }//end while for cont check
            
        Console.WriteLine("\nExiting..");

    }//end Main()

    public static char PromptContinue(){
         char cont = 'y';
         try{
                Console.Write("\nKeep playing? y/n [y]: ");
                cont = char.ToLower(Console.ReadLine()[0]);
            } catch(IndexOutOfRangeException){
                cont = 'y';
            }//end try/catch
            return cont;
    }


}//end RandomGuesser class