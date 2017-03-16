

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Default/Movie", typeof(Serene.Sample1.Default.Pages.MovieController))]

namespace Serene.Sample1.Default.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Default/Movie"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.MovieRow))]
    public class MovieController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/Default/Movie/MovieIndex.cshtml");
        }
    }
}