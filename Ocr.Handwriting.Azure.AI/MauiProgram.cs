using Ocr.Handwriting.Azure.AI.Data;
using Ocr.Handwriting.Azure.AI.Lib;
using Ocr.Handwriting.Azure.AI.Services;
using TextCopy;

namespace Ocr.Handwriting.Azure.AI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddScoped<IComputerVisionClientFactory, ComputerVisionClientFactory>();
        builder.Services.AddScoped<IOcrImageService, OcrImageService>();
		builder.Services.AddScoped<IImageSaveService, ImageSaveService>();

		builder.Services.InjectClipboard();

        return builder.Build();
	}
}
