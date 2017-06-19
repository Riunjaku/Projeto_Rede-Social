using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatataSocial.Data
{

    public class ApplicationUserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdUser { get; set; }

        public string UserPhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StreetName { get; set; }
        public string neighborhood { get; set; }
        public string EstadoCivil { get; set; }
        public string WorkPlace { get; set; }
        public string School { get; set; }
        
    }
}