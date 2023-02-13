using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Medyx_EMR_BCA.Controllers.HSBA
{
    [Route("HSBALT/[action]")]
    public class HSBALTController : BCAController
    {
        // GET: Client/DMChucVu
        private IMemoryCache cache;
        //public readonly ISession session;
        public HSBALTController(IMemoryCache cache)
        {
            this.cache = cache;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }

        [HttpGet("{id}")]
        public ActionResult Detail(string id)
        {
            ViewData["id"] = id;
            return Khoitao(cache);
        }
    }
}
