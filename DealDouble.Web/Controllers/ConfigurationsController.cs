using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class ConfigurationsController : Controller
    {
        ConfigurationsService configurationsService = new ConfigurationsService(); 

        public ActionResult Index(int? configurationType, string searchTerm, int? pageNo, bool isPartial = false)
        {
            var pageSize = 10;

            ConfigurationsListingViewModels model = new ConfigurationsListingViewModels();

            model.PageTitle = "Configurations";
            model.PageDescription = "Configurations Listing Page";

            model.ConfigurationType = configurationType;
            model.SearchTerm = searchTerm;
            model.PageNo = pageNo ?? 1;

            model.Configurations = configurationsService.SearchConfigurations(configurationType, searchTerm, pageNo, pageSize);

            var totalConfigurations = configurationsService.GetConfigurationsCount(configurationType, searchTerm);

            model.Pager = new Pager(totalConfigurations, pageNo, pageSize);

            if(isPartial)
            {
                return PartialView("_Listing", model);
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult Edit(string key)
        {
            var configuration = configurationsService.GetConfigurationByKey(key);

            if (configuration == null) return HttpNotFound();

            if(configuration.ConfigurationType == (int)ConfigurationType.HomeSliders)
            {
                return PartialView("_HomeSlidersEdit", configuration);
            }
            else return PartialView("_Edit", configuration);
        }

        [HttpPost]
        public ActionResult Edit(Configuration configuration)
        {
            if (configuration == null) return HttpNotFound();

            if (configuration.ConfigurationType == (int)ConfigurationType.HomeSliders)
            {
                configurationsService.UpdateConfigurationValue(configuration.Key, configuration.Value);
            }
            else
            {
                configurationsService.UpdateConfiguration(configuration);
            }

            return RedirectToAction("Index", new { isPartial = true });
        }
    }
}