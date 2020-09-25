using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Character
    {
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands;

        public Player() : base()
        {
            _hands.name = "These hands";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, float healthVal, float damageVal, int inventorySize)
            : base(healthVal, nameVal, damageVal)
        {
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
            if (Contains(itemIndex) == true)
            {
                _currentWeapon = _inventory[itemIndex];
            }

        }

        public void unequipItem()
        {
            _currentWeapon = _hands;
        }

        public override float Attack(Character enemy)
        {
            float damageTaken = 0.0f;
            damageTaken = base.Attack(enemy);
            return damageTaken;
        }
    }
}
