using System;
using System.Linq;
using auction.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static auction.Models.UserDBModel;

namespace auction.Controllers
{
    [EnableCors()]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("list")]
        public IActionResult GetUsers()
        {
            try
            {
                var fellows = DatabaseConnections.OrganizationsCatalogDB.Users;
                if (fellows != null && fellows.Any())
                {
                    return Ok(fellows.ToList());
                }
                else 
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Errors.log", $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("auth")]
        public IActionResult GetAuth([FromBody] UserDTModel fellowDTModel)
        {
            try
            {
                if(fellowDTModel != null && fellowDTModel.email != null && fellowDTModel.password != null)
                {
                    var fellows = DatabaseConnections.OrganizationsCatalogDB.Users.Any( item => (item.password == fellowDTModel.password && item.email == fellowDTModel.email));
                    if (fellows)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Errors.log", $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("register")]
        public IActionResult PostRegister([FromBody] UserDTModel fellowDTModel)
        {
            try
            {
                if (fellowDTModel != null && ModelState.IsValid)
                {
                    DatabaseConnections.OrganizationsCatalogDB.Users.Add(UserDBModel.Convert(fellowDTModel));
                    DatabaseConnections.OrganizationsCatalogDB.SaveChanges();

                    return Created($"{Request.Path}/{DatabaseConnections.OrganizationsCatalogDB.Users.Last().id}", UserDTModel.Convert(DatabaseConnections.OrganizationsCatalogDB.Users.Last()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Errors.log", $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("info/{userId}")]
        public IActionResult GetUserById([FromRoute] int userId)
        {
            try
            {
                var fellows = DatabaseConnections.OrganizationsCatalogDB.Users.Where(item => item.id == userId);
                if (fellows != null && fellows.Any())
                {
                    return Ok(fellows);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Errors.log", $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}