namespace coursework
{
    partial class frmLogin
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel_up = new System.Windows.Forms.Panel();
            this.button_Minimum = new Guna.UI2.WinForms.Guna2ControlBox();
            this.button_Maximum = new Guna.UI2.WinForms.Guna2ControlBox();
            this.button_Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lbl_NameProject = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbl_UserHello = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.button_Login = new Guna.UI2.WinForms.Guna2Button();
            this.button_resetPassword = new Guna.UI2.WinForms.Guna2Button();
            this.button_Register = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_Note = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.animator = new Guna.UI2.WinForms.Guna2Transition();
            this.button_resize = new Guna.UI2.WinForms.Guna2ResizeBox();
            this.welcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.combo_Teachers = new Guna.UI2.WinForms.Guna2ComboBox();
            this.textBox_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.combo_Select = new Guna.UI2.WinForms.Guna2ComboBox();
            this.HelpTip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.frmSettings = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel_up.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_up
            // 
            this.panel_up.BackColor = System.Drawing.Color.White;
            this.panel_up.Controls.Add(this.button_Minimum);
            this.panel_up.Controls.Add(this.button_Maximum);
            this.panel_up.Controls.Add(this.button_Close);
            this.animator.SetDecoration(this.panel_up, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_up.Location = new System.Drawing.Point(0, 0);
            this.panel_up.Name = "panel_up";
            this.panel_up.Size = new System.Drawing.Size(1070, 37);
            this.panel_up.TabIndex = 0;
            this.panel_up.DoubleClick += new System.EventHandler(this.panel_up_DoubleClick);
            // 
            // button_Minimum
            // 
            this.button_Minimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Minimum.Animated = true;
            this.button_Minimum.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.animator.SetDecoration(this.button_Minimum, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_Minimum.FillColor = System.Drawing.Color.Transparent;
            this.button_Minimum.HoverState.Parent = this.button_Minimum;
            this.button_Minimum.IconColor = System.Drawing.Color.Gray;
            this.button_Minimum.Location = new System.Drawing.Point(926, 0);
            this.button_Minimum.Name = "button_Minimum";
            this.button_Minimum.ShadowDecoration.Parent = this.button_Minimum;
            this.button_Minimum.Size = new System.Drawing.Size(48, 37);
            this.button_Minimum.TabIndex = 2;
            // 
            // button_Maximum
            // 
            this.button_Maximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Maximum.Animated = true;
            this.button_Maximum.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.animator.SetDecoration(this.button_Maximum, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_Maximum.Enabled = false;
            this.button_Maximum.FillColor = System.Drawing.Color.Transparent;
            this.button_Maximum.HoverState.Parent = this.button_Maximum;
            this.button_Maximum.IconColor = System.Drawing.Color.Gray;
            this.button_Maximum.Location = new System.Drawing.Point(974, 0);
            this.button_Maximum.Name = "button_Maximum";
            this.button_Maximum.ShadowDecoration.Parent = this.button_Maximum;
            this.button_Maximum.Size = new System.Drawing.Size(48, 37);
            this.button_Maximum.TabIndex = 1;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Animated = true;
            this.animator.SetDecoration(this.button_Close, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_Close.FillColor = System.Drawing.Color.Transparent;
            this.button_Close.HoverState.FillColor = System.Drawing.Color.Brown;
            this.button_Close.HoverState.IconColor = System.Drawing.Color.White;
            this.button_Close.HoverState.Parent = this.button_Close;
            this.button_Close.IconColor = System.Drawing.Color.Gray;
            this.button_Close.Location = new System.Drawing.Point(1022, 0);
            this.button_Close.Name = "button_Close";
            this.button_Close.ShadowDecoration.Parent = this.button_Close;
            this.button_Close.Size = new System.Drawing.Size(48, 37);
            this.button_Close.TabIndex = 0;
            // 
            // lbl_NameProject
            // 
            this.lbl_NameProject.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.lbl_NameProject, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbl_NameProject.Font = new System.Drawing.Font("Segoe UI", 30F);
            this.lbl_NameProject.IsSelectionEnabled = false;
            this.lbl_NameProject.Location = new System.Drawing.Point(12, 43);
            this.lbl_NameProject.Name = "lbl_NameProject";
            this.lbl_NameProject.Size = new System.Drawing.Size(237, 56);
            this.lbl_NameProject.TabIndex = 2;
            this.lbl_NameProject.Text = "Wellness<b><font color=\"#6B7BCF\">App</font>";
            this.HelpTip.SetToolTip(this.lbl_NameProject, "Emergency help - Экстренная помощь.");
            this.lbl_NameProject.UseSystemCursors = true;
            // 
            // lbl_UserHello
            // 
            this.lbl_UserHello.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_UserHello.AutoSize = false;
            this.lbl_UserHello.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.lbl_UserHello, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbl_UserHello.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lbl_UserHello.IsSelectionEnabled = false;
            this.lbl_UserHello.Location = new System.Drawing.Point(358, 239);
            this.lbl_UserHello.Name = "lbl_UserHello";
            this.lbl_UserHello.Size = new System.Drawing.Size(358, 42);
            this.lbl_UserHello.TabIndex = 3;
            this.lbl_UserHello.Text = "Приветствуем, <b><font color=\"#6B7BCF\"> USER </b></font>";
            this.lbl_UserHello.UseSystemCursors = true;
            // 
            // button_Login
            // 
            this.button_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Login.Animated = true;
            this.button_Login.BorderRadius = 8;
            this.button_Login.CheckedState.Parent = this.button_Login;
            this.button_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Login.CustomImages.Parent = this.button_Login;
            this.animator.SetDecoration(this.button_Login, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_Login.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_Login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Login.ForeColor = System.Drawing.Color.White;
            this.button_Login.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(144)))), ((int)(((byte)(228)))));
            this.button_Login.HoverState.Parent = this.button_Login;
            this.button_Login.Location = new System.Drawing.Point(557, 429);
            this.button_Login.Name = "button_Login";
            this.button_Login.ShadowDecoration.Parent = this.button_Login;
            this.button_Login.Size = new System.Drawing.Size(149, 35);
            this.button_Login.TabIndex = 6;
            this.button_Login.Text = "Авторизоваться";
            this.button_Login.TextFormatNoPrefix = true;
            this.button_Login.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // button_resetPassword
            // 
            this.button_resetPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_resetPassword.Animated = true;
            this.button_resetPassword.BackColor = System.Drawing.Color.Transparent;
            this.button_resetPassword.BorderRadius = 8;
            this.button_resetPassword.CheckedState.Parent = this.button_resetPassword;
            this.button_resetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_resetPassword.CustomImages.Parent = this.button_resetPassword;
            this.animator.SetDecoration(this.button_resetPassword, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_resetPassword.FillColor = System.Drawing.Color.Transparent;
            this.button_resetPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_resetPassword.ForeColor = System.Drawing.Color.Black;
            this.button_resetPassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_resetPassword.HoverState.Parent = this.button_resetPassword;
            this.button_resetPassword.Location = new System.Drawing.Point(398, 436);
            this.button_resetPassword.Name = "button_resetPassword";
            this.button_resetPassword.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_resetPassword.ShadowDecoration.Parent = this.button_resetPassword;
            this.button_resetPassword.Size = new System.Drawing.Size(153, 22);
            this.button_resetPassword.TabIndex = 7;
            this.button_resetPassword.Text = "Забыл пароль?";
            this.button_resetPassword.TextFormatNoPrefix = true;
            this.button_resetPassword.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.button_resetPassword.UseTransparentBackground = true;
            this.button_resetPassword.Click += new System.EventHandler(this.button_resetPassword_Click);
            // 
            // button_Register
            // 
            this.button_Register.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Register.Animated = true;
            this.button_Register.BackColor = System.Drawing.Color.Transparent;
            this.button_Register.BorderRadius = 8;
            this.button_Register.CheckedState.Parent = this.button_Register;
            this.button_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Register.CustomImages.Parent = this.button_Register;
            this.animator.SetDecoration(this.button_Register, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_Register.FillColor = System.Drawing.Color.Transparent;
            this.button_Register.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Register.ForeColor = System.Drawing.Color.Black;
            this.button_Register.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_Register.HoverState.Parent = this.button_Register;
            this.button_Register.Location = new System.Drawing.Point(348, 584);
            this.button_Register.Name = "button_Register";
            this.button_Register.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_Register.PressedDepth = 5;
            this.button_Register.ShadowDecoration.Parent = this.button_Register;
            this.button_Register.Size = new System.Drawing.Size(358, 53);
            this.button_Register.TabIndex = 8;
            this.button_Register.Text = "Вас нет в списке? Пройдите простую регистрацию, просто нажав на этот текст.";
            this.button_Register.TextFormatNoPrefix = true;
            this.button_Register.UseTransparentBackground = true;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // lbl_Note
            // 
            this.lbl_Note.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_Note.AutoSize = false;
            this.lbl_Note.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.lbl_Note, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbl_Note.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Note.IsSelectionEnabled = false;
            this.lbl_Note.Location = new System.Drawing.Point(348, 560);
            this.lbl_Note.Name = "lbl_Note";
            this.lbl_Note.Size = new System.Drawing.Size(358, 18);
            this.lbl_Note.TabIndex = 9;
            this.lbl_Note.Text = "Подсказка:";
            this.lbl_Note.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Note.UseSystemCursors = true;
            // 
            // animator
            // 
            this.animator.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            this.animator.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.animator.DefaultAnimation = animation1;
            // 
            // button_resize
            // 
            this.button_resize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_resize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.animator.SetDecoration(this.button_resize, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_resize.ForeColor = System.Drawing.Color.Empty;
            this.button_resize.Location = new System.Drawing.Point(1046, 711);
            this.button_resize.Name = "button_resize";
            this.button_resize.Size = new System.Drawing.Size(20, 20);
            this.button_resize.TabIndex = 10;
            this.button_resize.TargetControl = this;
            this.button_resize.Visible = false;
            // 
            // welcome
            // 
            this.welcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.welcome.AutoSize = false;
            this.welcome.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.welcome, Guna.UI2.AnimatorNS.DecorationType.None);
            this.welcome.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.welcome.IsContextMenuEnabled = false;
            this.welcome.IsSelectionEnabled = false;
            this.welcome.Location = new System.Drawing.Point(102, 306);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(866, 117);
            this.welcome.TabIndex = 11;
            this.welcome.Text = null;
            this.welcome.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.welcome.Visible = false;
            // 
            // combo_Teachers
            // 
            this.combo_Teachers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.combo_Teachers.Animated = true;
            this.combo_Teachers.BackColor = System.Drawing.Color.Transparent;
            this.combo_Teachers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.combo_Teachers.BorderRadius = 8;
            this.animator.SetDecoration(this.combo_Teachers, Guna.UI2.AnimatorNS.DecorationType.None);
            this.combo_Teachers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_Teachers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Teachers.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.combo_Teachers.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.combo_Teachers.FocusedState.Parent = this.combo_Teachers;
            this.combo_Teachers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.combo_Teachers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.combo_Teachers.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.combo_Teachers.HoverState.Parent = this.combo_Teachers;
            this.combo_Teachers.ItemHeight = 30;
            this.combo_Teachers.ItemsAppearance.Parent = this.combo_Teachers;
            this.combo_Teachers.Location = new System.Drawing.Point(348, 343);
            this.combo_Teachers.Name = "combo_Teachers";
            this.combo_Teachers.ShadowDecoration.BorderRadius = 12;
            this.combo_Teachers.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.combo_Teachers.ShadowDecoration.Depth = 10;
            this.combo_Teachers.ShadowDecoration.Enabled = true;
            this.combo_Teachers.ShadowDecoration.Parent = this.combo_Teachers;
            this.combo_Teachers.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.combo_Teachers.Size = new System.Drawing.Size(358, 36);
            this.combo_Teachers.TabIndex = 12;
            this.combo_Teachers.SelectedIndexChanged += new System.EventHandler(this.combo_Teachers_SelectedIndexChanged);
            // 
            // textBox_password
            // 
            this.textBox_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_password.Animated = true;
            this.textBox_password.BackColor = System.Drawing.Color.Transparent;
            this.textBox_password.BorderRadius = 8;
            this.textBox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.animator.SetDecoration(this.textBox_password, Guna.UI2.AnimatorNS.DecorationType.None);
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
            this.textBox_password.Location = new System.Drawing.Point(348, 383);
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
            this.textBox_password.TabIndex = 5;
            this.textBox_password.TextOffset = new System.Drawing.Point(5, 0);
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // combo_Select
            // 
            this.combo_Select.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.combo_Select.Animated = true;
            this.combo_Select.BackColor = System.Drawing.Color.Transparent;
            this.combo_Select.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.combo_Select.BorderRadius = 8;
            this.animator.SetDecoration(this.combo_Select, Guna.UI2.AnimatorNS.DecorationType.None);
            this.combo_Select.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Select.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.combo_Select.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.combo_Select.FocusedState.Parent = this.combo_Select;
            this.combo_Select.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.combo_Select.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.combo_Select.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.combo_Select.HoverState.Parent = this.combo_Select;
            this.combo_Select.ItemHeight = 30;
            this.combo_Select.Items.AddRange(new object[] {
            "Фельдшер",
            "Учитель",
            "Администратор"});
            this.combo_Select.ItemsAppearance.Parent = this.combo_Select;
            this.combo_Select.Location = new System.Drawing.Point(348, 302);
            this.combo_Select.Name = "combo_Select";
            this.combo_Select.ShadowDecoration.BorderRadius = 12;
            this.combo_Select.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.combo_Select.ShadowDecoration.Depth = 10;
            this.combo_Select.ShadowDecoration.Enabled = true;
            this.combo_Select.ShadowDecoration.Parent = this.combo_Select;
            this.combo_Select.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.combo_Select.Size = new System.Drawing.Size(358, 36);
            this.combo_Select.StartIndex = 0;
            this.combo_Select.TabIndex = 13;
            this.combo_Select.SelectedIndexChanged += new System.EventHandler(this.combo_Select_SelectedValueChanged);
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
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1070, 735);
            this.Controls.Add(this.combo_Select);
            this.Controls.Add(this.combo_Teachers);
            this.Controls.Add(this.button_resetPassword);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.lbl_Note);
            this.Controls.Add(this.button_Register);
            this.Controls.Add(this.lbl_UserHello);
            this.Controls.Add(this.button_resize);
            this.Controls.Add(this.lbl_NameProject);
            this.Controls.Add(this.panel_up);
            this.Controls.Add(this.welcome);
            this.animator.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 560);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wellness - Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this._welcomeForm_Load);
            this.panel_up.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_up;
        private Guna.UI2.WinForms.Guna2ControlBox button_Close;
        private Guna.UI2.WinForms.Guna2ControlBox button_Minimum;
        private Guna.UI2.WinForms.Guna2ControlBox button_Maximum;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_NameProject;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_UserHello;
        private Guna.UI2.WinForms.Guna2TextBox textBox_password;
        private Guna.UI2.WinForms.Guna2Button button_Login;
        private Guna.UI2.WinForms.Guna2Button button_resetPassword;
        private Guna.UI2.WinForms.Guna2Button button_Register;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Note;
        private Guna.UI2.WinForms.Guna2Transition animator;
        private Guna.UI2.WinForms.Guna2ResizeBox button_resize;
        private Guna.UI2.WinForms.Guna2HtmlLabel welcome;
        private Guna.UI2.WinForms.Guna2ComboBox combo_Teachers;
        private Guna.UI2.WinForms.Guna2HtmlToolTip HelpTip;
        private Guna.UI2.WinForms.Guna2BorderlessForm frmSettings;
        private Guna.UI2.WinForms.Guna2DragControl drag;
        public Guna.UI2.WinForms.Guna2ComboBox combo_Select;
    }
}

