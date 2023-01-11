using Microsoft.AspNetCore.Mvc;
using WebDapper.Model;
using WebDapper.Repository.Interface;

namespace WebDapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _ifilmeRepository;

        public FilmeController(IFilmeRepository ifilmeRepository)
        {
            _ifilmeRepository = ifilmeRepository;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var filmes = await _ifilmeRepository.Listar_FilmesAsync();

            //validando se tem informações
            if (filmes.Any()) return Ok(filmes);
           
            return NoContent();
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var filmes = await _ifilmeRepository.BuscarId_FilmeAsync(id);

            //validando se tem informações
            if (filmes != null) return Ok(filmes);
            
            return NotFound("Filme não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post (FilmeRequestModel request)
        {
            if(string.IsNullOrEmpty(request.Nome) || request.Ano <= 0 || request.ProdutoraId <= 0)
            {                                    //ou
                return BadRequest("Informações invalidas");
            }

            var  filmDb = await _ifilmeRepository.Adiciona_Filme(request);

            return filmDb
                ? Ok("Filme adicionado com sucesso")
                : BadRequest("Erro ao adicionar filme");
        }

        [HttpPut]
        public async Task<IActionResult> Put(FilmeRequestModel request, int id)
        {
            //verificar se o dados existe
            if (id < 0) return BadRequest("Filme invalido");

            var filmeDb = await _ifilmeRepository.BuscarId_FilmeAsync(id);

            //verificar se o filme existe

            if (filmeDb == null) return NotFound("Filme não Existe");

            if(string.IsNullOrEmpty(request.Nome)) request.Nome = filmeDb.Nome;//nome esta vazio?, coloca o nome que esta no Bd.  

            if(request.Ano <= 0) request.Ano = filmeDb.Ano;

            var atualizado = await _ifilmeRepository.Atualizar_Filme(request, id);

            return atualizado
                ? Ok("Filme atualizado com sucesso")
                : BadRequest("Erro ao atualizar filme");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) 
                return BadRequest("Filme invalido");

            var filmeDb = await _ifilmeRepository.BuscarId_FilmeAsync(id);

            if (filmeDb == null) 
                return NotFound("Filme não Existe");

            var delete = await _ifilmeRepository.Deletar_Filme(id);

            return delete
                ? Ok("Filme deletado com sucesso")
                : BadRequest("Erro ao deletar o filme");   
        }
    }
}
