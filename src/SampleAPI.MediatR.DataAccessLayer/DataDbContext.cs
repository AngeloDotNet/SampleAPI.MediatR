using Microsoft.EntityFrameworkCore;
using SampleAPI.MediatR.Shared.Models.DTO;

namespace SampleAPI.MediatR.DataAccessLayer;

public partial class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    public virtual DbSet<UserDTO> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserDTO>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(user => user.Id);
        });
    }
}