namespace coursework.dialogs
{
    partial class frmOk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOk));
            this.panel_up = new System.Windows.Forms.Panel();
            this.lbl_Name = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.button_Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lbl_Message = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.button_Ok = new Guna.UI2.WinForms.Guna2Button();
            this.frmSettings = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.drag2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel_up.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_up
            // 
            this.panel_up.BackColor = System.Drawing.Color.White;
            this.panel_up.Controls.Add(this.lbl_Name);
            this.panel_up.Controls.Add(this.button_Close);
            this.panel_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_up.Location = new System.Drawing.Point(0, 0);
            this.panel_up.Name = "panel_up";
            this.panel_up.Size = new System.Drawing.Size(630, 37);
            this.panel_up.TabIndex = 2;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Name.AutoSize = false;
            this.lbl_Name.AutoSizeHeightOnly = true;
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_Name.IsSelectionEnabled = false;
            this.lbl_Name.Location = new System.Drawing.Point(9, 11);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(574, 25);
            this.lbl_Name.TabIndex = 16;
            this.lbl_Name.Text = "Название";
            this.lbl_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Name.UseSystemCursors = true;
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
            this.button_Close.Location = new System.Drawing.Point(582, 0);
            this.button_Close.Name = "button_Close";
            this.button_Close.ShadowDecoration.Parent = this.button_Close;
            this.button_Close.Size = new System.Drawing.Size(48, 37);
            this.button_Close.TabIndex = 0;
            this.button_Close.Visible = false;
            // 
            // lbl_Message
            // 
            this.lbl_Message.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_Message.AutoSize = false;
            this.lbl_Message.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Message.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbl_Message.IsSelectionEnabled = false;
            this.lbl_Message.Location = new System.Drawing.Point(9, 43);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(613, 158);
            this.lbl_Message.TabIndex = 10;
            this.lbl_Message.Text = "сообщение\r\n";
            this.lbl_Message.UseSystemCursors = true;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Ok.Animated = true;
            this.button_Ok.BorderRadius = 8;
            this.button_Ok.CheckedState.Parent = this.button_Ok;
            this.button_Ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Ok.CustomImages.Parent = this.button_Ok;
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Ok.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_Ok.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Ok.ForeColor = System.Drawing.Color.White;
            this.button_Ok.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(144)))), ((int)(((byte)(228)))));
            this.button_Ok.HoverState.Parent = this.button_Ok;
            this.button_Ok.Location = new System.Drawing.Point(202, 211);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.ShadowDecoration.Parent = this.button_Ok;
            this.button_Ok.Size = new System.Drawing.Size(246, 35);
            this.button_Ok.TabIndex = 11;
            this.button_Ok.Text = "Окей";
            this.button_Ok.TextFormatNoPrefix = true;
            this.button_Ok.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
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
            // drag2
            // 
            this.drag2.ContainerControl = this;
            this.drag2.TargetControl = this.lbl_Name;
            // 
            // frmOk
            // 
            this.AcceptButton = this.button_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(630, 255);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.panel_up);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOk";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wellness - Диалоговое окно";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmOk_Load);
            this.panel_up.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_up;
        private Guna.UI2.WinForms.Guna2ControlBox button_Close;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Message;
        private Guna.UI2.WinForms.Guna2Button button_Ok;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_Name;
        private Guna.UI2.WinForms.Guna2BorderlessForm frmSettings;
        private Guna.UI2.WinForms.Guna2DragControl drag;
        private Guna.UI2.WinForms.Guna2DragControl drag2;
    }
}