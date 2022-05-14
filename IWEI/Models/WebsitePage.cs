using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWEI.Models
{
    public class WebsitePage
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }  
        public DateTime DateModified { get; set; }
        public string PageUniqueId { get; set; }
        public virtual ICollection<Image> Images { get; set; }

  
    }
}
