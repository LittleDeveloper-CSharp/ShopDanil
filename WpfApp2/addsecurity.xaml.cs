using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для addsecurity.xaml
    /// </summary>
    public partial class addsecurity : Window
    {
        public addsecurity()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=1234;database=danya");
        DataBase db = new DataBase();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable g = new DataTable();
        MySqlCommand command = new MySqlCommand();
        private void DGO_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM danya.охрана", db.GetConnection());
            adapter.Fill(dt);
            DGO.ItemsSource = dt.AsDataView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.openConnection();

            command = new MySqlCommand("INSERT INTO `Danya`.`охрана`(`ФИО`,`Дата_рождения`,`Дата_поступления`,`Зарплата`,`Телефон`) Values (@NT,@DR,@DP,@ZP,@TEL)", db.GetConnection());
            command.Parameters.Add("@NT", MySqlDbType.VarChar).Value = Fio.Text;
            command.Parameters.Add("@DR", MySqlDbType.VarChar).Value = DateR.Text;
            command.Parameters.Add("@DP", MySqlDbType.VarChar).Value = DateP.Text;
            command.Parameters.Add("@ZP", MySqlDbType.VarChar).Value = ZP.Text;
            command.Parameters.Add("@TEL", MySqlDbType.VarChar).Value = Tel.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("охранник добавлен");
            DGO_Loaded(null, null);
            db.closeConnection();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(DGO.SelectedIndex != -1)
            {
                command = new MySqlCommand($"DELETE FROM `охрана` WHERE `id_Охраны` = '{(DGO.SelectedItem as DataRowView)[0]}'", db.GetConnection());
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                DGO_Loaded(null, null);
            }
        }
    }
}