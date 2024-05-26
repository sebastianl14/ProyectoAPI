using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Models;

namespace ProyectoAPI;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        
        CreateCategoria(modelBuilder);
        /*
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Nombre = "Actividades pendientes", Peso = 20});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Nombre = "Actividades personales", Peso = 50});

        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p=> p.Peso);
            categoria.HasData(categoriasInit);
        }); */

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en netflix", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb412"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), PrioridadTarea = Prioridad.Alta, Titulo = "Tarea 3", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb413"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), PrioridadTarea = Prioridad.Baja, Titulo = "Tarea 4", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb414"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb404"), PrioridadTarea = Prioridad.Media, Titulo = "Tarea 5", FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
            tarea.Ignore(p=> p.Resumen);

            tarea.HasData(tareasInit);
        });

    }

    private void CreateCategoria(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p=> p.Peso);

            categoria.HasData(CategoriasIniciales());
        });
    }

    private List<Categoria> CategoriasIniciales()
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Nombre = "Actividades pendientes", Peso = 20});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Nombre = "Actividades personales", Peso = 50});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb403"), Nombre = "Categoria 3", Peso = 30});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb404"), Nombre = "Categoria 4", Peso = 40});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb405"), Nombre = "Categoria 5", Peso = 5});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb406"), Nombre = "Categoria 6", Peso = 6});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb407"), Nombre = "Categoria 7", Peso = 7});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb408"), Nombre = "Categoria 8", Peso = 8});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb409"), Nombre = "Categoria 9", Peso = 9});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), Nombre = "Categoria 10", Peso = 10});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), Nombre = "Categoria 11", Peso = 40});

        return categoriasInit;
    }

}