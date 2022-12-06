using SampleAPI.MediatR.Shared.Models.Requests;
using SampleAPI.MediatR.Shared.Models.Response;

namespace SampleAPI.MediatR.DataAccessLayer.Repository.Generic;

public interface IGenericRepository
{
    Task<List<UserResponse>> GetAllAsync();
    Task<UserResponse> GetByIdAsync(int id);
    Task<bool> CreateAsync(UserRequest entity);
    Task<bool> UpdateAsync(UserRequest entity);
    Task<bool> DeleteAsync(UserRequest entity);
}