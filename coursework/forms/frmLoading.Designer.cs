
namespace coursework.dialogs
{
    partial class frmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.win_progress = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.lbl_loadingInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel_up = new System.Windows.Forms.Panel();
            this.button_Minimum = new Guna.UI2.WinForms.Guna2ControlBox();
            this.button_Maximum = new Guna.UI2.WinForms.Guna2ControlBox();
            this.button_Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.frmSettings = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel_up.SuspendLayout();
            this.SuspendLayout();
            // 
            // win_progress
            // 
            this.win_progress.AnimationSpeed = 80;
            this.win_progress.AutoStart = true;
            this.win_progress.CircleSize = 0.1F;
            this.win_progress.Location = new System.Drawing.Point(214, 50);
            this.win_progress.Name = "win_progress";
            this.win_progress.NumberOfCircles = 10;
            this.win_progress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.win_progress.Size = new System.Drawing.Size(90, 90);
            this.win_progress.TabIndex = 0;
            // 
            // lbl_loadingInfo
            // 
            this.lbl_loadingInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_loadingInfo.AutoSize = false;
            this.lbl_loadingInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_loadingInfo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl_loadingInfo.IsSelectionEnabled = false;
            this.lbl_loadingInfo.Location = new System.Drawing.Point(10, 162);
            this.lbl_loadingInfo.Name = "lbl_loadingInfo";
            this.lbl_loadingInfo.Size = new System.Drawing.Size(500, 42);
            this.lbl_loadingInfo.TabIndex = 4;
            this.lbl_loadingInfo.Text = "Проверка интернет соединения, пожалуйста подождите...";
            this.lbl_loadingInfo.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_loadingInfo.UseSystemCursors = true;
            // 
            // DragControl
            // 
            this.DragControl.ContainerControl = this;
            this.DragControl.TargetControl = this;
            this.DragControl.TransparentWhileDrag = true;
            this.DragControl.UseTransparentDrag = true;
            // 
            // panel_up
            // 
            this.panel_up.BackColor = System.Drawing.Color.White;
            this.panel_up.Controls.Add(this.button_Minimum);
            this.panel_up.Controls.Add(this.button_Maximum);
            this.panel_up.Controls.Add(this.button_Close);
            this.panel_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_up.Enabled = false;
            this.panel_up.Location = new System.Drawing.Point(0, 0);
            this.panel_up.Name = "panel_up";
            this.panel_up.Size = new System.Drawing.Size(520, 33);
            this.panel_up.TabIndex = 5;
            // 
            // button_Minimum
            // 
            this.button_Minimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Minimum.Animated = true;
            this.button_Minimum.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.button_Minimum.FillColor = System.Drawing.Color.Transparent;
            this.button_Minimum.HoverState.Parent = this.button_Minimum;
            this.button_Minimum.IconColor = System.Drawing.Color.Gray;
            this.button_Minimum.Location = new System.Drawing.Point(376, 0);
            this.button_Minimum.Name = "button_Minimum";
            this.button_Minimum.ShadowDecoration.Parent = this.button_Minimum;
            this.button_Minimum.Size = new System.Drawing.Size(48, 33);
            this.button_Minimum.TabIndex = 2;
            // 
            // button_Maximum
            // 
            this.button_Maximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Maximum.Animated = true;
            this.button_Maximum.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.button_Maximum.FillColor = System.Drawing.Color.Transparent;
            this.button_Maximum.HoverState.Parent = this.button_Maximum;
            this.button_Maximum.IconColor = System.Drawing.Color.Gray;
            this.button_Maximum.Location = new System.Drawing.Point(424, 0);
            this.button_Maximum.Name = "button_Maximum";
            this.button_Maximum.ShadowDecoration.Parent = this.button_Maximum;
            this.button_Maximum.Size = new System.Drawing.Size(48, 33);
            this.button_Maximum.TabIndex = 1;
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
            this.button_Close.Location = new System.Drawing.Point(472, 0);
            this.button_Close.Name = "button_Close";
            this.button_Close.ShadowDecoration.Parent = this.button_Close;
            this.button_Close.Size = new System.Drawing.Size(48, 33);
            this.button_Close.TabIndex = 0;
            // 
            // frmSettings
            // 
            this.frmSettings.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.frmSettings.ContainerControl = this;
            this.frmSettings.DragForm = false;
            this.frmSettings.ResizeForm = false;
            this.frmSettings.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            // 
            // drag
            // 
            this.drag.ContainerControl = this;
            this.drag.TargetControl = this.panel_up;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(520, 210);
            this.Controls.Add(this.panel_up);
            this.Controls.Add(this.lbl_loadingInfo);
            this.Controls.Add(this.win_progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wellness - Загрузка программы";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCheckInternet_Load);
            this.panel_up.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2WinProgressIndicator win_progress;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_loadingInfo;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private System.Windows.Forms.Panel panel_up;
        private Guna.UI2.WinForms.Guna2ControlBox button_Minimum;
        private Guna.UI2.WinForms.Guna2ControlBox button_Maximum;
        private Guna.UI2.WinForms.Guna2ControlBox button_Close;
        private Guna.UI2.WinForms.Guna2BorderlessForm frmSettings;
        private Guna.UI2.WinForms.Guna2DragControl drag;
    }
}