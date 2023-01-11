using WebDapper.Model;

namespace WebDapper.Repository.Interface
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<FilmeResponseModel>> Listar_FilmesAsync();

        Task<FilmeResponseModel> BuscarId_FilmeAsync(int id);

        Task<bool> Adiciona_Filme(FilmeRequestModel request);

        Task<bool> Atualizar_Filme(FilmeRequestModel request, int id);

        Task<bool> Deletar_Filme(int id);

       
    }
}
