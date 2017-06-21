using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
  [Route ("api/[controller]")]
  public class PersonsController : Controller {

    [HttpGet]
    public IEnumerable<dynamic> Get () {
      return new List<dynamic> {
        new {
          Id = Guid.NewGuid ()
        },
        new {
          Id = Guid.NewGuid ()
        }
      };
    }

    [HttpGet ("{id}")]
    public dynamic Get (int id) {
      if(id == 2){
        throw new Exception("Not Found");
      }
      return new {
        Id = Guid.NewGuid ()
      };
    }
  }
}