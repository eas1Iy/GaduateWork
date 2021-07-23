namespace coursework.dialogs
{
    partial class frmNotification
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
            this.panel_up = new System.Windows.Forms.Panel();
            this.button_Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lbl_Message = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.picture_NotificationIcon = new System.Windows.Forms.PictureBox();
            this.frmSettings = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel_up.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_NotificationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_up
            // 
            this.panel_up.BackColor = System.Drawing.Color.White;
            this.panel_up.Controls.Add(this.button_Close);
            this.panel_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_up.Location = new System.Drawing.Point(0, 0);
            this.panel_up.Name = "panel_up";
            this.panel_up.Size = new System.Drawing.Size(355, 26);
            this.panel_up.TabIndex = 2;
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
            this.button_Close.Location = new System.Drawing.Point(307, 0);
            this.button_Close.Name = "button_Close";
            this.button_Close.ShadowDecoration.Parent = this.button_Close;
            this.button_Close.Size = new System.Drawing.Size(48, 26);
            this.button_Close.TabIndex = 0;
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = false;
            this.lbl_Message.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Message.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Message.Location = new System.Drawing.Point(84, 36);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(259, 59);
            this.lbl_Message.TabIndex = 3;
            this.lbl_Message.Text = "message";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // picture_NotificationIcon
            // 
            this.picture_NotificationIcon.Location = new System.Drawing.Point(12, 36);
            this.picture_NotificationIcon.Name = "picture_NotificationIcon";
            this.picture_NotificationIcon.Size = new System.Drawing.Size(66, 59);
            this.picture_NotificationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_NotificationIcon.TabIndex = 4;
            this.picture_NotificationIcon.TabStop = false;
            // 
            // frmSettings
            // 
            this.frmSettings.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.frmSettings.ContainerControl = this;
            this.frmSettings.DragForm = false;
            this.frmSettings.ResizeForm = false;
            this.frmSettings.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            // 
            // frmNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(355, 109);
            this.Controls.Add(this.picture_NotificationIcon);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.panel_up);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Wellness - Уведомление";
            this.Load += new System.EventHandler(this.frmNotification_Load);
            this.panel_up.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_NotificationIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_up;
        private Guna.UI2.WinForms.Guna2ControlBox button_Close;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Message;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox picture_NotificationIcon;
        private Guna.UI2.WinForms.Guna2BorderlessForm frmSettings;
    }
}