using Microsoft.EntityFrameworkCore;
using SampleAPI.MediatR.DataAccessLayer.Entities;
using SampleAPI.MediatR.Models.Requests;
using SampleAPI.MediatR.Models.Response;

namespace SampleAPI.MediatR.DataAccessLayer.Repository.Generic;

public abstract class GenericRepository : IGenericRepository
{
    protected readonly DataDbContext _dbContext;

    protected GenericRepository(DataDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<UserResponse>> GetAllAsync()
    {
        IQueryable<User> baseQuery = _dbContext.Users;

        var queryLinq = baseQuery
            .AsNoTracking();

        var result = await queryLinq
            .Select(utente => UserResponse.ToUserViewModel(utente))
            .ToListAsync();

        return result;
    }

    public async Task<UserResponse> GetByIdAsync(int id)
    {
        var queryLinq = _dbContext.Users
            .AsNoTracking()
            .Where(utente => utente.Id == id)
            .Select(utente => UserResponse.ToUserViewModel(utente));

        var result = await queryLinq.FirstOrDefaultAsync();

        return result;
    }

    public async Task<bool> CreateAsync(UserRequest entity)
    {
        User user = new()
        {
            Id = entity.Id,
            Cognome = entity.Cognome,
            Nome = entity.Nome,
            Telefono = entity.Telefono,
            Email = entity.Email
        };

        _dbContext.Add(user);

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateAsync(UserRequest entity)
    {
        var user = await _dbContext.Users.FindAsync(entity.Id);

        if (user == null)
        {
            throw new Exception();
        }

        user.Id = entity.Id;
        user.Cognome = entity.Cognome;
        user.Nome = entity.Nome;
        user.Telefono = entity.Telefono;
        user.Email = entity.Email;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteAsync(UserRequest entity)
    {
        User user = await _dbContext.Users.FindAsync(entity.Id);

        if (user == null)
        {
            throw new Exception();
        }

        _dbContext.Remove(user);

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }
}