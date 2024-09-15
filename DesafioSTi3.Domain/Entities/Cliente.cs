﻿using DesafioSTi3.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSTi3.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public CategoriaCliente Categoria { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
