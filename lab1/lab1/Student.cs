﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Student : Person
    {
        public string hobby { get; set; }
        public int course { get; set; }
        public string studentTicket { get; set; }
        public string idNumber { get; set; }
        public string Study()
        {
            return "i'm studying";
        }
        new public void validate()
        {
            if (firstName == "" || firstName == null) { throw new ArgumentException("First name cannot be empty!"); }
            if (studentTicket == "" || studentTicket == null) { throw new ArgumentException("First name cannot be empty!"); }
        }
    }
}