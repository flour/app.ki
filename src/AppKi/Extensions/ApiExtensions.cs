using Microsoft.AspNetCore.Mvc;
using IResult = AppKi.Commons.Models.IResult;

namespace AppKi.Extensions;

internal static class ServicesExtensions
{
    public static IActionResult R(this ControllerBase controllerBase, IResult result)
    {
        return controllerBase.StatusCode(result.StatusCode, result);
    }
}