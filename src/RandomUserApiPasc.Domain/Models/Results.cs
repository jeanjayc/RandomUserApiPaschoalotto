﻿using RandomUserApiPasc.Domain.Models.ValueObjects;

namespace RandomUserApiPasc.Domain.Models
{
    public class Results
    {
        public Result[] results { get; set; }
        public Info info { get; set; }
    }
}
