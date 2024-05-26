using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProyectoAPI;
using ProyectoAPI.Middlewares;
using ProyectoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configura la documentacion de Swagger
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tareas y Categorias API",
        Description = "ASP.NET Core Web API - Mi primer acercamiento a Swagger",
        Contact = new OpenApiContact
        {
            Name = "Contacte al creador Sebastian Londoño",
            Url = new Uri("https://www.linkedin.com/in/sebastian-londo%C3%B1o-benitez-06a45051/")
        }
    });
});

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//builder.Services.AddControllers().AddJsonOptions(x =>
//                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//Configuracion EF
//builder.Services.AddSqlServer<TareasContext>("ConexionString");


//string dbPath = Path.Join(Directory.GetCurrentDirectory() + "\\Data", "Demo.db");

//builder.Services.AddDbContext<TareasContext>(options=>  options.UseSqlite("Data Source=Demo.db"));
builder.Services.AddDbContext<TareasContext>(options =>  
    options.UseSqlite(builder.Configuration.GetConnectionString("cnTareas")));
//builder.Services.AddDbContext<TareasContext>(options=>  options.UseSqlite($"Data Source={dbPath}"));


//Verificar que la BD ya exista.


//Inyección de dependencias
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

//Inyectar la dependencia directamente con la clase sin la interfaz, aqui se le puede pasar parametros en el constructor.
//builder.Services.AddScoped(p=> new HelloWorldService());
//builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());

//builder.Build().MigrateDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Middleware de pagina de bienvenida.
//app.UseWelcomePage();

app.UseTimeMiddleware();

app.MapControllers();

app.CreateDatabase().Run();
