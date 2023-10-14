using AutoMapper;
using Microsoft.Extensions.Configuration;
using Taller.Application.Admins.Dtos.Users;
using Taller.Application.Cores.Exceptions;
using Taller.Core.Securities.Services;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.Application.Admins.Services.Implementations
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _securityService = securityService;
        }

        public async Task<UserDto> CreateAsync(UserSaveDto saveDto)
        {
            User user = _mapper.Map<User>(saveDto);
            user.State = true;
            user.RegistrationDate = DateTime.Now;

            user.Password = _securityService.HasPassword(saveDto.Name, saveDto.Password);

            await _userRepository.SaveAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public Task<UserDto> DisabledAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> EditAsync(int id, UserSaveDto saveDto)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserDto>> findAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSecurityDto> LoginAsync(UserAuthDto auth)
        {
            User? user = await _userRepository.FindByEmailAsync(auth.Email);

            if (user is null) throw new NotFoundCoreException("Usuario no esta registaado en el sistema");

            bool isCorrect = _securityService.VerifyHashedPassword(user.Email, user.Password, auth.Password);


            if (!isCorrect) throw new NotFoundCoreException("La contraseña que ingreso no es correcto");

            if (!user.State) throw new NotFoundCoreException("Usuario no esta activo, Comuniquese con el administrador");

            UserSecurityDto userSecutiry = _mapper.Map<UserSecurityDto>(user);

            string jwtSecretKey = _configuration.GetSection("Secutiry:JwSecrectKey").Get<string>();

            userSecutiry.Security = _securityService.JwtSecutiry(jwtSecretKey);

            return userSecutiry;
        }
    }
}
