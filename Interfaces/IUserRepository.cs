using eCommerceMVC.Models;

namespace eCommerceMVC.Interfaces;

public interface IUserRepository
{
    List<User> GetAll();
    User GetById(int id);
    User Create(User user);
    User Update(User user);
    void Delete(int id);
    
    
}