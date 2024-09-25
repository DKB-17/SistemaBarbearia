using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(10, ErrorMessage = "Tamanho maximo de 10 caracteres")]
        [Display(Name = "Descricao: ")]
        public string descricao { get; set; }

        [Display(Name = "Valor: ")]
        public float valor { get; set; }
    }
}
