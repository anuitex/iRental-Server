using iRental.BusinessLogicLayer.Exceptions;
using iRental.BusinessLogicLayer.Helpers;
using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Interfaces.Clients;
using iRental.BusinessLogicLayer.Mappers.User;
using iRental.Domain.Entities.User;
using iRental.ViewModel.RequestModels;
using iRental.ViewModel.ResponseModels;
using iRental.ViewModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Services
{
    public class AccountService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly JwtManager _jwtManager;
        private readonly IFileUploader _fileUploader;

        public AccountService(
            ApplicationUserManager userManager,
            SignInManager<UserEntity> signInManager,
            JwtManager jwtManager,
            IFileUploader fileUploader
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtManager = jwtManager;
            _fileUploader = fileUploader;
        }

        public async Task<UserEntity> SignUpAsync(UserCreateRequest request)
        {
            var user = UserCreateMapper.Map(request);
            var identityResult = await _userManager.CreateAsync(user, request.Password);

            if (!identityResult.Succeeded)
            {
                throw new IdentityException { Errors = identityResult.Errors };
            }


            if (request.Avatar != null)
            {
                using (MemoryStream avatarStream = new MemoryStream())
                {
                    request.Avatar.CopyTo(avatarStream);

                    var avatarPhotoEntity = await _fileUploader.UploadAvatarPhotoAsync(avatarStream, contentType: request.Avatar.ContentType);
                    user.Avatar = avatarPhotoEntity;
                    await _userManager.UpdateAsync(user);
                }
            }

            return user;
        }

        public async Task<string> CreateEmailConfirmCodeAsync(UserEntity user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return code;
        }

        public async Task<JwtTokensReponse> RefreshTokensAsync(RefreshTokenRequest request)
        {
            var refreshSecurityToken = _jwtManager.JwtSecurityTokenHandler.ReadJwtToken(request.RefreshToken);
            var userIdClaim = refreshSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new InvalidOperationException("UserId can't found in claims");
            }

            if (refreshSecurityToken.ValidTo < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Token invalid");
            }

            var user = await _signInManager.UserManager.FindByIdAsync(userIdClaim.Value);

            var jwtAuth = new JwtTokensReponse
            {
                AccessToken = _jwtManager.GenerateAccessToken(user, user.Roles),
                RefreshToken = _jwtManager.GenerateRefreshToken(user)
            };

            return jwtAuth;
        }

        public async Task ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var resultConfirm = await _userManager.ConfirmEmailAsync(user, code);

            if (!resultConfirm.Succeeded)
            {
                throw new IdentityException { Errors = resultConfirm.Errors };
            }
        }

        public async Task<JwtTokensReponse> SignInAsync(SignInRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Login);
            if (user == null)
            {
                return null;
            }

            var resultSignIn = await _signInManager.PasswordSignInAsync(request.Login, request.Password, true, false);
            if (!resultSignIn.Succeeded)
            {
                return null;
            }

            var jwtResponse = new JwtTokensReponse
            {
                AccessToken = _jwtManager.GenerateAccessToken(user, user.Roles),
                RefreshToken = _jwtManager.GenerateRefreshToken(user)
            };

            return jwtResponse;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
