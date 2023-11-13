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
		[DataType(DataType.Currency)]
		public decimal? Balance { get; set; }

		public Owner Owner { get; set; }
	}
}