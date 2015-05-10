using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rogue_Game
{
    [Serializable]
    public class SaveCharacter
    {
        public SaveCharacter()
        {
            location = new Point(0, 0);
            stats = new d3vector();
            inventory = new Item[4, 5];
            equip = new Equipment();
        }
        public int level { set; get; }
        public int level_progress { set; get; }
        public Point location { set; get; }
        public d3vector stats { set; get; }
        public Item[,] inventory { set; get; }
        public Equipment equip { set; get; }
        public int unused { set; get; }
        public int gold { set; get; }
        public int health { set; get; }
        public SaveCharacter(int Level, int Level_progress, Point Location, d3vector Stats, Item[,] Inventory, Equipment Equip, int Unused, int Gold,int health)
        {
            level = Level;
            level_progress = Level_progress;
            location = Location;
            stats = Stats;
            inventory = Inventory;
            equip = Equip;
            unused = Unused;
            gold = Gold;
            this.health = health;

        }
    }
}
