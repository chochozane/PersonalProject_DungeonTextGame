using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunDunDungeon
{
    internal class Character
    {
        public string name;
        public int level;
        public string job;
        public int atk;
        public int def;
        public int hp;
        public int gold;

        public Character(string newName, int newLevel, string newJob, int newAtk, int newDef, int newHp, int newGold)
        {
            name = newName;
            level = newLevel;
            job = newJob;
            atk = newAtk;
            def = newDef;
            hp = newHp;
            gold = newGold;
        }
    }
}
