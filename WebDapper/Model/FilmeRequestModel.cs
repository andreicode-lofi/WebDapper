using System.ComponentModel.DataAnnotations;

namespace WebDapper.Model
{
    public class FilmeRequestModel
    {
        [MaxLength(50)]
        public string Nome { get; set; }

        public int Ano { get; set; }

        public int ProdutoraId { get; set; }
    }
}
