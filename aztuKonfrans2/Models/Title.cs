//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aztuKonfrans2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Title
    {
        public Title()
        {
            this.Authors = new HashSet<Author>();
            this.Users = new HashSet<User>();
        }
    
        public byte id { get; set; }
    
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
