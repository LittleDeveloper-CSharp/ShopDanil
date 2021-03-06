﻿using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Addtovar.xaml
    /// </summary>
    public partial class Addtovar : Window
    {
        public Addtovar()
        {
            InitializeComponent();
        }

        
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=1234;database=danya");
        DataBase db = new DataBase();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable g = new DataTable();
        MySqlCommand command = new MySqlCommand();

        private void DGT_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM danya.товар", db.GetConnection());
            adapter.Fill(dt);
            DGT.ItemsSource = dt.AsDataView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.openConnection();

            command = new MySqlCommand("INSERT INTO `Danya`.`товар`(``,`Кол-во товара`,`Стоимость`) Values (@NT,@KT,@S)", db.GetConnection());
            command.Parameters.Add("@NT", MySqlDbType.VarChar).Value = NameTB.Text;
            command.Parameters.Add("@KT", MySqlDbType.VarChar).Value = KolTB.Text;
            command.Parameters.Add("@S", MySqlDbType.VarChar).Value = costTB.Text;
            command.ExecuteNonQuery();
            MessageBox.Show("товар добавлен");

            db.closeConnection();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DGT.SelectedIndex != -1) 
            {
                db.openConnection();
                DataTable dt = new DataTable();
                MySqlCommand command = new MySqlCommand($"Delete From `товар` WHERE `id_Товар` = '{(DGT.SelectedItem as DataRowView)[0]}'", db.GetConnection());
                command.ExecuteNonQuery();
                DGT_Loaded(null, null);
                MessageBox.Show("товар удален");
                db.closeConnection();
            } 
        }
    }
}