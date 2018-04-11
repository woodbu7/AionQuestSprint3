using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Universe _gameUniverse;
        private SpaceTimeLocation _currentLocation;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameTraveler = new Traveler();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);
            _playingGame = true;

            //
            // add initial items to the traveler's inventory
            //
            _gameTraveler.Inventory.Add(_gameUniverse.GetGameObjectById(5) as TravelerObject);
            _gameTraveler.Inventory.Add(_gameUniverse.GetGameObjectById(6) as TravelerObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                {
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                }

                //
                // choose an action based on the player's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;

                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;

                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case TravelerAction.Travel:
                        TravelAction();
                        break;

                    case TravelerAction.TravelerLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                          break;

                    case TravelerAction.ListSpaceTimeLocations:
                        _gameConsoleView.DisplayListOfSpaceTimeLocations();
                        break;

                    case TravelerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case TravelerAction.LookAt:
                        LookAtAction();
                        break;

                    case TravelerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case TravelerAction.PickUp:
                        PickUpAction();
                        break;

                    case TravelerAction.PutDown:
                        PutDownAction();
                        break;

                    case TravelerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu", ActionMenu.AdminMenu, "");
                        break;

                    case TravelerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case TravelerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Traveler traveler = _gameConsoleView.GetInitialTravelerInfo();

            _gameTraveler.Name = traveler.Name;
            _gameTraveler.Age = traveler.Age;
            _gameTraveler.Race = traveler.Race;
            _gameTraveler.SpaceTimeLocationID = 1;

            _gameTraveler.ExperiencePoints = 0;
            _gameTraveler.Health = 100;
            _gameTraveler.Lives = 3;
        }

        private void UpdateGameStatus()
        {
            if (!_gameTraveler.HasVisited(_currentLocation.SpaceTimeLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gameTraveler.SpaceTimeLocationsVisited.Add(_currentLocation.SpaceTimeLocationID);

                //
                // update experience points for visiting locations
                //
                _gameTraveler.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        private void TravelAction()
        {
            
            GameObject keyObject = _gameUniverse.GetGameObjectById(10);

            //
            // Looks for the key object in the traveler's inventory. If found set all locations accesbility to true
            //
            if (_gameTraveler.Inventory.Contains(keyObject))
            {
                foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
                {
                    location.Accessible = true;
                }
            }

            //
            // get new location choice and update the current location property
            // 
            _gameTraveler.SpaceTimeLocationID = _gameConsoleView.DisplayGetNextSpaceTimeLocation();
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);

            //
            // display the new space-time location info
            //
            _gameConsoleView.DisplayCurrentLocationInfo();
        }

        private void LookAtAction()
        {
            //
            // display a list of traveler objects in space-time location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayeGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        private void PickUpAction()
        {
            //
            // display a list of traveler objects in space-time location and get a player choice
            //
            int travelerObjectToPickUpId = _gameConsoleView.DisplayGetTravelerObjectsToPickUp();

            //
            // add the traveler object to traveler's inventory
            //
            if (travelerObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                TravelerObject travelerObject = _gameUniverse.GetGameObjectById(travelerObjectToPickUpId) as TravelerObject;
                //
                // note: traveler object is added to list and space-time location is set to 0
                _gameTraveler.Inventory.Add(travelerObject);
                travelerObject.SpaceTimeLocationId = 0;
                _gameTraveler.ExperiencePoints += travelerObject.ExperiencePoints;

                if (travelerObject.Id == 11 && _gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(12)) || travelerObject.Id == 12 && _gameTraveler.Inventory.Contains(_gameUniverse.GetGameObjectById(11)))
                {
                    _gameTraveler.Lives += 1;
                    _gameConsoleView.DisplayGamePlayScreen("Pick Up Game Object", Text.HeartStonesFound(travelerObject), ActionMenu.MainMenu, "");
                }
                else if (travelerObject.Id == 13)
                {
                    _gameTraveler.Health -= 30;
                    _gameConsoleView.DisplayGamePlayScreen("Pick Up Game Object", Text.RadiarionFound(travelerObject), ActionMenu.MainMenu, "");

                }
                else if (travelerObject.Id == 14)
                {
                    _gameTraveler.Lives -= 1;
                    _gameTraveler.Inventory.Remove(travelerObject);
                    _gameTraveler.SpaceTimeLocationID = -1;
                    _gameConsoleView.DisplayGamePlayScreen("Pick Up Game Object", Text.BombFound(travelerObject), ActionMenu.MainMenu, "");

                }
                else if (travelerObject.Id == 15)
                {
                    int newId;
                    int currentId = _currentLocation.SpaceTimeLocationID;
                    do
                    {
                        newId = _gameConsoleView.GetRandomNumber();
                        _gameTraveler.SpaceTimeLocationID = newId;
                        _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);
                    } while (newId == currentId);
                    _gameConsoleView.DisplayGamePlayScreen("Pick Up Game Object", Text.Transporter(travelerObject, _currentLocation), ActionMenu.MainMenu, "");

                }
                else
                {
                    _gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);
                }
                

            }
        }

        private void PutDownAction()
        {
            //
            // display a list of traveler objects in inventory and get a player choice
            //
            int travelerObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            TravelerObject travelerObject = _gameUniverse.GetGameObjectById(travelerObjectToPutDownId) as TravelerObject;

            //
            // remove the object from inventry and set the space-time location to the current value
            //
            _gameTraveler.Inventory.Remove(travelerObject);
            travelerObject.SpaceTimeLocationId = _currentLocation.SpaceTimeLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmTravelerObjectRemovedFromInventory(travelerObject);
            
        }

        #endregion
    }
}
