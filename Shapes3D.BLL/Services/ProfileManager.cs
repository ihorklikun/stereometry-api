using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shapes3D.BLL.Models.User;
using Shapes3D.BLL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services
{
    public class ProfileManager<T> : UserManager<T>, IProfileManager where T : IdentityUser
    {
        public ProfileManager(IUserStore<T> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<T> passwordHasher, IEnumerable<IUserValidator<T>> userValidators,
            IEnumerable<IPasswordValidator<T>> passwordValidators, ILookupNormalizer lookupNormalizer,
            IdentityErrorDescriber identityErrorDescriber, IServiceProvider serviceProvider,
            ILogger<UserManager<T>> logger) :
                base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators,
                lookupNormalizer, identityErrorDescriber, serviceProvider, logger)
        {

        }

        public async Task<string> GetEmailByUserId(Guid id)
        {
            var user = await FindByIdAsync(id.ToString());

            return user.Email;
        }

        public async Task UpdateEmailByUserId(UpdateEmailViewModel model, Guid id)
        {
            var user = await FindByIdAsync(id.ToString());

            if (!await CheckPasswordAsync(user, model.CurrentPassword))
            {
                throw new Exception("Wrong password!");
            }

            await SetEmailAsync(user, model.NewEmail);
            await SetUserNameAsync(user, model.NewEmail);
        }

        public async Task UpdatePasswordByUserId(UpdatePasswordViewModel model, Guid id)
        {
            var user = await FindByIdAsync(id.ToString());

            var operationResult = await ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!operationResult.Succeeded)
            {
                throw new Exception("Wrong password!");
            }
        }

    }
}
