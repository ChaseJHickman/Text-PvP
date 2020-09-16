using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelloWorld
{
   
    struct Item
    {
        public int statBoost;
    }



    class Game
    {
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item longSword;
        private Item dagger;

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
            longSword.statBoost = 15;
            dagger.statBoost = 10;
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

        //Equip items to both players in the beginning of the game
        public void SelectItems(Player player)
        {
            //Get input for player one
            char input;
            GetInput(out input, "Lonsword", "Dagger", "Welcome! Player one please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                player.AddItemToInventory(longSword, 0);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(dagger, 0);
            }
            _player1.PrintStats();

            //Get input fro player two
            GetInput(out input, "Lonsword", "Dagger", "Welcome! Player two please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                player.AddItemToInventory(longSword, 0);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(dagger, 0);
            }
            Console.WriteLine("Player 2");
            _player2.PrintStats();
        }

        public Player CreateCharacter()
        {
            Console.Write("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10,5);
            SelectItems(player);
            return player;
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
                GetInput(out input, "Attack", "Defend", "Your turn player 1!");

                if (input == '1')
                {
                    _player1.Attack(_player2);
                }
                else
                {
                    Console.WriteLine("I haven't implemented that yet so P E R I S H ! !");
                    _player2.Attack(_player1);
                }

                GetInput(out input, "Attack", "Defend", "Your trun player 2!");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    Console.WriteLine("I haven't implemented that yet so P E R I S H ! !");
                    _player1.Attack(_player2);
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
