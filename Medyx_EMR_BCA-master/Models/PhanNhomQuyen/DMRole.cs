using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMRoleVM
    {
        public String ApplicationRolesId { get; set; }
        public String TenRole { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMRole
    {
        public String ApplicationRolesId { get; set; }
        public String TenRole { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
    public class DMRole_C
    {
        public String ApplicationRolesId { get; set; }
        public String TenRole { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        //public IEnumerable<MenuRole> MenuRole { get; set; }
        //public IEnumerable<ActionRole> ActionRole { get; set; }
        public List<MenuRole> MenuRoleC { get; set; }
        //public List<ActionRole> ActionRoleC { get; set; }
        public List<MenuRole> MenuRoleD { get; set; }
        //public List<ActionRole> ActionRoleD { get; set; }
        public List<ActionRole> ActionRole { get; set; }
    }
    public class MenuRole
    {
        public Boolean Chon { get; set; }
        public String MenuId { get; set; }
        public String MenuName { get; set; }
        public Int64 ApplicationActionId { get; set; }
        public String tenaction { get; set; }
    }
    public class ActionRole
    {
        public Boolean Chon { get; set; }
        public String MaAction { get; set; }
        public String TenAction { get; set; }
        public String ButtonName { get; set; }
        public Int64 ApplicationActionId { get; set; }
    }
    public class sendRole
    {
        public String ApplicationRolesId { get; set; }
        public String TenRole { get; set; }
        public Boolean Huy { get; set; }
        public List<MenuRole> MenuRole { get; set; }
        public List<ActionRole> ActionRole { get; set; }
    }
    public class DMNVKhoa
    {
        public Boolean Chon { get; set; }
        public String MaKhoa { get; set; }
        public String Tenkhoa { get; set; }
    }
    public class sendNVKhoa
    {
        public String MaNV { get; set; }
        public List<DMNVKhoa> MenuRole { get; set; }
    }
}
