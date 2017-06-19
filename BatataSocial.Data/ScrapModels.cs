using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatataSocial.Data
{

    public class ApplicationUserScrap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdUser { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required] 
        [MaxLength(250)]
        public string Scrap { get; set; }

        public string Image { get; set; }
    }
}
