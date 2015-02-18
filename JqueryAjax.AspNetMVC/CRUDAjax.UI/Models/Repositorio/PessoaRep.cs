using CRUDAjax.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAjax.UI.Models.DbContext
{
    public class PessoaRep
    {
        //como o foco nao é banco de dados, criamos uma lista estática
        private static List<PessoaModel> _listPessoas;
        //construtor da classe
        public PessoaRep()
        {
            //caso nossa lista nao for instanciada, ele cria a nova instancia
            if (_listPessoas == null)
            {
                _listPessoas = new List<PessoaModel>();

                //caso queira que inicie com algum valor.
                _listPessoas.Add(new PessoaModel { Id = 1, Nome = "Erick Wendel Gomes da Silva", DataNascimento = new DateTime(1995, 04, 25), Email = "erick.workspace@gmail.com" });
                _listPessoas.Add(new PessoaModel { Id = 2, Nome = "Segundo Registro", DataNascimento = DateTime.Now, Email = "erick@erick" });
            }
        }

        /// <summary>
        /// Método responsável pelo cadastro de novas pessoas
        /// </summary>
        /// <param name="pessoa">Recebe o objeto de pessoa</param>
        public void Cadastrar(PessoaModel pessoa)
        {
            //para o objeto static, fizemos esta logica para a cada nova pessoa, adicionar um novo Id
            var y = 1;
            //vai incrementando a variavel até que nao existir
            while (_listPessoas.Any(x => x.Id == y))
                y++;
            pessoa.Id = y;
            //adiciona a pessoa no nosso banco fantasia
            _listPessoas.Add(pessoa);
        }

        /// <summary>
        /// Método Responsável por Atualizar uma pessoa existente
        /// </summary>
        /// <param name="pessoa"></param>
        public void Atualizar(PessoaModel pessoa)
        {
            //pega em nosso banco fantasia aquela pessoa existente
            var pessoaDadoAnterior = GetById(pessoa.Id);
            if (pessoaDadoAnterior != null)
            {
                //usando reflection, pegamos todas as propriedades que nao sejam ID
                //e adicionamos o novo valor do objeto
                foreach (var propertyInfo in typeof(PessoaModel)
                    .GetProperties().Where(x => x.Name != "Id"))
                {
                    //obejto antigo
                    //segundo parametro é onde vai setar o novo valor
                    propertyInfo.SetValue(pessoaDadoAnterior, propertyInfo.GetValue(pessoa));
                }
            }

        }

        /// <summary>
        /// Método Responsável por Remover Pessoas
        /// </summary>
        /// <param name="id">Recebe um Id Da Pessoa como Parametro</param>
        public void Deletar(int id)
        {
            //Pega em nosso banco fantasia aquela pessoa
            var obj = GetById(id);
            //remove da lista aquela pessoa.
            _listPessoas.Remove(obj);
        }

        /// <summary>
        /// Método Responsável por retornar um objeto do tipo pessoa, de nosso banco fantasia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PessoaModel GetById(int id)
        {
            return _listPessoas.SingleOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Retorna a Lista de Pessoas Existentes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PessoaModel> Listar()
        {
            //caso nulo retorna null, senao retorna a lista de pessoas
            return _listPessoas ?? _listPessoas;
        }

    }
}