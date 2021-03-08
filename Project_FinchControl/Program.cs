using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinchAPI;


namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - S1-S5
    // Description: This is an application for the Finch robot to show off its crazy talents
    // Application Type: Console
    // Author: Pearl, Natham
    // Dated Created: 2/16/2021
    // Last Modified: 2/29/2021
    //
    // **************************************************


    /// <summary>
    /// User Commandds
    /// </summary>
    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }


    class Program
    {




        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>

        static void Main (string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }


   


        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();
            do
            {
                DisplayScreenHeader("Main Screen");
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DisplayDataRecorderMenu(finchRobot);
                        break;

                    case "d":
                        
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        /// 


        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mix it up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }




        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            //
            // variables
            //
            int redColor;
            int greenColor;
            int blueColor;
            int soundLevel;
            string userResponse;
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");
            Console.WriteLine("Pick values for colors");
            Console.WriteLine("Red 0-255 for the first number");
            userResponse = Console.ReadLine();
            redColor = int.Parse(userResponse);
            Console.WriteLine("Pick a number value for Green 0-255");
            userResponse = Console.ReadLine();
            greenColor = int.Parse(userResponse);

            Console.WriteLine("Pick a number value for Blue 0-255");
            userResponse = Console.ReadLine();
            blueColor = int.Parse(userResponse);

            Console.WriteLine("Pick a number between 1-255 for the beep volume");
            userResponse = Console.ReadLine();
            soundLevel = int.Parse(userResponse);



            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 14; lightSoundLevel++)
            {
                finchRobot.wait(1000);
                finchRobot.setLED(redColor, 0, 0);
                finchRobot.noteOn(soundLevel);
                finchRobot.wait(500);
                finchRobot.setLED(0, greenColor, blueColor);
                finchRobot.wait(100);
                finchRobot.noteOff();
                finchRobot.setLED(redColor, 0, blueColor);

            }

            DisplayMenuPrompt("Talent Show Menu");
        }



        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance/ movement                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayDance(Finch finchRobot)
        {
            //
            // variables
            //
            int wheelRotations;
            int times;
            string userResponse;
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("Plese enter a number between 90-255 to see my skills");
            userResponse = Console.ReadLine();
            wheelRotations = int.Parse(userResponse);

            Console.WriteLine("How many times whould you like my talent to be shown.");
            Console.WriteLine("pick a vaule between 1-5");
            userResponse = Console.ReadLine();
            times = int.Parse(userResponse);


            Console.WriteLine("\tThe Finch robot will not show off its glorious talents!");
            DisplayContinuePrompt();

            for (int movementLevel = 0; movementLevel < times; movementLevel++)
            {
                finchRobot.wait(200);
                finchRobot.setMotors(90, 0);
                finchRobot.wait(1000);
                finchRobot.setMotors(wheelRotations, wheelRotations);
                finchRobot.wait(1000);
                finchRobot.setMotors(90, 0);
                finchRobot.wait(1000);
                finchRobot.setMotors(wheelRotations, wheelRotations);
                finchRobot.wait(1000);
                finchRobot.setMotors(90, 0);
                finchRobot.wait(1000);
                finchRobot.setMotors(wheelRotations, wheelRotations);
                finchRobot.wait(1000);
                finchRobot.setMotors(90, 0);
                finchRobot.wait(1000);
                finchRobot.setMotors(wheelRotations, wheelRotations);
                finchRobot.wait(1000);
                finchRobot.setMotors(0, 0);

            }


            DisplayMenuPrompt("Talent Show Menu");
        }



        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing It Up                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mix it Up");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 3; lightSoundLevel++)
            {
                finchRobot.setLED(0, 189, 189);
                finchRobot.noteOn(100);
                finchRobot.wait(1000);
                finchRobot.noteOn(130);
                finchRobot.wait(500);
                finchRobot.noteOn(100);
                finchRobot.wait(500);
                finchRobot.noteOn(160);
                finchRobot.wait(500);
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(140);
                finchRobot.wait(500);
                finchRobot.noteOn(100);
                finchRobot.wait(500);
                finchRobot.noteOn(100);
                finchRobot.wait(500);
                finchRobot.noteOn(130);
                finchRobot.wait(500);
                finchRobot.noteOn(100);
                finchRobot.wait(500);
                finchRobot.noteOn(175);
                finchRobot.wait(500);
                finchRobot.noteOn(160);
                finchRobot.wait(500);
                finchRobot.noteOn(100);
                finchRobot.wait(500);
                finchRobot.noteOn(110);
                finchRobot.wait(500);
                finchRobot.noteOn(210);
                finchRobot.wait(500);
                finchRobot.noteOn(190);
                finchRobot.wait(500);
                finchRobot.noteOn(160);
                finchRobot.wait(500);
                finchRobot.noteOn(140);
                finchRobot.wait(500);
                finchRobot.noteOn(130);
                finchRobot.wait(500);
                finchRobot.noteOn(210);
                finchRobot.wait(250);
                finchRobot.noteOn(210);
                finchRobot.wait(250);
                finchRobot.noteOn(190);
                finchRobot.wait(500);
                finchRobot.noteOn(160);
                finchRobot.wait(500);
                finchRobot.noteOn(175);
                finchRobot.wait(500);
                finchRobot.noteOn(160);
                finchRobot.wait(500);
                finchRobot.setMotors(250, 0);
                finchRobot.wait(1000);
                finchRobot.noteOff();
                finchRobot.setLED(0, 0, 0);
                finchRobot.setMotors(0, 0);


            }

            DisplayMenuPrompt("Talent Show Menu");
        }


        #endregion




        #region Data Recorder

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                        *
        /// *****************************************************************
        /// </summary>
        /// 


        static void DisplayDataRecorderMenu(Finch myfinch)
        {
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;


            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGEtDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, myfinch);
                        break;

                    case "d":
                        DataRecorderDisplayShowData(temperatures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);
        }

        /// <summary>
        /// Show off the dat the finch has gathered
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayShowData(double[] temperatures)
        {
            DisplayScreenHeader("show Data");
            // table headers
            Console.WriteLine(
                    "recording #".PadLeft(20) +
                    "Temp".PadLeft(20)
                    );
            Console.WriteLine(
                   "___________".PadLeft(20) +
                   "____".PadLeft(20)
                   );

            //Display table Data
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                  (index + 1).ToString().PadLeft(20) +
                   temperatures[index].ToString("n2").PadLeft(20)
                  );

            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// use the values that the user has given the program as well as the finch to give the vales of temp and place them in a graph.
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayTable(double[] temperatures)
        {
            // table headers
            Console.WriteLine(
                    "recording #".PadLeft(20) +
                    "Temp".PadLeft(20)
                    );
            Console.WriteLine(
                   "___________".PadLeft(20) +
                   "____".PadLeft(20)
                   );

            //Display table Data
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                  (index + 1).ToString().PadLeft(20) +
                   temperatures[index].ToString("n2").PadLeft(20)
                  );

            }

        }

        /// <summary>
        /// useing the user respose to collect data fromt the finch robot on the user comandes
        /// </summary>
        /// <returns>Display Get data</returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch myfinch)
        {

            double[] temperatures = new double[numberOfDataPoints];


            DisplayScreenHeader("Get Data");

            Console.WriteLine($"  \tNumber of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"  \tData Point Frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("I am ready to start recording you information. I mean temperatures.");
            Console.WriteLine("Yes that is my job to record temperatures.");
            DisplayContinuePrompt();
            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = myfinch.getTemperature() * 9 / 5 + 32;
                Console.WriteLine($"\tReading{index + 1}: {temperatures[index].ToString("n2")}");
                int waitInSecounds = (int)(dataPointFrequency * 1000);
                myfinch.wait(waitInSecounds);
            }


            Console.WriteLine();
            Console.WriteLine("\tTable of Temperatures");
            Console.WriteLine();
            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();

            return temperatures;
        }




        /// <summary>
        /// get the frequency of data points from the user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGEtDataPointFrequency()
        {
            double dataPointFrequency;
            bool validResponse;

            DisplayScreenHeader("Data point Frequency");
            Console.WriteLine("Hi again what Frequency would you like this Project to be at.");
            Console.WriteLine("Please enter a numerical Value Here:");


            // validate user imput
            //
            //
            do
            {
                validResponse = double.TryParse(Console.ReadLine(), out dataPointFrequency);
                Console.WriteLine($"Did you say {dataPointFrequency}. Yes or No");
                Console.ReadLine();
                if (!validResponse)
                {
                    Console.WriteLine("Please Put in an interger:");
                    DisplayContinuePrompt();
                }
            } while (validResponse);

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// get the data points and display them as needed
        /// </summary>
        /// <returns>Display Data points</returns>
        static int DataRecorderDisplayNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;
            bool validResponse;
            do
            {
                DisplayScreenHeader("Number of Data Points");
                Console.WriteLine("Hello How many data points would you like to use for this Project.");
                userResponse = Console.ReadLine();

                // validate user imput
                validResponse = int.TryParse(userResponse, out numberOfDataPoints);
                Console.WriteLine($"Total Number of Data Points: {numberOfDataPoints}");
                if (!validResponse)
                {
                    Console.WriteLine("Please Put in an interger:");
                    DisplayContinuePrompt();
                }
            } while (validResponse);

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }



        #endregion



        #region User Programming

        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            /// <summary>
            /// *****************************************************************
            /// *                User Programming Menu                          *
            /// *****************************************************************
            /// </summary>
            /// 
            {
                Console.CursorVisible = true;

                bool quitUserProgrammingMenu = false;
                string menuChoice;

                (int motorSpeed, int ledBrightness, double waitSecounds) comandParameters;
                comandParameters.motorSpeed = 0;
                comandParameters.ledBrightness = 0;
                comandParameters.waitSecounds = 0;
                List<Command> commands = new List<Command>();

                do
                {
                    DisplayScreenHeader("User Programming Menu");

                    //
                    // get user menu choice
                    //
                    Console.WriteLine("\ta) Set Command Parameters");
                    Console.WriteLine("\tb) Add Commands");
                    Console.WriteLine("\tc) View Comands");
                    Console.WriteLine("\td) Execute Commands");
                    Console.WriteLine("\tq) Main Menu");
                    Console.Write("\t\tEnter Choice:");
                    menuChoice = Console.ReadLine().ToLower();

                    //
                    // process user menu choice
                    //
                    switch (menuChoice)
                    {
                        case "a":
                            comandParameters = UserProgrammingDisplayGetCommandParameters();
                            break;

                        case "b":
                            UserProgrammingDisplayGetFinchCommands(commands);
                            break;

                        case "c":
                            UserProgrammingDisplayFinchCommands(commands);
                            break;

                        case "d":
                            UserProgrammingDisplayExecuteFinchCommands(finchRobot, commands, comandParameters);
                            break;

                        case "q":
                            quitUserProgrammingMenu = true;
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("\tPlease enter a letter for the menu choice.");
                            DisplayContinuePrompt();
                            break;
                    }

                } while (!quitUserProgrammingMenu);

            }


        }
        static (int motorSpeed, int ledBrightness, double waitSecounds) UserProgrammingDisplayGetCommandParameters()
        {
            DisplayScreenHeader("Cammand Parameters");
            (int motorSpeed, int ledBrightness, double waitSecounds) comandParameters;
            comandParameters.motorSpeed = 0;
            comandParameters.ledBrightness = 0;
            comandParameters.waitSecounds = 0;
            bool validinteger;
            bool validDouble;
            // need a for loop for the next three things
            Console.WriteLine("\tEnter Motor Speed [ 1 - 255]:");
            validinteger = int.TryParse(Console.ReadLine(), out comandParameters.motorSpeed);
            if (!validinteger)
            {
                Console.WriteLine("Please Put in an interger between [1 - 255]:");
                DisplayContinuePrompt();
            }

            Console.WriteLine("\tEnter Led Brightness [1 - 255]:");
            validinteger = int.TryParse(Console.ReadLine(), out comandParameters.ledBrightness);
            if (!validinteger)
            {
                Console.WriteLine("Please Put in an interger between [1 - 255]:");
                DisplayContinuePrompt();
            }
            Console.WriteLine("\tEnter Wait in Seconds:");
            validDouble = double.TryParse(Console.ReadLine(), out comandParameters.waitSecounds);
            if (!validDouble)
            {
                Console.WriteLine("Please Put in an interger between [1 - 255]:");
                DisplayContinuePrompt();
            }

            Console.WriteLine($"\t Motor Speed: {comandParameters.motorSpeed}");
            Console.WriteLine($"\t LED Brightness: {comandParameters.ledBrightness}");
            Console.WriteLine($"\t Wait Command Duration: {comandParameters.waitSecounds}");

            DisplayMenuPrompt("User Programming");

            return comandParameters;

        }
        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;
            DisplayScreenHeader("Finch Robot Commands");

            int commandCount = 1;
            Console.WriteLine("\tList Of Available COmmands");
            Console.WriteLine("\t");
            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.WriteLine($". {commandName.ToLower()}  .");

                if (commandCount % 5 == 0) Console.WriteLine(".\n\t.");
                commandCount++;
            }
            while (command != Command.DONE)
            {
                Console.WriteLine("\tEnter Command:");
                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\t\t*******************************************");
                    Console.WriteLine("\t\tPLease enter a command from the list above");
                    Console.WriteLine("\t\t*******************************************");
                }

            }

            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");
            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
                Console.WriteLine();
            }
            DisplayMenuPrompt("USer Programming");
        }

        static void UserProgrammingDisplayExecuteFinchCommands(Finch finchRobot,
            List<Command> commands,
            (int motorSpeed, int ledBrightness, double waitSecounds) comandParameters)
        {
            int motorSpeed = comandParameters.motorSpeed;
            int ledBrightness = comandParameters.ledBrightness;
            int waitMilliSecounds = (int) comandParameters.waitSecounds * 100;
            string CommandFeedback = "";
            const int TURNING_MOTO_SPEED = 100;
            
            DisplayScreenHeader("Executing Finch Commands:");
            Console.WriteLine("\tI'm Ready To Start Executing The List Commands:");
            DisplayContinuePrompt();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;
                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        CommandFeedback = Command.MOVEFORWARD.ToString();
                        ; break;
                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        CommandFeedback = Command.MOVEBACKWARD.ToString();
                        ; break;
                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        CommandFeedback = Command.STOPMOTORS.ToString();
                        ; break;
                    case Command.WAIT:
                        finchRobot.wait(waitMilliSecounds);
                        CommandFeedback = Command.WAIT.ToString();
                        ; break;
                    case Command.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTO_SPEED, -TURNING_MOTO_SPEED);
                        CommandFeedback = Command.TURNRIGHT.ToString();
                        ; break;
                    case Command.TURNLEFT:
                        finchRobot.setMotors(-TURNING_MOTO_SPEED, TURNING_MOTO_SPEED);
                        CommandFeedback = Command.TURNLEFT.ToString();
                        ; break;
                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        CommandFeedback = Command.LEDOFF.ToString();
                        ; break;
                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        finchRobot.wait(1000);
                        finchRobot.setLED(ledBrightness, 0, ledBrightness);
                        finchRobot.wait(1000);
                        finchRobot.setLED(ledBrightness - 10, ledBrightness + 30, ledBrightness - 10);
                        CommandFeedback = Command.LEDON.ToString();
                        ; break;
                    case Command.GETTEMPERATURE:
                        CommandFeedback = $"Temperature Of Lights Currently: {finchRobot.getTemperature().ToString("n2")}\n";
                        ; break;
                    case Command.DONE:
                        CommandFeedback = Command.DONE.ToString();
                        ; break;

                    default:

                        ; break;
                }
                Console.WriteLine($"\t{CommandFeedback}:");
            }
            DisplayMenuPrompt("User Programming");

        }



        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds



            //
            // reset finch robot
            //
            finchRobot.setLED(34, 59, 100);
            finchRobot.noteOn(190);
            finchRobot.wait(500);
            finchRobot.noteOff();

            return robotConnected;

        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }
        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }
        #endregion
    }
}

