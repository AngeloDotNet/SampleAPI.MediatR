using SampleAPI.MediatR.DataAccessLayer.UnitOfWork;
using SampleAPI.MediatR.Shared.Models.Entities;
using SampleAPI.MediatR.Shared.Models.ViewModels;

namespace SampleAPI.MediatR.DataAccessLayer.Services;

public class UserService : IUserService
{
    public IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserViewModel>> GetAllUsersAsync()
    {
        IEnumerable<User> baseQuery = await _unitOfWork.Users.GetAllAsync();

        int countRows = baseQuery.Count();

        if (countRows > 0)
        {
            List<UserViewModel> viewModels = baseQuery.Select(x => UserViewModel.FromEntity(x)).ToList();

            if (viewModels != null)
            {
                return viewModels;
            }
        }

        return null;
    }

    public async Task<UserViewModel> GetUserAsync(int userId)
    {
        if (userId > 0)
        {
            var result = await _unitOfWork.Users.GetByIdAsync(userId);

            if (result != null)
            {
                UserViewModel viewModel = UserViewModel.FromEntity(result);

                if (viewModel != null)
                {
                    return viewModel;
                }
            }
        }

        return null;
    }

    public async Task<bool> CreateUser(User request)
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

    public async Task<bool> UpdateUser(User request)
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