using System.Windows;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Addsotr.xaml
    /// </summary>
    public partial class Addsotr : Window
    {
        public Addsotr()
        {
            InitializeComponent();

            LogTB.Text = "Введите логин";
            LogTB.Foreground = new SolidColorBrush(Colors.Gray);

            Fio.Text = "Введите ФИО";
            Fio.Foreground = new SolidColorBrush(Colors.Gray);

            Pass.Text = "Введите пароль";
            Pass.Foreground = new SolidColorBrush(Colors.Gray);

            DateR.Text = "гггг-мм-дд";
            DateR.Foreground = new SolidColorBrush(Colors.Gray);

            DateP.Text = "гггг-мм-дд";
            DateP.Foreground = new SolidColorBrush(Colors.Gray);

            Adr.Text = "Введите адрес";
            Adr.Foreground = new SolidColorBrush(Colors.Gray);

            Tel.Text = "Введите номер телефона";
            Tel.Foreground = new SolidColorBrush(Colors.Gray);

            ZP.Text = "Введите номер телефона";
            ZP.Foreground = new SolidColorBrush(Colors.Gray);
        }

        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=1234;database=danya");
        DataBase db = new DataBase();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable g = new DataTable();
        MySqlCommand command = new MySqlCommand();

        private void DGS_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM danya.продавцы", db.GetConnection());
            adapter.Fill(dt);
            DGS.ItemsSource = dt.AsDataView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.openConnection();

            command = new MySqlCommand("INSERT INTO `Danya`.`продавцы`(`Логин`, `Пароль`, `Тип сотрудника_Код`, `ФИО`,`Дата рождения`, `Дата поступления`, `Зарплата`, `Адрес`, `Телефон`) Values (@log, @pas, @type, @NT, @DR, @DP, @ZP, @ADR, @TEL)", db.GetConnection());
            command.Parameters.Add("@NT", MySqlDbType.VarChar).Value = Fio.Text;
            command.Parameters.Add("@DR", MySqlDbType.VarChar).Value = DateR.Text;
            command.Parameters.Add("@DP", MySqlDbType.VarChar).Value = DateP.Text;
            command.Parameters.Add("@ZP", MySqlDbType.VarChar).Value = ZP.Text;
            command.Parameters.Add("@ADR", MySqlDbType.VarChar).Value = Adr.Text;
            command.Parameters.Add("@TEL", MySqlDbType.VarChar).Value = Tel.Text;
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = LogTB.Text;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = Pass.Text;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = TypeEmp.SelectedIndex == 0 ? "US" : "AD";

            command.ExecuteNonQuery();
            MessageBox.Show("Продавец добавлен добавлен");
            DGS_Loaded(null, null);
            db.closeConnection();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(DGS.SelectedIndex != -1)
            {
                db.openConnection();
                command = new MySqlCommand($"DELETE FROM `продавцы` WHERE `id_Продавца` = '{(DGS.SelectedItem as DataRowView)[0]}'", db.GetConnection());
                command.ExecuteNonQuery();
                DGS_Loaded(null, null);
                db.closeConnection();
            }
        }


        private void LogTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LogTB.Text == "Введите логин")
            {
                LogTB.Text = "";
                LogTB.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void LogTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LogTB.Text == "")
            {
                LogTB.Text = "Введите логин";
                LogTB.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void NameTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Fio.Text == "Введите ФИО")
            {
                Fio.Text = "";
                Fio.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void NameTB_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (Fio.Text == "")
            {
                Fio.Text = "Введите ФИО";
                Fio.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        
        private void Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Pass.Text == "Введите пароль")
            {
                Pass.Text = "";
                Pass.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Pass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Pass.Text == "")
            {
                Pass.Text = "Введите пароль";
                Pass.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void DateR_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DateR.Text == "гггг-мм-дд")
            {
                DateR.Text = "";
                DateR.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void DateR_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DateR.Text == "")
            {
                DateR.Text = "гггг-мм-дд";
                DateR.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void DateP_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DateP.Text == "гггг-мм-дд")
            {
                DateP.Text = "";
                DateP.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void DateP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DateP.Text == "")
            {
                DateP.Text = "гггг-мм-дд";
                DateP.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Adr_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Adr.Text == "Введите адрес")
            {
                Adr.Text = "";
                Adr.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Adr_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Adr.Text == "")
            {
                Adr.Text = "Введите адрес";
                Adr.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Tel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tel.Text == "Введите номер телефона")
            {
                Tel.Text = "";
                Tel.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Tel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tel.Text == "")
            {
                Tel.Text = "Введите номер телефона";
                Tel.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void ZP_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ZP.Text == "Введите номер телефона")
            {
                ZP.Text = "";
                ZP.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void ZP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ZP.Text == "")
            {
                ZP.Text = "Введите номер телефона";
                ZP.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
