using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.DAL.Entities
{
    public class RegularUser : User
    {
        public RegularUser(Guid idLink) : base(idLink)
        {
            UserShapes = new HashSet<Shape>();
        }

        public virtual ICollection<Shape> UserShapes { get; set; }
    }
}
