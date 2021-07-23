
namespace coursework.dialogs
{
    partial class frmImport
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
            Guna.UI2.AnimatorNS.Animation animation6 = new Guna.UI2.AnimatorNS.Animation();
            Guna.UI2.AnimatorNS.Animation animation5 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.panel_up = new System.Windows.Forms.Panel();
            this.label_import = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.button_Close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.button_import_word = new Guna.UI2.WinForms.Guna2Button();
            this.button_import_exel = new Guna.UI2.WinForms.Guna2Button();
            this.drag2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.animator2 = new Guna.UI2.WinForms.Guna2Transition();
            this.animator = new Guna.UI2.WinForms.Guna2Transition();
            this.frmSettings = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel_up.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_up
            // 
            this.panel_up.BackColor = System.Drawing.Color.White;
            this.panel_up.Controls.Add(this.label_import);
            this.panel_up.Controls.Add(this.button_Close);
            this.animator.SetDecoration(this.panel_up, Guna.UI2.AnimatorNS.DecorationType.None);
            this.animator2.SetDecoration(this.panel_up, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel_up.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_up.Location = new System.Drawing.Point(0, 0);
            this.panel_up.Name = "panel_up";
            this.panel_up.Size = new System.Drawing.Size(424, 28);
            this.panel_up.TabIndex = 2;
            // 
            // label_import
            // 
            this.label_import.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_import.AutoSize = false;
            this.label_import.BackColor = System.Drawing.Color.Transparent;
            this.animator.SetDecoration(this.label_import, Guna.UI2.AnimatorNS.DecorationType.None);
            this.animator2.SetDecoration(this.label_import, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label_import.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label_import.IsSelectionEnabled = false;
            this.label_import.Location = new System.Drawing.Point(3, 3);
            this.label_import.Name = "label_import";
            this.label_import.Size = new System.Drawing.Size(367, 22);
            this.label_import.TabIndex = 103;
            this.label_import.Text = null;
            this.label_import.UseGdiPlusTextRendering = true;
            this.label_import.Visible = false;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Animated = true;
            this.animator.SetDecoration(this.button_Close, Guna.UI2.AnimatorNS.DecorationType.None);
            this.animator2.SetDecoration(this.button_Close, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_Close.FillColor = System.Drawing.Color.Transparent;
            this.button_Close.HoverState.FillColor = System.Drawing.Color.Brown;
            this.button_Close.HoverState.IconColor = System.Drawing.Color.White;
            this.button_Close.HoverState.Parent = this.button_Close;
            this.button_Close.IconColor = System.Drawing.Color.Gray;
            this.button_Close.Location = new System.Drawing.Point(376, 0);
            this.button_Close.Name = "button_Close";
            this.button_Close.ShadowDecoration.Parent = this.button_Close;
            this.button_Close.Size = new System.Drawing.Size(48, 28);
            this.button_Close.TabIndex = 0;
            // 
            // button_import_word
            // 
            this.button_import_word.Animated = true;
            this.button_import_word.BackColor = System.Drawing.Color.Transparent;
            this.button_import_word.BorderRadius = 20;
            this.button_import_word.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(245)))));
            this.button_import_word.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_import_word.CheckedState.Parent = this.button_import_word;
            this.button_import_word.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_import_word.CustomImages.Parent = this.button_import_word;
            this.animator.SetDecoration(this.button_import_word, Guna.UI2.AnimatorNS.DecorationType.None);
            this.animator2.SetDecoration(this.button_import_word, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_import_word.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.button_import_word.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_import_word.ForeColor = System.Drawing.Color.Black;
            this.button_import_word.HoverState.FillColor = System.Drawing.Color.White;
            this.button_import_word.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_import_word.HoverState.Parent = this.button_import_word;
            this.button_import_word.Image = global::coursework.Properties.Resources.image_word;
            this.button_import_word.ImageSize = new System.Drawing.Size(64, 64);
            this.button_import_word.Location = new System.Drawing.Point(210, 49);
            this.button_import_word.Name = "button_import_word";
            this.button_import_word.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_import_word.ShadowDecoration.Parent = this.button_import_word;
            this.button_import_word.Size = new System.Drawing.Size(122, 89);
            this.button_import_word.TabIndex = 102;
            this.button_import_word.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button_import_word.TextFormatNoPrefix = true;
            this.button_import_word.TextOffset = new System.Drawing.Point(25, 2);
            this.button_import_word.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.button_import_word.UseTransparentBackground = true;
            this.button_import_word.Visible = false;
            this.button_import_word.Click += new System.EventHandler(this.button_import_word_Click);
            // 
            // button_import_exel
            // 
            this.button_import_exel.Animated = true;
            this.button_import_exel.BackColor = System.Drawing.Color.Transparent;
            this.button_import_exel.BorderRadius = 20;
            this.button_import_exel.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(245)))));
            this.button_import_exel.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_import_exel.CheckedState.Parent = this.button_import_exel;
            this.button_import_exel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_import_exel.CustomImages.Parent = this.button_import_exel;
            this.animator.SetDecoration(this.button_import_exel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.animator2.SetDecoration(this.button_import_exel, Guna.UI2.AnimatorNS.DecorationType.None);
            this.button_import_exel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.button_import_exel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_import_exel.ForeColor = System.Drawing.Color.Black;
            this.button_import_exel.HoverState.FillColor = System.Drawing.Color.White;
            this.button_import_exel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_import_exel.HoverState.Parent = this.button_import_exel;
            this.button_import_exel.Image = global::coursework.Properties.Resources.image_exel;
            this.button_import_exel.ImageSize = new System.Drawing.Size(64, 64);
            this.button_import_exel.Location = new System.Drawing.Point(82, 49);
            this.button_import_exel.Name = "button_import_exel";
            this.button_import_exel.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.button_import_exel.ShadowDecoration.Parent = this.button_import_exel;
            this.button_import_exel.Size = new System.Drawing.Size(122, 89);
            this.button_import_exel.TabIndex = 101;
            this.button_import_exel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.button_import_exel.TextFormatNoPrefix = true;
            this.button_import_exel.TextOffset = new System.Drawing.Point(25, 2);
            this.button_import_exel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.button_import_exel.UseTransparentBackground = true;
            this.button_import_exel.Visible = false;
            this.button_import_exel.Click += new System.EventHandler(this.button_import_exel_Click);
            // 
            // drag2
            // 
            this.drag2.ContainerControl = this;
            this.drag2.TargetControl = this.label_import;
            this.drag2.TransparentWhileDrag = true;
            this.drag2.UseTransparentDrag = true;
            // 
            // animator2
            // 
            this.animator2.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.animator2.Cursor = null;
            animation6.AnimateOnlyDifferences = true;
            animation6.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.BlindCoeff")));
            animation6.LeafCoeff = 0F;
            animation6.MaxTime = 1F;
            animation6.MinTime = 0F;
            animation6.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicCoeff")));
            animation6.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicShift")));
            animation6.MosaicSize = 0;
            animation6.Padding = new System.Windows.Forms.Padding(0);
            animation6.RotateCoeff = 0F;
            animation6.RotateLimit = 0F;
            animation6.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.ScaleCoeff")));
            animation6.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.SlideCoeff")));
            animation6.TimeCoeff = 0F;
            animation6.TransparencyCoeff = 0F;
            this.animator2.DefaultAnimation = animation6;
            // 
            // animator
            // 
            this.animator.AnimationType = Guna.UI2.AnimatorNS.AnimationType.ScaleAndRotate;
            this.animator.Cursor = null;
            animation5.AnimateOnlyDifferences = true;
            animation5.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.BlindCoeff")));
            animation5.LeafCoeff = 0F;
            animation5.MaxTime = 1F;
            animation5.MinTime = 0F;
            animation5.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicCoeff")));
            animation5.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicShift")));
            animation5.MosaicSize = 0;
            animation5.Padding = new System.Windows.Forms.Padding(30);
            animation5.RotateCoeff = 0.5F;
            animation5.RotateLimit = 0.2F;
            animation5.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.ScaleCoeff")));
            animation5.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.SlideCoeff")));
            animation5.TimeCoeff = 0F;
            animation5.TransparencyCoeff = 0F;
            this.animator.DefaultAnimation = animation5;
            // 
            // frmSettings
            // 
            this.frmSettings.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.frmSettings.BorderRadius = 8;
            this.frmSettings.ContainerControl = this;
            this.frmSettings.ResizeForm = false;
            this.frmSettings.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            // 
            // drag
            // 
            this.drag.ContainerControl = this;
            this.drag.TargetControl = this.panel_up;
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(424, 150);
            this.Controls.Add(this.button_import_word);
            this.Controls.Add(this.button_import_exel);
            this.Controls.Add(this.panel_up);
            this.animator.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.animator2.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wellness - Импорт";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImport_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImport_FormClosed);
            this.Load += new System.EventHandler(this.frmImport_Load);
            this.panel_up.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_up;
        private Guna.UI2.WinForms.Guna2ControlBox button_Close;
        private Guna.UI2.WinForms.Guna2HtmlLabel label_import;
        private Guna.UI2.WinForms.Guna2DragControl drag2;
        private Guna.UI2.WinForms.Guna2Transition animator2;
        private Guna.UI2.WinForms.Guna2Transition animator;
        private Guna.UI2.WinForms.Guna2BorderlessForm frmSettings;
        private Guna.UI2.WinForms.Guna2DragControl drag;
        public Guna.UI2.WinForms.Guna2Button button_import_exel;
        public Guna.UI2.WinForms.Guna2Button button_import_word;
    }
}