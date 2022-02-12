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

namespace BankStorePlus
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_first_name.Text.Length != 0 && TextBox_last_name.Text.Length != 0 && TextBox_middle_name.Text.Length != 0 && TextBox_login.Text.Length != 0 && TextBox_email.Text.Length != 0 && PasswordBox_pass.Password.Length != 0) 
            {
                if (PasswordBox_pass.Password == PasswordBox_passduo.Password)
                {
                    ConnectorDB connector = new ConnectorDB();
                    connector.openConnection();
                    MySqlCommand sqlCommandNewPol = new MySqlCommand("INSERT INTO users (role_id, first_name, last_name, middle_name, login, email, password) VALUES ('0', @fn, @ln, @mn, @login, @email, @pass)", connector.getConnection());
                    sqlCommandNewPol.Parameters.Add("@fn", MySqlDbType.VarChar).Value = TextBox_first_name.Text;
                    sqlCommandNewPol.Parameters.Add("@ln", MySqlDbType.VarChar).Value = TextBox_last_name.Text;
                    sqlCommandNewPol.Parameters.Add("@mn", MySqlDbType.VarChar).Value = TextBox_middle_name.Text;
                    sqlCommandNewPol.Parameters.Add("@login", MySqlDbType.VarChar).Value = TextBox_login.Text;
                    sqlCommandNewPol.Parameters.Add("@email", MySqlDbType.VarChar).Value = TextBox_email.Text;
                    sqlCommandNewPol.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PasswordBox_pass.Password;
                    if (sqlCommandNewPol.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Вы успешно зарегистрированы!");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
            }
            else 
            {
                MessageBox.Show("Одно или более поле не заполнено");
            }
        }

        private void Button_Vihod_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
