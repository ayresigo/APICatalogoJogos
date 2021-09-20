using APICatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            { Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Jogo{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Fifa 21", Produtora = "EA", Preco = 200 } },
            { Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Jogo{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Fifa 19", Produtora = "EA", Preco = 150 } },
            { Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Jogo{ Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Nome = "Call of Duty: Modern Warfare", Produtora = "Infinity Ward", Preco = 250 } },
            { Guid.Parse("0a88b471-2335-4ef1-9fd8-b2509a16a815"), new Jogo{ Id = Guid.Parse("0a88b471-2335-4ef1-9fd8-b2509a16a815"), Nome = "Call of Duty: Cold War", Produtora = "Infinity Ward", Preco = 250 } }
            
            
        };

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo); 
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
    }
}
