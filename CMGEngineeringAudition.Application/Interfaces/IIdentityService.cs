using CMGEngineeringAudition.Application.DTOs.Identity;
using AspNetCoreHero.Results;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<Result<TokenResponse>> GetTokenAsync(TokenRequest request, string ipAddress);
    }
}
