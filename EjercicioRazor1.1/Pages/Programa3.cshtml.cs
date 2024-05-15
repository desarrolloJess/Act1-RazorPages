using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjercicioRazor1._1.Pages
{
    public class Programa3Model : PageModel
    {
        [BindProperty]
        public string a { get; set; } = "";
        [BindProperty]
        public string b { get; set; } = "";
        [BindProperty]
        public string x { get; set; } = "";
        [BindProperty]
        public string y { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";
        public double Operacion1 = 0;
        public double Operacion2 = 0;

        public void OnPost()
        {
            double A = Convert.ToDouble(a);
            double B = Convert.ToDouble(b);
            double X = Convert.ToDouble(x);
            double Y = Convert.ToDouble(y);
            double N = Convert.ToDouble(n);
            Operacion1 = Math.Pow((A * X) + (B * Y), N);

            Operacion2 = 0;
            for (int j = 0; j <= N; j++)
            {
                double numBinomio = CalcularNumBinomio(N, j);
                double nAX = Math.Pow(A * X, N - j);
                double nBY = Math.Pow(B * Y, j);

                Operacion2 += numBinomio * nAX * nBY;
            }


            ModelState.Clear();
        }

        private double CalcularNumBinomio(double n, double j)
        {
            if (j == 0 || j == n)
            {
                return 1;
            }
            else
            {
                return CalcularNumBinomio(n - 1, j - 1) + CalcularNumBinomio(n - 1, j);
            }
        }
    }
}
