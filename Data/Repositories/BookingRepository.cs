using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class BookingRepository(DataContext context) : BaseRepository<BookingEntity>(context), IBookingRepository
{
    public override async Task<RepositoryResponse<IEnumerable<BookingEntity>>> GetAllAsync()
    {
        var entities = await _dbSet.Include(b => b.BookingOwner).ThenInclude(bo => bo!.BookingAddressId).ToListAsync();
        return new RepositoryResponse<IEnumerable<BookingEntity>> { Succeeded = true, Result = entities };
    }

    public override async Task<RepositoryResponse<BookingEntity>> GetOneAsync(Expression<Func<BookingEntity, bool>> expression)
    {
        if (expression == null)
            return new RepositoryResponse<BookingEntity> { Succeeded = false, Error = "Expression cannot be null", Result = null };

        var entity = await _dbSet.Include(b => b.BookingOwner).ThenInclude(bo => bo!.BookingAddressId).FirstOrDefaultAsync(expression);

        return entity != null
            ? new RepositoryResponse<BookingEntity> { Succeeded = true, Result = entity }
            : new RepositoryResponse<BookingEntity> { Succeeded = false, Result = null, Error = "Entity not found" };
    }
}
