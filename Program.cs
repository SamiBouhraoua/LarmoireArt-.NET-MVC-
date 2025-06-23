using LarmoireArt.Data;
using LarmoireArt.Data.Services;
using Microsoft.EntityFrameworkCore;
using LarmoireArt.Data.Cart;

namespace LarmoireArt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            //tout les service doivent etre entre cette ligne et : builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("MaConnexion"))); //modifié
            builder.Services.AddScoped<IProduitServices, ProduitService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();

            //Service pour gestion du panier
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            builder.Services.AddSession();

            //
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
