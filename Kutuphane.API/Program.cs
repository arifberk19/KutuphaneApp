using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Kutuphane.DAL.EntityFramework;
using Kutuphane.DAL.Abstract;
using Kutuphane.DAL.Concrete;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Kutuphane.Core.DTO;

namespace KutuphaneOtomasyon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();

            var cBuilder = new ConfigurationBuilder();
            cBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = cBuilder.Build();
            var connString = configuration.GetConnectionString("KutuphaneDB");

            builder.Services.AddDbContext<KutuphaneContext>(options => options.UseSqlServer(connString));
            builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            builder.Services.AddScoped<IKategoriManager, KategoriManager>();
            builder.Services.AddScoped<IYazarManager, YazarManager>();
            builder.Services.AddScoped<IYayineviManager, YayineviManager>();
            builder.Services.AddScoped<IPersonelManager, PersonelManager>();
            builder.Services.AddScoped<IUyeManager, UyeManager>();
            builder.Services.AddScoped<IKitapKopyaManager, KitapKopyaManager>();
            builder.Services.AddScoped<IKitapManager, KitapManager>();
            builder.Services.AddScoped<IEmanetManager, EmanetManager>();
			builder.Services.AddScoped<IAccountManager, AccountManager>();

			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
			builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection(nameof(JWTExceptURLList)));

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}