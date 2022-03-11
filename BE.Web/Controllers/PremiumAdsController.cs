using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Web.Models.Api;
using BE.Web.Models.View;
using BE.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE.Web.Controllers
{
    public class PremiumAdsController : Controller
    {
        private readonly IPremiumAdsService premiumAdsService;
        public IEnumerable<Location> locations;
        public IEnumerable<SubCategory> subcategories;
        public PremiumAdsController(IPremiumAdsService premiumAdsService)
        {
            this.premiumAdsService = premiumAdsService;
        }
        public async Task<IActionResult> Index()
        {
            return View(new PremiumAdListModel { PremiumAds = await premiumAdsService.GetPremiumAds() });
        }

        public async Task<IActionResult> AddNew()
        {
            locations = await premiumAdsService.GetLocations();
            //Subcategories can be loaded as per the location dropdown change to make it more robust. 
            subcategories = await premiumAdsService.GetSubCategories(); 


            return View(new AddNewModel {
                Locations = locations, 
                SubCategories = subcategories,
                SelectedLocationId = string.Empty 
            });
        }

        [HttpPost]
        public  async Task<IActionResult> AddNewPremium(AddNewModel addNewModel)
        {
            await premiumAdsService.CreatePremiumAd(new PremiumAds
            {
                LocationsID = Convert.ToInt32(addNewModel.SelectedLocationId),
                SubCategoryID = Convert.ToInt32(addNewModel.SelectedSubcategoryId),
                PremiumStart = addNewModel.PremiumStart,
                PremiumEnd = addNewModel.PremiumEnd,
            });
            return RedirectToAction("Index", new { categoryId = addNewModel.SelectedLocationId });
        }

    }
}
