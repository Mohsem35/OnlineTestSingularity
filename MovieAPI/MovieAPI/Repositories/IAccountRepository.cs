using Microsoft.AspNetCore.Identity;
using MovieAPI.Models;
using System.Threading.Tasks;

namespace MovieAPI.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
    }
}