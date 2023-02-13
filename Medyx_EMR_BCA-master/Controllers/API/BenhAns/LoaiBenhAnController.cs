using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Enums;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.QueryParameters;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medyx_EMR_BCA.Controllers.API.BenhAns
{
    [Route("api/loai-benh-an")]
    [ApiController]
    public class LoaiBenhAnController : ControllerBase
    {
        private IRepository<DmbaLoaiBa> repository = null;
        public LoaiBenhAnController()
        {
            repository = new GenericRepository<DmbaLoaiBa>();
        }

        // GET: api/<LoaiBenhAnController>
        [HttpGet]
        [SetActionContextItem(ActionType.PagedList)]
        public Response<DmbaLoaiBa> Get([FromQuery] LoaiBenhAnParameters parameters)
        {
            var query = repository.Table.AsQueryable();
            if (!string.IsNullOrEmpty(parameters.Search))
            {
                query = query.Where(x => x.TenLoaiBa.Contains(parameters.Search));
            }

            return Res<DmbaLoaiBa>.Get(query, parameters.PageNumber, parameters.PageSize);
        }

        // GET api/<LoaiBenhAnController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoaiBenhAnController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoaiBenhAnController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoaiBenhAnController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
