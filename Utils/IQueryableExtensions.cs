using ProyectoAPI.Dto;

namespace ProyectoAPI.Utils;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
    {
        return queryable
            .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina)
            .Take(paginacionDTO.RecordsPorPagina);
    }
}