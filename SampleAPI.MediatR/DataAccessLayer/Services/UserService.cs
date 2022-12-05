using SampleAPI.MediatR.DataAccessLayer.UnitOfWork;
using SampleAPI.MediatR.Models.Requests;
using SampleAPI.MediatR.Models.Response;

namespace SampleAPI.MediatR.DataAccessLayer.Services;

public class UserService : IUserService
{
    public IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserResponse>> GetAllUsersAsync()
    {
        var result = await _unitOfWork.userRepository.GetAllAsync();

        return result;
    }

    public async Task<UserResponse> GetUserAsync(int id)
    {
        var user = await _unitOfWork.userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        return user;
    }

    public async Task<bool> CreateUser(UserRequest request)
    {
        if (request == null)
        {
            return false;
        }

        var response = await _unitOfWork.userRepository.CreateAsync(request);

        if (!response)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateUser(UserRequest request)
    {
        if (request == null)
        {
            return false;
        }

        var response = await _unitOfWork.userRepository.UpdateAsync(request);

        if (!response)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteUser(UserRequest request)
    {
        if (request.Id == 0)
        {
            return false;
        }

        var response = await _unitOfWork.userRepository.DeleteAsync(request);

        if (!response)
        {
            return false;
        }

        return true;
    }
}