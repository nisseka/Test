using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * Programmeringsuppgifter Programmering Förberedande kurs
 * av
 * Stefan Sundbeck
*/

class Player
{
// Private fields:
    private int FHealth;
    private int FStrength;
    private int FLuck;

    private string FName;
    private Random rand;

// Public Properties:
    public string Name
    {
        get => FName;
        set
        {
            if (FName != value)
            {
                FName = value;
            }
        }
    }

    public int Health
    {
        get => FHealth;
        set
        {
	    if (FHealth!=value && value >= 0 && value<200)
            {
                FHealth=value;
	    }
        }
    }

    public int Strength
    {
        get => FStrength;
        set
        {
            if (FStrength != value && value >= 0 && value < 100)
            {
                FStrength = value;
            }
        }
    }

    public int Luck
    {
        get => FLuck;
        set
        {
            if (FLuck != value && value >= 0 && value < 100)
            {
                FLuck = value;
            }
        }
    }

// Public Member functions:
// Constructor:
    public Player()
    {
        FHealth = 0;
        FStrength = 0;
        FLuck = 0;
        FName = "";
        rand = new Random();
    }

/*
  *  Function:    RandomizeHealth
  *  
  *  Assigns a random value to the Health member
  *  
  *  returns: the new value
*/
    public int RandomizeHealth()
    {
        return Health = rand.Next(1, 100);
    }

/*
 *  Function:    RandomizeStrength
 *  
 *  Assigns a random value to the Strength member
 *  
 *  returns: the new value
*/
    public int RandomizeStrength()
    {
        return Strength = rand.Next(1, 100);
    }

/*
 *  Function:    RandomizeLuck
 *  
 *  Assigns a random value to the Luck member
 *  
 *  returns: the new value
*/
    public int RandomizeLuck()
    {
        return Luck = rand.Next(1, 100);
    }

/*
 *  Function:    RandomizeValues
 *  
 *  Assigns random values to Health, Strength & Luck members
 *  
*/
    public void RandomizeValues()
    {
        RandomizeHealth();
        RandomizeStrength();
        RandomizeLuck();
    }

/*
 *  Function:    PrintPlayerDetails
 *  
 *  Outputs the players details to the console
 *  
*/
    public void PrintPlayerDetails()
    {
            Console.WriteLine("Namn:  \t{0}",Name);
            Console.WriteLine("Hälsa: \t{0}",Health);
            Console.WriteLine("Styrka:\t{0}",Strength);
            Console.WriteLine("Tur:   \t{0}",Luck);
    }
}

class Program
{
    static  string filename = @"c:\temp\TextFil.txt";
    static  string[] VardeStr = { "Värde 1", "Värde 2" };
    static  string[] MenuItems = { "Avsluta", "Hello World", "Ange användar-info", "Ändra textfärg", "Dagens datum", "Värde-jämförare", "Gissa Slumptal",
            "Skapa textfil", "Läs textfil", "Lite matte","Multiplikationstabell", "Två arrayer","Palindrom check","Siffror emellan","Udda/jämna värden",
            "Summa Värden","Karaktär & Motståndare"
    };

    static void Main(string[] args)
    {
        int i,age,a,b,c,c2;
        int MenuItemsCount;
        double tal1, tal2;
        bool exit=false;
        bool colorchanged = false;
        string s,firstname,lastname,s2;
        string[] substrs;

        Random rand = new Random();
        ConsoleColor oldcolor = Console.ForegroundColor;
        DateTime datetime = DateTime.Now;

        do
        {
            Console.Clear();

            Console.WriteLine("Välkommen till mitt program\n");

            MenuItemsCount=DrawMenu(MenuItems);                 // Display the menu
            
            i = RequestNumberFromUser_Int("\nAnge val:");     // The user must enter a value

            if (i >= 0 && i < MenuItemsCount)
            {
                Console.Clear();
                Console.WriteLine(MenuItems[i]);                // Display Menu Title
                Console.WriteLine("");
 
                switch (i)          // Act on the selected menu item
                {
                    case 1:         // Function 1: Hello World
                        Console.WriteLine("{0}!",MenuItems[i]);
                        break;
                    case 2:         // Function 2: Enter user info
                        firstname = RequestStringFromUser("Förnamn?  ");
                        lastname =  RequestStringFromUser("Efternamn?");
                        do
                            {
                            age = RequestNumberFromUser_Int("    Ålder?");
                        } while (age < 0);

                        Console.WriteLine("Förnamn:   {0}", firstname);
                        Console.WriteLine("Efternamn: {0}", lastname);
                        Console.WriteLine("Ålder:     {0}", age);
                        break;
                    case 3:         // Function 3 : Change text colour
                        Console.ForegroundColor = colorchanged == false ? ConsoleColor.Green : oldcolor;
                        colorchanged = !colorchanged;
                        Console.WriteLine("Textfärg ändrad till {0}", Console.ForegroundColor);
                        break;
                    case 4:         // Function 4: Print Date
                        datetime = DateTime.Now;
                        Console.WriteLine("{0:F}", datetime);
                        break;
                    case 5:         // Function 5 : Compare 2 values
                        tal1 = RequestNumberFromUser_Double($"{VardeStr[0]}?");
                        tal2 = RequestNumberFromUser_Double($"{VardeStr[1]}?");
                        if (tal1 > tal2)
                        {
                            Console.WriteLine("{0} ({1}) är störst!", VardeStr[0],tal1);
                        } else
                        if (tal1 < tal2)
                        {
                            Console.WriteLine("{0} ({1}) är störst!", VardeStr[1], tal2);
                        } else
                            Console.WriteLine("De är lika!");
                        break;
                    case 6:         // Function 6 : Guess random number
                        Console.WriteLine("Genererar slumptal mellan 1 och 100...\n");
                        a = rand.Next(1,100);
                        for (i = 1; ; i++)
                        {
                            b = RequestNumberFromUser_Int("Ange ett tal:");

		            if (a == b)
		            {
                                Console.WriteLine("Rätt! Det tog {0} försök!",i);
                                break;
                            } else
		            {
                                Console.Write("Fel! Angivet tal är för ");
                                if (b < a)
                                    Console.Write("litet");
                                else
                                    Console.Write("stort");

                                Console.WriteLine("!");
                            }
                        }
                        break;
                    case 7:        // Function 7 : Create Text file
                        s = RequestStringFromUser("Skriv in en text:");

                        Console.WriteLine("Sparar ned inskriven text till filen {0}",filename);
                        File.WriteAllText(filename, s);
                        break;
                    case 8:        // Function 8: Read text file
                        if (File.Exists(filename))
			{
                            Console.WriteLine("Filen {0} innehåller:", filename);
                            s = File.ReadAllText(filename);
                            Console.WriteLine(s);
                        } else
                            Console.WriteLine("Filen {0} finns inte!", filename);

                            break;
                    case 9:        // Function 9 : Some math
                        double sqrt, pow2, pow10;

                        tal1 = RequestNumberFromUser_Double("Ange ett tal:");
                        sqrt = Math.Sqrt(tal1);
                        pow2 = Math.Pow(tal1, 2);
                        pow10 = Math.Pow(tal1, 10);

                        Console.WriteLine("\nRoten ur {0,4}: {1:F}",tal1,sqrt);
                        Console.WriteLine("       {0,4}^2: {1:F}", tal1, pow2);
                        Console.WriteLine(pow10 > 100000 ? "      {0,4}^10: {1:E}" : "      {0,4}^10: {1:F}", tal1, pow10);
                        break;
                    case 10:        // Function 10 : Multiplicationstable
                        int x, y;

                        for (i = 0; i < 2; i++)
                        {
                            for (x = 1; x <= 10; x++)
                            {
                                for (y = 1; y <= 5; y++)
                                {
                                    b = y + (i * 5);
                                    a = x * b;
                                    Console.Write("{0,2:D} x {1,2:D} = {2,2:D}\t", b, x, a);
                                }
                                Console.Write("\r\n");
                            }
                            Console.WriteLine("\n");
                        }
                        break;
                   case 11:        // Function 11 : Two arrays
                        int ArraySize = RequestNumberFromUser_Int("Antal element i arrayerna?");

                        int[] array1 = new int[ArraySize];
                        int[] array2 = new int[ArraySize];

                        x = Math.Max(ArraySize, 1000);
                        for (i = 0; i < ArraySize; i++)             // Fill the arrays with random numbers
			{
                            a = rand.Next(0,x);
                            array1[i] = a;
                            array2[i] = a;
                        }

                        for (x = 0; x < ArraySize; x++)             // Sort array2 in ascending order
                        {
                            for (y = 0; y < ArraySize; y++)
                            {
                                a = array2[x];
                                b = array2[y];
				if (a < b)
				{                                   // Swap array elements
                                    array2[x] = b;
                                    array2[y] = a;
                                }
                            }
                        }

                        Console.WriteLine("\n    Array 1:\tArray 2:");
                        for (i = 0; i < ArraySize; i++)             // Output the 2 arrays to the console
                        {
                            Console.WriteLine("{0,2}: {1,4}\t{2,4}", i+1, array1[i],array2[i]);
                        }

                        break;
                    case 12:       // Function 12 : Palindrome check
                        s = RequestStringFromUser("Skriv in ett ord:");

                        c = s.Length;
                        c2 = c / 2;                             // Split the word in 2 parts

			for ( i = 0; i < c2; i++)
			{
			    if (s[i]!=s[c-1-i])                 // Compare the first character with the last, then the 2nd with the next last and so on.. 
			    {
                                break;
		            }    
			}
                        Console.Write("\n'{0}' är ",s);

                        if (i<c2)
			{
                            Console.Write("inte ");
                        }
                        Console.WriteLine("en palindrom");
                        break;
                    case 13:       // Function 13 : Numbers between 2 values
                        a = RequestNumberFromUser_Int($"{VardeStr[0]}?");
                        b = RequestNumberFromUser_Int($"{VardeStr[1]}?");

                        Console.WriteLine("\n");

                        if (b > a)
                        {
                            c = b - a;
                            x = a;
                        } else
			{
                            c = a - b;
                            x = b;
                        }                           // x is the lowest number of the 2 inputted values
                        c--;                        // Subtract the difference with 1 to get the number of numbers between the 2 inputted values

                        Console.Write(c > 0 ? "Siffror" : "Inga siffror finns");
 
                        Console.WriteLine(" mellan {0} & {1}:", a, b);

                        for (i = 0; i < c; i++)
			{
                            y = x + i + 1;
                            Console.WriteLine("{0}", y);
                        }

                        break;
                    case 14:       // Function 14 : Odd/even values
                        s2 = RequestStringFromUser("Skriv in värden, separerade med ',' (komma-tecken):");
                        
                        substrs = s2.Split(',');

                        int[] odd = new int[0];
                        int[] even = new int[0];
                        x = 0;
                        y = 0;
			foreach (string substr in substrs)
			{
                            s = substr.Trim();             // Remove white-spaces from string

			    try
		            {
                                a= int.Parse(s);
                                if ((a & 1) == 1)             // Check if the number is odd
                                {
                                    odd=odd.Append(a).ToArray();
                                    x++;
                                } else
				{                           // or even
                                    even=even.Append(a).ToArray();
                                    y++;
                                }
                            }
		            catch (FormatException)
		            {
			    }
			}

                        Console.WriteLine("\n{0} jämn{1} värden:", even.Length, (even.Length > 1 || even.Length==0 )? 'a' : 't');
                        foreach (int item in even)
                        {
                            Console.WriteLine("{0}", item);
                        }

                        Console.WriteLine("\n{0} udda värden:", odd.Length);
                        foreach (int item in odd)
                        {
                            Console.WriteLine("{0}", item);
                        }
                        break;
                    case 15:       // Function 15 : Sum values
                        s2 = RequestStringFromUser("Skriv in värden, separerade med ',' (komma-tecken):");

                        substrs = s2.Split(',');

                        c = substrs.Length;
                        b = 0;
                        foreach (string substr in substrs)
                        {
                            s = substr.Trim();             // Remove white-spaces from string

                            try
                            {
                                a = int.Parse(s);
                            }
                            catch (FormatException)
                            {
                                a = 0;
                            }
                            b += a;
                        }
                        Console.WriteLine("Summa värden: {0}", b);
                        break;
                    case 16:       // Function 16: Random player & opponent values
                        Player player = new Player();
                        Player opponent = new Player();

                        player.Name = RequestStringFromUser("Karaktärens namn:  "); 
                        opponent.Name = RequestStringFromUser("Motståndarens namn:");

                        player.RandomizeValues();           // Create random values on strength, health and luck
                        opponent.RandomizeValues();
                        opponent.RandomizeValues();         // for some reason(?) RandomizeValues() must be run twice otherwise the opponent object
                                                            // contains the same random values in Luck,Strength & Health as in object player...

                        Console.WriteLine("\nKaraktär:");
                        player.PrintPlayerDetails();

                        Console.WriteLine("\nMotståndare:");
                        opponent.PrintPlayerDetails();
                        break;
                    case 0:         // Exit
                        exit = true;
                        break;
                } 

                if (!exit)
                {
                    WaitForUserPressedAKey();
                }

            }
        } while (!exit);

    }
        
 /*
  * Function:    RequestStringFromUser
  * 
  * Outputs a title text specified by DisplayText in the console and records the users keypresses until return key is pressed
  * 
  * returns:    The recorded text string
 */
    static string  RequestStringFromUser(string    DisplayText)
    {
        string  r;
        Console.Write("{0} ",DisplayText);
        r = Console.ReadLine();
        return r;
    }

/*
 * Function:    RequestNumberFromUser_Int
 * 
 * Outputs a title text specified by DisplayText in the console and waits for the user to enter a number. If WaitForValidNumber is true, the function 
 * doesn't return until a valid number has been entered.
 * 
 * returns:    The number in Integer format
  * 
*/
    static int RequestNumberFromUser_Int(string DisplayText,bool WaitForValidNumber = true)
    {
        int r=0;
        string s;
        bool exit;
        do
        {
            s = RequestStringFromUser(DisplayText);
            try
            {
                exit = true;
                r = int.Parse(s);           // Convert the string to a number. If the string contains non-numerical characters
                                            // int.Parse() will throw an exception which will be handled by the try catch statement to allow the
                                            // program to continue
            }
            catch (FormatException)
            {
                exit = false;               // Non-numerical characters in the string s, try again..
            }
        } while (!exit && WaitForValidNumber);
        return r;
    }

/*
 * Function:    RequestNumberFromUser_Double
 * 
 * Outputs a title text specified by DisplayText in the console and waits for the user to enter a number. If WaitForValidNumber is true, the function 
 * doesn't return until a valid number has been entered.
 * 
 * returns:    The number in Double format

 */
    static double RequestNumberFromUser_Double(string DisplayText, bool WaitForValidNumber = true)
    {
        double r=0;
        string s;
        bool exit;
        do
        {
            s = RequestStringFromUser(DisplayText);
            try
            {
                exit = true;
                r = double.Parse(s);        // Convert the string to a number. If the string contains non-numerical characters
                                            // double.Parse() will throw an exception which will be handled by the try catch statement to allow the
                                            // program to continue
            }
            catch (FormatException)
            {
                exit = false;               // Non-numerical characters in the string s, try again..
            }
        } while (!exit && WaitForValidNumber);
        return r;
    }



 /*
  * Function:    WaitForUserPressedAKey
  * 
  * Outputs an information text and waits for the user to press a key to continue
*/
    static void WaitForUserPressedAKey()
    {
        Console.Write("\nTryck en tangent för att fortsätta..");
        Console.ReadKey();
    }

/*
 *  Function:    DrawMenu
 *  
 *  Outputs a menu specified by MenuItems to the console
 *  
 *  returns:   The number of menuitems drawn  
 */
    static  int    DrawMenu(string[] MenuItems)
    {
        int i;
        Console.WriteLine("Meny:");

        i = 0;
        foreach (string menuitem in MenuItems)
        {
            Console.WriteLine("{0,5}: {1}", i, menuitem);
            i++;
        }
        return i;   // Return the number of menuitems drawn;
    }
}
