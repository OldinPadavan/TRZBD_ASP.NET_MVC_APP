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

	public partial class Bill
	{
        public int Id { get; set; }

		[DisplayName("����")]
		public System.DateTime Date { get; set; }
		[DisplayName("�����")]
		public decimal Amount { get; set; }
		[DisplayName("������ �� ����")]
		public string Paper_bill_link { get; set; }
		[DisplayName("���������� ��� ��������")]
		public int Flat_id { get; set; }
    
        public virtual Flat Flat { get; set; }
    }
}
