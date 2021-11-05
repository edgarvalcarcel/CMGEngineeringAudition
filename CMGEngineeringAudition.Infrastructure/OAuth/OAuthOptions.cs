using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.OAuth
{
    public class OAuthOptions
    {
        public string SigningKey { get; set; }
        public string Audience { get; set; }
        public string Authority { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool RefreshOnIssuerKeyNotFound { get; set; }
        public int ClockSkew { get; set; }
        public bool RequireHttpsMetadata { get; internal set; }
    }
}
