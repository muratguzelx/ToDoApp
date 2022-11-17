using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using ToDoApp.Business.Interfaces;
using ToDoApp.Common.ResponseObjects;
using ToDoApp.Dtos;

namespace ToDoApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private IworkService _workServices;

        public HomeController(IworkService workServices, IMapper mapper)
        {
            _workServices = workServices;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _workServices.GetAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            var response = await _workServices.Create(dto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.validationErrors)
                {
                    ModelState.AddModelError(error.ErrorMessage, error.PropertyName);
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> Update(int id)
        {
            var response = await _workServices.GetById<UpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDto dto)
        {
            var response = await _workServices.Update(dto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.validationErrors)
                {
                    ModelState.AddModelError(error.ErrorMessage, error.PropertyName);
                }
                
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workServices.Remove(id);
            if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
