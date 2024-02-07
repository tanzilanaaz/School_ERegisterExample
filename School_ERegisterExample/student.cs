using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_ERegisterExample
{
    class student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int UniqueId { get; set; }
        public override string ToString()
        {
            return $"UniqueId: {UniqueId}, Name: {Name}, Age: {Age}, Email: {Email}";
        }
    }
}
