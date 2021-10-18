using Gruppeoppgave2.Models;
using Gruppeoppgave2.DAL;
using Gruppeoppgave2.Controllers;
using Moq;
using System;
using System.Threading.Tasks;
using XUnitTestGruppeoppgave2;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestGruppeoppgave2
{
    public class StrekningTest
    {
        [Fact]

        public async Task HentAlle()
        {
            var strekning1 = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Pris = 750
            };
            var strekning2 = new Strekning
            {
                Id = 2,
                Navn = "Larvik - Hirthals",
                Pris = 600
            };

            var strekning3 = new Strekning
            {
                Id = 3,
                Navn = "Sandefjord - Strømstad",
                Pris = 400
            };

            var strekningListe = new List<Strekning>();
            strekningListe.Add(strekning1);
            strekningListe.Add(strekning2);
            strekningListe.Add(strekning3);

            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.HentAlle()).ReturnsAsync(strekningListe);
            var strekningController = new StrekningController(mock.Object);
            List<Strekning> resultat = await strekningController.HentAlle();
            Assert.Equal<List<Strekning>>(strekningListe, resultat);
        }

        [Fact]
        public async Task HentAlleTomListe()
        {
            var strekningListe = new List<Strekning>();

            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.HentAlle()).ReturnsAsync(()=>null);
            var strekningController = new StrekningController(mock.Object);
            List<Strekning> resultat = await strekningController.HentAlle();
            Assert.Null(resultat);
        }


        [Fact]
        public async Task LagreOK()
        {
            // Arrange
            var innStrekning = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Pris = 750
            };

            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.Lagre(innStrekning)).ReturnsAsync(true);
            var strekningController = new StrekningController(mock.Object);
            bool resultat = await strekningController.Lagre(innStrekning);
            Assert.True(resultat);
        }

        [Fact]
        public async Task LagreIkkeOK()
        {
            // Arrange
            var innStrekning = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Pris = 750
            };

            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.Lagre(innStrekning)).ReturnsAsync(false);
            var strekningController = new StrekningController(mock.Object);
            bool resultat = await strekningController.Lagre(innStrekning);
            Assert.False(resultat);
        }

        [Fact]
        public async Task HentEnOK()
        {
            var returStrekning = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Pris = 750
            };
            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.HentEn(1)).ReturnsAsync(returStrekning);
            var strekningController = new StrekningController(mock.Object);
            Strekning resultat = await strekningController.HentEn(1);
            Assert.Equal<Strekning>(returStrekning, resultat);
        }

        [Fact]
        public async Task HentEnIkkeOK()
        {
            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.HentEn(1)).ReturnsAsync(()=>null);
            var strekningController = new StrekningController(mock.Object);
            Strekning resultat = await strekningController.HentEn(1);
            Assert.Null(resultat);
        }
        [Fact]
        
        public async Task SlettOK()
        {
            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.Slett(1)).ReturnsAsync(true);
            var strekningController = new StrekningController(mock.Object);
            bool resultat = await strekningController.Slett(1);
            Assert.True(resultat);
        }

        [Fact]
        public async Task SlettIkkeOK()
        {
            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.Slett(1)).ReturnsAsync(false);
            var strekningController = new StrekningController(mock.Object);
            bool resultat = await strekningController.Slett(1);
            Assert.False(resultat);
        }

        [Fact]
        public async Task EndreOK()
        {
            var innStrekning = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Pris = 750
            };
            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.Endre(innStrekning)).ReturnsAsync(true);
            var strekningController = new StrekningController(mock.Object);
            bool resultat = await strekningController.Endre(innStrekning);
            Assert.True(resultat);
        }

        [Fact]
        public async Task EndreIkkeOK()
        {
            var innStrekning = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Pris = 750
            };
            var mock = new Mock<IStrekningRepository>();
            mock.Setup(s => s.Endre(innStrekning)).ReturnsAsync(false);
            var strekningController = new StrekningController(mock.Object);
            bool resultat = await strekningController.Endre(innStrekning);
            Assert.False(resultat);
        }
    }
}
