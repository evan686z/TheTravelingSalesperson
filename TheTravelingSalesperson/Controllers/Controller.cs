using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    public class Controller
    {
        #region FIELDS

        private Salesperson _salesperson;
        private ConsoleView _consoleView;

        #endregion

        #region PROPERTIES





        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // instantiate the salespersons
            //
            _salesperson = new Salesperson();

            //
            // instantiate the console view
            //
            _consoleView = new ConsoleView(_salesperson);

            //
            // call application loop manager method
            //
            ManageApplicationLoop();
        }

        /// <summary>
        /// method to control the flow of the application
        /// </summary>
        private void ManageApplicationLoop()
        {
            bool _usingApplication = true;
            MenuOption userMenuChoice;

            //
            // show welcome screen
            //
            _consoleView.DisplayWelcomeScreen();

            //
            // setup account
            //
            _consoleView.DisplaySetupAccount();

            //
            // using menu
            //
            while (_usingApplication)
            {
                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                switch (userMenuChoice)
                {
                    case MenuOption.Travel:
                        string nextCity = _consoleView.DisplayGetNextCity();
                        _salesperson.CitiesVisited.Add(nextCity);
                        break;
                    case MenuOption.Buy:
                        _salesperson.CurrentStock.AddWidgets(_consoleView.DisplayGetNumberOfUnitsToBuy());
                        break;
                    case MenuOption.Sell:
                        _salesperson.CurrentStock.SubtractWidgets(_consoleView.DisplayGetNumberOfUnitsToSell());
                        break;
                    case MenuOption.DisplayInventory:
                        _consoleView.DisplayInventory();
                        break;
                    case MenuOption.DisplayCities:
                        _consoleView.DisplayCitiesTraveled();
                        break;
                    case MenuOption.DisplayAccountInfo:
                        _consoleView.DisplayAccountInfo();
                        break;
                    case MenuOption.Exit:
                        _consoleView.DisplayExitPrompt();
                        break;
                    default:
                        break;
                }
            }
        }




        #endregion

        #region METHODS

        #endregion
    }
}
