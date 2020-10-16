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
    
    public partial class Paper
    {
        public Paper()
        {
            this.Paper_Author = new HashSet<Paper_Author>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<byte> topic_id { get; set; }
        public Nullable<short> user_id { get; set; }
        public string file_path { get; set; }
        public Nullable<System.DateTime> submit_date { get; set; }
        public Nullable<byte> isApproved { get; set; }
        public Nullable<byte> isVisible { get; set; }
    
        public virtual ICollection<Paper_Author> Paper_Author { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual User User { get; set; }
    }
}