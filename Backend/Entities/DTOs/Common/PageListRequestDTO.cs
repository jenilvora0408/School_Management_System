using System.Linq.Expressions;

namespace Entities.DTOs.Common;

public class PageListRequestDTO<T> : BaseListRequestDTO where T : class
{
    public Expression<Func<T, object>>[]? IncludeExpressions { get; set; }

    public string[]? ThenIncludeExpressions { get; set; }

    public Expression<Func<T, T>>? Selects { get; set; }

    public Expression<Func<T, object>>? OrderByDescending { get; set; }
}
