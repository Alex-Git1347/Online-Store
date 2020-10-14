using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        private AppDBContent db;

        IHostingEnvironment _appEnvironment;

        public CarsController(IAllCars iAllCars,ICarsCategory iCarsCat,AppDBContent appDB, IHostingEnvironment appEnvironment)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
            db = appDB;
            _appEnvironment= appEnvironment;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        [Authorize(Roles = "admin,user")]
        public ViewResult List(string category)
        {
            //Электромобили  Классические автомобили
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "All Cars";
            //if (category != null) { currCategory = category; }
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Electric Cars", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Electric Cars")).OrderBy(i => i.id);
                    currCategory = "Electric Cars";
                }
                else
                {
                    if (string.Equals("Fuel Cars", category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Fuel Cars")).OrderBy(i => i.id);
                        currCategory = "Fuel Cars";
                    }
                }
               
            }

            var carObj = new CarsListViewModel
            {
                    allCars = cars,
                    currCategory = currCategory
            };
            
            ViewBag.Title = "Page with сars";
            return View(carObj);
        }

        
        [Route("Cars/CarDetails/{id}")]
        [Authorize(Roles = "admin,user")]
        public ViewResult CarDetails(int id)
        {
            Car car = null;
            car = _allCars.getObjectCar(id);
            ViewBag.Title = "Page with current сar";
            return View(car);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public void AddCar(Car car,IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/img/" + uploadedFile.FileName;
                ViewBag.Message += path;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                   uploadedFile.CopyToAsync(fileStream);
                    
                }
                car.img = path;
                db.Car.AddRange(car);
                db.SaveChanges();
            }

            this.List("");
        }

        [HttpPost]
        public IActionResult AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/img/" + uploadedFile.FileName;
                ViewBag.Message += path;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyToAsync(fileStream);
                }
                //FileMode file = new FileMode { Name = uploadedFile.FileName, Path = path };
            }
            return View("test");
        }

        [Authorize(Roles = "admin")]
        public ViewResult addcarView(Car newCar)
        {
            return View("AddCar");
        }
    }
}
