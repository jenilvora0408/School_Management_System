using System.ComponentModel.DataAnnotations;
using static Common.Constants.SystemConstants;

namespace Entities.DTOs;

public class BaseListRequestDTO
{
    public int PageIndex { get; set; } = INITIAL_PAGE_SIZE;

    public int PageSize { get; set; } = DEFAULT_PAGE_SIZE;

    [RegularExpression(ModelStateConstant.SORTORDER_REGEX, ErrorMessage = ModelStateConstant.VALIDATE_SORTORDER)]
    public string SortOrder { get; set; } = string.Empty;

    public string SortColumn { get; set; } = DEFAULT_SORTCOLUMN;

    public BaseListRequestDTO()
    {
        PageIndex = PageIndex < 1 ? 1 : PageIndex;
        PageSize = PageSize < 1 ? 4 : PageSize;
    }
}