//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maram_sTask.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int Id { get; set; }
        public string bookName { get; set; }
        public string Description { get; set; }
        public int PublicationYear { get; set; }
        public int authorId { get; set; }
        public int categoryId { get; set; }
    
        public virtual author author { get; set; }
        public virtual category category { get; set; }
    }
}