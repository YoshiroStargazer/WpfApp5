using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.Models;
using WpfApp5.Views;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        _1Context _context;
        Driver _driver;
        public MainWindow()
        {
            InitializeComponent();
            _context = new _1Context();
            _driver = new Driver();
            LoadData();
        }

        private void LoadData()
        {
            PersonListView.ItemsSource = _context.Drivers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddData addData = new AddData();
            addData.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(_driver == null)
            {
                MessageBox.Show("Выберите пользователя");
            }
            _driver.LastName = LastnameTxb.Text;
            _driver.FirstName = NameTxb.Text;
            _driver.middlename = MidleNameTxb.Text;
            _driver.PassportSerial = PassportSerialTxb.Text;
            _driver.PassportNumber = PassportNumberTxb.Text;
            _driver.Address = AddressTxb.Text;
            _driver.AddressLife_ = AddressLifeTxb.Text;
            _driver.PostCode = PostCodeTxb.Text;
            _driver.Company = CompanyTxb.Text;
            _driver.JobName = JobNameTxb.Text;
            _driver.Phone = PhoneTxb.Text;
            _driver.Email = EmailTxb.Text;
            _context.Drivers.Update(_driver);
            _context.SaveChanges();
            MessageBox.Show("Данные изменены");
        }

        private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _driver = PersonListView.SelectedItem as Driver;
            
            
            if(_driver != null)
            {
                LastnameTxb.Text = _driver.LastName;
                NameTxb.Text = _driver.FirstName;
                MidleNameTxb.Text = _driver.middlename;
                PassportSerialTxb.Text = _driver.PassportSerial.ToString();
                PassportNumberTxb.Text = _driver.PassportNumber.ToString();
                PostCodeTxb.Text = _driver.PostCode.ToString();
                AddressTxb.Text = _driver.Address;
                AddressLifeTxb.Text = _driver.AddressLife_;
                CompanyTxb.Text = _driver.Company;
                JobNameTxb.Text = _driver.JobName;
                PhoneTxb.Text = _driver.Phone.ToString();
                EmailTxb.Text = _driver.Email;
                
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedDriver = PersonListView.SelectedItem as Driver;

            if (selectedDriver == null)
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления");
                return;
            }

            // Подтверждение удаления
            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить {selectedDriver.LastName} {selectedDriver.FirstName}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            try
            {
                // Находим запись в базе данных
                var driverToDelete = _context.Drivers.Find(selectedDriver.ID);

                if (driverToDelete != null)
                {
                    // Удаляем запись
                    _context.Drivers.Remove(driverToDelete);
                    _context.SaveChanges();
                    // Обновляем ListView
                    PersonListView.ItemsSource = _context.Drivers.ToList();

                    MessageBox.Show("Запись успешно удалена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
    }
}