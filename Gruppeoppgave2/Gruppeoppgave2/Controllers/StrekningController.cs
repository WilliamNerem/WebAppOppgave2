using Gruppeoppgave2.DAL;
using Gruppeoppgave2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2.Controllers
{
    [Route("[controller]/[action]")]
    public class StrekningController : ControllerBase
    {
        private readonly DB _db;

        public StrekningController(DB db)
        {
            _db = db;
        }
    }
}
