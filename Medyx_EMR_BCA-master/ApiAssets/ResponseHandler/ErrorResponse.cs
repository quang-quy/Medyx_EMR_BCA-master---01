using System;
using System.Net;

namespace Medyx_EMR_BCA.ApiAssets.ResponseHandler
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Error { get; set; }

        public ErrorResponse(Exception ex, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            Error = ex.Message;
            StatusCode = httpStatusCode;
        }
    }
}
