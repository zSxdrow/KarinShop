using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;

namespace KarinShop.Application.Services.HomePage.Query.GetSlider
{
    public interface IGetSlider
    {
        ResultDto<List<GetSliderDto>> Execute();
    }
    public class GetSliderServices : IGetSlider
    {
        private readonly IDataBaseContext _context;
        public GetSliderServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetSliderDto>> Execute()
        {
            var Slider = _context.Sliders.OrderByDescending(p => p.ID)
                  .Select(p => new GetSliderDto
                  {
                      Link = p.Link,
                      Src = p.Src,
                  }).ToList();
            return new ResultDto<List<GetSliderDto>>
            {
                Data = Slider
            };
        }
    }

    public class GetSliderDto
    {
        public string Link { get; set; }
        public string Src { get; set; }
    }
}
