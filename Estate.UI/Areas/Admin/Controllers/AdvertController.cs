using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Type = Entity.Concrete.Type;

namespace Estate.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class AdvertController : Controller
	{
		IAdvertService _advertService;
		ICityService _cityService;
		IDistrictService _districtService;
		INeighbourhoodService _neighbourhoodService;
		ISituationService _situationService;
		ITypeService _typeService;
		IWebHostEnvironment _webHostEnvironment;
		IImageService _imageService;

		public AdvertController(IAdvertService advertService, ICityService cityService, IDistrictService districtService, INeighbourhoodService neighbourhoodService, ISituationService situationService, ITypeService typeService, IWebHostEnvironment webHostEnvironment, IImageService imageService)
		{
			_advertService = advertService;
			_cityService = cityService;
			_districtService = districtService;
			_neighbourhoodService = neighbourhoodService;
			_situationService = situationService;
			_typeService = typeService;
			_webHostEnvironment = webHostEnvironment;
			_imageService = imageService;
		}

		public IActionResult Index()
		{
			string id = HttpContext.Session.GetString("Id");
			var list = _advertService.GetFilteredAdverts(x => x.Status == true && x.UserAdminId == id).Data;
			return View(list);
		}

		public IActionResult ImageList(int id)
		{
			var list = _imageService.GetFilteredImages(x => x.Status == true && x.AdvertId == id).Data;
			return View(list);
		}



		public IActionResult DeleteList()
		{
			string id = HttpContext.Session.GetString("Id");
			var list = _advertService.GetFilteredAdverts(x => x.Status == false && x.UserAdminId == id).Data;
			return View(list);
		}

		public IActionResult RestoreDeleted(int id)
		{
			var sessionUser = HttpContext.Session.GetString("Id");
			var deleted = _advertService.Get(id);
			if (sessionUser.ToString() == deleted.Data.UserAdminId)
			{
				_advertService.RestoreDeleted(deleted.Data.AdvertId);
				TempData["RestoreDelete"] = "Advert is successfuly restored";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult FullDeleted(int id)
		{
			var sessionUser = HttpContext.Session.GetString("Id");
			var deleted = _advertService.Get(id);
			if (sessionUser.ToString() == deleted.Data.UserAdminId)
			{
				_advertService.FullDelete(deleted.Data.AdvertId);
				TempData["FullDeleted"] = "Advert is successfuly deleted";
				return RedirectToAction("Index");
			}
			return View();
		}


		public IActionResult Create()
		{
			ViewBag.userId = HttpContext.Session.GetString("Id");
			DropDown();
			return View();

		}

		public IActionResult Update(int id)
		{
			ViewBag.userId = HttpContext.Session.GetString("Id");
			DropDown();
			var advert = _advertService.Get(id);
			return View(advert.Data);

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Advert data)
		{

			AdvertValidator validationRules = new AdvertValidator();
			ValidationResult validationResult = validationRules.Validate(data);
			if (validationResult.IsValid)
			{
				if (data.Image != null)
				{
					
					_advertService.Update(data);
					TempData["Update"] = "Advert is successfuly updated";
					return RedirectToAction("Index");
				}

			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			DropDown();
			return View(data);
		}

		public IActionResult Delete(int id)
		{
			var sessionUser = HttpContext.Session.GetString("Id");
			var deleted = _advertService.Get(id);
			if (sessionUser.ToString()==deleted.Data.UserAdminId)
			{
				_advertService.Delete(deleted.Data.AdvertId);
				return RedirectToAction("Index");
			}
			return View();
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		
		public IActionResult Create(Advert data)
		{

			AdvertValidator validationRules = new AdvertValidator();
			ValidationResult validationResult = validationRules.Validate(data);
			if (validationResult.IsValid)
			{
				if (data.Image != null)
				{
					var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img");
					foreach (var item in data.Image)
					{
						var fullFileName = Path.Combine(filePath, item.FileName);
						using (var fileStream = new FileStream(fullFileName, FileMode.Create))
						{
							item.CopyTo(fileStream);
						}
						data.Images.Add(new Image()
						{
							ImageName = item.FileName,
							Status = true

						});
					}
					_advertService.Add(data);
					TempData["Success"] = "Advert is successfuly added";
					return RedirectToAction("Index");
				}
				
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			DropDown();
			return View();

		}

		public IActionResult DistrictGet(int CityId)
		{
			List<District> districtList = _districtService.GetFilteredDistricts(x => x.Status == true && x.CityId == CityId).Data;
			ViewBag.district = new SelectList(districtList, "DistrictId", "DistrictName");
			return PartialView("DistrictPartial");
		}

		public IActionResult TypeGet(int SituationId)
		{
			List<Type> typeList = _typeService.GetFilteredTypes(x => x.Status == true && x.SituationId == SituationId).Data;
			ViewBag.type = new SelectList(typeList, "TypeId", "TypeName");
			return PartialView("TypePartial");
		}

		public PartialViewResult DistrictPartial()
		{
			return PartialView();
		}

		public PartialViewResult NeighbourhoodPartial()
		{
			return PartialView();
		}


		public PartialViewResult TypePartial()
		{
			return PartialView();
		}

		public IActionResult NeighbourhoodGet(int DistrictId)
		{
			List<Neighbourhood> neighlist = _neighbourhoodService.GetFilteredNeighbourhoods(x => x.Status == true && x.DistrictId == DistrictId).Data;
			ViewBag.neigh = new SelectList(neighlist, "NeighbourhoodId", "NeighbourhoodName");
			return PartialView("NeighbourhoodPartial");
		}

		public void DropDown()
		{
			ViewBag.cityList = new SelectList(_cityService.GetFilteredCities(x => x.Status == true).Data, "CityId", "CityName");
			ViewBag.situations = new SelectList(_situationService.GetAllFilteredSituations(x => x.Status == true).Data,"SituationId","SituationName");

			List<SelectListItem> value1 = (from i in _districtService.GetFilteredDistricts(x => x.Status == true).Data
										   select new SelectListItem
										   {
											   Text = i.DistrictName,
											   Value = i.DistrictId.ToString()
										   }).ToList();
			ViewBag.district = value1;


			List<SelectListItem> value2 = (from i in _neighbourhoodService.GetFilteredNeighbourhoods(x => x.Status == true).Data
										   select new SelectListItem
										   {
											   Text = i.NeighbourhoodName,
											   Value = i.NeighbourhoodId.ToString()
										   }).ToList();
			ViewBag.neighbourhood = value2;


			List<SelectListItem> value3 = (from i in _typeService.GetFilteredTypes(x => x.Status == true).Data
										   select new SelectListItem
										   {
											   Text = i.TypeName,
											   Value = i.TypeId.ToString()
										   }).ToList();
			ViewBag.type = value3;


			List<SelectListItem> value4 = (from i in _situationService.GetAllFilteredSituations(x => x.Status == true).Data
										   select new SelectListItem
										   {
											   Text = i.SituationName,
											   Value = i.SituationId.ToString()
										   }).ToList();
			ViewBag.situation = value4;

		}


	}
}
