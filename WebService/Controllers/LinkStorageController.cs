
using WebService.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace WebService.Controllers;
/// 
[ApiController]
[Route("api/[controller]")]
public class LinkStorageController : AbstractController
{

    /// 
    public LinkStorageController() { }
    /// <summary>
    /// Тестовый контироллер.
    /// </summary>
    [HttpPost]
    [Route("Test")]
    public async Task<IActionResult> Test() => await ExecuteAnActionAsync(async () =>
    {
       
    });
}