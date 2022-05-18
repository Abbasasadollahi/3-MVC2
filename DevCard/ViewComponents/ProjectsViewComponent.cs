using DevCard.Data;
using Microsoft.AspNetCore.Mvc;

namespace DevCard.ViewComponents
{
    public class ProjectsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var projects = ProjectStore.GetProjects();
            return View("_Projects", projects);
        }
    }
}
