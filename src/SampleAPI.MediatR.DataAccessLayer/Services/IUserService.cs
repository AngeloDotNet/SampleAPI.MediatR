using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.DataAccessLayer.Services;

public interface IUserService
{
    Task<List<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetUserAsync(int id);
    Task<bool> CreateUser(UserDTO request);
    Task<bool> UpdateUser(UserDTO request);
    Task<bool> DeleteUser(int id);
}