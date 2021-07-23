using coursework.classes;
using coursework.dialogs;
using coursework.forms;
using coursework.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class frmLogin : Form
    {
        #region Переменные
        static string AppPath = Environment.CurrentDirectory;
        static string usersDirectory = AppPath + "/users/";
        static string imagesDirectory = usersDirectory + "images/";
        //
        database db = new database();
        //
        public bool dark;
        public bool lowPC;
        //
        public string username;
        public string password;
        public string status;
        public int id_user;
        #endregion

        #region Начало
        public frmLogin()
        {
            InitializeComponent();

            dark = Convert.ToBoolean(Settings.Default["dark"]);
            lowPC = Convert.ToBoolean(Settings.Default["lowToggle"]);
            if (dark == true)
                Theme(true);
            else
                Theme(false);
        }
        void _welcomeForm_Load(object sender, EventArgs e)
        {
            lbl_UserHello.Text = "Приветствуем, <b><font color='#6B7BCF'> " + Environment.UserName + " </b></font>";
            combobox();
        }
        #endregion

        #region Кнопки
        void button_Register_Click(object sender, EventArgs e)
        {
            frmRegister reg = new frmRegister();
            reg.ShowDialog();
        }
        void button_resetPassword_Click(object sender, EventArgs e)
        {
            _2DMessageBox.Show("Извините, но восстановление пользователя, временно отключено разработчиком программы.\n\nПриносим наши извинения.", "Неизвестная ошибка.", MessageBoxButtons.OK);
        }
        void button_Login_Click(object sender, EventArgs e)
        {
            if (combo_Teachers.SelectedIndex != -1)
            {
                if (textBox_password.Text == password)
                {
                    this.Alert("Успешная авторизация, приятного использования!", frmNotification.enmType.Success);
                    helloShow();
                }
                else if (textBox_password.Text.Length == 0)
                {
                    this.Alert("Введите пароль!", frmNotification.enmType.Error);
                }
                else
                {
                    this.Alert("Неверный пароль, введите корректные данные!", frmNotification.enmType.Error);
                }
            }
            else
            {
                this.Alert("Необходимо выбрать кем вы являетесь!", frmNotification.enmType.Error);
            }
        }
        #endregion

        #region Заполнение
        public void combobox()
        {
            try
            {
                combo_Teachers.Enabled = true;
                if ((int)combo_Select.SelectedIndex == 0)
                {
                    db.combobox(combo_Teachers, "SELECT FIO,id_doctor FROM doctors", "FIO", "id_doctor");
                }
                else if ((int)combo_Select.SelectedIndex == 1)
                {
                    db.combobox(combo_Teachers, "SELECT FIO,id_teacher FROM teachers", "FIO", "id_teacher");
                }
                else
                {
                    combo_Teachers.Enabled = false;
                    id_user = 0;
                    password = "12344321";
                    username = "Администратор";
                    status = "developer";
                }
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void combo_Select_SelectedValueChanged(object sender, EventArgs e)
        {
            combobox();
        }
        async void combo_Teachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Delay(500);
            if (combo_Select.SelectedIndex == 0)
            {
                password = db.getPassword(false, Convert.ToInt32(combo_Teachers.SelectedValue));
                username = combo_Teachers.Text;
                id_user = Convert.ToInt32(combo_Teachers.SelectedValue);
                status = "Фельдшер";
            }
            else if (combo_Select.SelectedIndex == 1)
            {
                password = db.getPassword(true, (int)combo_Teachers.SelectedValue);
                username = combo_Teachers.Text;
                id_user = (int)combo_Teachers.SelectedValue;
                status = "Куратор";
            }
        }
        #endregion

        #region Другое
        void ThemeChanger(Color cl_borderText, Color cl_buttonHover, Color cl_panel, Color cl_mainPanel, Color cl_label, string nameProject)
        {
            panel_up.BackColor = cl_panel;
            this.BackColor = cl_mainPanel;
            lbl_NameProject.Text = nameProject;
            button_resetPassword.HoverState.FillColor = cl_buttonHover;
            button_Register.HoverState.FillColor = cl_buttonHover;

            //
            combo_Teachers.FillColor = cl_panel;
            combo_Teachers.BorderColor = cl_borderText;
            //
            combo_Select.FillColor = cl_panel;
            combo_Select.BorderColor = cl_borderText;

            textBox_password.FillColor = cl_panel;
            textBox_password.BorderColor = cl_borderText;
            //
            HelpTip.BackColor = cl_panel;
            HelpTip.ForeColor = cl_label;

            foreach (Guna.UI2.WinForms.Guna2Button item in this.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                item.ForeColor = cl_label;
            }

            foreach (Guna.UI2.WinForms.Guna2HtmlLabel item in this.Controls.OfType<Guna.UI2.WinForms.Guna2HtmlLabel>())
            {
                item.ForeColor = cl_label;
            }
        }

        void Theme(bool dark)
        {
            if (dark == true)
            {
                ThemeChanger(Color.FromArgb(52, 52, 55), Color.FromArgb(45, 45, 48), Color.FromArgb(45, 45, 48), Color.FromArgb(27, 27, 28), Color.White, "<font color='#FFFFFF'>Wellness</font><b><font color='#6B7BCF'>App</font>");
            }
            else
            {
                ThemeChanger(Color.FromArgb(213, 218, 223), Color.FromArgb(224, 224, 224), Color.White, Color.FromArgb(239, 242, 252), Color.Black, "Wellness<b><font color='#6B7BCF'>App</font>");
                button_Login.ForeColor = Color.White;
            }
        }

        void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void panel_up_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        async void helloShow()
        {
            if (lowPC == false)
            {
                button_Login.Enabled = false;
                button_resetPassword.Enabled = false;
                button_Register.Enabled = false;

                //animator.Hide(panel_up);
                panel_up.Enabled = false;
                animator.Hide(lbl_NameProject);
                animator.Hide(lbl_UserHello);
                animator.Hide(combo_Select);
                animator.Hide(combo_Teachers);
                animator.Hide(textBox_password);
                animator.Hide(button_resetPassword);
                animator.Hide(button_Login);
                animator.Hide(lbl_Note);
                animator.Hide(button_Register);
                animator.HideSync(panel_up);

                welcome.Text = $"Добро пожаловать, <b><font color='#6B7BCF'>{username}</b></font>";
                animator.ShowSync(welcome);
                await Task.Delay(800);
                animator.HideSync(welcome);


                frmMain main = new frmMain();
                main.userName = username;
                main.status = status;
                main.id_user = id_user;
                main.Show();
                this.Hide();
            }
            else
            {
                frmMain main = new frmMain();
                main.userName = username;
                main.status = status;
                main.id_user = id_user;
                main.Show();
                this.Hide();
            }
        }
        // this.Alert("Проверка, УСПЕШНО", frmNotification.enmType.Success);
        // this.Alert("Проверка, Ошибка", frmNotification.enmType.Error);
        // this.Alert("Проверка, ИНФОРМАЦИЯ", frmNotification.enmType.Info);
        // this.Alert("Проверка, ПРЕДУПРЕЖДЕНИЕ", frmNotification.enmType.Warning);
        public void Alert(string msg, frmNotification.enmType type)
        {
            frmNotification frm = new frmNotification();
            frm.showAlert(msg, type);
        }
        #endregion
    }
}
