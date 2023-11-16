﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class VolunteersItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id_Volunteers { get; set; }
        public string name { get; set; }
        public string dni { get; set; }
        public string birthdate { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string education { get; set; }
        public string shift { get; set; }
        public bool termsAccepted { get; set; }
    }
}
