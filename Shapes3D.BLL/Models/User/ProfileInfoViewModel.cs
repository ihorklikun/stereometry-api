using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Models.User
{
    public class ProfileInfoViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Min FirstName lenght 2")]
        [MaxLength(20, ErrorMessage = "Max FirstName lenght 20")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Min LastName lenght 2")]
        [MaxLength(20, ErrorMessage = "Max LastName lenght 20")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
