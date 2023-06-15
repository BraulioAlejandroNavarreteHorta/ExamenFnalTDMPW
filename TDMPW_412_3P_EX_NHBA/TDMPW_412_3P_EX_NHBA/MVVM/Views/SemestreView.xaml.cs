namespace TDMPW_412_3P_EX_NHBA.MVVM.Views;
using TDMPW_412_3P_EX_NHBA.MVVM.ViewModels;

public partial class SemestreView : ContentPage
{
	public SemestreView()
	{
		InitializeComponent();
        BindingContext = new SemestreViewModel();
    }
}
