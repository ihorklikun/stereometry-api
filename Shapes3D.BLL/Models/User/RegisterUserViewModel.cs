using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Models.User
{
    public class RegisterUserViewModel : LoginUserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
