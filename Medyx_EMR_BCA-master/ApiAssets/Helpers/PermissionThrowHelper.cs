using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using System;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.Helpers
{
    public class PermissionThrowHelper
    {
        public static void IDHISCheck(string IDHIS, string message = "Bạn không có quyền sử dụng chức năng này")
        {
            if (!string.IsNullOrEmpty(IDHIS))
            {
                throw new HttpStatusException(HttpStatusCode.Forbidden, message);
            }
        }
        public static void DongBenhAnCheck(byte? XacNhanKetThucHs, string message = "Hồ sơ bệnh án đã đóng! Bạn không có quyền sử dụng chức năng này"){
            if(Convert.ToBoolean(XacNhanKetThucHs)){
                throw new HttpStatusException(HttpStatusCode.Forbidden, message);
            }
        }
        public static BenhAn GetBenhAnAndCheckPermission(decimal idba)
        {
            var repository = new GenericRepository<BenhAn>();
            var benhan = repository.GetById(idba);
            //permission
            PermissionThrowHelper.DongBenhAnCheck(benhan?.XacNhanKetThucHs);
            return benhan;
        }
    }
}
