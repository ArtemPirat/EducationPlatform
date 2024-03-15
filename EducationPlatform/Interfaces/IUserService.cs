using EducationPlatform.DTOs;

namespace EducationPlatform.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        UserDto CreateUser(CreateUserDto userDto);
        UserDto UpdateUser(int id, UpdateUserDto userDto);
        UserDto DeleteUser(int id);
    }
}
