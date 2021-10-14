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
        private readonly IStrekningRepository _db;

        public StrekningController(IStrekningRepository db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Strekning innKunde)
        {
            return await _db.Lagre(innKunde);
        }

        public async Task<List<Strekning>> HentAlle()
        {
            return await _db.HentAlle();
        }

        public async Task<bool> Slett(int id)
        {
            return await _db.Slett(id);
        }

        public async Task<Strekning> HentEn(int id)
        {
            return await _db.HentEn(id);
        }

        public async Task<bool> Endre(Strekning endreStrekning)
        {
            return await _db.Endre(endreStrekning);
        }
    }
}