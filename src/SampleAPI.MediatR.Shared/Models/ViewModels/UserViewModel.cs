using SampleAPI.MediatR.Shared.Models.Entities;

namespace SampleAPI.MediatR.Shared.Models.ViewModels;

public class UserViewModel
{
    public int Id { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public static UserViewModel FromEntity(User user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            Cognome = user.Cognome,
            Nome = user.Nome,
            Telefono = user.Telefono,
            Email = user.Email,
        };
    }
}