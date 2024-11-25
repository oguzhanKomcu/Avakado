using Avakado.Services.CouponApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avakado.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CouponApiController(AppDbContext appDbContext )
        {
            _db = appDbContext;
        }
    }
}
