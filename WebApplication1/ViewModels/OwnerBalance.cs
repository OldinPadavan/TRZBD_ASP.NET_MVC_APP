using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
	public class OwnerBalance
	{
		
		public Owner Owner { get; set; }

		public Bill Bill { get; set; }	
		public Flat Flat {  get; set; }
		public int OwnerFlatCount { get; set; }

	}
}