
namespace coursework.forms
{
    partial class frmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.button_Register = new Guna.UI2.WinForms.Guna2Button();
            this.panel_up = new System.Windows.Forms.Panel();
            this.button_Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.textBox_FIO = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox_key = new Guna.UI2.WinForms.Guna2TextBox();
            this.HelpTip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.textBox_phone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_UserHello = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.frmSettings = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel_up.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Register
            // 
            this.button_Register.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Register.Animated = true;
            this.button_Register.BorderRadius = 8;
            this.button_Register.CheckedState.Parent = this.button_Register;
            this.button_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Register.CustomImages.Parent = this.button_Register;
            this.button_Register.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_Register.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button_Register.ForeColor = System.Drawing.Color.White;
            this.button_Register.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(144)))), ((int)(((byte)(228)))));
            this.button_Register.HoverState.Parent = this.button_Register;
            this.button_Register.Location = new System.Drawing.Point(17, 319);
            this.button_Register.Name = "button_Register";
            this.button_Register.ShadowDecoration.Parent = this.button_Register;
            this.button_Register.Size = new System.Drawing.Size(189, 35);
            this.button_Register.TabIndex = 7;
            this.button_Register.Text = "Зарегистрироваться";
            this.button_Register.TextFormatNoPrefix = true;
            this.button_Register.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // panel_up
            // 
            this.panel_up.BackColor = System.Drawing.Color.White;
            this.panel_up.Controls.Add(this.button_Close);
            this.panel_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_up.Location = new System.Drawing.Point(0, 0);
            this.panel_up.Name = "panel_up";
            this.panel_up.Size = new System.Drawing.Size(392, 37);
            this.panel_up.TabIndex = 8;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Animated = true;
            this.button_Close.FillColor = System.Drawing.Color.Transparent;
            this.button_Close.HoverState.FillColor = System.Drawing.Color.Brown;
            this.button_Close.HoverState.IconColor = System.Drawing.Color.White;
            this.button_Close.HoverState.Parent = this.button_Close;
            this.button_Close.IconColor = System.Drawing.Color.Gray;
            this.button_Close.Location = new System.Drawing.Point(344, 0);
            this.button_Close.Name = "button_Close";
            this.button_Close.ShadowDecoration.Parent = this.button_Close;
            this.button_Close.Size = new System.Drawing.Size(48, 37);
            this.button_Close.TabIndex = 0;
            // 
            // textBox_FIO
            // 
            this.textBox_FIO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_FIO.Animated = true;
            this.textBox_FIO.BackColor = System.Drawing.Color.Transparent;
            this.textBox_FIO.BorderRadius = 8;
            this.textBox_FIO.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_FIO.DefaultText = "";
            this.textBox_FIO.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_FIO.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_FIO.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_FIO.DisabledState.Parent = this.textBox_FIO;
            this.textBox_FIO.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_FIO.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_FIO.FocusedState.Parent = this.textBox_FIO;
            this.textBox_FIO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_FIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_FIO.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.textBox_FIO.HoverState.Parent = this.textBox_FIO;
            this.textBox_FIO.IconLeft = global::coursework.Properties.Resources.image_user;
            this.textBox_FIO.IconLeftSize = new System.Drawing.Size(24, 24);
            this.textBox_FIO.Location = new System.Drawing.Point(17, 97);
            this.textBox_FIO.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.textBox_FIO.Name = "textBox_FIO";
            this.textBox_FIO.PasswordChar = '\0';
            this.textBox_FIO.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.textBox_FIO.PlaceholderText = "ФИО";
            this.textBox_FIO.SelectedText = "";
            this.textBox_FIO.ShadowDecoration.BorderRadius = 12;
            this.textBox_FIO.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.textBox_FIO.ShadowDecoration.Depth = 10;
            this.textBox_FIO.ShadowDecoration.Enabled = true;
            this.textBox_FIO.ShadowDecoration.Parent = this.textBox_FIO;
            this.textBox_FIO.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.textBox_FIO.Size = new System.Drawing.Size(358, 39);
            this.textBox_FIO.TabIndex = 11;
            this.textBox_FIO.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_password.Animated = true;
            this.textBox_password.BackColor = System.Drawing.Color.Transparent;
            this.textBox_password.BorderRadius = 8;
            this.textBox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_password.DefaultText = "";
            this.textBox_password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_password.DisabledState.Parent = this.textBox_password;
            this.textBox_password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_password.FocusedState.Parent = this.textBox_password;
            this.textBox_password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.textBox_password.HoverState.Parent = this.textBox_password;
            this.textBox_password.IconLeft = global::coursework.Properties.Resources.image_password;
            this.textBox_password.IconLeftSize = new System.Drawing.Size(24, 24);
            this.textBox_password.Location = new System.Drawing.Point(17, 154);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '\0';
            this.textBox_password.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.textBox_password.PlaceholderText = "Пароль";
            this.textBox_password.SelectedText = "";
            this.textBox_password.ShadowDecoration.BorderRadius = 12;
            this.textBox_password.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.textBox_password.ShadowDecoration.Depth = 10;
            this.textBox_password.ShadowDecoration.Enabled = true;
            this.textBox_password.ShadowDecoration.Parent = this.textBox_password;
            this.textBox_password.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.textBox_password.Size = new System.Drawing.Size(358, 39);
            this.textBox_password.TabIndex = 10;
            this.textBox_password.TextOffset = new System.Drawing.Point(5, 0);
            this.HelpTip.SetToolTip(this.textBox_password, "Пароль необходим для единоличного доступа к аккаунту.");
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // textBox_key
            // 
            this.textBox_key.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_key.Animated = true;
            this.textBox_key.BackColor = System.Drawing.Color.Transparent;
            this.textBox_key.BorderRadius = 8;
            this.textBox_key.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_key.DefaultText = "";
            this.textBox_key.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_key.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_key.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_key.DisabledState.Parent = this.textBox_key;
            this.textBox_key.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_key.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_key.FocusedState.Parent = this.textBox_key;
            this.textBox_key.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_key.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.textBox_key.HoverState.Parent = this.textBox_key;
            this.textBox_key.IconLeft = global::coursework.Properties.Resources.image_key;
            this.textBox_key.IconLeftSize = new System.Drawing.Size(24, 24);
            this.textBox_key.Location = new System.Drawing.Point(17, 268);
            this.textBox_key.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.PasswordChar = '\0';
            this.textBox_key.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.textBox_key.PlaceholderText = "Ключ доступа";
            this.textBox_key.SelectedText = "";
            this.textBox_key.ShadowDecoration.BorderRadius = 12;
            this.textBox_key.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.textBox_key.ShadowDecoration.Depth = 10;
            this.textBox_key.ShadowDecoration.Enabled = true;
            this.textBox_key.ShadowDecoration.Parent = this.textBox_key;
            this.textBox_key.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.textBox_key.Size = new System.Drawing.Size(358, 39);
            this.textBox_key.TabIndex = 9;
            this.textBox_key.TextOffset = new System.Drawing.Point(5, 0);
            this.HelpTip.SetToolTip(this.textBox_key, "Ключ доступа - пригласительный ключ, который вам послал администратор учебного за" +
        "ведения.");
            // 
            // HelpTip
            // 
            this.HelpTip.AllowLinksHandling = true;
            this.HelpTip.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.HelpTip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.HelpTip.ForeColor = System.Drawing.Color.Black;
            this.HelpTip.MaximumSize = new System.Drawing.Size(0, 0);
            this.HelpTip.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.HelpTip.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.HelpTip.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.HelpTip.ToolTipTitle = "Подсказка";
            // 
            // textBox_phone
            // 
            this.textBox_phone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_phone.Animated = true;
            this.textBox_phone.BackColor = System.Drawing.Color.Transparent;
            this.textBox_phone.BorderRadius = 8;
            this.textBox_phone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_phone.DefaultText = "";
            this.textBox_phone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_phone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_phone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_phone.DisabledState.Parent = this.textBox_phone;
            this.textBox_phone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_phone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_phone.FocusedState.Parent = this.textBox_phone;
            this.textBox_phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_phone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.textBox_phone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.textBox_phone.HoverState.Parent = this.textBox_phone;
            this.textBox_phone.IconLeft = global::coursework.Properties.Resources.image_telephone;
            this.textBox_phone.IconLeftSize = new System.Drawing.Size(24, 24);
            this.textBox_phone.Location = new System.Drawing.Point(17, 211);
            this.textBox_phone.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.PasswordChar = '\0';
            this.textBox_phone.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.textBox_phone.PlaceholderText = "Номер телефона";
            this.textBox_phone.SelectedText = "";
            this.textBox_phone.ShadowDecoration.BorderRadius = 12;
            this.textBox_phone.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.textBox_phone.ShadowDecoration.Depth = 10;
            this.textBox_phone.ShadowDecoration.Enabled = true;
            this.textBox_phone.ShadowDecoration.Parent = this.textBox_phone;
            this.textBox_phone.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.textBox_phone.Size = new System.Drawing.Size(358, 39);
            this.textBox_phone.TabIndex = 13;
            this.textBox_phone.TextOffset = new System.Drawing.Point(5, 0);
            this.HelpTip.SetToolTip(this.textBox_phone, "Личный мобильный номер телефона преподавателя.");
            // 
            // lbl_UserHello
            // 
            this.lbl_UserHello.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_UserHello.AutoSize = false;
            this.lbl_UserHello.BackColor = System.Drawing.Color.Transparent;
            this.lbl_UserHello.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lbl_UserHello.IsSelectionEnabled = false;
            this.lbl_UserHello.Location = new System.Drawing.Point(17, 58);
            this.lbl_UserHello.Name = "lbl_UserHello";
            this.lbl_UserHello.Size = new System.Drawing.Size(358, 27);
            this.lbl_UserHello.TabIndex = 12;
            this.lbl_UserHello.Text = "Регистрация нового, <b><font color=\"#6B7BCF\"> преподавателя </b></font>.";
            this.lbl_UserHello.UseSystemCursors = true;
            // 
            // frmSettings
            // 
            this.frmSettings.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.frmSettings.ContainerControl = this;
            this.frmSettings.ResizeForm = false;
            this.frmSettings.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            // 
            // drag
            // 
            this.drag.ContainerControl = this;
            this.drag.TargetControl = this.panel_up;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(392, 361);
            this.Controls.Add(this.textBox_phone);
            this.Controls.Add(this.lbl_UserHello);
            this.Controls.Add(this.textBox_FIO);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_key);
            this.Controls.Add(this.panel_up);
            this.Controls.Add(this.button_Register);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wellness - Регистрация";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.panel_up.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button button_Register;
        private System.Windows.Forms.Panel panel_up;
        private Guna.UI2.WinForms.Guna2ControlBox button_Close;
        private Guna.UI2.WinForms.Guna2TextBox textBox_key;
        private Guna.UI2.WinForms.Guna2TextBox textBox_password;
        private Guna.UI2.WinForms.Guna2TextBox textBox_FIO;
        private Guna.UI2.WinForms.Guna2HtmlToolTip HelpTip;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_UserHello;
        private Guna.UI2.WinForms.Guna2TextBox textBox_phone;
        private Guna.UI2.WinForms.Guna2BorderlessForm frmSettings;
        private Guna.UI2.WinForms.Guna2DragControl drag;
    }
}