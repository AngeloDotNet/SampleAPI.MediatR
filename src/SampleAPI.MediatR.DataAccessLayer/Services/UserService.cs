using SampleAPI.MediatR.DataAccessLayer.UnitOfWork;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.DataAccessLayer.Services;

public class UserService : IUserService
{
    public IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var result = await _unitOfWork.Users.GetAllAsync();

        return result;
    }

    public async Task<UserDTO> GetUserAsync(int userId)
    {
        if (userId > 0)
        {
            var result = await _unitOfWork.Users.GetByIdAsync(userId);

            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    public async Task<bool> CreateUser(UserDTO request)
    {
        if (request != null)
        {
            var result = await _unitOfWork.Users.CreateAsync(request);

            if (result == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public async Task<bool> UpdateUser(UserDTO request)
    {
        if (request != null)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

            if (user != null)
            {
                var result = await _unitOfWork.Users.UpdateAsync(request);

                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

    public async Task<bool> DeleteUser(int Id)
    {
        if (Id > 0)
        {
            var userDetail = await _unitOfWork.Users.GetByIdAsync(Id);

            if (userDetail != null)
            {
                var result = await _unitOfWork.Users.DeleteAsync(userDetail);

                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }
}