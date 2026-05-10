// using eCommerceMVC.DTOs;
// using eCommerceMVC.Interfaces;
// using eCommerceMVC.Models;
//
// public class AuthService
// {
//     private readonly IUserRepository _userRepository;
//     private readonly IConfiguration _configuration;
//
//     public AuthService(IUserRepository userRepository, IConfiguration configuration)
//     {
//         _userRepository = userRepository;
//         _configuration = configuration;
//     }
//
//     public User Register(RegisterDto dto)
//     {
//         var checkUser = _userRepository.GetAll();
//
//     }
//
//     public string Login(LoginDto dto)
//     {
//     }
//
//     public User ForgotPassword(string email, string password)
//     {
//     }
//
//     private string GenerateToken(User user)
//     {
//     }
// }