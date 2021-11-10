using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    abstract class Character : Tile
    {    //Protected Integers alongside the Death Boolean, Char symbol for Characters and Vision
        protected int hp; // Integer for HP
        protected int maxhp; // Integer for Maximum Health Points
        protected int purse; // Integer for the purse.
        protected int damage; // Integer for Damage
        protected char symbol; //Character Symbol for each of the Tile Types
        protected bool isdead;  // Boolean for Death True/False check.
        public Tile[] player_vision; // Vision up, down, left and right around player.

        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Damage { get; set; }
        public int Purse { get; set; }
        protected Tile[] playerVision { get; set; }

        public Tile[] Vision
        {
            get => playerVision;
            set => playerVision = value;
        }

        //Constructor for Characters
        public Character(int x, int y, int maxhp, int damage, char symbol) : base(x, y)
        {

        }

        //Attack
        public virtual void Attack(Character target)
        {
            target.hp -= this.damage;
            if (target.hp <= 0)
            {
                target.isdead = true;
            }
        }

        //Boolean for Death Check.
        public bool IsDead()
        {
            if (this.hp >= 0)
            {
                return false;
            }

            else
                return true;
        }
        // Check Range for characters.
        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) < -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check Range.
        private int DistanceTo(Character target)
        {
            int distance = (this.X - target.X) + (this.Y - target.Y);
            int value = Math.Abs(distance);
            return value;
        }


        // Movement Enums
        public enum EnumMovement
        {
            NoMovement,
            Up,
            Down,
            Left,
            Right
        }
        //Movement 
        public void Move(EnumMovement move)
        {
            if (move == EnumMovement.Down)
            {
                this.Y++;
            }
            if (move == EnumMovement.Up)
            {
                this.Y--;
            }
            if (move == EnumMovement.Right)
            {
                this.X++;
            }
            if (move == EnumMovement.Left)
            {
                this.X--;
            }
        }

        public void Pickup(Item i)
        {
            if (i == null)
            {
                return;
            }
            if (i.GetType() == typeof(Gold))
            {
                purse += ((Gold)i).GetGold();
            }
        }

        //Return for Movement
        public abstract EnumMovement ReturnMove(EnumMovement move);
        //ToString
        public abstract override string ToString();
    }
}
