using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelloWorld
{
   
    struct Item
    {
        public string name;
        public int statBoost;
    }



    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Character _player1Partner;
        private Character _player2Partner;
        private Item _longSword;
        private Item _dagger;
        private Item _bow;
        private Item _crossBow;
        private Item _cherryBomb;
        private Item _mace;
        

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();

        }

        public void InitializeItems()
        {
            _longSword.name = "Long Sword";
            _longSword.statBoost = 15;
            _dagger.name = "Dagger";
            _dagger.statBoost = 10;
            _bow.name = "Bow";
            _bow.statBoost = 12;
            _crossBow.name = "Crossbow";
            _crossBow.statBoost = 34;
            _cherryBomb.name = "Cherry Bomb";
            _cherryBomb.statBoost = 24;
            _mace.name = "Mace";
            _mace.statBoost = 25;
        }

        //Displays two options to the player. Outputs the choice of teh two options
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        //Equip items to both players in the beginning of the game
        public void SelectLoadout(Player player)
        {
            Console.Clear();
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(_longSword.name);
            Console.WriteLine(_dagger.name);
            Console.WriteLine(_bow.name);

            Console.WriteLine("\nLoadout2: ");
            Console.WriteLine(_crossBow.name);
            Console.WriteLine(_cherryBomb.name);
            Console.WriteLine(_mace.name);
            Console.WriteLine();
            //Get input for player one
            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "Welcome! Player one please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
                player.AddItemToInventory(_dagger, 1);
                player.AddItemToInventory(_bow, 2);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(_crossBow, 0);
                player.AddItemToInventory(_cherryBomb, 1);
                player.AddItemToInventory(_mace, 2);
            }
            _player1.PrintStats();

            //Get input from player two
            GetInput(out input, "Loadout 1", "Loadout 2", "Welcome! Player two please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                player.AddItemToInventory(_longSword, 0);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(_dagger, 0);
            }
            Console.WriteLine("Player 2");
            _player2.PrintStats();
        }

        public Player CreateCharacter()
        {
            Console.Write("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10,3);
            SelectLoadout(player);
            return player;
        }

        public void SwitchWeapons(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + " \n Damage: " + inventory[i].statBoost);
            }
            Console.Write("> ");
            input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("You equipped " + inventory[0].name);
                        Console.WriteLine("Base Damage increased by " + inventory[0].statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("You equipped " + inventory[1].name);
                        Console.WriteLine("Base Damage increased by " + inventory[1].statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("You equipped " + inventory[2].name);
                        Console.WriteLine("Base Damage increased by " + inventory[2].statBoost);
                        break;
                    }
                default:
                    {
                        player.unequipItem();
                        Console.WriteLine("You accidently dropped your weapon! \nUnfortunate...");
                        break;
                    }
            }
        }

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("Now FIGHT!!!");

            while (_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                //print player stats to console
                Console.WriteLine("Player1");
                _player1.PrintStats();
                Console.WriteLine("Player2");
                _player2.PrintStats();
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "Change Weapon", "Your turn player 1!");

                if (input == '1')
                {
                    float damageTaken = _player1.Attack(_player2);
                    Console.WriteLine(_player1.GetName() + "did " + damageTaken + " damage");
                    damageTaken = _player1Partner.Attack(_player2);
                    Console.WriteLine(_player1Partner.GetName() + "did " + damageTaken + " damage");
                }
                else
                {
                    SwitchWeapons(_player1);
                }

                GetInput(out input, "Attack", "Change Weapon", "Your trun player 2!");

                if (input == '1')
                {
                    float damageTaken = _player2.Attack(_player1);
                    Console.WriteLine(_player2.GetName() + "did " + damageTaken + " damage");
                    damageTaken = _player1Partner.Attack(_player1);
                    Console.WriteLine(_player2Partner.GetName() + "did " + damageTaken + " damage");
                }
                else
                {
                    SwitchWeapons(_player2);
                }
                Console.Clear();
            }
            if (_player1.GetIsAlive())
            {
                Console.WriteLine("Player 1 WINS !!!111!!1!11!!!1111!!11!1!!!!!");
            }
            else
            {
                Console.WriteLine("Player 2 wins or whatever...");
            }
            Console.Clear();
            _gameOver = true;
        }

        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
            _player1Partner = new Wizard(120, "Wizard Lizard", 20, 100);
            _player2Partner = new Wizard(120, "Harry Wizard101", 20, 100);
        }

        //Repeated until the game ends
        public void Update()
        {
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}
