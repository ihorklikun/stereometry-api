using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.DAL.Entities
{
    public class Shape : BaseEntity
    {
        public DateTime AddedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string Json { get; set; }
        public bool IsAvailableInGallary { get; set; }

        public Guid ShapeTypeId { get; set; }
        public virtual ShapeType ShapeType { get; set; }

        public Guid RegularUserId { get; set; }
        public virtual RegularUser RegularUser { get; set; }
    }
}
