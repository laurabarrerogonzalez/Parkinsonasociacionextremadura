using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NewsItem
    {
        [Key]
        public int Id_News { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string thumbnail { get; set; }
    }
}
