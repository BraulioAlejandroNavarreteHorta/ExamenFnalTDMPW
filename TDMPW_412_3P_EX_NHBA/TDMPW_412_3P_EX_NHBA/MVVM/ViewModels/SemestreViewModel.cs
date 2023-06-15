using System;
using PropertyChanged;
using TDMPW_412_3P_EX_NHBA.MVVM.Models;
using System.Windows.Input;

namespace TDMPW_412_3P_EX_NHBA.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SemestreViewModel
	{
        public Semestre Semestre { get; set; }
        public ICommand ClickCommand { get; }
        public double CalificacionParaSacarSeis { get; set; }
        public double CalificacionParaSacarDiez { get; set; }
        public ICommand CmdCalcular { get; }
        public ICommand Reiniciar { get; }
        public SemestreViewModel()
		{
            Semestre = new Semestre();
            CmdCalcular = new Command(() =>
            {
                Semestre.Calcular();
            }
            );

            Reiniciar = new Command(() =>
            {
                Semestre.Reset();
            }
            );
        }
	}
}

