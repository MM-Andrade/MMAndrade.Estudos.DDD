using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades
{
    public class Prato : EntidadeBase
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
