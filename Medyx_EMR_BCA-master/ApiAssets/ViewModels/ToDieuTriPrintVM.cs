using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class ToDieuTriPrintVM
    {
		[FromQuery(Name = "Stt[]")]
        public List<int> Stt { get; set; } = new List<int>();
    }
}
