//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website_BĐS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class STREET
    {
        public STREET()
        {
            this.PROPERTY = new HashSet<PROPERTY>();
        }
    
        public int ID { get; set; }
        public string StreetName { get; set; }
        public Nullable<int> District_ID { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual DISTRICT DISTRICT { get; set; }
        public virtual ICollection<PROPERTY> PROPERTY { get; set; }
    }
}
