using System;
using System.Collections.Generic;
using System.Linq;
using auction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static auction.Models.AuctionInfoDBModel;
using static auction.Models.StavkaDBModel;
using static auction.Models.StavkaUserDBModel;

namespace auction.Controllers
{
    [Route("api/auction")]
    [ApiController]
    public class AuctionInfoController : Controller
    {
        [HttpGet("list")]
        public IActionResult GetAuctionInfo()
        {
            try
            {
                var fellows = DatabaseConnections.OrganizationsCatalogDB.auctionInfo;
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

        [HttpGet("{actionId}/{userId}")]
        public IActionResult GetAuctionInfoById([FromRoute] int actionId, [FromRoute] int userId)
        {
            try
            {
                var fellows = DatabaseConnections.OrganizationsCatalogDB.auctionInfo.Find(actionId);
                AuctionInfoInStavka auctionInfoInStavka = new AuctionInfoInStavka();
                auctionInfoInStavka.auctionInfo = fellows;
                if(DatabaseConnections.OrganizationsCatalogDB.Users.Any(x => x.id == userId))
                {
                    var stavki = DatabaseConnections.OrganizationsCatalogDB.stavkaUser.Where(x => x.userId == userId && x.auctionId == actionId);
                    List<StavkaDBModel> listStavka = new List<StavkaDBModel>();
                    foreach(StavkaUserDBModel item in stavki)
                    {
                        var stavkaItem = DatabaseConnections.OrganizationsCatalogDB.stavka.Find(item.stavkaId);
                        listStavka.Add(stavkaItem);
                    }
                    auctionInfoInStavka.listStavka = listStavka;
                }

                if (fellows != null)
                {
                    return Ok(auctionInfoInStavka);
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

        [HttpGet("history/{userId}")]
        public IActionResult GetAuctionInfoByUserId([FromRoute] int userId)
        {
            try
            {
                var userAuction = DatabaseConnections.OrganizationsCatalogDB.auctionInfo.Where(x => x.idUser == userId).Select(item => AuctionInfoDTModel.Convert(item));
                if (userAuction != null && userAuction.Any())
                {
                    return Ok(userAuction);
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

        [HttpPost("add")]
        public IActionResult PostAuctionInfo([FromBody] AuctionInfoDTModel fellowDTModel)
        {
            try
            {
                if (fellowDTModel != null && ModelState.IsValid)
                {
                    DatabaseConnections.OrganizationsCatalogDB.auctionInfo.Add(AuctionInfoDBModel.Convert(fellowDTModel));
                    DatabaseConnections.OrganizationsCatalogDB.SaveChanges();

                    return Created($"{Request.Path}/{DatabaseConnections.OrganizationsCatalogDB.auctionInfo.Last().id}", AuctionInfoDTModel.Convert(DatabaseConnections.OrganizationsCatalogDB.auctionInfo.Last()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Errors.log", $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("stavka/{actionId}")]
        public IActionResult PostStavkaAuction([FromRoute] int actionId, [FromBody] StavkaDTModel stavkaDTModel)
        {
            try
            {
                if (stavkaDTModel != null && ModelState.IsValid)
                {
                    DatabaseConnections.OrganizationsCatalogDB.stavka.Add(StavkaDBModel.Convert(stavkaDTModel));
                    DatabaseConnections.OrganizationsCatalogDB.SaveChanges();

                    StavkaDBModel stavkaDB = DatabaseConnections.OrganizationsCatalogDB.stavka.Last();
                    
                    StavkaUserDBModel stavkaUserDB = new StavkaUserDBModel();
                    stavkaUserDB.auctionId = actionId;
                    stavkaUserDB.stavkaId = stavkaDB.id;
                    stavkaUserDB.userId = stavkaDTModel.idUser;
                    DatabaseConnections.OrganizationsCatalogDB.stavkaUser.Add(stavkaUserDB);

                    DatabaseConnections.OrganizationsCatalogDB.SaveChanges();

                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Errors.log", $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]{Environment.NewLine}{ex.Message}{Environment.NewLine}{Environment.NewLine}");
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}