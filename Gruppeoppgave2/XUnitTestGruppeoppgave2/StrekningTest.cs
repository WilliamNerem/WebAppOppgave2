using Gruppeoppgave2.Models;
using Gruppeoppgave2.DAL;
using Gruppeoppgave2.Controllers;
using Moq;
using System;
using System.Threading.Tasks;
using XUnitTestGruppeoppgave2;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace XUnitTestGruppeoppgave2
{
    public class StrekningTest
    {
        private const string _loggetInn = "loggetInn";
        private const string _ikkeLoggetInn = "";

        private readonly Mock<IStrekningRepository> mockRep = new Mock<IStrekningRepository>();
        private readonly Mock<ILogger<StrekningController>> mockLog = new Mock<ILogger<StrekningController>>();

        private readonly Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
        private readonly MockHttpSession mockSession = new MockHttpSession();




        [Fact]

        public async Task HentAlleLoggetInnOK()
        {
            var strekning1 = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Tid = "11:15",
                Pris = 750
            };
            var strekning2 = new Strekning
            {
                Id = 2,
                Navn = "Larvik - Hirthals",
                Tid = "10:00",
                Pris = 600
            };

            var strekning3 = new Strekning
            {
                Id = 3,
                Navn = "Sandefjord - Strømstad",
                Tid = "09:30",
                Pris = 400
            };

            var strekningListe = new List<Strekning>();
            strekningListe.Add(strekning1);
            strekningListe.Add(strekning2);
            strekningListe.Add(strekning3);

            mockRep.Setup(s => s.HentAlle()).ReturnsAsync(strekningListe);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            var resultat = await strekningController.HentAlle() as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal<List<Strekning>>((List<Strekning>)resultat.Value, strekningListe);
        }

        [Fact]
        public async Task HentAlleIkkeLoggetInn()
        {

            //Kan bruke It.IsAny

            mockRep.Setup(s => s.HentAlle()).ReturnsAsync(It.IsAny<List<Strekning>>());

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            var resultat = await strekningController.HentAlle() as UnauthorizedObjectResult;

            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task HentAlleTomListeLoggetInn()
        {
            var strekningListe = new List<Strekning>();

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);
            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            mockRep.Setup(s => s.HentAlle()).ReturnsAsync(()=>null);
            var resultat = await strekningController.HentAlle() as NotFoundObjectResult;
            Assert.Null(resultat);
        }


        [Fact]
        public async Task LagreLoggetInnOK()
        {
            // Arrange

            mockRep.Setup(s => s.Lagre(It.IsAny<Strekning>())).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Lagre(It.IsAny<Strekning>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Strekning lagret", resultat.Value);
        }

        [Fact]
        public async Task LagreLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(s => s.Lagre(It.IsAny<Strekning>())).ReturnsAsync(false);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Lagre(It.IsAny<Strekning>()) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Strekning kunne ikke lagres", resultat.Value);
        }

        [Fact]
        public async Task LagreLoggetInnFeilModel()
        {
            var strekning1 = new Strekning
            {
                Id = 1,
                Navn = "",
                Tid = "10:00",
                Pris = 600,
            };

            mockRep.Setup(s => s.Lagre(strekning1)).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            strekningController.ModelState.AddModelError("Navn", "Feil i inputvalidering på server");

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            var resultat = await strekningController.Lagre(strekning1) as BadRequestObjectResult;

            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Feil i inputvalidering på server", resultat.Value);
        }

        [Fact]
        public async Task LagreIkkeLoggetInn()
        {
            mockRep.Setup(s => s.Lagre(It.IsAny<Strekning>())).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Lagre(It.IsAny<Strekning>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task SlettLoggetInnOK()
        {
            // Arrange

            mockRep.Setup(s => s.Slett(It.IsAny<int>())).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Slett(It.IsAny<int>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Strekning slettet", resultat.Value);
        }

        [Fact]
        public async Task SlettLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(s => s.Slett(It.IsAny<int>())).ReturnsAsync(false);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Slett(It.IsAny<int>()) as NotFoundObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.NotFound, resultat.StatusCode);
            Assert.Equal("Sletting av strekningen ble ikke utført", resultat.Value);
        }

        [Fact]
        public async Task SletteIkkeLoggetInn()
        {
            mockRep.Setup(s => s.Slett(It.IsAny<int>())).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Slett(It.IsAny<int>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task HentEnLoggetInnOK()
        {
            // Arrange
            var strekning1 = new Strekning
            {
                Id = 1,
                Navn = "Larvik - Hirtshals",
                Tid = "10:00",
                Pris = 600,
            };

            mockRep.Setup(s => s.HentEn(It.IsAny<int>())).ReturnsAsync(strekning1);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.HentEn(It.IsAny<int>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal<Strekning>(strekning1, (Strekning)resultat.Value);
        }

        [Fact]
        public async Task HentEnLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(s => s.HentEn(It.IsAny<int>())).ReturnsAsync(() => null);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.HentEn(It.IsAny<int>()) as NotFoundObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.NotFound, resultat.StatusCode);
            Assert.Equal("Fant ikke strekningen", resultat.Value);
        }

        [Fact]
        public async Task HentEnIkkeLoggetInn()
        {
            mockRep.Setup(s => s.HentEn(It.IsAny<int>())).ReturnsAsync(() => null);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.HentEn(It.IsAny<int>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task EndreLoggetInnOK()
        {
            // Arrange

            mockRep.Setup(s => s.Endre(It.IsAny<Strekning>())).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Endre(It.IsAny<Strekning>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Strekningen er endret", resultat.Value);
        }

        [Fact]
        public async Task EndreLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(s => s.Lagre(It.IsAny<Strekning>())).ReturnsAsync(false);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Endre(It.IsAny<Strekning>()) as NotFoundObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.NotFound, resultat.StatusCode);
            Assert.Equal("Endringen av strekningen kunne ikke utføres", resultat.Value);
        }

        [Fact]
        public async Task EndreLoggetInnFeilModel()
        {
            var strekning1 = new Strekning
            {
                Id = 1,
                Navn = "",
                Tid = "10:00",
                Pris = 600,
            };

            mockRep.Setup(s => s.Endre(strekning1)).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            strekningController.ModelState.AddModelError("Navn", "Feil i inputvalidering på server");

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Endre(strekning1) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Feil i inputvalidering på server", resultat.Value);
        }

        [Fact]
        public async Task EndreIkkeLoggetInn()
        {
            mockRep.Setup(s => s.Endre(It.IsAny<Strekning>())).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.Endre(It.IsAny<Strekning>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task LoggInnOK()
        {
            mockRep.Setup(s => s.LoggInn(It.IsAny<Admin>())).ReturnsAsync(true);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.LoggInn(It.IsAny<Admin>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.True((bool)resultat.Value);
        }

        [Fact]
        public async Task LoggInnFeilPassordEllerBruker()
        {
            mockRep.Setup(s => s.LoggInn(It.IsAny<Admin>())).ReturnsAsync(false);

            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await strekningController.LoggInn(It.IsAny<Admin>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.False((bool)resultat.Value);
        }

        [Fact]
        public void LoggUt()
        {
            var strekningController = new StrekningController(mockRep.Object, mockLog.Object);

            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            mockSession[_loggetInn] = _loggetInn;
           strekningController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            strekningController.LoggUt();

            // Assert
            Assert.Equal(_ikkeLoggetInn, mockSession[_loggetInn]);
        }
    }
}
