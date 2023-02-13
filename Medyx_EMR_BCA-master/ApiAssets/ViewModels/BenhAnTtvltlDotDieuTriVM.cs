using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTtvltlDotDieuTriVM
    {
        [Required(ErrorMessage = "Stt khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        public byte LoaiBa { get; set; }
        public string Ppdt { get; set; }
        public string KhamBenh { get; set; }
        public string XuTri { get; set; }
        public string Kq { get; set; }
        public string BsdieuTri { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnTtvltlDotDieuTriCreateVM : BenhAnTtvltlDotDieuTriVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}