using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _baseDamage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        public Player()
        {
            _inventory = new Item[3];
            _health = 100;
            _baseDamage = 10;
            _hands.name = "These hands";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, int healthVal, int damageVal, int inventorySize)
        {
            _name = nameVal;
            _health = healthVal;
            _baseDamage = damageVal;
            _inventory = new Item[inventorySize];
            _hands.name = "These Hands";
            _hands.statBoost = 0;
            
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex) == true)
            {
                _currentWeapon = _inventory[itemIndex];
            }

        }

        public string GetName()
        {
            return _name;
        }
        
        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public void unequipItem()
        {
            _currentWeapon = _hands;
        }

        public void Attack(Player enemy)
        {
            int totalDamage = _baseDamage + _currentWeapon.statBoost;
            enemy.TakeDamage(_baseDamage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _baseDamage);
        }

        private void TakeDamage(int damageVal)
        {
            if(GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage!");
        }
    }
}
