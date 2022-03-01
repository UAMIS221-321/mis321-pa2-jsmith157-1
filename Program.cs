using System;
using System.IO;


namespace mis321_pa2_jsmith157_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Character playerCharacter = new Character();
            Character opponentCharacter = new Character();


            string userInput = "";
            userInput = BattleMenu();

            switch (userInput)
            {
                case "1":
                playerCharacter = new JackSparrow();
                Console.WriteLine("You have chosen Jack Sparrow");
                break;

                case "2":
                playerCharacter = new DavyJones();
                Console.WriteLine("You have chosen Davy Jones");
                break;

                case "3":
                playerCharacter = new WillTurner();
                Console.WriteLine("You have chosen Will Turner");
                break;

            }
                
            Console.WriteLine("\n\n");
            opponentCharacter = CPU();

            string userInput2 = "";
            string flip = "";

            userInput2 = goFirst();
            flip = peicesofEightFlip();


            if(userInput2 == flip)
            {
                Console.WriteLine("You go first!");
                playerCharacter.AttackBehavior.Attack(playerCharacter, opponentCharacter);
            }
            else
            {
                Console.WriteLine("The CPU goes first!");
                opponentCharacter.AttackBehavior.Attack(opponentCharacter, playerCharacter);
            }

            while(playerCharacter.Health > 0 && opponentCharacter.Health > 0)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

                if(userInput2 != flip)
                {
                    playerCharacter.AttackBehavior.Attack(playerCharacter, opponentCharacter);
                        damageDelt(playerCharacter, opponentCharacter);
                    
                        if(playerCharacter.Health > 0)
                        {
                            opponentCharacter.AttackBehavior.Attack(opponentCharacter, playerCharacter);
                            
                        }
                    damageDelt(playerCharacter, opponentCharacter);
                }
                else
                {
                    opponentCharacter.AttackBehavior.Attack(opponentCharacter, playerCharacter);
                    damageDelt(opponentCharacter, playerCharacter);
                    
                        if(playerCharacter.Health > 0)
                        {
                            playerCharacter.AttackBehavior.Attack(playerCharacter, opponentCharacter);
                            
                        }
                    damageDelt(playerCharacter, opponentCharacter);
                }  
                
            }

            if(playerCharacter.Health <= 0)
            {
                Console.WriteLine("You lost!");
            }
            else
            {
                Console.WriteLine("You won!");
            }

            if(opponentCharacter.Health <= 0)
            {
                Console.WriteLine("The CPU lost!");
            }
            else
            {
                Console.WriteLine("The CPU won!");
            }


        }

         static string BattleMenu()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Battle Menu!");

            Console.WriteLine("\n\n");
            Console.WriteLine("Choose your character:");
            Console.WriteLine("1. Jack Sparrow");
            Console.WriteLine("2. Davy Jones");
            Console.WriteLine("3. Will Turner");
            Console.WriteLine("4. Exit");
            string userInput = Console.ReadLine();


            while(userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Invalid input. Please try again.");
                Console.WriteLine("\n\n");
                Console.WriteLine("Choose your character:");
                Console.WriteLine("1. Jack Sparrow");
                Console.WriteLine("2. Davy Jones");
                Console.WriteLine("3. Will Turner");
                Console.WriteLine("4. Exit");
                userInput = Console.ReadLine();
            }
            if(userInput == "4")
            {
                Environment.Exit(0);
            }
            
            return userInput; 
        }
        
            static string peicesofEightFlip()
            {
                Random rand = new Random();
                int flip = rand.Next(0, 1);
                string[] Character = {"Heads", "Tails"};
                Console.WriteLine(flip);
                
                return Character[flip];

                
            }

            static string goFirst()
            {
                Random rand = new Random();
                Console.WriteLine("\n\n");
                Console.WriteLine("0: Heads or 1: Tails?");
                Console.WriteLine("\n\n");
                string userChoice = Console.ReadLine();
                Console.WriteLine("\n\n");

                return userChoice;

            }

            static string RandomCharacter()
            {
                Random rand = new Random();
                int opponent = rand.Next(0, 2);
                string[] Character = {"Jack Sparrow", "Davy Jones", "Will Turner"};

                return Character[opponent];
            
               
            }

            static Character CPU()
            {
                Character opponentCharacter = new Character();
                string Character = RandomCharacter();

                if(Character == "Jack Sparrow")
                {
                    opponentCharacter = new JackSparrow();
                }
                if(Character == "Davy Jones")
                {
                    opponentCharacter = new DavyJones();
                }
                if(Character == "Will Turner")
                {
                    opponentCharacter = new WillTurner();
                }

                Console.WriteLine("The CPU is playing as {0}", Character);

                return opponentCharacter;
               
            }

            static void damageDelt(Character attacker, Character defender)
            {
                int damage = attacker.Strength - defender.Defense;

                if(damage < 1)
                {
                    damage = 1;
                }
                int newHealth = defender.Health - damage;
                defender.Health = newHealth;

                Console.WriteLine("{0}'s attack did {1} damage to {2}", attacker.Name, damage, defender.Name);
            }     

        
        
    }
}

