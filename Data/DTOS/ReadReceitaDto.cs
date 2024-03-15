﻿using System.ComponentModel.DataAnnotations;

namespace Controle_Financeiro.Data.DTOS
{
    public class ReadReceitaDto
    {
        [Required]
        public string Descricao_Receita { get; set; }
        [Required]
        public double Valor_Receita { get; set; }
        [Required]
        public DateTime Data_Receita { get; set; }
    }
}
