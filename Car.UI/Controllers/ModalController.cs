using Car.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car.UI.Controllers
{
    public class ModalController : Controller
    {
        [HttpGet]
        public IActionResult BootstrapModalPartial(string title, string bodyText, bool showVideo)
        {
            var vm = new ModalViewModel();
            vm.Title = title;
            vm.BodyText = bodyText;
            vm.ShowVideo = showVideo;
            return PartialView(vm);
        }
    }
}
