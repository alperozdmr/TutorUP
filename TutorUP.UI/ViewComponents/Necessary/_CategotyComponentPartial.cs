using Microsoft.AspNetCore.Mvc;
using TutorUp.ServiceLayer.Abstract;

namespace TutorUP.UI.ViewComponents.Necessary
{
    public class _CategotyComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategotyComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetListAll();
            return View(values);
        }
    }
}
