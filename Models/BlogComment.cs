using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class BlogComment
    {
        public string Id { get; set; } = "";
        public string BlogId { get; set; } = "";
        public string Username { get; set; } = "";
        public string Comment { get; set; } = "";
        public DateTime Date { get; set; }
    }
}
