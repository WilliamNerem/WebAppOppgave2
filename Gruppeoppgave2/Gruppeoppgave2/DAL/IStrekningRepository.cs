using Gruppeoppgave2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2.DAL
{
    public interface IStrekningRepository
    {
        Task<bool> Lagre(Strekning innStrekning);
        Task<List<Strekning>> HentAlle();
        Task<bool> Slett(int id);
        Task<Strekning> HentEn(int id);
        Task<bool> Endre(Strekning endreStrekning);
        Task<bool> LoggInn(Admin admin);
    }
}
