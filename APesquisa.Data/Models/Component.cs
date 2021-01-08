using APesquisa.Data.Enum;
using System;
using System.Collections.Generic;

namespace APesquisa.Data.Models
{
    public class Component
    {
        public Component()
        {
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? AllowedNoPoo { get; set; }
        public bool? AllowedLowPoo { get; set; }
        public bool? Prohibited { get; set; }
        public bool? Vegan { get; set; }
        public bool? MayBeVegan { get; set; }
        public bool? NonVegan { get; set; }
    }
}
