using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMMenu
    {
        public String MenuID { get; set; }
        public String MenuName { get; set; }
        public int Level { get; set; }
        public String MenuParent { get; set; }
        public int ApplicationActionID { get; set; }
        public String ActionName { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMMenuVM
    {
        public String MenuID { get; set; }
        public String MenuName { get; set; }
        public int Level { get; set; }
        public String MenuParent { get; set; }
        public int ApplicationActionID { get; set; }
        public String ActionName { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
}
