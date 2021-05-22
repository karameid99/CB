using CB.Infrastructure.Services.Auction;
using CB.Models.Constants;
using CB.Models.DTOs.Auction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{
    public class AuctionController : BaseController
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuctionCreateDto input)
        {
            if (ModelState.IsValid)
            {
                await _auctionService.Create(input, GetCurrntUserId());
                return Ok(Results.AddSuccessResult());
            }
            return View(input);
        }
    }
}
