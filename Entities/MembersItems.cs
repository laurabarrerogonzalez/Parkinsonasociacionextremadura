using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Entities
{
    public class MembersItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id_Members { get; set; }
        public string name { get; set; }
        public string dni { get; set; }
        public string birthdate { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string iban { get; set; }
        public string holder { get; set; }
        public string services { get; set; }
        public string members { get; set; }
        public bool termsAccepted { get; set; }
    }
}
