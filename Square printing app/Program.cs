using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Square_printing_app
{
    internal class Program
    {
        //[SupportedOSPlatform("windows")] <--- remove the // to fix CA1416
        static void Main(string[] args)
        {
            //start and introduce the program to the user

            Console.Title = "Square Printing App";
            Console.WindowHeight = 50;
            Console.WindowWidth = 110;

            Console.WriteLine("   ╔═════════════════════════════╗");
            Console.WriteLine("   ║ Square Printing Application ║");
            Console.WriteLine("   ║         Version 1.0         ║");
            Console.WriteLine("   ║       By Alexledragon       ║");
            Console.WriteLine("   ╚═════════════════════════════╝\n");

            Console.WriteLine(" Welcome! This console will allow you to display a grid of squares that follow your preferences.");
            Console.Write(" When you are ready to proceed, ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("press ENTER ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("on your keyboard.");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

            }
            Console.WriteLine("");

            SquarePrintingSequenceBegining:

            //ask the user for how big the squares should be, make sure the answers are valid

            int squareSizeWanted = 0;
            bool isAnswerSizeGiven = false;
            int savedCoordX; //those coord are used for the UI, to erase the previous entry and let the user rewrite them in the case of an error or such
            int savedCoordY;
            int spamModeCheck = 0; //increase by one everytime user just press enter without giving a proper answer, used to trigger spam mode

            Console.WriteLine("\n════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.Write(" How large do you want the squares to be? Please make it between 2 and 40 units (ex: 8): ");
            savedCoordX = Console.CursorLeft;
            savedCoordY = Console.CursorTop;
            while (isAnswerSizeGiven == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string squareSizeWantedString = Console.ReadLine(); //declare this as var to fix CS8600
                int.TryParse(squareSizeWantedString, out squareSizeWanted);
                if (squareSizeWanted >= 2 & squareSizeWanted <= 40)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    isAnswerSizeGiven = true;
                }
                else if (squareSizeWanted == 0 & squareSizeWantedString == "")
                {
                    Random random = new Random();
                    squareSizeWanted = random.Next(2, 31);
                    isAnswerSizeGiven = true;
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.WriteLine("Random");
                    Console.ForegroundColor = ConsoleColor.White;
                    spamModeCheck++;
                }
                else
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Value is incorrect");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    {

                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                }
            }

            //put a cap to the amount of squares possibly printed, to make it fit the window

            int squareAmmountCap = 1;

            switch (squareSizeWanted)
            {
                case <= 3:
                    squareAmmountCap = 20;
                    break;
                case <= 5:
                    squareAmmountCap = 14;
                    break;
                case <= 7:
                    squareAmmountCap = 10;
                    break;
                case <= 9:
                    squareAmmountCap = 8;
                    break;
                case <= 10:
                    squareAmmountCap = 7;
                    break;
                case <= 12:
                    squareAmmountCap = 6;
                    break;
                case <= 15:
                    squareAmmountCap = 5;
                    break;
                case <= 20:
                    squareAmmountCap = 4;
                    break;
                case <= 26:
                    squareAmmountCap = 3;
                    break;
                case <= 40:
                    squareAmmountCap = 2;
                    break;
            }

            //ask the user for how many squares to print horizontally and vertically, make sure the answers are valid

            int squareAmmountWantedVertical = 0;
            bool isAnswerAmountVerticalGiven = false;

            Console.Write(" How many squares do you want vertically? Please make it between 1 and " + squareAmmountCap + " units (ex: 2): ");
            savedCoordX = Console.CursorLeft;
            savedCoordY = Console.CursorTop;
            while (isAnswerAmountVerticalGiven == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string squareAmmountWantedVerticalString = Console.ReadLine(); //declare this as var to fix CS8600
                int.TryParse(squareAmmountWantedVerticalString, out squareAmmountWantedVertical);
                if (squareAmmountWantedVertical >= 1 & squareAmmountWantedVertical <= squareAmmountCap)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    isAnswerAmountVerticalGiven = true;
                }
                else if (squareAmmountWantedVertical == 0 & squareAmmountWantedVerticalString == "")
                {
                    Random random = new Random();
                    squareAmmountWantedVertical = random.Next(1, squareAmmountCap+1);
                    isAnswerAmountVerticalGiven = true;
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.WriteLine("Random");
                    Console.ForegroundColor = ConsoleColor.White;
                    spamModeCheck++;
                }
                else
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Value is incorrect");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    {

                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                }
            }

            int squareAmmountWantedHorizontal = 0;
            bool isAnswerAmountHorizontalGiven = false;

            Console.Write(" How many squares do you want horizontally? Please make it between 1 and " + squareAmmountCap + " units (ex: 2): ");
            savedCoordX = Console.CursorLeft;
            savedCoordY = Console.CursorTop;
            while (isAnswerAmountHorizontalGiven == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string squareAmmountWantedHorizontalString = Console.ReadLine(); //declare this as var to fix CS8600
                int.TryParse(squareAmmountWantedHorizontalString, out squareAmmountWantedHorizontal);
                if (squareAmmountWantedHorizontal >= 1 & squareAmmountWantedHorizontal <= squareAmmountCap)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    isAnswerAmountHorizontalGiven = true;
                }
                else if (squareAmmountWantedHorizontal == 0 & squareAmmountWantedHorizontalString == "")
                {
                    Random random = new Random();
                    squareAmmountWantedHorizontal = random.Next(1, squareAmmountCap + 1);
                    isAnswerAmountHorizontalGiven = true;
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.WriteLine("Random");
                    Console.ForegroundColor = ConsoleColor.White;
                    spamModeCheck++;
                }
                else
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Value is incorrect");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    {

                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                }
            }

            //show color modes to user, ask his choice and store it as a number to be treated later

            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine(" The squares are avaible in multiple colours, here are your options:\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" [Red] ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[Dark Red] ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[Blue] ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[Dark Blue] ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Green] ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[Dark Green] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[Yellow] ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[Dark Yellow] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" [Cyan] ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[Dark Cyan] ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[Magenta] ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[Dark Magenta] ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("[Black]");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" [White] ");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("R");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("a");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("i");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("b");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("w");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.WriteLine("[Random]\n");

            string wantedColourString = "White"; //declare this as var to fix CS8600
            int wantedColourNumber = 14;
            bool isAnswerColourGiven = false;
            bool rainbowModeEnabled = false;
            int rainbowModeNumber = 1; //used to define if rainbow mode is horizontal, vertical or diagonal during print
            bool rainbowModeIsRandom = false; //check if the rainbow mode was enabled by being picked by random mode, to make the next choice random as well

            Console.Write(" Which one do you wish your squares to be? (ex: dark blue): ");
            savedCoordX = Console.CursorLeft;
            savedCoordY = Console.CursorTop;
            while (isAnswerColourGiven == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                wantedColourString = Console.ReadLine();
                wantedColourString = wantedColourString.ToUpper();

                /* <-- replace the 2 lines above by this commentary to fix CS8602
                wantedColourString = Console.ReadLine();
                if(wantedColourString != null)
                {
                    wantedColourString = wantedColourString.ToUpper();
                }
                */

                switch (wantedColourString)
                {
                    case "RED":
                        wantedColourNumber = 1;
                        break;
                    case "DARK RED":
                        wantedColourNumber = 2;
                        break;
                    case "BLUE":
                        wantedColourNumber = 3;
                        break;
                    case "DARK BLUE":
                        wantedColourNumber = 4;
                        break;
                    case "GREEN":
                        wantedColourNumber = 5;
                        break;
                    case "DARK GREEN":
                        wantedColourNumber = 6;
                        break;
                    case "YELLOW":
                        wantedColourNumber = 7;
                        break;
                    case "DARK YELLOW":
                        wantedColourNumber = 8;
                        break;
                    case "CYAN":
                        wantedColourNumber = 9;
                        break;
                    case "DARK CYAN":
                        wantedColourNumber = 10;
                        break;
                    case "MAGENTA":
                        wantedColourNumber = 11;
                        break;
                    case "DARK MAGENTA":
                        wantedColourNumber = 12;
                        break;
                    case "BLACK":
                        wantedColourNumber = 13;
                        break;
                    case "WHITE":
                        wantedColourNumber = 14;
                        break;
                    case "RAINBOW":
                        wantedColourNumber = 15;
                        break;
                    case "RANDOM":
                        Random random = new Random();
                        wantedColourNumber = random.Next(1, 16);
                        rainbowModeIsRandom = true;
                        break;
                    case "":
                        if (spamModeCheck >= 3)
                        {
                            Random randomAlt = new Random();
                            wantedColourNumber = randomAlt.Next(1, 16);
                            rainbowModeIsRandom = true;
                            Console.SetCursorPosition(savedCoordX, savedCoordY);
                            for (int i = 0; i < 5; i++)
                            {
                                Console.Write("                                                                                                    ");
                            }
                            Console.SetCursorPosition(savedCoordX, savedCoordY);
                            Console.WriteLine("Random");
                            spamModeCheck++;
                        }
                        else
                        {
                            wantedColourNumber = 0;
                        }
                        break;
                    default:
                        wantedColourNumber = 0;
                        break;
                }
                if (wantedColourNumber >= 1 & wantedColourNumber <= 15)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    isAnswerColourGiven = true;
                }
                else
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Value is incorrect");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    {

                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                }
            }

            if(wantedColourNumber == 15 & rainbowModeIsRandom == false) //in case of rainbow mode, elaborate
            {
                Console.Write(" Do you want your rainbow to be horizontal, vertical or diagonal? (ex: vertical): ");
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;
                for (int i = 1; i == 1; i = 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    string rainbowAnswer = Console.ReadLine(); //declare this as var to fix CS8600
                    rainbowAnswer = rainbowAnswer.ToUpper();

                    /* <-- replace the 2 lines above by this commentary to fix CS8602
                    string rainbowAnswer = Console.ReadLine(); //declare this as var to fix CS8600
                    if(rainbowAnswer != null)
                    {
                        rainbowAnswer = rainbowAnswer.ToUpper();
                    }
                    */

                    if (rainbowAnswer == "HORIZONTAL")
                    {
                        rainbowModeNumber = 1;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else if (rainbowAnswer == "VERTICAL")
                    {
                        rainbowModeNumber = 2;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else if (rainbowAnswer == "DIAGONAL")
                    {
                        rainbowModeNumber = 3;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        for (int iOne = 0; iOne < 5; iOne++)
                        {
                            Console.Write("                                                                                                    ");
                        }
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Value is incorrect");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {

                        }
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        for (int iOne = 0; iOne < 5; iOne++)
                        {
                            Console.Write("                                                                                                    ");
                        }
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                    }

                }
            }
            else if(wantedColourNumber == 15 & rainbowModeIsRandom == true) //used if rainbow mode was randomly picked, not to spoil the result and make it random as well
            {
                Random random = new Random();
                rainbowModeNumber = random.Next(1, 4);
            }

            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════");

            //apply the colour requested by the user before printing the squares

            switch (wantedColourNumber)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 11:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 12:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 13:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case 14:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 15:
                    rainbowModeEnabled = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }

            //create strings of the wanted size to be assembled during the print later, following the user inputs

            int squareInsideSizeHorizontal = squareSizeWanted - 2;
            int squareInsideSizeVertical = (squareSizeWanted - 2) / 2; //divided by two to compensate for the height to width diffence of a standard character in the final print
            string squareHorizontalLine = new('═', squareInsideSizeHorizontal);
            string squareHorizontalBlank = new(' ', squareInsideSizeHorizontal);

            //start the actual printing process by looping different sequences, then restore the default colour
            //printing sequence: start by making one horizontal line of squares, from the top to bottom, then loop that sequence to create multiple other lines and adding verticality

            int rainbowModeIteration = 1; //get incremented everytime the rainbow mode need to switch to the next colour, to define which one to display
            int rainbowModeReset = 1; //reset rainbowModeIteration at every new line in vertical/diagonal mode, increment at each line during diagonal to change the starting colour

            for (int i = 0; i < squareAmmountWantedVertical; i++) //loop the horizontal square printing sequence to also print them vertically
            {
                if (rainbowModeEnabled == true & rainbowModeNumber == 1)
                {
                    switch (rainbowModeIteration)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            rainbowModeIteration = 0;
                            break;
                    }
                    rainbowModeIteration++;
                }
                if (rainbowModeNumber >= 2)
                {
                    rainbowModeIteration = rainbowModeReset;
                }
                for (int iOne = 0; iOne < squareAmmountWantedHorizontal; iOne++) //horizontally print the right amount of square tops
                {
                    if (rainbowModeEnabled == true & rainbowModeNumber >= 2)
                    {
                        switch (rainbowModeIteration)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                rainbowModeIteration = 0;
                                break;
                        }
                        rainbowModeIteration++;
                    }
                    Console.Write(" ╔" + squareHorizontalLine + "╗");
                }
                Console.WriteLine();
                for (int iOne = 0; iOne < squareInsideSizeVertical; iOne++) //loop the inside square printing sequences to vertically create the inside as well
                {
                    if (rainbowModeNumber >= 2)
                    {
                        rainbowModeIteration = rainbowModeReset;
                    }
                    for (int iTwo = 0; iTwo < squareAmmountWantedHorizontal; iTwo++) //horizontally print the right amount of square insides
                    {
                        if (rainbowModeEnabled == true & rainbowModeNumber >= 2)
                        {
                            switch (rainbowModeIteration)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case 6:
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    break;
                                case 7:
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    rainbowModeIteration = 0;
                                    break;
                            }
                            rainbowModeIteration++;
                        }
                        Console.Write(" ║" + squareHorizontalBlank + "║");
                    }
                    Console.WriteLine();
                }
                if (rainbowModeNumber >= 2)
                {
                    rainbowModeIteration = rainbowModeReset;
                }
                for (int iOne = 0; iOne < squareAmmountWantedHorizontal; iOne++) //horizontally print the right amount of square bottoms
                {
                    if (rainbowModeEnabled == true & rainbowModeNumber >= 2)
                    {
                        switch (rainbowModeIteration)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                rainbowModeIteration = 0;
                                break;
                        }
                        rainbowModeIteration++;
                    }
                    Console.Write(" ╚" + squareHorizontalLine + "╝");
                }
                if (rainbowModeNumber == 3)
                {
                    rainbowModeReset++;
                    if (rainbowModeReset == 8)
                    {
                        rainbowModeReset = 1;
                    }
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            //ask the user if he wish to print another square or not, if yes then go to the begining label, before asking all the initial questions

            Console.WriteLine();
            Console.Write(" Would you like to create another square grid? (Yes/No): ");
            savedCoordX = Console.CursorLeft;
            savedCoordY = Console.CursorTop;
            for(int i = 1; i == 1; i = 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string restartAnswer = Console.ReadLine(); //declare this as var to fix CS8600
                restartAnswer = restartAnswer.ToUpper();

                /* <-- replace the 2 lines above by this commentary to fix CS8602
                string restartAnswer = Console.ReadLine(); //declare this as var to fix CS8600
                if(restartAnswer != null)
                {
                    restartAnswer = restartAnswer.ToUpper();
                }
                */

                if (restartAnswer == "YES" ^ restartAnswer == "Y")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    goto SquarePrintingSequenceBegining;
                }
                else if (restartAnswer == "" & spamModeCheck >= 4)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int iOne = 0; iOne < 5; iOne++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.WriteLine("Spam mode successful");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto SquarePrintingSequenceBegining;
                }
                else if(restartAnswer == "NO" ^ restartAnswer == "N")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int iOne = 0; iOne < 5; iOne++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Value is incorrect");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    {

                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int iOne = 0; iOne < 5; iOne++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                }
            }

            //allow the user to enter specific special lines before closing the app, mostly for easter eggs or such

            string walterTriggerWord = "WALTER"; //allow to summon Walter and check how many times was he mentioned
            bool walterIsMentioned;
            int walterTriggerCount = 0;
            int glitchEffectCoordX = 1;
            int glitchEffectCoordY = 1;

            Console.Write(" Do you have anything else to say before ending this program? ");
            savedCoordX = Console.CursorLeft;
            savedCoordY = Console.CursorTop;
            for (int i = 1; i == 1; i = 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string additionalAnswer = Console.ReadLine(); //declare this as var to fix CS8600
                additionalAnswer = additionalAnswer.ToUpper();

                /* <-- replace the 2 lines above by this commentary to fix CS8602
                string additionalAnswer = Console.ReadLine(); //declare this as var to fix CS8600
                if(additionalAnswer != null)
                {
                    additionalAnswer = additionalAnswer.ToUpper();
                }
                */

                walterIsMentioned = additionalAnswer.Contains(walterTriggerWord); //check if Walter was summoned

                if (walterIsMentioned == true) //try to summon Walter after 3 attempts, glitch the buffer at each try
                {
                    walterTriggerCount++;
                    Console.ForegroundColor = ConsoleColor.Red;

                    for(int iOne = 1; iOne <= walterTriggerCount * (4 * ((savedCoordY / 40) +1)); iOne++) //repeat the glitch effects enough to evenly spread it no matter the text size already written
                    {
                        Random random = new Random(); //pick a random location in the already written area to glitch out
                        glitchEffectCoordX = random.Next(1, 110);
                        glitchEffectCoordY = random.Next(1, savedCoordY + 1);

                        Console.SetCursorPosition(glitchEffectCoordX, glitchEffectCoordY);
                        int glitchLength = random.Next(30, 81);
                        
                        for(int iTwo = 1; iTwo <= 2; iTwo++) //create 2 halves of a string of the randomly defined length made out of random glitched characters and write them two
                        {
                            string glitchBlock = ""; 
                            for(int iThree = 1; iThree <= glitchLength/2; iThree++)
                            {
                                int randomGlitchCharacter = random.Next(1, 10);
                                switch (randomGlitchCharacter)
                                {
                                    case 1:
                                        glitchBlock += "░";
                                        break;
                                    case 2:
                                        glitchBlock += "▒";
                                        break;
                                    case 3:
                                        glitchBlock += "▓";
                                        break;
                                    case 4:
                                        glitchBlock += "█";
                                        break;
                                    case 5:
                                        glitchBlock += "▀";
                                        break;
                                    case 6:
                                        glitchBlock += "▄";
                                        break;
                                    case 7:
                                        glitchBlock += "▌";
                                        break;
                                    case 8:
                                        glitchBlock += "▐";
                                        break;
                                    case 9:
                                        glitchBlock += "■";
                                        break;
                                }
                            }
                            Console.Write(glitchBlock);
                            Thread.Sleep(1);
                        }
                    }

                    if (walterTriggerCount == 2)
                    {
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        for (int iOne = 0; iOne < 5; iOne++)
                        {
                            Console.Write("                                                                                                    ");
                        }
                        Random random = new Random();
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" S                                ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ST                               ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ▒T █▄▌ ▒■  ▐                     ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" S░   ▄▌ ▓■▀▌      ▄░█▀▌          ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" STO                              ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" STOP                             ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" STOP T                           ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ■T▒▓ ▀H ▄█▐   ░▒                 ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" STO▓ TH█■   ░                    ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ▀▓▀▌■TH▒▓▓    █▄▄▐▒▀▄█■▓░        ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" STOP THI                         ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" STOP THIS                        ");
                        Thread.Sleep(random.Next(120, 171));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" S■▄▓ ░H█▄   ▌▓▀▀■  ▒▓            ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" STOP THIS                        ");
                        Thread.Sleep(random.Next(120, 171));
                    }

                    int savedWindowCoordX = Console.WindowLeft; //make the screen shake to accentuate the effect
                    int savedWindowCoordY = Console.WindowTop;
                    Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY + 5);
                    Console.WriteLine("");
                    Thread.Sleep(50);
                    Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY);
                    Console.WriteLine("");
                    Thread.Sleep(25);
                    Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY + 10);
                    Console.WriteLine("");
                    Thread.Sleep(100);
                    Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY + 7);
                    Console.WriteLine("");
                    Thread.Sleep(50);
                    Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY + 5);
                    Console.WriteLine("");
                    Thread.Sleep(50);
                    Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY);
                    Console.WriteLine("");
                }

                if (additionalAnswer == "NO" ^ additionalAnswer == "N")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else if (additionalAnswer == "YES" ^ additionalAnswer == "Y")
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Oh really now... What is it then?");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    {

                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int iOne = 0; iOne < 5; iOne++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);

                }
                else if (additionalAnswer == "I LOVE YOU")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("   0");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" / ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("0          ");
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Thread.Sleep(150);

                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("   0");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("/");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("/");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("/");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("0          ");
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Thread.Sleep(2000);

                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("   0");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" / ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("0          ");
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Thread.Sleep(50);

                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("   0 - 0          ");
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Thread.Sleep(2000);

                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("   > - <  ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\"B-... Baka!\"          ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("                           ");
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                }
                else
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int iOne = 0; iOne < 5; iOne++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Value is incorrect");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                    {

                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    for (int iOne = 0; iOne < 5; iOne++)
                    {
                        Console.Write("                                                                                                    ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                }
            }

            //conclude the program and propose to show an extra info tab, close the app upon enter being pressed

            Console.WriteLine("\n════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine(" Thanks you for using my application! I hope you liked it.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(" Press space ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("to open an information tab or ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("press any other key ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("to close the program.");

            savedCoordX = Console.CursorLeft;
            savedCoordY = Console.CursorTop;

        EndPrompt:

            if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine("\n════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine(" Square Printing Application (C) 2022 Alexledragon \n");

                Console.WriteLine(" » Can't decide on your square? «");
                Console.WriteLine(" Did you know that if you just press enter without giving any value when the console ask you how");
                Console.WriteLine(" many squares do you want or how big do you want them, it will randomly pick one for you?\n");

                Console.WriteLine(" » Spam it to the limit «");
                Console.WriteLine(" Also, if during the creation of your square you just keep pressing enter, it will enable spam mode.");
                Console.WriteLine(" This is not a bug, but a feature! It allow you to just spam enter to creater endlesses random squares.");
                Console.WriteLine(" Why not giving it a try?\n");

                Console.WriteLine(" » Codes have feelings too «");
                Console.WriteLine(" The life of a program must be quite lonely, all this time processing data, asking questions...");
                Console.WriteLine(" I wonder what would happen if someone was to tell it \"I love you\"...\n");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" Press space ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("to hide this information tab.");
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.WriteLine("");
                    for (int iOne = 0; iOne < 17; iOne++)
                    {
                        Console.WriteLine("                                                                                                                 ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    goto EndPrompt;
                } 
            }
        }
    }
}