using EducationPlatform.DTOs;
using EducationPlatform.Entities;
using EducationPlatform.Interfaces;

namespace EducationPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.Select(u => new UserDto { UserId = u.UserId, Username = u.Username, FirstName = u.FirstName, LastName = u.LastName, DateOfBirth = u.DateOfBirth, Email = u.Email });
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return user != null ? new UserDto { UserId = user.UserId, Username = user.Username, FirstName = user.FirstName, LastName = user.LastName, DateOfBirth = user.DateOfBirth, Email = user.Email } : null;
        }

        public UserDto CreateUser(CreateUserDto userDto)
        {
            var user = new User { Username = userDto.Username, Password = userDto.Password, FirstName = userDto.FirstName, LastName = userDto.LastName, DateOfBirth = userDto.DateOfBirth, Email = userDto.Email };
            _userRepository.Add(user);
            return new UserDto { UserId = user.UserId, Username = user.Username, FirstName = user.FirstName, LastName = user.LastName, DateOfBirth = user.DateOfBirth, Email = user.Email};
        }

        public UserDto UpdateUser(int id, UpdateUserDto userDto)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
                return null;

            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.DateOfBirth = userDto.DateOfBirth;
            existingUser.Email = userDto.Email;

            _userRepository.Update(existingUser);

            return new UserDto { UserId = existingUser.UserId, Username = existingUser.Username, FirstName = existingUser.FirstName, LastName = existingUser.LastName, DateOfBirth = existingUser.DateOfBirth, Email = existingUser.Email };
        }

        public UserDto DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return null;

            _userRepository.Delete(user);
            return new UserDto { UserId = user.UserId, Username = user.Username, FirstName = user.FirstName, LastName = user.LastName, DateOfBirth = user.DateOfBirth, Email = user.Email };
        }
    }

}
