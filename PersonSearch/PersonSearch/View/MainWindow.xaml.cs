using System.Windows;
using PersonSearch.ViewModel;

namespace PersonSearch.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Set DataContext for the window
            DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// Button click event for Search menuitem. Manipulates the visibility of different controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            grSearchPerson.Visibility = System.Windows.Visibility.Visible;
            grAddPerson.Visibility = System.Windows.Visibility.Collapsed;
            btnAdd.Visibility = System.Windows.Visibility.Collapsed;
            lblMessage.Visibility = System.Windows.Visibility.Collapsed;
            grBrowseImage.Visibility = System.Windows.Visibility.Collapsed;
            lblSeedDataStatus.Visibility = System.Windows.Visibility.Collapsed;
            txtPersonName.Text = "";
        }

        /// <summary>
        /// Button click event for Add menuitem. Manipulates the visibility of different controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            grSearchPerson.Visibility = System.Windows.Visibility.Collapsed;
            grAddPerson.Visibility = System.Windows.Visibility.Visible;
            btnAdd.Visibility = System.Windows.Visibility.Visible;
            lblMessage.Visibility = System.Windows.Visibility.Visible;
            grBrowseImage.Visibility = System.Windows.Visibility.Visible;
            lblSeedDataStatus.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Button click event for Search Person button. Manipulates the visibility of different controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchPerson_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Button click event for Add button. Manipulates the visibility of different controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            grSearchPerson.Visibility = System.Windows.Visibility.Collapsed;
            grAddPerson.Visibility = System.Windows.Visibility.Visible;
            btnAdd.Visibility = System.Windows.Visibility.Visible;
            lblMessage.Visibility = System.Windows.Visibility.Visible;
            grBrowseImage.Visibility = System.Windows.Visibility.Visible;
            lblSeedDataStatus.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// <summary>
        /// Button click event for Seed Data button. Manipulates the visibility of different controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeedData_Click(object sender, RoutedEventArgs e)
        {
            grSearchPerson.Visibility = System.Windows.Visibility.Collapsed;
            grAddPerson.Visibility = System.Windows.Visibility.Collapsed;
            btnAdd.Visibility = System.Windows.Visibility.Collapsed;
            lblMessage.Visibility = System.Windows.Visibility.Collapsed;
            grBrowseImage.Visibility = System.Windows.Visibility.Collapsed;
            lblSeedDataStatus.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
