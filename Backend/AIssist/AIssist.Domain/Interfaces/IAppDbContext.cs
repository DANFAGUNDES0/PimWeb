using AIssist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIssist.Domain.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Profiles> Profiles { get; }
        DbSet<Users> Users { get; }
        DbSet<RootCause> RootCauses { get; }
        DbSet<Tickets> Tickets { get; }
        DbSet<Logs> Logs { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void Atualizar<T>(T entity, T updatedEntity) where T : class;
    }
}

