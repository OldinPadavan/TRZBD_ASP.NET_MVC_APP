//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ManagmentCompany_Employees
    {
        public int Id { get; set; }
        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string Middle_name { get; set; }
        public int Company_id { get; set; }
    
        public virtual Managment_company Managment_company { get; set; }
    }
}