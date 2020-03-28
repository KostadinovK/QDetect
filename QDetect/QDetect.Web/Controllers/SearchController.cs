﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QDetect.Services.Interfaces;
using QDetect.Web.ViewModels;

namespace QDetect.Web.Controllers
{
    public class SearchController: Controller
    {
        private readonly IPeopleService peopleService;

        public SearchController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchQuery)
        {
            var people = this.peopleService.GetAll()
                .Where(p => p.Name.Contains(searchQuery) || p.UCN.StartsWith(searchQuery)).ToList();

            var peopleModel = new PeopleListingPageViewModel();

            foreach (var person in people)
            {
                peopleModel.Peoples.Append(new PeopleViewModel()
                {
                    Name = person.Name,
                    City = person.City,
                    HasReports = person.Reports.Count > 0,
                    Id = person.Id,
                    Image = this.peopleService.GetPersonImageLink(person.Id).Result,
                    QuarantineEndDate = person.QuarantineEndDate.ToShortTimeString(),
                    UCN = person.UCN
                });
            }

            return this.View(people);
        }
    }
}