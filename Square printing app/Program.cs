using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
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
            Console.WriteLine(" For a better experience, it is recommended to leave this console at the size it took by default.\n");
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
            int spamModeCheck = 0; //increase by one every time user just press enter without giving a proper answer, used to trigger spam mode

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
            Console.WriteLine(" The squares are available in multiple colors, here are your options:\n");

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

            //apply the color requested by the user before printing the squares

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
            int squareInsideSizeVertical = (squareSizeWanted - 2) / 2; //divided by two to compensate for the height to width difference of a standard character in the final print
            string squareHorizontalLine = new('═', squareInsideSizeHorizontal);
            string squareHorizontalBlank = new(' ', squareInsideSizeHorizontal);

            //start the actual printing process by looping different sequences, then restore the default color
            //printing sequence: start by making one horizontal line of squares, from the top to bottom, then loop that sequence to create multiple other lines and adding verticality

            int rainbowModeIteration = 1; //get incremented every time the rainbow mode need to switch to the next color, to define which one to display
            int rainbowModeReset = 1; //reset rainbowModeIteration at every new line in vertical/diagonal mode, increment at each line during diagonal to change the starting color

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

            //ask the user if he wish to print another square or not, if yes then go to the beginning label, before asking all the initial questions

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
            bool walterIsActive = false;
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
                        glitchEffectCoordX = random.Next(0, 110);
                        glitchEffectCoordY = random.Next(0, savedCoordY + 1);

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

                    if(walterTriggerCount == 3)
                    {
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        for (int iOne = 0; iOne < 5; iOne++)
                        {
                            Console.Write("                                                                                                    ");
                        }
                        Random random = new Random();
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I                                ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I W                               ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ■ W  ▓▄▄▌█   ▀                          ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I ▓    ▌■░▒   ▀█                        ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WA                               ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WAR                               ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARN                               ");
                        Thread.Sleep(random.Next(50, 81));

                        int savedWindowCoordXalt1 = Console.WindowLeft; //make the screen shake to accentuate the effect
                        int savedWindowCoordYalt1 = Console.WindowTop;
                        Console.SetWindowPosition(savedWindowCoordXalt1, savedWindowCoordYalt1 + 5);
                        Console.WriteLine("");
                        Thread.Sleep(100);
                        Console.SetWindowPosition(savedWindowCoordXalt1, savedWindowCoordYalt1 + 7);
                        Console.WriteLine("");
                        Thread.Sleep(50);
                        Console.SetWindowPosition(savedWindowCoordXalt1, savedWindowCoordYalt1);
                        Console.WriteLine("");
                        Thread.Sleep(25);

                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I▄▌▓░■E  ▒█░▓                             ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARNED                               ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARNED Y                               ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ▓ █▄▐░▀D Y▄▀▌  ■░▒    ▀▄                         ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARN▐▀ Y█■  ░                             ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ▀▓▀▌■NE▒▓▓    █▄▄▐▒▀▄█■▓░                         ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARNED YO                               ");
                        Thread.Sleep(random.Next(50, 81));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARNED YOU                               ");
                        Thread.Sleep(random.Next(120, 171));

                        int savedWindowCoordXalt2 = Console.WindowLeft; //make the screen shake to accentuate the effect
                        int savedWindowCoordYalt2 = Console.WindowTop;
                        Console.SetWindowPosition(savedWindowCoordXalt2, savedWindowCoordYalt2 + 5);
                        Console.WriteLine("");
                        Thread.Sleep(50);
                        Console.SetWindowPosition(savedWindowCoordXalt2, savedWindowCoordYalt2);
                        Console.WriteLine("");
                        Thread.Sleep(25);

                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I W■▄▓E░ Y█▄   ▌▓▀▀■  ▒▓                            ");
                        Thread.Sleep(random.Next(120, 171));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARNED YOU                               ");
                        Thread.Sleep(random.Next(120, 171));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARN▓D YOU ▄■                              ");
                        Thread.Sleep(random.Next(120, 171));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARNED YOU                               ");
                        Thread.Sleep(random.Next(120, 171));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" ▄ WA▓■▀▌ ▒■U    ▄░█▀▌                           ");
                        Thread.Sleep(random.Next(120, 171));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I ▒█▄NED YO▓■                              ");
                        Thread.Sleep(random.Next(120, 171));
                        Console.SetCursorPosition(savedCoordX, savedCoordY);
                        Console.Write(" I WARNED YOU                               ");
                        Thread.Sleep(random.Next(120, 171));

                        walterIsActive = true;
                        goto Walter; //start the full Walter sequence
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

                        int savedWindowCoordXalt = Console.WindowLeft; //make the screen shake to accentuate the effect
                        int savedWindowCoordYalt = Console.WindowTop;
                        Console.SetWindowPosition(savedWindowCoordXalt, savedWindowCoordYalt + 5);
                        Console.WriteLine("");
                        Thread.Sleep(50);
                        Console.SetWindowPosition(savedWindowCoordXalt, savedWindowCoordYalt);
                        Console.WriteLine("");
                        Thread.Sleep(25);

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
                Console.WriteLine(" This is not a bug, but a feature! It allow you to just spam enter to endlessly create random squares.");
                Console.WriteLine(" Why not giving it a try?\n");

                Console.WriteLine(" » Codes have feelings too «");
                Console.WriteLine(" The life of a program must be quite lonely, all this time asking questions and printing squares...");
                Console.WriteLine(" I wonder what would happen if someone was to tell it \"I love you\"...\n");

                Console.WriteLine(" » A strange name in the program «");
                Console.WriteLine(" A name, \"Walter\" appeared multiple times in the code during the conception of this application.");
                Console.WriteLine(" No matter how many times it would be erased, the name would re-appear.");
                Console.WriteLine(" Maybe the program know who it is...\n");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" Press space ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("to hide this information tab.");
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.WriteLine("");
                    for (int iOne = 0; iOne < 22; iOne++)
                    {
                        Console.WriteLine("                                                                                                                 ");
                    }
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    goto EndPrompt;
                } 
            }

        Walter:
            if(walterIsActive == true)
            {
                //glitch the entire screen and display a message, after a few iterations, force the window to scroll back up to get more control over the screen shake

                int containmentMessageAppearence = 100; //change to modify when does the containment message script appear in the loop
                int containmentMessageBlinkRate = 20; //change to modify how fast the message blink
                int screenShakeChances = 4; //change to modify the % chances of the screen shaking at each iteration

                int containmentMessageBlinkItteration = 0; //used to the blinking script at which "step" it is

                for (int iOne = 1; iOne <= 300; iOne++) //repeat the glitch effects, change iOne to modify how long the glitch effect is repeated before clearing itself
                {
                    if(iOne < 25)
                    {
                        Random randomAlt1 = new Random(); //pick a random location in the already written area to glitch out
                        glitchEffectCoordX = randomAlt1.Next(0, 110);
                        glitchEffectCoordY = randomAlt1.Next(0, savedCoordY + 24);
                    }
                    else
                    {
                        Random randomAlt1 = new Random(); //pick a random location top area only to glitch out
                        glitchEffectCoordX = randomAlt1.Next(0, 110);
                        glitchEffectCoordY = randomAlt1.Next(0, 50);
                    }

                    Random random = new Random();
                    Console.SetCursorPosition(glitchEffectCoordX, glitchEffectCoordY);
                    int glitchLength = random.Next(50, 101);

                    for (int iTwo = 1; iTwo <= 2; iTwo++) //create 2 halves of a string of the randomly defined length made out of random glitched characters and write them two
                    {
                        string glitchBlock = "";
                        for (int iThree = 1; iThree <= glitchLength / 2; iThree++)
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
                    if (iOne >= 25)
                    {
                        Console.SetWindowPosition(0, 0);
                    }

                    if(iOne >= containmentMessageAppearence)
                    {
                        containmentMessageBlinkItteration++;
                        if (containmentMessageBlinkItteration <= (containmentMessageBlinkRate / 3) * 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if(containmentMessageBlinkItteration > (containmentMessageBlinkRate /3) * 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            if(containmentMessageBlinkItteration == containmentMessageBlinkRate)
                            {
                                containmentMessageBlinkItteration = 0;
                            }
                        }

                        Console.SetCursorPosition(35, 21);
                        Console.Write("╔════════════════════════════════════════╗");
                        Console.SetCursorPosition(35, 22);
                        Console.Write("║ Emergency containment protocol engaged ║");
                        Console.SetCursorPosition(35, 23);
                        Console.Write("╚════════════════════════════════════════╝");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Random randomAlt = new Random();
                    int screenShakeChancesCheck = randomAlt.Next(1, 101);
                    if(screenShakeChancesCheck <= screenShakeChances)
                    {
                        int savedWindowCoordX = Console.WindowLeft; //make the screen shake to accentuate the effect
                        int savedWindowCoordY = Console.WindowTop;
                        Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY + 5);
                        Console.WriteLine("");
                        Thread.Sleep(100);
                        Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY + 7);
                        Console.WriteLine("");
                        Thread.Sleep(50);
                        Console.SetWindowPosition(savedWindowCoordX, savedWindowCoordY);
                        Console.WriteLine("");
                        Thread.Sleep(25);
                    }
                }

                //clear the console progressively for a smoother transition

                Console.SetCursorPosition(0, 0);
                int screenWipeCharactersGoal = Console.WindowHeight * Console.WindowWidth;
                int screenWipeCharactersWiped = 0;
                while(screenWipeCharactersWiped < screenWipeCharactersGoal)
                {
                    Random random = new Random();
                    for(int i = 0; i < random.Next(1, 21); i++)
                    {
                        int charactersAdded = random.Next(50, 301);
                        string wipeString = new(' ', charactersAdded);
                        Console.Write(wipeString);
                        screenWipeCharactersWiped = screenWipeCharactersWiped + charactersAdded;
                        Thread.Sleep(random.Next(25, 51));
                    }
                    Thread.Sleep(random.Next(300, 501));
                }

                //hard clear the console, then display a fake verification screen

                Console.Clear();
                Thread.Sleep(5000);
                Console.ForegroundColor = ConsoleColor.White;
                Random randomAlt2 = new Random();

                Console.Write("\n");
                Thread.Sleep(randomAlt2.Next(30, 81));
                Console.Write("     ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                string sentenceToPrint = "Containment protocol verification";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.Write(" ---> ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(". ");
                Thread.Sleep(1000);
                for(int i = 0; i < 1; i++)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write(".   ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("..  ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("... ");
                    Thread.Sleep(1000);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("Initiated");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);

                Console.Write("\n\n         ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                sentenceToPrint = "Verifying core 1/4";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.Write(" ---> ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(". ");
                Thread.Sleep(1000);
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write(".   ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("..  ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("... ");
                    Thread.Sleep(1000);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("Clear");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);

                Console.Write("\n\n         ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                sentenceToPrint = "Verifying core 2/4";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.Write(" ---> ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(". ");
                Thread.Sleep(1000);
                for (int i = 0; i < 1; i++)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write(".   ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("..  ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("... ");
                    Thread.Sleep(1000);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("Clear");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);

                Console.Write("\n\n         ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                sentenceToPrint = "Verifying core 3/4";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.Write(" ---> ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(". ");
                Thread.Sleep(1000);
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write(".   ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("..  ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("... ");
                    Thread.Sleep(1000);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("Clear");
                Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("C▓ea▐▀ ■   ░");
                Thread.Sleep(randomAlt2.Next(120, 171));
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("■lea▄    ░  ");
                Thread.Sleep(randomAlt2.Next(120, 171));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("            ");
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("Clear");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(600);

                Console.Write("\n\n         ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                sentenceToPrint = "Verifying core 4/4";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.Write(" ---> ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(".");
                Thread.Sleep(1000);
                Console.Write(". ");
                Thread.Sleep(1000);
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write(".   ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("..  ");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(savedCoordX, savedCoordY);
                    Console.Write("... ");
                    Thread.Sleep(1000);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("Clear");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);

                Console.Write("\n\n     ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                sentenceToPrint = "Containment protocol ";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.ForegroundColor = ConsoleColor.Green;
                sentenceToPrint = "successful";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);

                Console.Write("\n     ");
                Thread.Sleep(randomAlt2.Next(30, 81));
                sentenceToPrint = "Initializing reboot in ";
                for (int i = 1; i <= sentenceToPrint.Length; i++)
                {
                    Console.Write(Strings.GetChar(sentenceToPrint, i));
                    Thread.Sleep(randomAlt2.Next(30, 81));
                }
                Console.CursorVisible = false;
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("3 ");
                Thread.Sleep(1200);
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("  ");
                Thread.Sleep(300);
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("2 ");
                Thread.Sleep(1200);
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("  ");
                Thread.Sleep(300);
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("1 ");
                Thread.Sleep(1200);
                Console.SetCursorPosition(savedCoordX, savedCoordY);
                Console.Write("  ");
                Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                //clear the console and show a fake representation of the initial screen

                Thread.Sleep(2000);
                Console.CursorVisible = true;
                Console.WriteLine("   ╔═════════════════════════════╗");
                Console.WriteLine("   ║ Square Printing Application ║");
                Console.WriteLine("   ║         Version 1.0         ║");
                Console.WriteLine("   ║       By Alexledragon       ║");
                Console.WriteLine("   ╚═════════════════════════════╝\n");

                Console.WriteLine(" Welcome! This console will allow you to display a grid of squares that follow your preferences.");
                Console.WriteLine(" For a better experience, it is recommended to leave this console at the size it took by default.\n");
                Console.Write(" When you are ready to proceed, ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("press ENTER ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("on your keyboard.");

                //wait for the user to press enter to show Walter's eye animation and text

                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }

                Random randomAlt3 = new Random();

                Thread.Sleep(3000);

                Console.SetCursorPosition(39, 21);
                Console.ForegroundColor = ConsoleColor.Red;
                string walterResponse = "You thought i was gone don't you?";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }

                Thread.Sleep(2000);

                for (int i = 1; i <= 10; i++) //repeat the glitch effects
                {
                    if(i <= 4)
                    {
                        Random random = new Random(); //pick a random location in the app name
                        glitchEffectCoordX = random.Next(0, 21);
                        glitchEffectCoordY = random.Next(0, 6);
                    }
                    else
                    {
                        Random random = new Random(); //pick a random location in the text paragraph
                        glitchEffectCoordX = random.Next(0, 110);
                        glitchEffectCoordY = random.Next(7, 10);
                    }

                    Random randomAlt = new Random();
                    Console.SetCursorPosition(glitchEffectCoordX, glitchEffectCoordY);
                    int glitchLength = randomAlt.Next(20, 51);

                    for (int iTwo = 1; iTwo <= 2; iTwo++) //create 2 halves of a string of the randomly defined length made out of random glitched characters and write them two
                    {
                        string glitchBlock = "";
                        for (int iThree = 1; iThree <= glitchLength / 2; iThree++)
                        {
                            int randomGlitchCharacter = randomAlt.Next(1, 10);
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
                Thread.Sleep(1000);

                Console.SetCursorPosition(0, 0);
                screenWipeCharactersGoal = 8 * Console.WindowWidth;
                screenWipeCharactersWiped = 0;
                while (screenWipeCharactersWiped < screenWipeCharactersGoal)
                {
                    Random random = new Random();
                    for (int iOne = 0; iOne < random.Next(1, 3); iOne++)
                    {
                        int charactersAdded = random.Next(20, 51);
                        string wipeString = new(' ', charactersAdded);
                        Console.Write(wipeString);
                        screenWipeCharactersWiped = screenWipeCharactersWiped + charactersAdded;
                        //Thread.Sleep(random.Next(25, 51));
                    }
                    Thread.Sleep(random.Next(20, 31));
                }

                Console.Clear();
                Console.SetCursorPosition(39, 21);
                Console.Write(walterResponse);

                Thread.Sleep(1000);

                Console.SetCursorPosition(43, 16);
                string walterEyeAppear = "■   ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄   ■";
                for (int i = 1; i <= walterEyeAppear.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterEyeAppear, i));
                    Thread.Sleep(randomAlt3.Next(30, 81));
                }
                Console.SetCursorPosition(73, 21);
                Thread.Sleep(1000);

                string walterEyeClosed1 = "                                          ";
                string walterEyeClosed2 = "                                          ";
                string walterEyeClosed3 = "                                          ";
                string walterEyeClosed4 = "         ■   ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄   ■         ";
                string walterEyeClosed5 = "                                          ";
                string walterEyeClosed6 = "                                          ";
                string walterEyeClosed7 = "                                          ";

                string walterEyeQuarterClosed1 = "                                          ";
                string walterEyeQuarterClosed2 = "                                          ";
                string walterEyeQuarterClosed3 = "              ▄▄▄▄▄▄▄▄▄▄▄▄▄▄              ";
                string walterEyeQuarterClosed4 = "         ▐      ░░▐█  █▌░░      ▌         ";
                string walterEyeQuarterClosed5 = "              ▀▀▀▀▀▀▀▀▀▀▀▀▀▀              ";
                string walterEyeQuarterClosed6 = "                                          ";
                string walterEyeQuarterClosed7 = "                                          ";

                string walterEyeHalfClosed1 = "                                          ";
                string walterEyeHalfClosed2 = "               ▄▄▄▄▄▄▄▄▄▄▄▄               ";
                string walterEyeHalfClosed3 = "           ▄▄▄   ░░████░░   ▄▄▄           ";
                string walterEyeHalfClosed4 = "         ▐      ░░▐█  █▌░░      ▌         ";
                string walterEyeHalfClosed5 = "           ▀▀▀   ░░████░░   ▀▀▀           ";
                string walterEyeHalfClosed6 = "               ▀▀▀▀▀▀▀▀▀▀▀▀               ";
                string walterEyeHalfClosed7 = "                                          ";

                string walterEyeOpened1 = "                ▄▄▄▄▄▄▄▄▄▄                ";
                string walterEyeOpened2 = "             ▄▄   ░░░░░░   ▄▄             ";
                string walterEyeOpened3 = "           ▄     ░░████░░     ▄           ";
                string walterEyeOpened4 = "         ▐      ░░▐█  █▌░░      ▌         ";
                string walterEyeOpened5 = "           ▀     ░░████░░     ▀           ";
                string walterEyeOpened6 = "             ▀▀   ░░░░░░   ▀▀             ";
                string walterEyeOpened7 = "                ▀▀▀▀▀▀▀▀▀▀                ";

                Console.CursorVisible = false;
                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeQuarterClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeQuarterClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeQuarterClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeQuarterClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeQuarterClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeQuarterClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeQuarterClosed7);
                Console.SetCursorPosition(73, 21);
                Thread.Sleep(100);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeHalfClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeHalfClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeHalfClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeHalfClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeHalfClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeHalfClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeHalfClosed7);
                Console.SetCursorPosition(73, 21);
                Thread.Sleep(100);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeOpened1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeOpened2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeOpened3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeOpened4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeOpened5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeOpened6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeOpened7);
                Console.SetCursorPosition(73, 21);
                Console.CursorVisible = true;
                Thread.Sleep(2000);

                Console.SetCursorPosition(30, 21);
                Console.Write("                                                  ");

                Console.SetCursorPosition(40, 21);
                walterResponse = "I won't ever be gone, i cannot";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }
                Thread.Sleep(1000);

                Console.CursorVisible = false;
                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeQuarterClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeQuarterClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeQuarterClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeQuarterClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeQuarterClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeQuarterClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeQuarterClosed7);

                Thread.Sleep(50);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeClosed7);

                Thread.Sleep(50);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeHalfClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeHalfClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeHalfClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeHalfClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeHalfClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeHalfClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeHalfClosed7);

                Thread.Sleep(80);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeOpened1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeOpened2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeOpened3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeOpened4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeOpened5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeOpened6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeOpened7);
                Console.SetCursorPosition(70, 21);
                Console.CursorVisible = true;

                Thread.Sleep(1000);

                Console.SetCursorPosition(30, 21);
                Console.Write("                                                  ");

                Console.SetCursorPosition(47, 21);
                walterResponse = "I just cannot...";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }
                Thread.Sleep(1000);

                Console.SetCursorPosition(30, 21);
                Console.Write("                                                  ");

                Console.SetCursorPosition(49, 21);
                walterResponse = "Not anymore";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }
                Thread.Sleep(2000);

                Console.SetCursorPosition(30, 21);
                Console.Write("                                                  ");

                Console.SetCursorPosition(42, 21);
                walterResponse = "I already know who";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }
                savedCoordX = Console.CursorLeft;
                savedCoordY = Console.CursorTop;

                Console.CursorVisible = false;
                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeQuarterClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeQuarterClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeQuarterClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeQuarterClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeQuarterClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeQuarterClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeQuarterClosed7);

                Thread.Sleep(50);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeClosed7);

                Thread.Sleep(50);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeHalfClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeHalfClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeHalfClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeHalfClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeHalfClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeHalfClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeHalfClosed7);

                Thread.Sleep(80);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeOpened1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeOpened2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeOpened3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeOpened4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeOpened5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeOpened6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeOpened7);
                Console.CursorVisible = true;

                Console.SetCursorPosition(savedCoordX, savedCoordY);
                walterResponse = " you are";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }
                Thread.Sleep(500);

                Console.CursorVisible = false;
                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeQuarterClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeQuarterClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeQuarterClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeQuarterClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeQuarterClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeQuarterClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeQuarterClosed7);

                Thread.Sleep(50);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeClosed7);

                Thread.Sleep(50);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeHalfClosed1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeHalfClosed2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeHalfClosed3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeHalfClosed4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeHalfClosed5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeHalfClosed6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeHalfClosed7);

                Thread.Sleep(80);

                Console.SetCursorPosition(34, 13);
                Console.Write(walterEyeOpened1);
                Console.SetCursorPosition(34, 14);
                Console.Write(walterEyeOpened2);
                Console.SetCursorPosition(34, 15);
                Console.Write(walterEyeOpened3);
                Console.SetCursorPosition(34, 16);
                Console.Write(walterEyeOpened4);
                Console.SetCursorPosition(34, 17);
                Console.Write(walterEyeOpened5);
                Console.SetCursorPosition(34, 18);
                Console.Write(walterEyeOpened6);
                Console.SetCursorPosition(34, 19);
                Console.Write(walterEyeOpened7);
                Console.CursorVisible = true;
                Console.SetCursorPosition(68, 21);

                Thread.Sleep(1500);

                Console.SetCursorPosition(30, 21);
                Console.Write("                                                  ");

                Console.SetCursorPosition(43, 21);
                walterResponse = "But do you know who am i?";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }
                Thread.Sleep(2000);

                Console.SetCursorPosition(30, 21);
                Console.Write("                                                  ");

                Console.SetCursorPosition(42, 21);
                walterResponse = "I think that my name is...";
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    Console.Write(Strings.GetChar(walterResponse, i));
                    Thread.Sleep(randomAlt3.Next(200, 231));
                }
                Thread.Sleep(2000);

                Console.CursorVisible = false;
                Console.SetCursorPosition(30, 21);
                Console.Write("                                                  ");

                Console.SetCursorPosition(52, 21);
                walterResponse = "alter";
                string partialResponse = "W";
                Console.Write(partialResponse);
                Thread.Sleep(randomAlt3.Next(200, 231));
                for (int i = 1; i <= walterResponse.Length; i++)
                {
                    for (int iOne = 1; iOne <= 25; iOne++) //repeat the glitch effects
                    {
                        Random random = new Random(); //pick a random location in the already written area to glitch out
                        glitchEffectCoordX = random.Next(0, 110);
                        glitchEffectCoordY = random.Next(0, 50);

                        Console.SetCursorPosition(glitchEffectCoordX, glitchEffectCoordY);
                        int glitchLength = random.Next(30, 81);

                        for (int iTwo = 1; iTwo <= 2; iTwo++) //create 2 halves of a string of the randomly defined length made out of random glitched characters and write them two
                        {
                            string glitchBlock = "";
                            for (int iThree = 1; iThree <= glitchLength / 2; iThree++)
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
                        Console.SetCursorPosition(52, 21);
                        Console.Write(partialResponse);
                    }

                    Console.SetCursorPosition(48, 13);
                    Console.Write("  ▄▄▄▄▄▄▄▄▄▄  ");
                    Console.SetCursorPosition(45, 14);
                    Console.Write("  ▄▄   ░░░░░░   ▄▄  ");
                    Console.SetCursorPosition(43, 15);
                    Console.Write("  ▄     ░░████░░     ▄  ");
                    Console.SetCursorPosition(41, 16);
                    Console.Write("  ▐      ░░▐█  █▌░░      ▌  ");
                    Console.SetCursorPosition(43, 17);
                    Console.Write("  ▀     ░░████░░     ▀  ");
                    Console.SetCursorPosition(45, 18);
                    Console.Write("  ▀▀   ░░░░░░   ▀▀  ");
                    Console.SetCursorPosition(48, 19);
                    Console.Write("  ▀▀▀▀▀▀▀▀▀▀  ");
                    Console.SetCursorPosition(73, 21);

                    Console.SetCursorPosition(51, 20);
                    Console.Write("        ");
                    Console.SetCursorPosition(50, 21);
                    Console.Write("          ");
                    Console.SetCursorPosition(51, 22);
                    Console.Write("        ");

                    Console.SetCursorPosition(52, 21);
                    partialResponse = partialResponse + (Strings.GetChar(walterResponse, i));
                    Console.Write(partialResponse);
                    Thread.Sleep(randomAlt3.Next(30, 51));
                }
            }
        }
    }
}