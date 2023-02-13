using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnTvBbkiemDiemTvVM : BenhAnTvBbkiemDiemTv
    {
    }

    public class BenhAnTvBbkiemDiemTvCreateVM : BenhAnTvBbkiemDiemTvVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public new decimal Idba { get; set; }
        [Required(ErrorMessage = "Mã thành viên tham gia là bắt buộc.")]
        public new string MaNv { get; set; }
    }
}