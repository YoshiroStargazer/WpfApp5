using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp5.Models;

namespace WpfApp5.Views
{
    /// <summary>
    /// Логика взаимодействия для AddData.xaml
    /// </summary>
    public partial class AddData : Window
    {
        _1Context _1Context;
        Driver driver;
        public AddData()
        {
            InitializeComponent();
            _1Context = new _1Context();
            driver = new Driver();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastnameTxb.Text;
            string firstName = NameTxb.Text;
            string middleName = MidleNameTxb.Text;
            string passportSerail = PassportSerialTxb.Text;
            string passportNumber = PassportNumberTxb.Text;
            string postcode = PostCodeTxb.Text;
            string Addres = AddressTxb.Text;
            string addresLife = AddressLifeTxb.Text;
            string Company = CompanyTxb.Text;
            string jobName = JobNameTxb.Text;
            string phone = PhoneTxb.Text;
            string Email = EmailTxb.Text;
            string photoDescription = PhotoDescriptionTxb.Text;
            try
            {


                var newDriver = new Driver
                {
                    LastName = lastName,
                    FirstName = firstName,
                    middlename = middleName,
                    PassportSerial = passportSerail,
                    PassportNumber = passportNumber,
                    PostCode = postcode,
                    Address = Addres,
                    AddressLife_ = addresLife,
                    Company = Company,
                    JobName = jobName,
                    Phone = phone,
                    Email = Email,
                    PhotoDescription = photoDescription,

                };
                _1Context.Drivers.Add(newDriver);

                int result = _1Context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Пользователь успешно добавлен");
                    this.Close(); // Закрыть окно после успешного добавления
                }
                else
                {
                    MessageBox.Show("Не удалось добавить пользователя");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

    }
}
