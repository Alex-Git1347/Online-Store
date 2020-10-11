using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        name = "Tesla Model S",
                        shortDesc ="Быстрый Электромобиль",
                        longDescription = "Tesla Model S — пятидверный электромобиль производства американской компании Tesla. Прототип был впервые показан на Франкфуртском автосалоне в 2009 году; поставки автомобиля в США начались в июне 2012 года[1].",
                        img ="/img/tesla1.jpg",
                        price = 55000,
                        isFavourite =false,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        name = "Tesla Model X",
                        shortDesc ="Это полноразмерный кроссовер с тремя рядами сидений",
                        longDescription = "Tesla Model X — полноразмерный электрический кроссовер производства компании Tesla. Прототип был впервые показан в Лос-Анджелесе 9 февраля 2012 года[1]. Коммерческие поставки начались 29 сентября 2015 года. Tesla Model X разрабатывается на базе платформы Tesla Model S и собирается на основном заводе компании во Фримонте, штат Калифорния.",
                        img ="/img/teslaX.jpg",
                        price = 75000,
                        isFavourite =true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        name = "BMW X7",
                        shortDesc ="Это oversize кроссовер с тремя рядами сидений от компании BMW",
                        longDescription = "BMW X7 — полноразмерный люксовый кроссовер немецкой компании BMW, который был запущен в производство в декабре 2017 года, но в продажу модель пошла только с марта 2019. Автомобиль составляет конкуренцию таким моделям, как Mercedes-Benz GLS-класс, Lexus LX и Range Rover." ,
                        img ="/img/bmwX7.jpg",
                        price = 105000,
                        isFavourite =true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name = "AUDI RS6",
                        shortDesc ="Audi RS 6 — спортивный, быстрый, стремительный автомобиль",
                        longDescription = "Audi RS 6 — спортивный автомобиль выпускаемый подразделением Audi Sport GmbH (ранее quattro GmbH) на платформе Audi A6. Автомобиль выпускается в двух типах кузова, седан и универсал (Avant). Существует менее мощная спортивная версия Audi S6.",
                        img ="/img/audiRS6.jpg",
                        price = 62000,
                        isFavourite =true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name = "LADA Vesta",
                        shortDesc ="LADA Vesta седан – автомобиль нового поколения.",
                        longDescription = "LADA Vesta (рус. Лада Веста) — российский компактный автомобиль малого класса, выпускаемый АвтоВАЗом с 25 сентября 2015 года в кузове седан, а с 2017 года в кузове универсал. Заменил семейство LADA Priora в модельной линейке. Старт продаж Vesta состоялся 25 ноября 2015 года[1]. По итогам 2018 года LADA Vesta стала самым продаваемым автомобилем в России с результатом 108 364 штуки.",
                        img ="/img/LadaVesta.jpeg",
                        price = 12000,
                        isFavourite =false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name = "LADA Vesta SW Cross",
                        shortDesc ="LADA Vesta SW Cross – автомобиль нового поколения",
                        longDescription = "Самый просторный в классе салон – это возможность разместиться с максимальным удобством. А полный комплект опций для достижения наибольшего комфорта позволяет сконцентрироваться на главном — удовольствии от вождения. Особое внимание уделено пассажирам – для них предусмотрен обогрев заднего сиденья, отдельный плафон освещения и USB-гнездо для подзарядки гаджетов.",
                        img ="/img/LadaVestaSWCross.jpg",
                        price = 16000,
                        isFavourite =false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name = "Dodge RAM",
                        shortDesc ="Dodge RAM рамный, грузовой пикап.",
                        longDescription = "Dodge Ram- большой пикап, способный вместить до шести человек. Его габаритные размеры составляют: длина 5816 мм, ширина 2017 мм, высота 1923 мм а величина колесной базы равняется 3570 миллиметрам. Еще одним нововведением стала пневматическая подвеска.",
                        img ="/img/dodgeRam.jpg",
                        price = 65000,
                        isFavourite =false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name = "BMW i8",
                        shortDesc ="Новый BMW i8 Купе - футуристический снаружи, интуитивный изнутри",
                        longDescription = "BMW i8 — серийный образец модели (заводской индекс I12) представили во Франкфурте осенью 2013. Спорт-купе стало вторым (после BMW i3) автомобилем нового бренда баварцев, который получил название BMW i. Под ним немцы намерены выпустить целый модельный ряд природолюбивых и незаурядных машин.",
                        img ="/img/BMWi8.jpg",
                        price = 125000,
                        isFavourite =true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        name = "Nissan LEAF",
                        shortDesc ="Nissan LEAF - современный бюджетный электромобиль",
                        longDescription = "Nissan LEAF — электромобиль японского концерна Nissan, серийно выпускаемый с весны 2010 года. Мировая премьера состоялась на международном Токийском автосалоне в 2009 году, затем с 2012 года Nissan развернул производство электромобилей Leaf на заводах в США.",
                        img ="/img/nissanLeaf.jpg",
                        price = 11500,
                        isFavourite =true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                    //new Car
                    //{
                    //    name = "Great Wall Hover",
                    //    shortDesc ="Great Wall Hover - современный функциональный, внедорожный кроссовер",
                    //    longDescription = "Nissan LEAF — электромобиль японского концерна Nissan, серийно выпускаемый с весны 2010 года. Мировая премьера состоялась на международном Токийском автосалоне в 2009 году, затем с 2012 года Nissan развернул производство электромобилей Leaf на заводах в США.",
                    //    img ="/img/Hover.jpg",
                    //    price = 45500,
                    //    isFavourite =true,
                    //    available = true,
                    //    Category = _categoryCars.AllCategories.Last()
                    //}

                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
