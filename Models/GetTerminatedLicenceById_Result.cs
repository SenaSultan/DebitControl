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
    
    public partial class GetTerminatedLicenceById_Result
    {
        public int licenseId { get; set; }
        public string licenseName { get; set; }
        public string obtainedFrom { get; set; }
        public Nullable<System.DateTime> obtainedDate { get; set; }
        public string email { get; set; }
        public string licencepassword { get; set; }
        public string licenceCode { get; set; }
        public string issuedPerson { get; set; }
        public string issuedDepartment { get; set; }
        public Nullable<short> licenceDuration { get; set; }
    }
}
