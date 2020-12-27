using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AdApplication.xaml
    /// </summary>
    public partial class AdApplication : Window
    {

        public string ID { get; set; }
        bool IsEdit;
        public string SellerName { get; set; }
        private int idOrder;

        public AdApplication(bool IsEdit, DataRowView SelectedRow = null)
        {
            InitializeComponent();
            command.Connection = connection;
            this.IsEdit = IsEdit;
            idOrder = int.Parse(SelectedRow[0].ToString());
            command.Connection = db.GetConnection();
            db.openConnection();
            if (IsEdit)
            {
                AddZaiav.Content = "Изменить заявку";
                labelkolvo.Content = SelectedRow.Row["Кол-во"].ToString();
                //string kolvo = $"UPDATE товар join чек on `товар`.`id_Товар` = `чек`.`Товар_id_Товар` SET `товар`.`Кол-во товара` = `товар`.`Кол-во товара` + `чек`.`Товар_id_Товар` Where `товар`.`id_Товар` = {SelectedRow.Row["ТоварID"]}";
                string kolvo = $"UPDATE товар SET `Кол-во товара` = `Кол-во товара` + {SelectedRow["Кол-во"]} WHERE id_Товар = {SelectedRow.Row["ТоварID"]}";

                command.CommandText = "Start transaction";
                command.ExecuteNonQuery();

                command.CommandText = kolvo;
                command.ExecuteNonQuery();

                command.CommandText = $"DELETE FROM чек WHERE `№_Чека`= {SelectedRow[0]} and `Товар_id_Товар` = {SelectedRow.Row["ТоварID"]}";
                command.ExecuteNonQuery();

                labelkons.Content = SelectedRow.Row["Консультант"].ToString();
                labelprod.Content = SelectedRow.Row["Продавец"].ToString();
                labelpok.Content = SelectedRow.Row["Покупатель"].ToString();
                labeltovar.Content = SelectedRow.Row["Наименование товара"].ToString();
            }
        }

        

        string pok;
        string prod;
        string tov;
        string kons;

        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=1234;database=danya");
        DataBase db = new DataBase();
        MySqlCommand command = new MySqlCommand();
        DataTable datatable = new DataTable();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            AddPokypatel pokadd = new AddPokypatel();
            pokadd.Show();
            //this.Hide();
        }

        private void TovarDG_Loaded(object sender, RoutedEventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM danya.товар WHERE id_Товар not in (SELECT Товар_id_Товар FROM чек WHERE №_Чека = {idOrder})", db.GetConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            TovarDG.ItemsSource = dt.AsDataView();
            
        }

        private void DGKons_Loaded(object sender, RoutedEventArgs e)
        {

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM danya.консультанты", db.GetConnection());
            adapter.Fill(dt);
            DGKons.ItemsSource = dt.AsDataView();

        }

        private void DGPok_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM danya.покупатели", db.GetConnection());
            adapter.Fill(dt);
            DGPok.ItemsSource = dt.AsDataView();
        }

        private void TB1_TextChanged(object sender, TextChangedEventArgs e)
        {

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string commandText = "Select * FROM покупатели where ФИО like '%" + TB1.Text + "%' or Лицензия  like '%" + TB1.Text + "%' or Номер_телефона like '%" + TB1.Text + "%'";
            command.CommandText = commandText;
            command.Connection = db.GetConnection();
            adapter.SelectCommand = command;
            datatable.Clear();
            adapter.Fill(dt);
            DGPok.ItemsSource = dt.AsDataView();
        }
        private void Tb2_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string commandText = "Select * FROM товар where `Наименование товара` like '%" + Tb2.Text + "%'";
            command.CommandText = commandText;
            command.Connection = db.GetConnection();
            adapter.SelectCommand = command;
            datatable.Clear();
            adapter.Fill(dt);
            TovarDG.ItemsSource = dt.AsDataView();
        }

        private void Tb3_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string commandText = "Select * FROM консультанты where ФИО like '%" + Tb3.Text + "%'";
            command.CommandText = commandText;
            command.Connection = db.GetConnection();
            adapter.SelectCommand = command;
            datatable.Clear();
            adapter.Fill(dt);
            DGKons.ItemsSource = dt.AsDataView();
        }

        private void TovarDG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `Наименование товара` FROM danya.товар where id_Товар = '" + (TovarDG.SelectedIndex+1)+"'", db.GetConnection());
            adapter.Fill(dt);
            labeltovar.Content=(dt.Rows[0][0].ToString());

            DataTable idtov = new DataTable();
            DataRowView view = (DataRowView)TovarDG.SelectedItem;
            MySqlDataAdapter adap = new MySqlDataAdapter("SELECT `id_Товар` FROM danya.товар where id_Товар = '" + (view[0]) + "'", db.GetConnection());
            adap.Fill(idtov);
            tov = (idtov.Rows[0][0].ToString());

            DataTable sum = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT '" + Kolv.Text + "' * `Стоимость` AS итого FROM danya.товар where id_Товар = '" + (TovarDG.SelectedIndex + 1) + "'", db.GetConnection());
            adapt.Fill(sum);
            summ.Content = (sum.Rows[0][0].ToString());
        }

        private void DGKons_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `ФИО` FROM danya.консультанты where id_Консультанта = '" + (DGKons.SelectedIndex + 1) + "'", db.GetConnection());
            adapter.Fill(dt);
            labelkons.Content = (dt.Rows[0][0].ToString());

            DataTable data = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter("SELECT `id_Консультанта` FROM danya.консультанты where id_Консультанта  = '" + (DGKons.SelectedIndex + 1) + "'", db.GetConnection());
            adap.Fill(data);
            kons = (data.Rows[0][0].ToString());
        }

        private void DGPok_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `ФИО` FROM danya.покупатели where idПокупатели = '" + (DGPok.SelectedIndex + 1) + "'", db.GetConnection());
            adapter.Fill(dt);
            labelpok.Content = (dt.Rows[0][0].ToString());

            DataTable data = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter("SELECT `idПокупатели` FROM danya.покупатели where idПокупатели = '" + (DGPok.SelectedIndex + 1) + "'", db.GetConnection());
            adap.Fill(data);
            pok = (data.Rows[0][0].ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            labelprod.Content = SellerName;
            prod = ID;
        }


        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelkolvo.Content = Kolv.Text;
        }

        int kol;
        int lok;
        string name;
        string id;
        private void AddZaiav_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEdit)
            {
                int kol = int.Parse(Kolv.Text.ToString());
                
                string s = $"INsert into чек (`№_Чека`, `Кол-во`, `Продавцы_id_Продавца`, `Товар_id_Товар`, `Покупатели_idПокупатели`, `Консультанты_id_Консультанта`) Values ('{idOrder}', '{labelkolvo.Content}','{prod}','{tov}','{pok}','{kons}')";
                command.Connection = db.GetConnection();
                command.CommandText = s;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //DataTable dt = new DataTable();
                //MySqlDataAdapter adapter = new MySqlDataAdapter();

                string vsiochenplohoisvinite = $"UPDATE товар SET `Кол-во товара` = `Кол-во товара` - {Kolv.Text} Where `id_Товар` =  '{tov}'";
                command.CommandText = vsiochenplohoisvinite;
                command.ExecuteNonQuery();
            }
            else if (IsEdit)
            {
                string s = $"INsert into чек (`№_Чека`, `Кол-во`, `Продавцы_id_Продавца`, `Товар_id_Товар`, `Покупатели_idПокупатели`, `Консультанты_id_Консультанта`) Values ('{idOrder}', '{labelkolvo.Content}','{prod}','{tov}','{pok}','{kons}')";
                command.Connection = db.GetConnection();
                command.CommandText = s;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //DataTable dt = new DataTable();
                //MySqlDataAdapter adapter = new MySqlDataAdapter();

                string vsiochenplohoisvinite = $"UPDATE товар SET `Кол-во товара` = `Кол-во товара` - {Kolv.Text} Where `id_Товар` =  '{tov}'";
                command.CommandText = vsiochenplohoisvinite;
                command.ExecuteNonQuery();
                command.CommandText = "commit";
                command.ExecuteNonQuery();
            }
            this.Close();
            db.closeConnection();
        }

        private void obn_Click(object sender, RoutedEventArgs e)
        { 
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("Select * FROM `покупатели`",db.GetConnection());
            adapter.Fill(dt);
            DGPok.ItemsSource = dt.AsDataView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                command.CommandText = "rollback";
                command.ExecuteNonQuery();
            }
            catch{ }

            if (!IsEdit)
            {
                this.Close();
            }
            else if (IsEdit)
            {
                

            }
        }
    }
}
