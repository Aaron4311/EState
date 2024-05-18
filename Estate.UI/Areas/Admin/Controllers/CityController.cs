using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Estate.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class CityController : Controller
	{
		ICityService _cityService;

		public CityController(ICityService cityService)
		{
			_cityService = cityService;
		}

		public IActionResult Index()
		{
			var list = _cityService.GetFilteredCities(x => x.Status == true).Data;
			return View(list);
		}


		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(City data)
		{
			CityValidator validationRules = new CityValidator();
			ValidationResult validationResult = validationRules.Validate(data);
			if (validationResult.IsValid)
			{
				_cityService.Add(data);
				TempData["Success"] = "City is successfuly added";
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		public IActionResult Delete(int id)
		{
			var city = _cityService.Get(id).Data;
			_cityService.Delete(city.CityId);
			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			var updated = _cityService.Get(id).Data;
			return View(updated);
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(City data)
		{
			CityValidator validationRules = new CityValidator();
			ValidationResult validationResult = validationRules.Validate(data);
			if (validationResult.IsValid)
			{
				_cityService.Update(data);
				TempData["Update"] = "City is successfuly updated";
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(data);
		}

	}
}

