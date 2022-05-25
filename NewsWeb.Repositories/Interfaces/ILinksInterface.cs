using NewsWeb.Models;
using POS_System.Domains.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWeb.Repositories.Interfaces
{
    public interface ILinksInterface
    {
        Task<PagedList<Links>> GetLinks(QueryStringParameters parameters);
        Task<List<Links>> GetAllLinksAsync();
        Task<Links> GetLinksAsync(Guid linksId);
        Task<Links> AddLinksAsync(Links links);
        Task<Links> UpdateLinksAsync(Links linksId);
        Task DeleteLinksAsync(Guid linksId);
    }
}
