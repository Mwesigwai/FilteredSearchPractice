using FilteredSearchPractice.Models;
using FilteredSearchPractice.RequestHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace FilteredSearchPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<List<SearchQuerryObject>> Get([FromQuery] SearchQuerryObject searchQuerry)
        {
            var handler1 = new CategoryAndEntryFilterHandler();
            var handler2 = new AllHandler();
            handler1.SetNext(handler2);
  
            return handler1.Handle(searchQuerry);
        }
    }
}
