﻿using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnPhauThuatDuyetMoParameters : QueryStringParameters
    {
        public BenhAnPhauThuatDuyetMoParameters()
        {
        }
        public decimal? Idba { get; set; }
        public int? Stt { get; set; }
    }
}
