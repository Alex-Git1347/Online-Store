using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        //private readonly IAllCompanies _allCompanies;
        private AppDBContent db;
        IHostingEnvironment _appEnvironment;

        public CarsController(IAllCars iAllCars,ICarsCategory iCarsCat, AppDBContent appDB, IHostingEnvironment appEnvironment)
        {
            //_allCompanies = iAllCompanies;
            _allCars = iAllCars;
            _allCategories = iCarsCat;
            db = appDB;
            _appEnvironment= appEnvironment;
        }


        // Выводим всех футболистов
        public ActionResult allCompany(int? Id)
        {
            if (Id == null)
            {
                //return HttpNotFound();
                //return http
            }
            Company company = db.Companies.Find(Id);
            if (company == null)
            {
                //return HttpNotFound();
            }
            company.allCars = db.Car.Where(m => m.companyID == company.id);
            return View(company);


            //var companies = db.Car.Include(p => p.company);
            //return View(companies.ToList());
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
            Company comp = null;
            //var a= db.Companies.Where(i =>i.id==car.companyID);
            //car.company = comp.allCars.ElementAtOrDefault((int)car.companyID);

            comp = db.Companies.Find(car.companyID);
            //foreach (var item in a)
            //{
            //    comp = item;
            //}
            car.company = comp;
            ViewBag.Title = "Page with current сar";
            return View(car);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public void AddCar(Car car,IFormFile uploadedFile)
        {
            //IEnumerable<Company> companies = null;
            
            //    companies = _allCompanies.getAllCompany.OrderBy(i => i.id > 0);
            

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
        [HttpGet]
        public ViewResult AddCar()
        {
            SelectList companies = new SelectList(db.Companies, "id", "nameCompany");
            ViewBag.Companies = companies;
            //Company company = db.Companies.Find();
            //List<Company> a = db.Companies.Where(m => m.id > 0);

            return View();
        }

        
        public ViewResult Test(Car newCar)
        {
            return View("Test");
        }
    }
}
    