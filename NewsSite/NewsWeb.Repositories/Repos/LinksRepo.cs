using Microsoft.EntityFrameworkCore;
using NewsWeb.Data;
using NewsWeb.Models;
using NewsWeb.Repositories.Interfaces;
using POS_System.Domains.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWeb.Repositories.Repos
{
    public class LinksRepo : ILinksInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public LinksRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Links> AddLinksAsync(Links links)
        {

            _dbContext.Link.Add(links);
            _dbContext.SaveChanges();
            return Task.FromResult(links);

        }

        public Task DeleteLinksAsync(Guid linksId)
        {
            _dbContext.Link.Remove(_dbContext.Link.FirstOrDefault(p => p.Id == linksId));
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Links>> GetAllLinksAsync() =>
            _dbContext.Link.ToListAsync();

        public Task<PagedList<Links>> GetLinks(QueryStringParameters parameters)
        {
            return Task.FromResult(PagedList<Links>.ToPagedList(_dbContext.Link, parameters.PageNumber, parameters.PageSize));
        }


        public Task<Links> GetLinksAsync(Guid linksId) =>
            _dbContext.Link.FirstOrDefaultAsync(p => p.Id == linksId);



        public Task<Links> UpdateLinksAsync(Links linksId)
        {
            _dbContext.Link.Update( linksId);
            _dbContext.SaveChanges();
            return Task.FromResult(linksId);
        }
    }


}
