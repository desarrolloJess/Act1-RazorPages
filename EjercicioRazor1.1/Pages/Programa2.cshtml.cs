using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace EjercicioRazor1._1.Pages
{
    public class Programa2Model : PageModel
    {
        //Definimos los atributos
        [BindProperty]
        public string msj { get; set; } = "";
        [BindProperty]
        public string valorN { get; set; } = "";
        [BindProperty]
        public string opcion { get; set; } = "";
        public string respuesta = "";
        public void OnPost()
        {
            if ( !string.IsNullOrEmpty(msj) & !string.IsNullOrEmpty(valorN) & !string.IsNullOrEmpty(opcion) ) 
            {
                switch (opcion)
                {
                    case "Codificar":
                        respuesta = Procesar(msj, int.Parse(valorN));
                        break;
                    case "Decodificar":
                        respuesta = Procesar(msj, 26 - int.Parse(valorN));
                        break;
                    default:
                        respuesta = "Operación no valida.";
                        break;
                }
            }
        }

        private string Procesar(string mensaje, int n)
        {
            StringBuilder mensajeCodificado = new StringBuilder();
            foreach (char caracter in mensaje)
            {
                if (char.IsLetter(caracter))
                {
                    char inicio = char.IsLower(caracter) ? 'a' : 'A';
                    mensajeCodificado.Append((char)(((caracter + n - inicio) % 26) + inicio));
                }
                else
                {
                    mensajeCodificado.Append(caracter);
                }
            }

            return mensajeCodificado.ToString();
        }
    }
}
