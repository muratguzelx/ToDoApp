using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using ToDoApp.Business.Interfaces;
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
            await _workServices.Create(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _workServices.GetById<UpdateDto>(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDto dto)
        {
            await _workServices.Update(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workServices.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
