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
    public class NewsItem
    {
        [Key]
        public int Id_News { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
    }
}
