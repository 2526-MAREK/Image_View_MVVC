using Mopups.Pages;
using Mopups.Services;
using System.Collections.Generic;
using System.Windows.Input;

namespace Image_View_V1._0;

public partial class PopUpWithLoadDataFromDataBase : PopupPage
{
    /*public PopUpWithLoadDataFromDataBases()//(PopUpWithLoadDataFromDataBaseViewModel popUpWithLoadDataFromDataBaseViewModel)
	{
		InitializeComponent();
        //BindingContext = new PopUpWithLoadDataFromDataBaseViewModel(Navigation);

        //BindingContext = popUpWithLoadDataFromDataBaseViewModel;
    }*/

    PopupLoadDataBaseViewModel _viewModel;
    public event EventHandler<int> ButtonClicked;

    //ImageToProcess imageAfterProcess;
    public PopUpWithLoadDataFromDataBase(IEnumerable<ImageToProcess> imageAfterProcessList)
    {
        InitializeComponent();
        _viewModel = new PopupLoadDataBaseViewModel(imageAfterProcessList);
        BindingContext = _viewModel;
        MyCollectionView.ItemsSource = imageAfterProcessList;
       // MyCollectionView.SelectionChanged     = OnNameOfChooseLoadImageClicked();

    }

    private void OnNameOfChooseLoadImageClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var image = button.BindingContext as ImageToProcess;
        if (image != null) { 
        
            // Zr�b co� z warto�ciami 'imageName' i 'imageType', np. wy�wietl alert
            ButtonClicked?.Invoke(this, image.Id);
        }
       
    }

        private void CloseButtonClick(object sender, EventArgs e)
    {
        //this.Navigation.PopModalAsync();
        MopupService.Instance.PopAsync();
    }


    /*public PopUpWithLoadDataFromDataBase(ImageDetailsViewModel viewModel)
    {
        InitializeComponent();
        //_viewModel = new PopupLoadDataBaseViewModel(imageAfterProcessList);
        BindingContext = viewModel;

    }*/

}