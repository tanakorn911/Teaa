using Tea.Shared.Services;
using Tea.Web.Components;
using Tea.Web.Services;

namespace Tea
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Add device-specific services used by the Tea.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            
            // Add bubble tea services
            builder.Services.AddSingleton<LanguageService>();
            builder.Services.AddSingleton<BeverageService>();
            builder.Services.AddScoped<CartService>();
            
            // Add HTTP client and payment service
            builder.Services.AddHttpClient<PaymentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(Tea.Shared.Services.LanguageService).Assembly);

            app.Run();
        }
    }
}
