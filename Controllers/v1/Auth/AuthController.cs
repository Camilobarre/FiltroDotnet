using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Auth
{
    [ApiController]
    [Route("api/v1/authentication")]
    public class AuthController : ControllerBase
    {
        protected readonly IUserRepository _userRepository; // Repositorio protegido

        // Constructor que inyecta el repositorio
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository; // Asigna el repositorio
        }
    }
}