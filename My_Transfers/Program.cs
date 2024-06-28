using Blazored.LocalStorage;
using My_Transfers.Class;
using My_Transfers.Data;
using My_Transfers.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using Radzen;
using Syncfusion.Blazor;

namespace My_Transfers
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddSingleton<WeatherForecastService>();
			builder.Services.AddRadzenComponents();
			builder.Services.AddSyncfusionBlazor();
			builder.Services.AddScoped<UserService>();
			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddSingleton<IMailService, SMTPMailService>();
			builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));



			static void ConfigureServices(IServiceCollection services)
			{
				// Access configuration
				var configuration = new ConfigurationBuilder()
					.SetBasePath(Environment.CurrentDirectory)
					.AddJsonFile("appsettings.json")
					.Build();

				services.Configure<MailConfiguration>(configuration.GetSection("MailConfiguration"));

			}



			Syncfusion.Licensing.SyncfusionLicenseProvider
				   .RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWXZfeHVTRGVZUkRxXko=");
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}


			app.UseStaticFiles();

			app.UseRouting();
			app.UseRequestLocalization("ar-EG");

			app.MapBlazorHub();
			app.MapFallbackToPage("/_Host");

			app.Run();
		}
	}
}
