using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Arbeitszeitaufzeichnung.Services
{
    public static class Extensions
    {
        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            return int.Parse(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
