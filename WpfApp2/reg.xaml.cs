using MySql.Data.MySqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для dva.xaml
    /// </summary>
    public partial class dva : Window
    {
        public dva()
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
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            avtor avtor = new avtor();
            avtor.Show();
            this.Close();
        }
        DataBase db = new DataBase();
        MySqlCommand command = new MySqlCommand();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.openConnection();


            
                command = new MySqlCommand("INSERT INTO `Danya`.`консультанты`(`Логин`,`Пароль`,`ФИО`,`Дата_рождения`,`Дата_поступления`,`Адрес`,`Телефон`) Values (@log,@pass,@fio,@DR,@DP,@Adr,@Telf)", db.GetConnection());

                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = LogTB.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = ParTB.Password;
                command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = Fio.Text;
                command.Parameters.Add("@DR", MySqlDbType.VarChar).Value = DateR.Text;
                command.Parameters.Add("@DP", MySqlDbType.VarChar).Value = DateP.Text;
                command.Parameters.Add("@Adr", MySqlDbType.VarChar).Value = Adr.Text;
                command.Parameters.Add("@Telf", MySqlDbType.VarChar).Value = Tel.Text;

                MessageBox.Show("Аккаунт зарегестрирован");
                avtor av = new avtor();
                av.Show();
                this.Close();

            db.closeConnection();   


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
            Pass.Visibility = Visibility.Hidden;
            ParTB.Visibility = Visibility.Visible;
            ParTB.Focus();

            if (Pass.Text == "Введите пароль")
            {
                Pass.Text = "";
                ParTB.Foreground = new SolidColorBrush(Colors.Black);
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

        private void ParTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ParTB.Password == "")
            {
                Pass.Visibility = Visibility.Visible;
                ParTB.Visibility = Visibility.Hidden;
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

       
    }
}
