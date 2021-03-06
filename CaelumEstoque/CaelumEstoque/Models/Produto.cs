﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required, StringLength(20)] //Model Validator. Anotações de validação do C#.
        public String Nome { get; set; }

        [Range(0.0, 10000.0)] // Determina o valor minimo e maximo
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        public int CategoriaId { get; set; }

        public String Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}