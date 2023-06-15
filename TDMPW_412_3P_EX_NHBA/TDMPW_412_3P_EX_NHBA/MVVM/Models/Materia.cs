using System;
using PropertyChanged;

namespace TDMPW_412_3P_EX_NHBA.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Materia
	{
		public string Nombre { get; set; }
        public string Rubro1 { get; set; }
        public string Rubro2 { get; set; }
        public string Rubro3 { get; set; }
        public double PorcentajeRubro1 { get; set; }
        public double PorcentajeRubro2 { get; set; }
        public double PorcentajeRubro3 { get; set; }
        public double CalificacionRubro1 { get; set; }
        public double CalificacionRubro2 { get; set; }
        public double CalificacionRubro3 { get; set; }

        public Materia()
		{
		}

        public double CalcularCalificacionFinal()
        {
            double calificacion = 0;
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Rubro1) || string.IsNullOrEmpty(Rubro2)
                || string.IsNullOrEmpty(Rubro3))
            {
                
                App.Current.MainPage.DisplayAlert("Campos vacíos.", "Revisa los campos de nombre de la materia o rubros, pueden que esten vacíos.", "OK");
                return calificacion = 0;
            }
            else {

                if ((PorcentajeRubro1 + PorcentajeRubro2 + PorcentajeRubro3 == 100) && (CalificacionRubro1 >= 0 && CalificacionRubro1 <= 10 && CalificacionRubro2 >= 0 && CalificacionRubro2 <= 10 && CalificacionRubro3 >= 0 && CalificacionRubro3 <= 10))
                {
                    double calificacionPrimerRubro = (PorcentajeRubro1 / 100) * CalificacionRubro1;
                    double calificacionSegundoRubro = (PorcentajeRubro2 / 100) * CalificacionRubro2;
                    double calificacionTercerRubro = (PorcentajeRubro3 / 100) * CalificacionRubro3;

                    calificacion = calificacionPrimerRubro + calificacionSegundoRubro + calificacionTercerRubro;
                    return Math.Round(calificacion,2);
                }
                else {
                    App.Current.MainPage.DisplayAlert("ERROR.", "🔴 Revisa que el valor de los porcentajes sumen 100, caso contrario, cambia los valores de los porcentajes. \n 🔴 Revisa que el valor de los campos de calificación sea un número entre 0 y 10.", "OK");
                    return calificacion = 0;
                }
            }
            
        }

        public void Reset()
        {
            Nombre = "";
            Rubro1 = "";
            Rubro2 = "";
            Rubro3 = "";
            PorcentajeRubro1 = 0;
            PorcentajeRubro2 = 0;
            PorcentajeRubro3 = 0;
            CalificacionRubro1 = 0;
            CalificacionRubro2 = 0;
            CalificacionRubro3 = 0;
        }
	}
}

