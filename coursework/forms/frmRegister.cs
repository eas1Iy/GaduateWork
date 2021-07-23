using coursework.classes;
using coursework.dialogs;
using coursework.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework.forms
{
    public partial class frmRegister : Form
    {
        #region Переменные
        database db = new database();
        public bool dark;
        #endregion

        #region Начало
        public frmRegister()
        {
            InitializeComponent();

            dark = Convert.ToBoolean(Settings.Default["dark"]);
            if (dark == true)
                Theme(true);
            else
                Theme(false);
        }

        void frmRegister_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Функционал
        public List<string> listSimplePassowrd = new List<string>()
            {
                "123456789","987654321",
                "1234567890","0987654321",
                "12345543231","5432154321",
                "5432112345",
                "qwerty12345","qwerty54321",
                @"qwertyuiop[]\",@"\][poiuytrewq",
                "mama12345","54321mama","мама12345","мама54321","12345mama","54321mama","12345мама","54321мама",
                "password","мойпароль","adminpassword","testpassword"
            };
        public bool noSimplePass(string password)
        {
            bool simple = false;
            for (int i = 0; i < listSimplePassowrd.Count; i++)
            {
                string simplePass = listSimplePassowrd.ElementAt(i);
                if (password == simplePass) { simple = true; } else { }
            }
            if (simple == true) return false;
            else return true;
        }
        async void button_Register_Click(object sender, EventArgs e)
        {
            frmLogin lg = new frmLogin();
            if (textBox_FIO.Text.Length > 5 && textBox_password.Text.Length > 8 && textBox_phone.Text.Length > 7)
            {
                if (noSimplePass(textBox_password.Text) == true && textBox_password.Text != textBox_phone.Text)
                    if (db.keyExist(textBox_key.Text) == true)
                    {
                        db.TeacherAdd(textBox_FIO.Text, textBox_phone.Text, textBox_password.Text);
                        //
                        lg.combo_Select_SelectedValueChanged(null,e);
                        await Task.Delay(500);
                        this.Close();
                    }
                    else { }
                else this.Alert("Ваш пароль слишком простой, придумайте что-то посложнее.", frmNotification.enmType.Error);
            }
            else
            {
                this.Alert("Пожалуйста корректно заполните поля.", frmNotification.enmType.Error);
            }
        }
        #endregion

        #region Другое
        void ThemeChanger(Color cl_borderTxt,Color cl_panel, Color cl_mainPanel, Color cl_label)
        {
            panel_up.BackColor = cl_panel;
            this.BackColor = cl_mainPanel;
            lbl_UserHello.ForeColor = cl_label;
            HelpTip.BackColor = cl_panel;
            HelpTip.ForeColor = cl_label;

            foreach (Guna.UI2.WinForms.Guna2TextBox textBox in this.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                textBox.FillColor = cl_panel;
                textBox.BorderColor = cl_borderTxt;
            }
        }

        void Theme(bool dark)
        {
            if (dark == true)
            {
                ThemeChanger(Color.FromArgb(52, 52, 55), Color.FromArgb(45, 45, 48), Color.FromArgb(27, 27, 28), Color.White);
            }
            else
            {
                ThemeChanger(Color.FromArgb(213, 218, 223), Color.White, Color.FromArgb(239, 242, 252), Color.Black);
            }
        }


        public void Alert(string msg, frmNotification.enmType type)
        {
            frmNotification frm = new frmNotification();
            frm.showAlert(msg, type);
        }
        #endregion
    }
}
