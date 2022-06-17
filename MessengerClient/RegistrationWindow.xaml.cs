using MessengerClient.DBMS;
using System.Windows;
using System.Windows.Input;


namespace MessengerClient
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        ApplicationContext applicationContext;
        public RegistrationWindow()
        {
            InitializeComponent();
            applicationContext = new ApplicationContext();
        }
        //Захват мышкой и перемещение
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //Выход из приложения
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Переход к другому окну если аккаунт уже есть
        private void Swipe_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            auth.Show();
            this.Close();
        }
        //Кнопка регестрации
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            //Получение логина
            string login = Login.Text.Trim();
            //Получение пароля
            string pass1 = Pass1.Password.Trim(); ;
            //Повтор пароля
            string pass2 = Pass2.Password.Trim(); ;
            CheckandRegistr(login, pass1, pass2);
           
        }
        //Проверка полей и регестрация в приложении
        public void CheckandRegistr(string login,string pass1,string pass2)
        {
            //Провекра условий логина
            if (login.Length <= 3)
            {
                Login.ToolTip = "Имя должно быть длинее(минимум 3 буквы)";
                MessageBox.Show("Проверьте введенные данные");
            }
            //Провекра условий пароля
            else if (pass1.Length < 5)
            {
                Pass1.ToolTip = "Пароль должен быть длиннее 5 символов";
                MessageBox.Show("Проверьте введенные данные");
            }
            //Проверка на совпадение паролей
            else if (pass1 != pass2)
            {
                Pass2.ToolTip = "Пароли не совпадают";
                MessageBox.Show("Проверьте введенные данные");
            }
            //Если все поля корректны
            else
            {
                Login.ToolTip = "";
                Pass1.ToolTip = "";
                Pass2.ToolTip = "";
                //Регестрация нового пользователя
                User user = new User(login, pass1);
                //Добавление клиента в список
                applicationContext.Users.Add(user);
                //Сохранение изменений
                applicationContext.SaveChanges();
                //Сообщение об успешной регестрации
                MessageBox.Show("Регестрация пройдена успешно!");
                //переход на другое окно
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Close();
            }
        }
    }
}

