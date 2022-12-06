using SampleAPI.MediatR.Shared.Entities;

namespace SampleAPI.MediatR.Shared.Models.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public static UserResponse ToUserViewModel(User dataRow)
    {
        return new UserResponse
        {
            Id = dataRow.Id,
            Cognome = dataRow.Cognome,
            Nome = dataRow.Nome,
            Telefono = dataRow.Telefono,
            Email = dataRow.Email
        };
    }
}