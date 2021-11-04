using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2.Models
{
    [ExcludeFromCodeCoverage]
    public class Admin
    {
        public String Brukernavn { get; set; }

        public String Passord { get; set; }
    }
}
