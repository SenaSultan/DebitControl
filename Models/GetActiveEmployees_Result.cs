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
    
    public partial class GetActiveEmployees_Result
    {
        public short employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeSurname { get; set; }
        public string employeeUsername { get; set; }
        public bool employeeStatus { get; set; }
        public Nullable<byte> departmentId { get; set; }
        public Nullable<short> mailId { get; set; }
        public string mailName { get; set; }
    }
}
