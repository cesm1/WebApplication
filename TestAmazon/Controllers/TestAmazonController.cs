using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAmazon.Controllers
{
    public class TestAmazonController : Controller
    {
        
        //
        // GET: /TestAmazon/

        public ActionResult PackageWeights()
        {
            return View();
        }


        [HttpPost]
        public ActionResult prueba(List<int> packageWeights)
        {
            bool continua = true;
            int indexbig = 0;
            int count = 0;
            int convinaciones = 0;
            int maxValue = 0;
            while (continua == true)
            {
                if (count < packageWeights.Count)
                {
                    if (packageWeights[count] > packageWeights[indexbig])
                    {
                        indexbig = count;
                    }
                    if ((indexbig - 1) >= 0 && (packageWeights.Count - 1) == count)
                    {
                        if (packageWeights[indexbig] > packageWeights[indexbig - 1])
                        {
                            packageWeights[indexbig - 1] = packageWeights[indexbig] + packageWeights[indexbig - 1];
                            packageWeights.RemoveAt(indexbig);
                            count = 0;
                            indexbig = 0;

                        }
                    }

                }
                else
                {
                    convinaciones = validarConvinaciones(packageWeights);
                    if (convinaciones > 0)
                    {
                        count = convinaciones - 1;
                        indexbig = convinaciones - 1;
                    }
                    else
                    {

                        maxValue = packageWeights.Max();
                        continua = false;
                    }

                }
                count++;

            }


            return Json(new { MaxPackageWeights = maxValue });
        }
        public int validarConvinaciones(List<int> packageWeights)
        {
            int convinaciones = 0;
            for (int i = 1; i < packageWeights.Count; i++)
            {
                if (packageWeights[i] > packageWeights[i - 1])
                {
                    convinaciones = i;
                    break;
                }
            }
            return convinaciones;
        }

    }
}
