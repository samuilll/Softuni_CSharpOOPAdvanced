﻿
    public class Gun:Ammunition
    {
        private const double weight = 1.4;

        public Gun(string name)
            : base(name, weight)
        {
            this.WearLevel = this.Weight * 100;
        }
    }