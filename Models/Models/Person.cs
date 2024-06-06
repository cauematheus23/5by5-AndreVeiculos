﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Person
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public Adress Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}