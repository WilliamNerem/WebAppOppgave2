using Gruppeoppgave2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2.DAL
{
    public class StrekningRepository : IStrekningRepository
    {
        private readonly DB _db;
        private ILogger<StrekningRepository> _log;

        public StrekningRepository(DB db, ILogger<StrekningRepository> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<bool> Lagre(Strekning innStrekning)
        {
            try
            {
                var nyStrekningRad = new Strekning();
                nyStrekningRad.Navn = innStrekning.Navn;
                nyStrekningRad.Pris = innStrekning.Pris;


                _db.Add(nyStrekningRad);
                await _db.SaveChangesAsync();
                _log.LogInformation("Strekningen " + nyStrekningRad.Navn + " ble lagret");
                return true;
            }
            catch
            {
                _log.LogInformation("Strekning ble forsøkt lagret men var mislykket");
                return false;
            }
        }


        public async Task<List<Strekning>> HentAlle()
        {
            try
            {
                List<Strekning> alleStrekninger = await _db.Strekning.Select(s => new Strekning
                {
                    Id = s.Id,
                    Navn = s.Navn,
                    Pris = s.Pris,
                }).ToListAsync();
                _log.LogInformation("Alle strekninger ble hentet");
                return alleStrekninger;
            }
            catch
            {
                _log.LogInformation("Alle strekninger ble forsøkt hentet men var mislykket");
                return null;
            }
        }

        public async Task<bool> Slett(int id)
        {
            try
            {
                Strekning enDBStrekning = await _db.Strekning.FindAsync(id);
                _db.Strekning.Remove(enDBStrekning);
                await _db.SaveChangesAsync();
                _log.LogInformation("Strekningen "+enDBStrekning.Navn+" ble slettet");
                return true;
            }
            catch
            {
                _log.LogInformation("En strekning ble forsøkt slettet men var mislykket");
                return false;
            }
        }

        public async Task<Strekning> HentEn(int id)
        {
            Strekning enStrekning = await _db.Strekning.FindAsync(id);
            var hentetStrekning = new Strekning()
            {
                Id = enStrekning.Id,
                Navn = enStrekning.Navn,
                Pris = enStrekning.Pris,
            };
            _log.LogInformation("Strekningen "+enStrekning.Navn+" ble hentet");
            return hentetStrekning;
        }

        public async Task<bool> Endre(Strekning endreStrekning)
        {
            try
            {
                var endreObjekt = await _db.Strekning.FindAsync(endreStrekning.Id);
                endreObjekt.Navn = endreStrekning.Navn;
                endreObjekt.Pris = endreStrekning.Pris;
                await _db.SaveChangesAsync();
                _log.LogInformation("Strekningen "+endreStrekning.Navn+" ble endret\nGammel pris: "+endreStrekning.Pris+"\nNytt navn: "+endreObjekt.Navn+", ny pris: "+endreObjekt.Pris);
            }
            catch
            {
                _log.LogInformation("Strekningen "+endreStrekning.Navn+" ble forsøkt endret var mislykket");
                return false;
            }
            return true;
        }
    }
}