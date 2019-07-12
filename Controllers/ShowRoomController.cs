using System.Web.Mvc;
using CarShow.DataAaccessLayer.Repository;
using CarShow.ViewModels;
using System.Collections.Generic;
using System.Linq;
namespace CarShow.Controllers
{
    public class ShowRoomController : Controller
    {
        private CarShowRepository _repository;
        public ShowRoomController()
        {
            _repository = new CarShowRepository();
        }
        // GET: ShowRoom
        public ActionResult Index()
        {
            var cars = _repository.GetAll<DataAaccessLayer.Model.Car>().OrderByDescending(x => x.Model);
            var model = new List<CarViewModel>();
            foreach (var item in cars)
            {
                model.Add(new CarViewModel()
                {
                    Id = item.Id,
                    Model = item.Model,
                    Img = item.Img,
                    Manufacturer = item.Manufacturer,
                    Wiki = item.Wiki
                });
            }

            return View(model);
        }

        //load custom pop-up dialog as partial view
        public ActionResult LoadCarDetails(int id)
        {
            var details = _repository.FindOne<DataAaccessLayer.Model.Car>(x => x.Id == id);
            var model = new CarViewModel()
            {
                Id = details.Id,
                Model = details.Model,
                Img = details.Img,
                Manufacturer = details.Manufacturer,
                Wiki = details.Wiki
            };

            return PartialView("_CarDetailsDialog", model);
        }

        // GET: ShowRoom/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowRoom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowRoom/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowRoom/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShowRoom/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowRoom/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowRoom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
