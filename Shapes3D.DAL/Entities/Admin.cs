using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.DAL.Entities
{
    public class Admin : User
    {
        public Admin(Guid idLink) : base(idLink) { }
    }
}
