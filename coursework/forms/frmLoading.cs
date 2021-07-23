using coursework.classes;
using coursework.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework.dialogs
{
    public partial class frmLoading : Form
    {
        #region Переменные
        bool dark;
        public bool load = true;
        #endregion

        #region Начало
        public frmLoading()
        {
            InitializeComponent();

            dark = Convert.ToBoolean(Settings.Default["dark"]);
            if (dark == true)
                ThemeChanger(Color.FromArgb(45, 45, 48), Color.FromArgb(28, 28, 28),Color.White);
            else
                ThemeChanger(Color.White,Color.FromArgb(239, 242, 252),Color.Black);
        }
        async void frmCheckInternet_Load(object sender, EventArgs e)
        {
            if (load == true)
            {
                await Task.Delay(800);
                if (Internet.CheckConnection())
                {
                    lbl_loadingInfo.Text = "Проверка соединение с сервером, пожалуйста ожидайте...";
                    await Task.Delay(500);
                    frmLogin login = new frmLogin();
                    this.Hide();
                    login.Show();
                }
                else
                {
                    _2DMessageBox.Show("Использование программы невозможно, отсутствует интернет соединение.", "Ошибка соединения.", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
            else
            {
                lbl_loadingInfo.Text = "Заполняются таблицы, пожалуйста подожите...";
                await Task.Delay(1500);
                lbl_loadingInfo.Text = "Проверка заполнения...";
                await Task.Delay(1000);
                lbl_loadingInfo.Text = "Запуск...";
                await Task.Delay(800);
                this.Close();
            }
        }
        #endregion

        #region Другое
        void ThemeChanger(Color cl_panel, Color cl_mainPanel, Color cl_label)
        {
            panel_up.BackColor = cl_panel;
            this.BackColor = cl_mainPanel;
            lbl_loadingInfo.ForeColor = cl_label;
        }
        #endregion
    }
}
