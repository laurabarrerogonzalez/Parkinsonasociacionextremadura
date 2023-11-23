using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Gallery1Item
    {
        [Key]
        public int Id_gallery1 { get; set; }
        public string url { get; set; }

    }
}
