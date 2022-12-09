using SampleAPI.MediatR.Shared.Models.Entities;
using SampleAPI.MediatR.Shared.Models.ViewModels;

namespace SampleAPI.MediatR.DataAccessLayer.Services;

public interface IUserService
{
    Task<List<UserViewModel>> GetAllUsersAsync();
    Task<UserViewModel> GetUserAsync(int id);
    Task<bool> CreateUser(User request);
    Task<bool> UpdateUser(User request);
    Task<bool> DeleteUser(int id);
}