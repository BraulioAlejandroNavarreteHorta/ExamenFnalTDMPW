namespace TDMPW_412_3P_EX_NHBA.MVVM.Views;
using TDMPW_412_3P_EX_NHBA.MVVM.ViewModels;

public partial class MateriaView : ContentPage
{
	public MateriaView()
	{
		InitializeComponent();
        BindingContext = new MateriaViewModel();
    }
}
