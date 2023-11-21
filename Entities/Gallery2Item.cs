using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Gallery2Item
    {
        [Key]

        public int Id_gallery2 { get; set; }
        public string url { get; set; }

    }
}