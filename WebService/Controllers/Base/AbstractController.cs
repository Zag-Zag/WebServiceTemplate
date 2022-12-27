using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebService.Controllers.Base;
/// 
public abstract class AbstractController : ControllerBase
{
    ///
    [NonAction]
    protected IActionResult ExecuteAnAction<T>(Func<T> func)
    {
        try
        {
            return Ok(func());
        }
        catch (Exception ex)
        {
            return WebExeption(ex);
        }
    }
    ///
    [NonAction]
    protected async Task<IActionResult> ExecuteAnActionAsync<T>(Func<T> func) =>
        await ExecuteAnActionAsync(async () => await Task.Run(() => func()), (e) => Ok(e));
    ///
    [NonAction]
    protected async Task<IActionResult> ExecuteAnActionAsync<T>(Func<Task<T>> func) =>
        await ExecuteAnActionAsync(func, (e) => Ok(e));
    ///
    [NonAction]
    protected async Task<IActionResult> ExecuteAnActionAsync<T>(Func<Task<T>> func, Func<T, IActionResult> createrResult)
    {
        try
        {
            return createrResult(await func());
        }
        catch (Exception ex)
        {
            return WebExeption(ex);
        }
    }
    private IActionResult WebExeption(Exception ex) => StatusCode(500, ex.ToString());
}
