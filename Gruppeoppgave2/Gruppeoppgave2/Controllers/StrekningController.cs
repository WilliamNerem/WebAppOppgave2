using Gruppeoppgave2.DAL;
using Gruppeoppgave2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2.Controllers
{
    [Route("[controller]/[action]")]
    public class StrekningController : ControllerBase
    {
        private IStrekningRepository _db;

        private ILogger<StrekningController> _log;

        private const string _loggetInn = "loggetInn";
        private const string _ikkeLoggetInn = "";

        public StrekningController(IStrekningRepository db, ILogger<StrekningController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> Lagre(Strekning innStrekning)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _db.Lagre(innStrekning);
                if (!returOK)
                {
                    _log.LogInformation("Strekning kunne ikke lagres!");
                    return BadRequest("Strekning kunne ikke lagres");
                }
                return Ok("Strekning lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult> HentAlle()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            List<Strekning> alleStrekninger = await _db.HentAlle();
            return Ok(alleStrekninger);
        }

        public async Task<bool> Slett(int id)
        {
            return await _db.Slett(id);
        }

        public async Task<ActionResult> HentEn(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized("Ikke logget inn");
            }
            Strekning strekningen = await _db.HentEn(id);
            if (strekningen == null)
            {
                _log.LogInformation("Fant ikke strekningen");
                return NotFound("Fant ikke strekningen");
            }
            return Ok(strekningen);
        }

        public async Task<bool> Endre(Strekning endreStrekning)
        {
            return await _db.Endre(endreStrekning);
        }

        public async Task<ActionResult> LoggInn(Admin admin)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _db.LoggInn(admin);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for admin");
                    HttpContext.Session.SetString(_loggetInn, _ikkeLoggetInn);
                    return Ok(false);
                }
                HttpContext.Session.SetString(_loggetInn, _loggetInn);
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }
        public void LoggUt()
        {
            HttpContext.Session.SetString(_loggetInn, _ikkeLoggetInn);
        }
    }
}