using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace quick_coffee_api.Controllers;

[Microsoft.AspNetCore.Components.Route("api/products")]
[ApiController]
[Authorize]
public class ProductController
{
    
}