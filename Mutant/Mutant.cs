using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutant
{
    internal class Mutant
    {
        public int[,] MutantCells { get; set; } 
        public int XCoordinate {  get; set; } 
        public int YCoordinate { get; set; } 
        public int Age { get; set; } //Représente le nombre de jours en vie du mutant.
        public int MovementSpeed { get; set; } //Vitesse de déplacement [1-3]
        public int GrowSpeed { get; set; } //Représente la vitesse de croissance d'un mutant [1-3]
        public int SizeMax { get; set; } //Nombre de cellules maximum que peuvent potentiellement constituer un mutant. [3-25]
        public int Size {  get; set; } //Nombre de cellules qui composent le mutant à l'instant T.
        public int Weight { get; set; } //Le poids représente une addition d'attributs (age+size) 
        public int Direction { get; set; } //Direction dans laquelle se déplace le mutant (voir methode Defining Direction)
        public int DirectionChangeFrequency { get; set; } //Représente la fréquence de changement de direction lors des déplacements [2-7]
        public int DirectionWeariness { get; set; } //Représente la lassitude la direction choisie. Lorsqu'il atteint 0 le mutant change de direction.
        public bool IsColliding { get; set; } 

        public Mutant() 
        {
            MutantCells = new int[,]
            {
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 0, 1, 0, 0},
                { 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0}
            };

            XCoordinate = 15;
            YCoordinate = 15;
            Age = 0;
            MovementSpeed = 1;
            GrowSpeed = 1;
            SizeMax = 10;
            Size = 1;
            Weight = 1;
            Direction = 2;
            DirectionChangeFrequency = 3;
            DirectionWeariness = DirectionChangeFrequency;
            IsColliding = false;
        }
        public void Life(Map map)
        {
            if(DirectionWeariness <= 0)
            {
                Direction = DefiningDirection();
                DirectionWeariness = DirectionChangeFrequency;
            }
            DirectionWeariness--;
            Move(map);
        }
        public void Move(Map map)
        {
            switch (Direction)
            {
                case 1:
                    if (YCoordinate - MovementSpeed - GetMutantHeight() > 1)
                    {
                        YCoordinate -= MovementSpeed;
                    }
                    break;
                case 2:
                    if (XCoordinate + MovementSpeed + GetMutantWidth() < map.MapWidth - 3)
                    {
                        XCoordinate += MovementSpeed;
                    }
                    break;
                case 3:
                    if(YCoordinate + MovementSpeed + GetMutantHeight() < map.MapHeight-3)
                    {
                        YCoordinate += MovementSpeed;
                    }
                    
                    break;
                case 4:
                    if(XCoordinate - MovementSpeed - GetMutantWidth() > 1)
                    {
                        XCoordinate -= MovementSpeed;
                    }
                    break;
                default:
                    break;
            }
        }
        public int DefiningDirection()
        {
            // 1 => top
            // 2 => right
            // 3 => bottom
            // 4 => left

            Random random = new Random();
            int chosenDirection = Direction;

            do
            {
                chosenDirection = random.Next(1,5);
            } while (chosenDirection - Direction == 2 || chosenDirection - Direction == -2);

            return chosenDirection;
        }
        public int GetMutantWidth()
        {
            int totalMaxWidthToReturn = 1;
            
            for(int i = 0; i < MutantCells.GetLength(0); i++)
            {
                int widthPerList = MutantCells.GetLength(1);
                for(int j = 0; j < MutantCells.GetLength(1); j++)
                {
                    if (MutantCells[i, j] == 0)
                    {
                        widthPerList--;
                    }
                }
                if(widthPerList > totalMaxWidthToReturn)
                {
                    totalMaxWidthToReturn = widthPerList;
                }
            }
            return totalMaxWidthToReturn;
        }
        public int GetMutantHeight()
        {
            int totalMaxHeightToReturn = 1;

            for(int i = 0; i < MutantCells.GetLength(0);i++)
            {
                int heightPerColumn = MutantCells.GetLength(0);
                for (int j = 0; j < MutantCells.GetLength(0); j++)
                {
                    if (MutantCells[j, i] == 0)
                    {
                        heightPerColumn--;
                    }
                }
                if (heightPerColumn > totalMaxHeightToReturn)
                {
                    totalMaxHeightToReturn = heightPerColumn;
                }
            }
            return totalMaxHeightToReturn;
        }
    }
}
