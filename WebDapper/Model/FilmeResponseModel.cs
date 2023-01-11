using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebDapper.Model;

namespace WebDapper
{
    public class FilmeResponseModel
    {
        
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        public int Ano { get; set; }

        [MaxLength(30)]
        public string Produtora { get; set; }
        
    }
}
