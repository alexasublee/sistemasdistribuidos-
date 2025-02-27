using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Repositories;
using PokemonApi.Services;
using SoapCore;

var Builder = WebApplication.CreateBuilder(args);
Builder.Services.AddSoapCore();

Builder.Services.AddScoped<IPokemonService, PokemonService>();
Builder.Services.AddScoped<IPokemonRepository ,PokemonRepository>();
Builder.Services.AddScoped<IHobbiesService , HobbiesService>();
Builder.Services.AddScoped<IHobbiesRepository ,HobbiesRepository>();


Builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(Builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(Builder.Configuration.GetConnectionString("DefaultConnection"))));

//Builder.Services.AddTransient<>();
//Builder.Services.AddSingleton<>();

var app = Builder.Build();

app.UseSoapEndpoint<IPokemonService>("/pokemonService.svc",new SoapEncoderOptions());
app.UseSoapEndpoint<IHobbiesService>("/RoblesAlexaHobbiesService.svc",new SoapEncoderOptions());
app.UseSoapEndpoint<IBookService>("/BookService.svc..svc",new SoapEncoderOptions());





app.Run();