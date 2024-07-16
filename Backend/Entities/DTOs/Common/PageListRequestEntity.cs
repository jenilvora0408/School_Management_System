using System.Linq.Expressions;
using Entities.DTOs.Common;

namespace Entities.DTOs;

public class PageListRequestEntity<T> : BaseListRequestDTO where T : class
{
    public Expression<Func<T, bool>>? Predicate { get; set; }

    public Expression<Func<T, object>>[]? IncludeExpressions { get; set; }

    public string[]? ThenIncludeExpressions { get; set; }

    public Expression<Func<T, T>>? Selects { get; set; }
}
