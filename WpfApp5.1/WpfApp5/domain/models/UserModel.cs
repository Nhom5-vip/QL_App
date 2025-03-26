using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.domain.models
{
    public class UserModel
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Gender { get; set; }
        public required string Telephone { get; set; }

        public required string Role { get; set; }
    }
}
