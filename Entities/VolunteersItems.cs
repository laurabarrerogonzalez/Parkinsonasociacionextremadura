using System.ComponentModel.DataAnnotations.Schema;
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
        public string Name { get; set; }
        public string Dni { get; set; }
        public string Birthdate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }

        [ForeignKey("Shift")]
        public int Id_Shift { get; set; }
        public string TermsAccepted { get; set; }

        [JsonIgnore]
        public virtual ShiftsItems Shift { get; set; }
    }
}
