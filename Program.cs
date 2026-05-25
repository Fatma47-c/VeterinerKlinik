using Microsoft.EntityFrameworkCore;
using VeterinerKlinik.Models;

namespace VeterinerKlinik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            builder.Services.AddDbContext<VeterinerKlinikContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<VeterinerAsistanServisi>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Anasayfa}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<VeterinerKlinikContext>();
                context.Database.Migrate();

                if (!context.Hastaliklar.Any())
                {
                    context.Hastaliklar.AddRange(
                        new VeterinerKlinik.Models.Hastalik { Ad = "Gastroenterit", Tedavi = "Sıvı takviyesi ve probiyotik tedavisi", Ucret = 1500 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Dermatit", Tedavi = "Kortikosteroid krem ve antibiyotik", Ucret = 1800 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Üst Solunum Yolu Enfeksiyonu", Tedavi = "Antibiyotik ve buhar tedavisi", Ucret = 2000 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Parazitoz", Tedavi = "Antiparaziter ilaç tedavisi", Ucret = 1200 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Otitis", Tedavi = "Kulak damlası ve temizlik", Ucret = 1100 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Konjunktivit", Tedavi = "Antibiyotikli göz damlası", Ucret = 900 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Anemi", Tedavi = "Demir takviyesi ve destekleyici tedavi", Ucret = 2500 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Hipotiroidi", Tedavi = "Hormon replasman tedavisi", Ucret = 3000 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Artrit", Tedavi = "Antienflamatuar ilaç ve fizik tedavi", Ucret = 2800 },
                        new VeterinerKlinik.Models.Hastalik { Ad = "Pnömoni", Tedavi = "Antibiyotik ve oksijen desteği", Ucret = 4500 }
                    );
                    context.SaveChanges();
                }
            }

            app.Run();
        }
    }
}