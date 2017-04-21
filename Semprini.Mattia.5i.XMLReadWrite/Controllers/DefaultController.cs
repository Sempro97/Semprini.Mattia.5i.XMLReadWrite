using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using System.Xml.Linq;



namespace Semprini.Mattia._5i.XMLReadWrite.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            try
            {
                string nomeFile = HostingEnvironment.MapPath(@"~/App_Data/Persone.xml");
            XElement data = XElement.Load(nomeFile);
            Persone prime = new Persone(data);

            return View(prime);
        }
            catch (Exception Erore)
            { return View(Erore.Message);
    }

}

        [HttpPost]
        public ActionResult NewData(Persona vm)
        {

            string savefile = HostingEnvironment.MapPath(@"~/App_Data/Persone.xml");


            //vm.Save(savefile);




            return View(vm);
        }
    }
}


