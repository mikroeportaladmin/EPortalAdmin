using EPortalAdmin.Application.Repositories;
using EPortalAdmin.Core.Domain.Entities;
using EPortalAdmin.Core.Persistence.Repositories;

namespace EPortalAdmin.Persistence.Repositories
{
    public class TaxRepository(EPortalAdminDbContext context) : EfRepositoryBase<Tax, EPortalAdminDbContext>(context), ITaxRepository
    {
    }
}