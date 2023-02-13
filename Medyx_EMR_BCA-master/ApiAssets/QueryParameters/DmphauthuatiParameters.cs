using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
	public class DmphauthuatiParameters : QueryStringParameters
	{
		public string MaChungloai { get; set; }
		[FromQuery(Name = "MaChungLoais[]")]
		public List<String> MaChungloais { get; set; } = new List<string>();
	}
}
