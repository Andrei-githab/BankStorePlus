using MySql.Data.MySqlClient;
using System;
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

namespace BankStorePlus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBox_login.Text.ToLower().Trim();
            string pasword = PasswordBox_pass.Password.Trim();

            if(login.Length == 0) 
            {
                TextBox_login.ToolTip = "Login не коректный!";
                TextBox_login.Background = Brushes.Red;

            } else if (pasword.Length == 0) 
            {
                PasswordBox_pass.ToolTip = "Пароль не коректный!";
                PasswordBox_pass.Background = Brushes.Red;

            } else
            {
                TextBox_login.ToolTip = "";
                TextBox_login.Background = Brushes.Transparent;
                PasswordBox_pass.ToolTip = "";
                PasswordBox_pass.Background = Brushes.Transparent;

                ConnectorDB dB = new ConnectorDB();
                DataTable data = new DataTable();
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @log AND password = @pass", dB.getConnection());
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pasword;
                sqlAdapter.SelectCommand = command;
                sqlAdapter.Fill(data);

                if (data.Rows.Count > 0)
                {
                    if (data.Rows[0][1].ToString() == "1") {
                        AdminPanelWindow adminPanelWindow = new AdminPanelWindow();
                        adminPanelWindow.Show();
                        Hide();
                    }
                    else 
                    {
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        Hide();
                    }
                }
                else 
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Hide();
        }       
    }
}
