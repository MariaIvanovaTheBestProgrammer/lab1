using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public void validate()
        {
            if (firstName == "" || firstName == null) { throw new ArgumentException("First name cannot be empty!"); }
        }

    }


}
