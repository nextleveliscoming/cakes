﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CakesLibrary
{
    public class Ingredient
    {
        public string Name { get; set; }

        public decimal Cost {  get; set; }

        public int Quantity { get; set; }
    }
}
