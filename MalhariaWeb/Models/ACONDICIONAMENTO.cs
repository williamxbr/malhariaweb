using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GenericRepository.EF;
using GenericRepository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MalhariaWeb.Models
{
    public class ACONDICIONAMENTO
    {
        [Key]
        [DisplayName("Id")]
        public int ID_ACONDICIONAMENTO { get; set; }
        [DisplayName("Nome")]
        [Required]
        public string NOME_ACONDICIONAMENTO { get; set; }
        [Required]
        [Display(Name = "Valor", Description = "Ex.: 1,33")]
        [RegularExpression(@"^\d*\,?\d*$", ErrorMessage = "{0} somente números.")]
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        [Range(0.1, 100)]
        public double VALOR { get; set; }
    }
}