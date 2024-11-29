using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_A
{
    public class Librarian : IEmployee
    {
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }

        public void FindBook(string title)
        {
            throw new NotImplementedException();
        }

        public void GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
