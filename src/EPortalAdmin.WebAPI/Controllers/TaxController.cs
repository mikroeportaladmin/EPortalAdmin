using EPortalAdmin.Application.Features.Taxes.Commands;
using EPortalAdmin.Application.Features.Taxes.Queries;
using EPortalAdmin.Application.Features.UserOperationClaims.Queries;
using EPortalAdmin.Core.Attributes;
using EPortalAdmin.Core.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EPortalAdmin.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/tax-management")]
    [ApiController]
    public class TaxController : BaseController
    {
        [HttpGet("tax")]
        [ExplorableEndpoint(Description = "Vergileri Listeleme")]
        public async Task<IActionResult> GetTaxList([FromQuery] GetTaxListQuery getTaxListQuery)
        {
            return Ok(await Mediator.Send(getTaxListQuery));
        }
        
        [HttpPost("tax")]
        [ExplorableEndpoint(Description = "Vergi ekle/güncelle")]
        public async Task<IActionResult> AddTax([FromBody] SaveTaxCommand saveTaxCommand)
        {
            return Ok(await Mediator.Send(saveTaxCommand));
        }
        
        [HttpDelete("tax/{taxId}")]
        [ExplorableEndpoint(Description = "Vergi sil")]
        public async Task<IActionResult> DeleteTax([FromRoute] int taxId)
        {
            return Ok(await Mediator.Send(new DeleteTaxCommand{ Id = taxId}));
        }
    }
}