using EPortalAdmin.Core.Persistence.Paging;

namespace EPortalAdmin.Application.ViewModels.Taxes
{
    public class TaxListDto : BasePageableModel
    {
        public IList<TaxDto> Items { get; set; }
    }
}