using eCommerceMVC.Data;
using eCommerceMVC.Interfaces;
using eCommerceMVC.Models;


namespace eCommerceMVC.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }


    public List<User> GetAll()
    {
        return _context.Users.Where(P => P.IsDeleted == false).ToList();
    }

    public User GetById(int id)
    {
        return _context.Users.FirstOrDefault(p => p.Id == id && p.IsDeleted == false);
    }

    public User Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User Update(User user)
    {
        var userUpdate = _context.Users.FirstOrDefault(p => p.Id == user.Id);
        if (userUpdate == null) return null;

        userUpdate.Name = user.Name;
        userUpdate.Email = user.Email;
        userUpdate.Password = user.Password;
        _context.SaveChanges();
        return userUpdate;
    }

    public void Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(p => p.Id == id);
        user.IsDeleted = true;
        _context.SaveChanges();
    }
}