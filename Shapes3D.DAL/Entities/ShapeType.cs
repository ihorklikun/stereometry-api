using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.DAL.Entities
{
    public class ShapeType : BaseEntity
    {
        public ShapeType()
        {
            Shapes = new HashSet<Shape>();
        }
        public string Name { get; set; }
        public virtual ICollection<Shape> Shapes { get; set; }
    }
}
