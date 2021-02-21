using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Login_Application
{
    // ****************************************************************************
    // 
    // Title: File IO Login
    // Description: Using a data file for user Login and Registation for the app
    // Applicatoin Type: Console
    // Author: Pearl, Nathan
    // Date Created: 4/2/2020
    // Last Modified: 4/5/2020
    //
    // ****************************************************************************

    class Program
    {
        
        static void Login(string[] args)
        {
            DisplayLoginRegister();

            //
            // call application menu
            //
        }
        /// <summary>
        /// **********************************************
        /// *      Login/Register SCreen                 *
        /// **********************************************
        /// </summary>
        static void DisplayLoginRegister()
        {
            DisplayScreenHeader("Login Register");
            Console.WriteLine("\tDo you have an account for this application [ yes | no ]");

            if (Console.ReadLine().ToLower() == "yes")
            {
                DisplayLogin();
            }
            else
            {
                DisplayRegisterUser();

                DisplayLogin();
            }
        }
        /// <summary>
        /// ***********************************************
        /// *       Login Screen                          *
        /// ***********************************************
        /// </summary>
        static void DisplayLogin()
        {
            string userName;
            string Password;
            bool validLogin;

            do
            {
                DisplayScreenHeader("Login");
                Console.WriteLine();
                Console.WriteLine("\tEnter your user name:");
                userName = Console.ReadLine();
                Console.WriteLine("\tEnter your password:");
                Password = Console.ReadLine();
                validLogin = IsValidLoginInfo(userName, Password);

                Console.WriteLine();
                if (validLogin)
                {
                    Console.WriteLine("\tYou are now logged in");
                    Console.WriteLine("\tPLease enjoy you day");
                }
                else
                {
                    Console.WriteLine("\tPlease enter your correct password or user name");
                    Console.WriteLine("\t Try again:");
                }
                DisplayContinuePrompt();

            } while (!validLogin);
        }

        /// <summary>
        ///  Check user Login
        ///  </summary>
        ///  <param name="userName">user name entered</param>
        ///  <param name="Password">Password entered</param>
        ///  <returns>tru if valid user</returns>
        static bool IsValidLoginInfo(string userName, string Password)
        {
            List<(string userName, string Password)> registeredUserLoginInfor = new List<(string userName, string Password)>();
            bool validUser = false;
            registeredUserLoginInfor = ReadLoginInfoData();

            foreach ((string userName, string Password) userLoginInfo in registeredUserLoginInfor)
            {
                if ((userLoginInfo.userName == userName) && (userLoginInfo.Password == Password))
                {
                    validUser = true;
                    break;

                }

            }
            return validUser;

        }
       
        /// <summary>
        /// *****************************************************************
        /// *                       Register Screen                         *
        /// *****************************************************************
        /// write login info to data file
        /// </summary>
        /// 
        static void DisplayRegisterUser()
        {
            string userName;
            string Password;

            DisplayScreenHeader("\tCreat Your Account");
            Console.WriteLine();
            Console.WriteLine("\tEnter your desiered User Name now please:");
            userName = Console.ReadLine();
            Console.WriteLine("\tEnter your Password:[ at least 8 figures | numbers and Letter ]");
            Password = Console.ReadLine();

            WriteLoginInfoData(userName, Password);
            Console.WriteLine();
            Console.WriteLine("\tYou have created you account with this application would you like to see your information again:");
            Console.WriteLine("[ yes | no ]");
            Console.ReadLine();
            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine($" Your User Name has been saved as: {userName}");
                Console.WriteLine($" Your Password has been saved as: {Password}");

                DisplayContinuePrompt();
            }
            else
            {
                DisplayContinuePrompt();
            }
        }

        /// <summary>
        /// read login info from data file
        /// Note: no error or validation checking
        /// </summary>
        /// <returns>list of tuple of user name and password</returns>
        
            static List<(string userName, string Password)>ReadLoginInfoData()
        {
            string dataPath = @"Data/Login.txt";
            
            string[] loginInfroArray;
            (string userName, string Password) loginInfoTuple;
            List<(string userName, string Password)> registeredUserLoginInfo = new List<(string userName, string Password)>();
            loginInfroArray = File.ReadAllLines(dataPath);

            foreach (string loginInfoText in loginInfroArray)
            {
                loginInfroArray = loginInfoText.Split(',');
                loginInfoTuple.userName = loginInfroArray[0];
                loginInfoTuple.Password = loginInfroArray[1];

                registeredUserLoginInfo.Add(loginInfoTuple);

            }
            return registeredUserLoginInfo;
        }

        /// <summary>
        /// write login info to data file
        /// Note: no error or validation checking
        /// </summary>
        
            static void WriteLoginInfoData(string userName, string Password)
        {
            string dataPath = @"Data/Login.txt";
            string loginInfoText;
            loginInfoText = userName + "," + Password;

            File.AppendAllText(dataPath, loginInfoText);


        }


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