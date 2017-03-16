using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace AspNetBuilerplate.Sample1.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : Sample1ControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}