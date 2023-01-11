using Microsoft.Data.SqlClient;
using WebDapper.Model;
using WebDapper.Repository.Interface;
using Dapper;

namespace WebDapper.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly IConfiguration _configuration;//IConfiguration para pegar as informações da appSettings
        private readonly string connectionString;

        public FilmeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlConnection");
        }



        public async Task<IEnumerable<FilmeResponseModel>> Listar_FilmesAsync()
        {
            string sql = @"SELECT
	                        f.id	Id,
	                        f.nome	Nome,
	                        f.ano	Ano,
	                        p.nome	Produtora
                        FROM tb_filme f
                        JOIN tb_produtora p ON f.id_produtora = p.id";

            //vamos utilizar using,
            //porq eu preciso consumir recursos,
            //eu vou abrir e fechar a conexão
            using var conection = new SqlConnection(connectionString);     
                return await conection.QueryAsync<FilmeResponseModel>(sql);
            
        }

        public async Task<FilmeResponseModel> BuscarId_FilmeAsync(int id)
        {
            string sql = @"SELECT
	                        f.id	Id,
	                        f.nome	Nome,
	                        f.ano	Ano,
	                        p.nome	Produtora
                        FROM tb_filme f
                        JOIN tb_produtora p ON f.id_produtora = p.id
                        WHERE f.id = @Id";

            using var conection = new SqlConnection(connectionString);               //passando meu parametro
            return await conection.QueryFirstOrDefaultAsync<FilmeResponseModel>(sql, new {Id = id});
        }
       
        public async Task<bool> Adiciona_Filme(FilmeRequestModel request)
        {
            var sql = @"INSERT INTO tb_filme (nome, ano, id_produtora)
		                VALUES (@Nome, @Ano, @ProdutoraId)";

            using var conection = new SqlConnection(connectionString);               
            return await conection.ExecuteAsync(sql, request) > 0;//verificando o numero de linhas afetadas
        }                                          //passando meu parametro

        public async Task<bool> Atualizar_Filme(FilmeRequestModel request, int id)
        {
            var sql = @"UPDATE tb_filme SET
	                        nome = @Nome,
	                        ano = @Ano
                        WHERE	id = @ProdutoraId";

            //Quero passar os parametros de forma dinamica

            var parametros = new DynamicParameters(); //criando os parametros dinamicos

            parametros.Add("Nome", request.Nome);
            parametros.Add("Ano", request.Ano);
            parametros.Add("ProdutoraId", id);

            using var conection = new SqlConnection(connectionString);
            return await conection.ExecuteAsync(sql, parametros) > 0;
        }

        public async Task<bool> Deletar_Filme(int id)
        {
            var sql = @"DELETE FROM tb_filme
                        WHERE id = @Id";

            using var conection = new SqlConnection(connectionString);
            return await conection.ExecuteAsync(sql, new {Id = id}) > 0;
        }
    }
}
