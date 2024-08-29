using BaseServerTest.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.HttpOverrides;
using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.State
{
    public class ApplicationState
    {
        public ApplicationUser CurrentUser { get; set; }
        public ClassifiedUser ClassifiedSeller { get; set; }
        public int GlobalniBroj { get; set; } = 0;
        
        
    }
}
