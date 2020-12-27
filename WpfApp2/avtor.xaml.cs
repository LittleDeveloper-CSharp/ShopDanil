using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class avtor : Window
    {
        public avtor()
        {
            InitializeComponent();

            loginTextBox.Text = "Введите логин";
            loginTextBox.Foreground = new SolidColorBrush(Colors.Gray);

            textbox.Text = "Введите пароль";
            textbox.Foreground = new SolidColorBrush(Colors.Gray);

            
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow Main = new MainWindow();
            //Main.Show();
            this.Close();
        }

       DataBase db = new DataBase();
        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        int kol;
        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            String logUser = loginTextBox.Text;
            String ParUser = parolTextBox.Password;
            MySqlCommand command = null;

           
            
                command = new MySqlCommand("SELECT * FROM danya.продавцы WHERE Логин = @UL AND Пароль = @UP", db.GetConnection()); //Выборка
                command.Parameters.Add("@UL", MySqlDbType.VarChar).Value = logUser;
                command.Parameters.Add("@UP", MySqlDbType.VarChar).Value = ParUser;



            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1) 
            {
                string name = (string)table.Rows[0]["ФИО"];
                string id = table.Rows[0]["id_Продавца"].ToString();

                var isAdmin = table.Rows[0]["Type_Employee_Code"].ToString() == "AS";

                glavn gl = new glavn(name,id,kol, isAdmin);
                gl.Show();
                this.Close();
                
            }
            else
                MessageBox.Show("Вы ввели не правильный логин/пароль", "Ошибка");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dva av = new dva();
            av.Show();
            this.Close();
        }
        private void loginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == "Введите логин")
            {
                loginTextBox.Text = "";
                loginTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void loginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == "")
            {
                loginTextBox.Text = "Введите логин";
                loginTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void parolTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (parolTextBox.Password == "")
            {
                textbox.Visibility = Visibility.Visible;
                parolTextBox.Visibility = Visibility.Hidden;
                textbox.Text = "Введите пароль";
                textbox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "")
            {
                textbox.Text = "Введите пароль";

            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox.Visibility = Visibility.Hidden;
            parolTextBox.Visibility = Visibility.Visible;
            parolTextBox.Focus();

            if (textbox.Text == "Введите пароль")
            {
                textbox.Text = "";
                parolTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }


    }

   
    
    
}
