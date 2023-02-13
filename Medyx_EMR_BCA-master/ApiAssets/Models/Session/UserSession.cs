using Medyx_EMR_BCA.ApiAssets.StoreProcedureModels;
using System.Collections.Generic;
namespace Medyx_EMR_BCA.ApiAssets.Models.Session
{
    public class UserSession
    {
        public string Pub_sNguoiSD { get; set; }
        public string Pub_sAccount { get; set; }
        public string Pub_sTenNguoiSD { get; set; }
        public string Pub_sQuay { get; set; }
        public bool? Pub_bQadmin { get; set; }
        public bool? Pub_bSgia { get; set; }
        public IEnumerable<sp_GetAllActionByRoleIDResult> ListRoleSession { get; set; }
        public List<Dmkhoa> DMKhoaAcc { get; set; }
    }
}
