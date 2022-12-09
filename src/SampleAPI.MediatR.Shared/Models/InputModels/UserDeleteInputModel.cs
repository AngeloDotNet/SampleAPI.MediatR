namespace SampleAPI.MediatR.Shared.Models.InputModels;

public class UserDeleteInputModel
{
    public int Id { get; set; }

    public UserDeleteInputModel(int id)
    {
        Id = id;
    }
}