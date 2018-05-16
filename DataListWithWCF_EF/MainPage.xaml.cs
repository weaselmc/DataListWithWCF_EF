using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DataListWithWCF_EF
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<AdvWorksServiceReference.Customer>
            Items
        { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
        }
        public async Task GetData()
        {
            AdvWorksServiceReference.AdvWorksDataServiceClient
                client = new AdvWorksServiceReference.AdvWorksDataServiceClient();
            if(client.State != 
                System.ServiceModel.CommunicationState.Opened)
            await client.OpenAsync();
            Items = await client.GetCustomersAsync();
            await client.CloseAsync();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await GetData();
        }
    }
}
