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
    public partial class frmYesNo : Form
    {
        #region Переменные
        public bool dark;
        #endregion

        #region Начало
        public frmYesNo()
        {
            InitializeComponent();

            dark = Convert.ToBoolean(Settings.Default["dark"]);
            if (dark == true)
                Theme(true);
            else
                Theme(false);

        }
        private void frmYesNo_Load(object sender, EventArgs e)
        {
            lbl_Name.Text = this.Text;
        }
        #endregion

        #region Создание диалога

        public string Message
        {
            get { return lbl_Message.Text; }
            set { lbl_Message.Text = value; }
        }

        private void button_Yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void button_No_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        #endregion

        #region Другое
        void ThemeChanger(Color cl_panel, Color cl_mainPanel, Color cl_label)
        {
            panel_up.BackColor = cl_panel;
            this.BackColor = cl_mainPanel;
            lbl_Message.ForeColor = cl_label;
            lbl_Name.ForeColor = cl_label;
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
