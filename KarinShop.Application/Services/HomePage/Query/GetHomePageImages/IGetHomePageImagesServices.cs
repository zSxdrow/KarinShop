using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.HomePage;

namespace KarinShop.Application.Services.HomePage.Query.GetHomePageImages
{
    public interface IGetHomePageImagesServices
    {
        ResultDto<List<HomePageImageDto>> Execute();
    }
    public class GetHomePageImagesServices : IGetHomePageImagesServices
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImagesServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImageDto>> Execute()
        {
            var images = _context.HomePageImages.OrderByDescending(p => p.ID)
                .Select(p => new HomePageImageDto()
                {
                    ID = p.ID,
                    Src = p.Src,
                    Link = p.Link,
                    imageLocation = p.Location,
                    Title = p.Title,
                }).ToList();

            return new ResultDto<List<HomePageImageDto>>
            {
                Data = images
            };
        }
    }

    public class HomePageImageDto
    {
        public long ID { get; set; }
        public string Link { get; set; }
        public string Src { get; set; }
        public string? Title { get; set; }
        public ImageLocation imageLocation { get; set; }

    }
}
