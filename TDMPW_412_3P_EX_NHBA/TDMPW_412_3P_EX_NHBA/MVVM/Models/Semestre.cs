using System;
using PropertyChanged;

namespace TDMPW_412_3P_EX_NHBA.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Semestre
	{
		public string NombreMateria { get; set; }
        public double PorcentajeParcial1 { get; set; }
        public double PorcentajeParcial2 { get; set; }
        public double PorcentajeParcial3 { get; set; }
        public double CalificacionParcial1 { get; set; }
        public double CalificacionParcial2 { get; set; }
        public double calificacionNecesaria6 { get; set; }
        public double calificacionNecesaria10 { get; set; }

        public Semestre()
		{
		}

        public void Calcular()
        {
            calificacionNecesaria6 = 0;
            calificacionNecesaria10 = 0;
            if (string.IsNullOrEmpty(NombreMateria))
            {

                App.Current.MainPage.DisplayAlert("Campo vacío.", "Revisa el campo de nombre de la materia.", "OK");
                calificacionNecesaria6 = 0;
                calificacionNecesaria10 = 0;
            }
            else
            {

                if ((PorcentajeParcial1 + PorcentajeParcial2 + PorcentajeParcial3 == 100) && (CalificacionParcial1 >= 0 && CalificacionParcial1 <= 10 && CalificacionParcial2 >= 0 && CalificacionParcial2 <= 10))
                {
                    calificacionNecesaria6 = (6 - (CalificacionParcial1 * (PorcentajeParcial1/100) + CalificacionParcial2 * (PorcentajeParcial2/100))) / (PorcentajeParcial3/100);
                    calificacionNecesaria10 = (10 - (CalificacionParcial1 * (PorcentajeParcial1 / 100) + CalificacionParcial2 * (PorcentajeParcial2 / 100))) / (PorcentajeParcial3 / 100);
                    calificacionNecesaria6 = Math.Round(calificacionNecesaria6, 2); ;
                    calificacionNecesaria10 = Math.Round(calificacionNecesaria10, 2); ;

                    if (calificacionNecesaria10 > 10)
                    {
                        App.Current.MainPage.DisplayAlert("Ya no alcanzas el 10.", $"Echale más ganas el siguiente semestre, se te muestra el la calificación que tendrías que sacar para obtener un 10 --> {calificacionNecesaria10} .", "OK");
                        calificacionNecesaria10 = 0;
                    }
                    else {
                        App.Current.MainPage.DisplayAlert("FELICIDADES", "Sigue así, obtuviste un semestre perfecto.", "OK");
                    }

                    if (calificacionNecesaria6 < 0)
                    {
                        App.Current.MainPage.DisplayAlert("FELICIDADES", "Obtendrás una calificacón más alta que 6", "OK");
                        calificacionNecesaria6 = 0;
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("ERROR.", "🔴 Revisa que el valor de los porcentajes sumen 100, caso contrario, cambia los valores de los porcentajes. \n 🔴 Revisa que el valor de los campos de calificación sea un número entre 0 y 10.", "OK");
                    calificacionNecesaria6 = 0;
                    calificacionNecesaria10 = 0;
                }
            }
        }

        public void Reset()
        {
            NombreMateria = "";
            PorcentajeParcial1 = 0;
            PorcentajeParcial2 = 0;
            PorcentajeParcial3 = 0;
            CalificacionParcial1 = 0;
            CalificacionParcial2 = 0;
            CalificacionParcial1 = 0;
            calificacionNecesaria6 = 0;
            calificacionNecesaria10 = 0;
        }


    }
}

