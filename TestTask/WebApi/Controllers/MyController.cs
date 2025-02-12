using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private readonly IPluginManager _plugin;
    public MyController(IPluginManager plugin)
    {
        _plugin = plugin;
    }


    [HttpPost(Name = "UploadImage")]
    public void UploadImage(byte[] image)
    {
        _plugin.UploadImage(image);
    }


    [HttpPost(Name = "Apply")]
    public void Apply(MainModel model)
    {
        _plugin.Apply(model);
    }

    [HttpPost(Name = "Clear")]
    public void Clear(MainModel model)
    {
        _plugin.Apply(model);
    }
}
