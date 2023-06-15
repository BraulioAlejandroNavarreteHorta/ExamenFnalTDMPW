using System;
using PropertyChanged;
using TDMPW_412_3P_EX_NHBA.MVVM.Models;
using System.Windows.Input;

namespace TDMPW_412_3P_EX_NHBA.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class MateriaViewModel
    {
        public Materia Materia { get; set; }
        public ICommand ClickCommand { get; }
        public double Calificacion { get; set; }
        public ICommand CmdResultado => new Command(() => Calificacion = Materia.CalcularCalificacionFinal());
        public ICommand CmdReiniciar { get; }
        public MateriaViewModel()
		{
            Materia = new Materia();

            CmdReiniciar = new Command(() =>
            {
                Calificacion = 0;
                Materia.Reset();
            }
            );
        }
	}
}

