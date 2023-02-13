using System.Collections.Generic;
using Medyx_EMR_BCA.ApiAssets.Constants;

namespace Medyx_EMR_BCA.ApiAssets.ResponseHandler
{
    public class Response<T>
    {
        public List<T> data { get; set; }
        public string message { get; set; } = MessageTypeConstant.getListSuccess;
        public Response()
        {
        }
        public Response(List<T> data)
        {
            this.data = data;
        }
    }
}
