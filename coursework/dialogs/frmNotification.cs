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
    public partial class frmNotification : Form
    {
        #region Переменные
        public bool dark;
        #endregion
        #region Начало
        public frmNotification()
        {
            InitializeComponent();

            dark = Convert.ToBoolean(Settings.Default["dark"]);
            if (dark == true)
                Theme(true);
            else
                Theme(false);
        }

        void frmNotification_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region enm разновидности
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private frmNotification.enmAction action;

        private int x, y;
        #endregion

        #region Создание уведомления
        private void timer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer.Interval = 5000;
                    action = enmAction.close;
                    break;
                case frmNotification.enmAction.start:
                    this.timer.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = frmNotification.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                frmNotification frm = (frmNotification)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.picture_NotificationIcon.Image = Resources.image_success;
                    break;
                case enmType.Error:
                    this.picture_NotificationIcon.Image = Resources.image_error;
                    break;
                case enmType.Info:
                    this.picture_NotificationIcon.Image = Resources.image_info;
                    break;
                case enmType.Warning:
                    this.picture_NotificationIcon.Image = Resources.image_warning;
                    break;
            }


            this.lbl_Message.Text = msg;

            this.Show();
            this.action = enmAction.start;
            this.timer.Interval = 1;
            this.timer.Start();
        }
        #endregion

        #region Другое
        void ThemeChanger(Color cl_panel, Color cl_mainPanel, Color cl_label)
        {
            panel_up.BackColor = cl_panel;
            this.BackColor = cl_mainPanel;
            lbl_Message.ForeColor = cl_label;
        }

        void Theme(bool dark)
        {
            if (dark == true)
            {
                ThemeChanger(Color.FromArgb(45, 45, 48), Color.FromArgb(27, 27, 28), Color.White);
            }
            else
            {
                ThemeChanger(Color.White, Color.FromArgb(239, 242, 252), Color.Black);
            }
        }
        #endregion
    }
}
