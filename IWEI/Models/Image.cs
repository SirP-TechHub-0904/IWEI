using System;

namespace IWEI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }
        public bool Show{ get; set; }
        public WebsitePage PageId { get; set; }                        

    }
}
