﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    class ConsoleView
    {
        #region FIELDS

        private Salesperson _salesperson;

        #endregion

        #region PROPERTIES





        #endregion

        #region CONSTRUCTORS

        public ConsoleView(Salesperson salesperson)
        {
            _salesperson = salesperson;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Welcome to the thing with the stuffs");
            Console.WriteLine();

            sb.Clear();
            sb.Append("Your first task will be to set up your account details.");
            sb.Append("Good luck with your sales.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();
            ConsoleUtil.HeaderText = "Main Menu";
            Console.CursorVisible = true;
        }
        /// <summary>
        /// Setup initial account information
        /// </summary>
        public void DisplaySetupAccount()
        {
            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Setup your account now.");
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your first name: ");
            _salesperson.FirstName = Console.ReadLine();
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your last name: ");
            _salesperson.LastName = Console.ReadLine();
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your account number: ");
            _salesperson.AccountId = Console.ReadLine();
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter your widget type(Fuzzy, Spotted, or Striped): ");
            string userResponse = Console.ReadLine();
            // typeof returns the type(WidgetType), where we are looking(userRepsonse).
            // Than we cast it as our own emum when we get it back from the user
            _salesperson.CurrentStock.Type = (WidgetItemStock.WidgetType)Enum.Parse(typeof(WidgetItemStock.WidgetType), userResponse, true);
            Console.WriteLine();

            ConsoleUtil.DisplayPromptMessage("Enter number of units: ");
            int numberOfUnits = int.Parse(Console.ReadLine());
            _salesperson.CurrentStock.AddWidgets(numberOfUnits);
            // vSame as above only more compact
            //_salesperson.CurrentStock.AddWidgets(int.Parse(Console.ReadLine()));
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Travel" + Environment.NewLine +
                    "\t" + "2. Buy" + Environment.NewLine +
                    "\t" + "3. Sell" + Environment.NewLine +
                    "\t" + "4. Display Inventory" + Environment.NewLine +
                    "\t" + "5. Display Cities" + Environment.NewLine +
                    "\t" + "6. Display Account Info" + Environment.NewLine +
                    "\t" + "7. Edit Account Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.Sell;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.DisplayInventory;
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    case '7':
                        userMenuChoice = MenuOption.UpdateAccountInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice."
                            + Environment.NewLine
                            + "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }
        /// <summary>
        /// Displays Account Info
        /// </summary>
        public void DisplayAccountInfo()
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("First Name: " + _salesperson.FirstName);
            ConsoleUtil.DisplayMessage("Last Name: " + _salesperson.LastName);
            ConsoleUtil.DisplayMessage("Account Id: " + _salesperson.AccountId);
            //ConsoleUtil.DisplayMessage(string.Format("Widget Type: {0}", _salesperson.CurrentStock.GetType));
            DisplayContinuePrompt();
        }
        /// <summary>
        /// Displays Exit Screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for using the application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }
        /// <summary>
        /// Display cities traveled
        /// </summary>
        public void DisplayCitiesTraveled()
        {
            ConsoleUtil.HeaderText = "Cities Traveled To";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage("You have traveled to the following cities:");
            Console.WriteLine();
            foreach (string city in _salesperson.CitiesVisited)
            {
                ConsoleUtil.DisplayMessage("\n" + city);
            }

            Console.WriteLine();

            DisplayContinuePrompt();
        }
        /// <summary>
        /// Get next city
        /// </summary>
        /// <returns>nextCity</returns>
        public string DisplayGetNextCity()
        {
            string nextCity = "";

            ConsoleUtil.HeaderText = "Next City of Travel";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayPromptMessage("Enter City to Travel to: ");

            nextCity = Console.ReadLine();
            Console.WriteLine();

            DisplayContinuePrompt();

            return nextCity;
        }
        /// <summary>
        /// Display Inventory Method
        /// </summary>
        public void DisplayInventory()
        {
            ConsoleUtil.HeaderText = "Inventory: ";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"Widget Type: { _salesperson.CurrentStock.Type}");
            ConsoleUtil.DisplayMessage($"Number of Units: { _salesperson.CurrentStock.NumberOfUnits}");

            DisplayContinuePrompt();
        }
        /// <summary>
        /// Method to buy inventory
        /// </summary>
        /// <returns></returns>
        public int DisplayGetNumberOfUnitsToBuy()
        {
            int numberOfUnitsToAdd = 0;

            ConsoleUtil.HeaderText = "Buy Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("How many would you like to buy?");
            numberOfUnitsToAdd = int.Parse(Console.ReadLine());

            DisplayContinuePrompt();

            return numberOfUnitsToAdd;
        }
        /// <summary>
        /// Method to sell inventory
        /// </summary>
        /// <returns></returns>
        public int DisplayGetNumberOfUnitsToSell()
        {
            int numberOfUnitsToSubtract = 0;

            ConsoleUtil.HeaderText = "Sell Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("How many would you like to sell?");
            numberOfUnitsToSubtract = int.Parse(Console.ReadLine());

            DisplayContinuePrompt();

            return numberOfUnitsToSubtract;
        }
        /// <summary>
        /// Update Salesperson Account Info
        /// </summary>
        /// <param name="salesperson"></param>
        /// <returns></returns>
        public Salesperson UpdateAccountInfo(Salesperson salesperson)
        {
            string updateSalesperson = "";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.HeaderText = "Update Account Info";
            ConsoleUtil.DisplayMessage("");
            // Update First Name
            ConsoleUtil.DisplayMessage(String.Format("Account First Name: {0}", salesperson.FirstName));
            ConsoleUtil.DisplayPromptMessage("Enter a new first name or press ENTER to keep current name: ");
            updateSalesperson = Console.ReadLine();
            if (updateSalesperson != "")
            {
                salesperson.FirstName = updateSalesperson;
            }
            ConsoleUtil.DisplayMessage("");
            // Update Last Name
            ConsoleUtil.DisplayMessage(String.Format("Account Last Name: {0}", salesperson.LastName));
            ConsoleUtil.DisplayPromptMessage("Enter a new last name or press ENTER to keep current name: ");
            updateSalesperson = Console.ReadLine();
            if (updateSalesperson != "")
            {
                salesperson.LastName = updateSalesperson;
            }
            ConsoleUtil.DisplayMessage("");
            // Update Account ID
            ConsoleUtil.DisplayMessage(String.Format("Account ID: {0}", salesperson.AccountId));
            ConsoleUtil.DisplayPromptMessage("Enter a new account number or press ENTER to keep current name: ");
            updateSalesperson = Console.ReadLine();
            if (updateSalesperson != "")
            {
                salesperson.AccountId = updateSalesperson;
            }

            ConsoleUtil.DisplayReset();
            DisplayContinuePrompt();

            return salesperson;
        }
        #endregion

    }
}
