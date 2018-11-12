using System.Windows;

namespace WpfBindingTest
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private BindingValues oMyVals = new BindingValues();
 
      public MainWindow()
      {
         InitializeComponent();

         this.DataContext = oMyVals;
      }	
   }  
}
