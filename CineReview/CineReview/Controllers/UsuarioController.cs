using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public static List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        //POST
        [HttpPost(Name = "PostUser")]
        public ActionResult PostUser(Usuario user)
        {
            Usuarios.Add(user);
            return Ok("Usuario Adicionado com sucesso");
        }

        //GETALL
        [HttpGet(Name = "GetUsers")]
        public ActionResult<List<Usuario>> GetAll()
        {
            return Ok(Usuarios);
        }

        //GETBYID
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var user = Usuarios.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        //PUT
        [HttpPut("{id}")]
        public ActionResult Put(int id, Usuario user)
        {
            var usuario = Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
                return NotFound();

            //Update
            usuario.Nome = user.Nome;
            usuario.Email = user.Email;

            return Ok(user);
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario == null)
                return NotFound();
            Usuarios.Remove(usuario);
            return Ok("Usuario deletado com sucesso");

        }

    }
}
