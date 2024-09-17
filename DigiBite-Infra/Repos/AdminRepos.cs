using DigiBite_Core.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigiBite_Infra.Repos
{
    public class AdminRepos
    {
        private readonly DigiBiteContext _context;

        public AdminRepos(DigiBiteContext context)
        {
            _context = context;
        }

        public async Task<List<IdentityRole>> GetRoles111() 
        {
            return await _context.Roles.Where(x => x.Name.Contains("C")).ToListAsync();
        }

        public async Task<List<IdentityRole>> GetRoles333()
        {
            return await (from role in _context.Roles
                          where role.Name.Contains("C")
                          select role).ToListAsync();
        }
        public async Task<IEnumerable<IdentityRole>> GetRoles444()
        {
            
            return await (from role in _context.Roles
                          where role.Name.Contains("C")
                          select role).ToListAsync();
        }

        public IQueryable<IdentityRole> GetRolesQuery()
        {
             var x = from role in _context.Roles
                    where role.Name.Contains("C")
                    select role;
            return x;
        }

        public IQueryable<IdentityRole> GetRolesMethod()
        {
           var x= _context.Roles.Where(x => x.Name.Contains("C"));
            return x;
        }

        public async Task<List<IdentityRole>> GetRoles1()
        {
            
            DbSet<IdentityRole> roles = _context.Roles;
            if(roles is null)
            {
                await Task.FromCanceled(new CancellationToken(true));
            }
            IQueryable<IdentityRole> queryable = Queryable.Where(roles, x => x.Name.Contains("C"));
            return await EntityFrameworkQueryableExtensions.ToListAsync<IdentityRole>(queryable, new CancellationToken());
        }

    }
}
