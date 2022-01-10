﻿using System;

namespace UIA.Models
{
    public class Fight
    {
        public Guid FightId { get; set; }
        public CalculatedCharacter Player { get; set; }
        public CalculatedCharacter Monster { get; set; }
        public bool? PlayerWon { get; set; }
    }
}
