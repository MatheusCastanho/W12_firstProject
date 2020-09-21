using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto.Models.Proxy;
using RestEase;

namespace Projeto.Api
{
    [Header("User-Agent","request")]
    public interface IGitHub
    {
         [Get("users/matheuscastanho/repos")]
         Task<Response<List<RepositoriesProxy>>> GetRepositories();
            
        [Get("repos/matheuscastanho/{repo}")]
         Task<Response<RepositoriesProxy>> GetRepository([Path] string repo);
            
            
    }
}