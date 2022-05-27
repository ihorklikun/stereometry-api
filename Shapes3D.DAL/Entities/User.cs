using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.DAL.Entities
{
    public abstract class User : BaseEntity
    {
        protected User(Guid idLink)
        {
            IdLink = idLink;
        }

        public Guid IdLink { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
