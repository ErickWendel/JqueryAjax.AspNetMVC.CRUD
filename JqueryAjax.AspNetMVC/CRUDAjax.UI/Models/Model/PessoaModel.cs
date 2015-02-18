using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAjax.UI
{
    public sealed class PessoaModel
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Email { get; set; }
    }
}