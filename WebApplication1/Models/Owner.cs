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
	using System.ComponentModel;

	public partial class Owner
	{
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Owner()
        {
            this.Flats = new HashSet<Flat>();
        }
    
        public int Id { get; set; }
		[DisplayName("�������")]
		public string Last_name { get; set; }
		[DisplayName("���")]
		public string First_name { get; set; }
		[DisplayName("��������")]
		public string Middle_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flat> Flats { get; set; }
    }
}
