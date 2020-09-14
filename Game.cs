using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }

    struct Item
    {
        public int statBoost;
    }



    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        Item longSword;
        Item dagger;

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

        public void InitializePlayers()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
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
        public void EquipItems()
        {
            //Get input for player one
            char input;
            GetInput(out input, "Lonsword", "Dagger", "Welcome! Player one please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                _player1.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player1.damage += dagger.statBoost;
            }
            Console.WriteLine("Player 1");
            PrintStats(_player1);

            //Get input fro player two
            GetInput(out input, "Lonsword", "Dagger", "Welcome! Player two please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                _player2.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player2.damage += dagger.statBoost;
            }
            Console.WriteLine("Player 2");
            PrintStats(_player2);
        }

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("Now FIGHT WORMS!!!");

            while (_player1.health >= 0 && _player2.health >= 0)
            {
                //print player stats to console
                Console.WriteLine("Player1");
                PrintStats(_player1);
                Console.WriteLine("Player2");
                PrintStats(_player2);
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "Defend", "Your turn player 1!");

                if (input == '1')
                {
                    _player2.health -= _player1.damage;
                    Console.WriteLine("Player 2 took  " + _player1.damage + " damage!");
                }
                else
                {
                    Console.WriteLine("I haven't implemented that yet so P E R I S H ! !");
                    _player1.health -= _player2.damage;
                }

                GetInput(out input, "Attack", "Defend", "Your trun player 2!");

                if (input == '1')
                {
                    _player1.health -= _player2.damage;
                    Console.WriteLine("Player 1 took  " + _player2.damage + " damage!");
                }
                else
                {
                    Console.WriteLine("I haven't implemented that yet so P E R I S H ! !");
                    _player2.health -= _player1.damage;
                }
                Console.Clear();
            }
            if (_player1.health > 0)
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

        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }

        //Performed once when the game begins
        public void Start()
        {
            InitializePlayers();
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            EquipItems();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}
