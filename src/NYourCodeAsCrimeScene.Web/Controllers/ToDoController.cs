//using System.Linq;
//using System.Threading.Tasks;
//using NYourCodeAsCrimeScene.Core;
//using NYourCodeAsCrimeScene.Core.Entities;
//using NYourCodeAsCrimeScene.SharedKernel.Interfaces;
//using NYourCodeAsCrimeScene.Web.ApiModels;
//using Microsoft.AspNetCore.Mvc;

//namespace NYourCodeAsCrimeScene.Web.Controllers
//{
//    public class ToDoController : Controller
//    {
//        private readonly IRepository _repository;

//        public ToDoController(IRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var items = (await _repository.ListAsync<ToDoItem>())
//                            .Select(ToDoItemDTO.FromToDoItem);
//            return View(items);
//        }

//        public IActionResult Populate()
//        {
//            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
//            return Ok(recordsAdded);
//        }
//    }
//}
