﻿using System;

namespace ProjectTwo.Models
{
    public class Token
    {
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
    }
}