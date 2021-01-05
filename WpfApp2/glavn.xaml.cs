using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace WpfApp2
{
    public partial class glavn : Window
    {

        //Убейте меня, я потерялся

        //Пусть мама услышит,
        //Пусть мама придет,
        //Пусть мама меня непременно найдет! 
        string name;
        public glavn(string name, string id, string type)
        {
            InitializeComponent();
            this.name = name;
            idprod.Content = id;
            PanelAdmin.Visibility = type == "AD" ? Visibility.Visible : Visibility.Hidden;
            post.Content = type == "AD" ? "Супер пользователь" : "Простой пользователь";
            command.Connection = connection;
            connection.Open();
            command.CommandText = "SELECT MAX(`№_Чека`) FROM чек";
            nomchek.Content = int.TryParse(command.ExecuteScalar().ToString(), out int idOrder) ? idOrder + 1 : 1;
            connection.Close();
        }

        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=1234;database=danya");
        DataBase db = new DataBase();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable g = new DataTable();
        MySqlCommand command = new MySqlCommand();
        
        
        private void DGZ_Loaded_1(object sender, RoutedEventArgs e)
        {
            string txt = "SELECT `чек`.`№_Чека`, `Кол-во`, `продавцы`.`ФИО` as 'Продавец', `Наименование товара`, `покупатели`.`ФИО` as 'Покупатель', `консультанты`.`ФИО` as 'Консультант', id_Товар as 'ТоварID' FROM danya.чек "+
            "INNER JOIN `консультанты` ON `консультанты`.`id_Консультанта` = `чек`.`Консультанты_id_Консультанта` " +
            "INNER JOIN `продавцы` ON `продавцы`.`id_Продавца` = `чек`.`Продавцы_id_Продавца` " +
            "INNER JOIN `товар` ON `товар`.`id_Товар` = `чек`.`Товар_id_Товар` " +
            $"INNER JOIN `покупатели` ON `покупатели`.`idПокупатели` = `чек`.`Покупатели_idПокупатели` WHERE `чек`.`№_Чека` = {nomchek.Content}";
            command.CommandText = txt;
            command.Connection = connection;
            adapter.SelectCommand = command;
            g.Clear();
            adapter.Fill(g);
            DGZ.ItemsSource = g.AsDataView();
            DGZ.Columns[6].Visibility = Visibility.Hidden;
            DGZ.Columns[0].Visibility = Visibility.Hidden;
            connection.Open();
            command.CommandText = $"SELECT SUM(`Кол-во` * `Стоимость`) FROM `чек` INNER JOIN товар ON `товар`.id_Товар = `чек`.`Товар_id_Товар` WHERE `№_Чека` = {nomchek.Content}";
            summ.Content = command.ExecuteScalar();
            connection.Close();
        }

        private void lbName_Loaded(object sender, RoutedEventArgs e)
        {
            lbName.Content = name;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var a = new DataTable();
            a.Columns.Add(new DataColumn());
            a.Rows.Add(nomchek.Content);
            var r = a.DefaultView[0];
            AdApplication add = new AdApplication(false, r)
            {
                Title = "Добавление",
                ID = idprod.Content.ToString(),
                SellerName = name
            };
            Hide();
            add.ShowDialog();
            Show();
            DGZ_Loaded_1(null, null);
        }

        
        private void DGZ_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DGZ.SelectedIndex != -1)
            {
                DataRowView p = (DataRowView)DGZ.SelectedItem;
                int k = Convert.ToInt32(p[0]);
                DataTable dt = new DataTable();
                dt.Clear();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `№_Чека` FROM danya.чек where `№_Чека`= '" + k + "'", db.GetConnection());
                adapter.Fill(dt);
                labeldelet.Content = (dt.Rows[0][0].ToString());
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            if (DGZ.SelectedIndex != -1)
            {
                DataRowView p = (DataRowView)DGZ.SelectedItem;
                command.Connection = connection;
                connection.Open();
                string txt = $"DELETE FROM чек WHERE `№_чека` = '{ labeldelet.Content }' and `Товар_id_Товар` = {p[6]} ";
                command.CommandText = txt;
                command.ExecuteNonQuery();

                string add = $"UPDATE товар SET `Кол-во товара` = `Кол-во товара` + {p[1]} WHERE id_Товар = {p[6]}";
                command.CommandText = add;
                command.ExecuteNonQuery();
                connection.Close();
                DGZ_Loaded_1(null, null);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            avtor avtor = new avtor();
            avtor.Show();
            this.Close();
        }

       

        private void ism_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowView p = (DataRowView)DGZ.SelectedItem;
            if(p != null)
            {
                AdApplication izm = new AdApplication(true, p)
                {
                    Title = "Изменение",
                    ID = idprod.Content.ToString(),
                    SellerName = name

                };
                Hide();
                izm.ShowDialog();
                Show();
                DGZ_Loaded_1(null, null);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nomchek.Content = int.Parse(nomchek.Content.ToString()) + 1;
            DGZ_Loaded_1(null, null);
        }

        private void inf_Click(object sender, RoutedEventArgs e)
        {
            infwindow inf = new infwindow();
            inf.Show();          
        }

        private void dobtov_Click(object sender, RoutedEventArgs e)
        {
            Addtovar at = new Addtovar();
            Hide();
            at.ShowDialog();
            Show();
        }

        private void spsotr_Click(object sender, RoutedEventArgs e)
        {
            Addsotr ads = new Addsotr();
            Hide();
            ads.ShowDialog();
            Show();
        }

        private void oxr_Click(object sender, RoutedEventArgs e)
        {
            addsecurity adss = new addsecurity();
            Hide();
            adss.ShowDialog();
            Show();
        }
    }
}
