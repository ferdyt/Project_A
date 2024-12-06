using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public abstract class Person
    {
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }

        public abstract void IntroduceYourself();
    }
}
