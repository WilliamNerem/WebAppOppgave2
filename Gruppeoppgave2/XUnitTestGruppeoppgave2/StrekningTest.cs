using EF_2.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestGruppeoppgave2
{
    public class StrekningTest
    {
        [Fact]
        public async Task Lagre()
        {
            // Arrange
            var innStrekning = new Strekning
            {
                Id = 1,
                Navn = "Oslo - Kiel",
                Pris = 700
            };

            var mock = new Mock<IStrekningRepository>();
        }
    }
}
