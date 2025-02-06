using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]

    public class UsersController : ControllerBase
    {
        // POST api/users
        [HttpPost]
        public IActionResult PostUser()
        {
            return Ok();
        }
        
        //POST api/users
        [HttpPut("profile-picture/{id}")]
        public IActionResult PutProfilePiscture(IFormFile file)
        {
            var description = $"FIle: {file.FileName}, Size: {file.Length}";
            
            //Processar a imagem
            
            
            return Ok(description);
            
        }
    }
}

