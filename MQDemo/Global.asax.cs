using LDTSSInterface;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MQDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RabbitMQGateWay.GetPublisher().InitializeForPublisher("DataMakerPublisher");
        }
    }
}
