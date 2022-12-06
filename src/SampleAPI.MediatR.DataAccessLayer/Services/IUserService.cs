﻿using SampleAPI.MediatR.Shared.Models.Requests;
using SampleAPI.MediatR.Shared.Models.Response;

namespace SampleAPI.MediatR.DataAccessLayer.Services;

public interface IUserService
{
    Task<List<UserResponse>> GetAllUsersAsync();
    Task<UserResponse> GetUserAsync(int id);
    Task<bool> CreateUser(UserRequest request);
    Task<bool> UpdateUser(UserRequest request);
    Task<bool> DeleteUser(UserRequest request);
}