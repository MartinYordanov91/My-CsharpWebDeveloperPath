﻿namespace Animalss.Models
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
            => $"{base.ToString()}{Environment.NewLine}MEEOW";
    }
}
