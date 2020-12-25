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
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AddPokypatel.xaml
    /// </summary>
    public partial class AddPokypatel : Window
    {
        
        public AddPokypatel()
        {
            InitializeComponent();
           
        }

        DataBase db = new DataBase();
        MySqlCommand command = new MySqlCommand();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.openConnection();

            command = new MySqlCommand("INSERT INTO `Danya`.`покупатели`(`ФИО`,`Номер_телефона`,`Лицензия`) Values (@fio,@tel,@lic)", db.GetConnection());
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = fioTB.Text;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = telTB.Text;
            command.Parameters.Add("@lic", MySqlDbType.VarChar).Value = licenseTB.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("Покупатель добавлен");

            this.Close();

            db.closeConnection();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
