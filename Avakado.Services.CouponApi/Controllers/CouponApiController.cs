using Avakado.Services.CouponApi.Data;
using Avakado.Services.CouponApi.Models;
using Avakado.Services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avakado.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;

        private readonly ResponseDto _responseDto;
        public CouponApiController(AppDbContext appDbContext )
        {
            _db = appDbContext;
            _responseDto = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto Get() {

            try
            {
                IEnumerable<Coupon> objlist = _db.Coupons.ToList();
                List<CouponDto> cuponlist = new List<CouponDto>();
                foreach (var item in objlist)
                {
                    var coupon = new CouponDto();
                    coupon.CouponId = item.Id;  
                    coupon.CouponCode = item.CouponCode;
                    coupon.DiscountAmount = item.DiscountAmount;
                    coupon.MinAmount = item.MinAmount;
                    cuponlist.Add(coupon);
                }
                _responseDto.Result = cuponlist;  

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto  Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(x=> x.Id == id);
                CouponDto couponDto = new ()
                {
                    CouponId = coupon.Id,
                    CouponCode = coupon.CouponCode,
                    DiscountAmount = coupon.DiscountAmount,
                    MinAmount = coupon.MinAmount,
                };
                _responseDto.Result = couponDto;
            }
            catch (Exception ex)
            {
                 _responseDto.IsSuccess=false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
