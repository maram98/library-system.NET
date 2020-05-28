using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maram_sTask.ViewModels
{
    public class BookViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}