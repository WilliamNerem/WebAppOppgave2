using Gruppeoppgave2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2.DAL
{
    public class StrekningRepository
    {
        private readonly DB _db;

        public StrekningRepository(DB db)
        {
            _db = db;
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
                return true;
            }
            catch
            {
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
                return alleStrekninger;
            }
            catch
            {
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
                return true;
            }
            catch
            {
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
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}