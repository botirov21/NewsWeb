using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWeb.Repositories.Interfaces
{
    public interface ILinksInterface
    {
        Task<List<Links>> GetAllLinksAsync();
        Task<Links> GetLinksAsync(Guid linksId);
        Task<Links> AddLinksAsync(Links links);
        Task<Links> UpdateLinksAsync(Links linksId);
        Task DeleteLinksAsync(Guid linksId);
    }
}
