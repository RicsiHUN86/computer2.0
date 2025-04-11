using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace computer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void computer(object sender, RoutedEventArgs e)
        {
            string query = "SELECT Id, Brand, Type, Display, Memory, CreatedTime FROM comp";
            DataTable table = Connect.GetData(query);
            data.ItemsSource = table.DefaultView;
        }

        private void operaciosrendszer(object sender, RoutedEventArgs e)
        {
            string query = "SELECT Id, Name FROM OSystem";
            DataTable table = Connect.GetData(query);
            data.ItemsSource = table.DefaultView;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = username_txt.Text;
            string password = passwordBox.Password;

            if (Login_ellenorzes(username, password))
            {
                MessageBox.Show("Sikeres bejelentkezés!");
                MainMenu.Visibility = Visibility.Visible;
                data.Visibility = Visibility.Visible;
                username_txt.Text = string.Empty;
                passwordBox.Password = string.Empty;

                Reg_Label.Visibility = Visibility.Collapsed;
                Reg_Button.Visibility = Visibility.Collapsed;
                Reg_Pass1.Visibility = Visibility.Collapsed;
                Reg_Pass2.Visibility = Visibility.Collapsed;
                Reg_User.Visibility = Visibility.Collapsed;

                username_txt.Visibility = Visibility.Collapsed;
                passwordBox.Visibility = Visibility.Collapsed;
                Login_Button.Visibility = Visibility.Collapsed;  
                Login_Label.Visibility = Visibility.Collapsed;

                Reg_Jelszo1L.Visibility = Visibility.Collapsed;
                Reg_Jelszo2L.Visibility = Visibility.Collapsed;
                Reg_UserL.Visibility = Visibility.Collapsed;
                login_UserL.Visibility = Visibility.Collapsed;
                Login_jelszoL.Visibility = Visibility.Collapsed;

            }
            else
            {
                MessageBox.Show("Hibás felhasználónév vagy jelszó.");
            }
        }

        private bool Login_ellenorzes(string username, string password)
        {

            string query = "SELECT COUNT(*) FROM users WHERE Username = @Username AND Password = @Password";


            using (MySqlConnection connection = Connect.GetConnection())
            {

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);


                    connection.Open();
                    int userCount = Convert.ToInt32(command.ExecuteScalar());
                    return userCount > 0;
                }


            }
        }
        private void kilepes_Click(object sender, RoutedEventArgs e)
        {
            Reg_Label.Visibility = Visibility.Visible;
            Reg_Button.Visibility = Visibility.Visible;
            Reg_Pass1.Visibility = Visibility.Visible;
            Reg_Pass2.Visibility = Visibility.Visible;
            Reg_User.Visibility = Visibility.Visible;

            username_txt.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Visible;
            Login_Button.Visibility = Visibility.Visible;
            Login_Label.Visibility = Visibility.Visible;

            MainMenu.Visibility = Visibility.Collapsed;
            data.Visibility = Visibility.Collapsed;

            Reg_Jelszo1L.Visibility = Visibility.Visible;
            Reg_Jelszo2L.Visibility = Visibility.Visible;
            Reg_UserL.Visibility = Visibility.Visible;
            login_UserL.Visibility = Visibility.Visible;
            Login_jelszoL.Visibility = Visibility.Visible;
        }


        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (Reg_Pass1.Password != Reg_Pass2.Password)
            {
                MessageBox.Show("A két jelszó nem egyezik!");
                Reg_Pass1.Password = "";
                Reg_Pass2.Password = "";
                return;
            }

            using (var conn = Connect.GetConnection())
            {
                conn.Open();

                var sql = $"SELECT * FROM users WHERE Username = '{Reg_User.Text}'";
                using (var checkCmd = new MySqlCommand(sql, conn))
                using (var reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Ez a felhasználónév már foglalt!");
                        return; 
                    }
                }

                sql = $"INSERT INTO users (Username, Password) VALUES ('{Reg_User.Text}', '{Reg_Pass1.Password}')";
                var insertCmd = new MySqlCommand(sql, conn);
                int siker = insertCmd.ExecuteNonQuery();

                if (siker == 1)
                {
                    MessageBox.Show("Sikeres regisztráció!");
                    Reg_Label.Visibility = Visibility.Collapsed;
                    Reg_Button.Visibility = Visibility.Collapsed;
                    Reg_Pass1.Visibility = Visibility.Collapsed;
                    Reg_Pass2.Visibility = Visibility.Collapsed;
                    Reg_User.Visibility = Visibility.Collapsed;

                    Reg_Jelszo1L.Visibility = Visibility.Collapsed;
                    Reg_Jelszo2L.Visibility = Visibility.Collapsed;
                    Reg_UserL.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Sikertelen regisztráció!");
                }

                Reg_User.Text = "";
                Reg_Pass1.Password = "";
                Reg_Pass2.Password = "";
            }
        }



    }
}