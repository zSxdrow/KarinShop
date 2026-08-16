using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Common.Dto.UploadDto;
using KarinShop.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KarinShop.Application.Services.HomePage.Command.AddNewSlider
{
    public interface IAddNewSlider
    {
        ResultDto Execute(IFormFile File, string Link);
    }
    public class AddNewSliderServices : IAddNewSlider
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewSliderServices(IDataBaseContext context , IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(IFormFile File, string Link)
        {
            if(string.IsNullOrEmpty(Link))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا لینک را وارد کنید"
                };
            }
            if(File == null || File.Length < 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا یک عکس برای اسلایدر انتخاب کنید"
                };
            }
            var resultUpload = UploadFile(File);

            Slider slider = new()
            {
                Link = Link,
                Src = resultUpload.FileNameAddress,
            };
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "اسلایدر با موفقیت اضافه شد"
            };
        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images/HomePages/Slider/";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
}
