using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_DB;

public class ARepository<TEntity>: IRepository<TEntity> where TEntity : class
{
    private LibraryContext _context;
    private DbSet<TEntity> table;
    
    public ARepository(LibraryContext context)
    {
        _context = context;
        table = _context.Set<TEntity>();
    }
    public TEntity Create(TEntity t)
    {
        table.Add(t);
        _context.SaveChanges();
        return t;
    }

    public List<TEntity> CreateRange(List<TEntity> list)
    {
        table.AddRange(list);
        _context.SaveChanges();
        return list;
    }

    public void Update(TEntity t)
    {
        _context.ChangeTracker.Clear();
        
        table.Update(t);
        _context.SaveChanges();
        
    }

    public void UpdateRange(List<TEntity> list)
    {
        _context.ChangeTracker.Clear();
        
        table.UpdateRange(list);
    }

    public TEntity? Read(int id) => table.Find(id);
 

    public List<TEntity> Read(Expression<Func<TEntity, bool>> filter) => table.Where(filter).ToList();
    

    public List<TEntity> Read(int start, int count) => table.Skip(start).Take(count).ToList();
    

    public List<TEntity> ReadAll() => table.ToList();
    

    public void Delete(TEntity t)
    {
        table.Remove(t);
        _context.SaveChanges();
    }
}