using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_DB;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly LibraryContext _context;
    private readonly DbSet<TEntity> table;

    public ARepository(LibraryContext context)
    {
        _context = context;
        table = _context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity t)
    {
        await table.AddAsync(t);
        await _context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        await table.AddRangeAsync(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(TEntity t)
    {
        _context.ChangeTracker.Clear();
        table.Update(t);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        _context.ChangeTracker.Clear();
        table.UpdateRange(list);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id) => await table.FindAsync(id);

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) => 
        await table.Where(filter).ToListAsync();

    public async Task<List<TEntity>> ReadAsync(int start, int count) => 
        await table.Skip(start).Take(count).ToListAsync();

    public async Task<List<TEntity>> ReadAllAsync() => await table.ToListAsync();

    public async Task DeleteAsync(TEntity t)
    {
        table.Remove(t);
        await _context.SaveChangesAsync();
    }
}