using KarinShop.Application.Interfaces.Context;
using KarinShop.Common.Dto;
using KarinShop.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarinShop.Application.Services.HomePage.Command.AddNewHomePageImage
{
    public interface IAddNewHomePageImageServices
    {
        ResultDto Execute(RequestAddNewHomePageImage request);
    }

    public class AddNewHomePageImageServices : IAddNewHomePageImageServices
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewHomePageImageServices(IDataBaseContext context , IHostingEnvironment hostingEnvironment)
        {
            _context = context; 
            _environment = hostingEnvironment; 
        }

        public ResultDto Execute(RequestAddNewHomePageImage request)
        {
            var loc = _context.HomePageImages.Where(p => p.Location == request.Location).FirstOrDefault();
//uniqe

            if (string.IsNullOrWhiteSpace(request.Link))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا لینک را وارد نمایید"
                };
            }
            if(request.Location == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا موقعیت قرار گیری تصویر در صفحه را انتخاب کنید"
                };
            }
            if(request.file == null || request.file.Length == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا تصویر را آپلود کنید"
                };
            }
            var UploadResult = UploadFile(request.file);
            HomePageImage image = new()
            {
                Link = request.Link,
                 Src = UploadResult.FileNameAddress,
                 Location = request.Location,
                 Title = request.Title,
            };
            _context.HomePageImages.Add(image);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "تصویر با موفقیت اضافه شد",
            };

        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
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

    public class RequestAddNewHomePageImage
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation Location { get; set; }
    public string? Title { get; set; }
}

