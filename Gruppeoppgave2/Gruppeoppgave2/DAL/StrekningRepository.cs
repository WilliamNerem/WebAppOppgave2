using Gruppeoppgave2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

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
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
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
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
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
                _log.LogInformation("Strekningen " + enDBStrekning.Navn + " ble slettet");
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public async Task<Strekning> HentEn(int id)
        {
            try
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
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return null;
            }
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
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
            return true;
        }
        //Nedenfor er kopiert fra moduler på Canvas
        public static byte[] LagHash(string passord, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                                password: passord,
                                salt: salt,
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 1000,
                                numBytesRequested: 32);
        }

        public static byte[] LagSalt()
        {
            var csp = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csp.GetBytes(salt);
            return salt;
        }

        public async Task<bool> LoggInn(Admin admin)
        {
            try
            {
                Adminer funnetAdmin = await _db.Adminer.FirstOrDefaultAsync(a => a.Brukernavn == admin.Brukernavn);
                // sjekk passordet
                byte[] hash = LagHash(admin.Passord, funnetAdmin.Salt);
                bool ok = hash.SequenceEqual(funnetAdmin.Passord);
                if (ok)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public Task<bool> LoggUt()
        {
            return Task.FromResult(true);
        }
    }
}