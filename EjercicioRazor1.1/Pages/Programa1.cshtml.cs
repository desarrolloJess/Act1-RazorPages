using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjercicioRazor1._1.Pages
{
    public class Programa1Model : PageModel
    {
        //Definimos los atributos
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";
        public double IMC = 0;

        
        public void OnPost()
        {
            double p = Convert.ToDouble(peso);
            double a = Convert.ToDouble(altura);

            //Convertir a metros la altura
            a = a/100;

            IMC = Math.Round( p/(a*a) ,2);
            ModelState.Clear();
        }
    }
}
