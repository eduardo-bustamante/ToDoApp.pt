using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.pt.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite uma descrição.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite uma  data  de vencimento.")]
        public DateTime? Vencimento { get; set; }

        [Required(ErrorMessage = "Digite uma categoria.")]
        public string CategoriaId { get; set; } = string.Empty;

        [ValidateNever]
        public Categoria Categoria { get; set; } = null!;

        [Required(ErrorMessage = "Selecione um  status.")]
        public string SituacaoId { get; set; } = string.Empty;

        [ValidateNever]
        public Situacao Situacao { get; set; } = null!;
        public bool Atrasado => SituacaoId == "aberto" && Vencimento < DateTime.Today;
    }
}
