//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DebitControl.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class License
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public License()
        {
            this.Computer = new HashSet<Computer>();
        }
    
        public short licenceId { get; set; }
        public string licenceName { get; set; }
        public string licenceKey { get; set; }
        public string licenceMail { get; set; }
        public string licencePassword { get; set; }
        public bool licenceStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Computer> Computer { get; set; }
    }
}
