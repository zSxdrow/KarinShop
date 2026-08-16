using KarinShop.Application.Interfaces.Context;
using KarinShop.Application.Interfaces.FacadPatterns.HomePage;
using KarinShop.Application.Services.HomePage.Command.AddNewHomePageImage;
using KarinShop.Application.Services.HomePage.Command.AddNewSlider;
using KarinShop.Application.Services.HomePage.Command.RemoveHomePageImage;
using KarinShop.Application.Services.HomePage.Query.GetHomePageImages;
using KarinShop.Application.Services.HomePage.Query.GetSlider;
using Microsoft.AspNetCore.Hosting;

namespace KarinShop.Application.Services.HomePage.Facade;

public class HomePageFacadeservices : IHomePageFacade
{
    private readonly IDataBaseContext _context;
    private readonly IHostingEnvironment _environment;
    public HomePageFacadeservices(IDataBaseContext context , IHostingEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }


    private AddNewSliderServices _AddNewSliderServices;
    public AddNewSliderServices AddNewSlider
    {
        get
        {
            return _AddNewSliderServices = _AddNewSliderServices ?? new AddNewSliderServices(_context , _environment);
        }
    }
    private IGetSlider _getSlider;
    public IGetSlider getSlider
    {
        get
        {
            return _getSlider = _getSlider ?? new GetSliderServices(_context);
        }
    }
    private AddNewHomePageImageServices _addNewHomePageImage;
    public AddNewHomePageImageServices addNewHomePageImage
    {
        get
        {
            return _addNewHomePageImage = _addNewHomePageImage ?? new AddNewHomePageImageServices(_context , _environment);
        }
    }
    private IGetHomePageImagesServices _getHomePageImages;
    public IGetHomePageImagesServices getHomePageImages
    {
        get
        {
            return _getHomePageImages = _getHomePageImages ?? new GetHomePageImagesServices(_context );
        }
    }
    private RemoveHomePageImageServices _removeHomePageImage;
    public RemoveHomePageImageServices removeHomePageImage
    {
        get
        {
            return _removeHomePageImage = _removeHomePageImage ?? new RemoveHomePageImageServices(_context );
        }
    }
    
}
