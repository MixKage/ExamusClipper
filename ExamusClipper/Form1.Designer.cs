namespace ExamusClipper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            ChangeClipboardChain(this.Handle, nextClipboardViewer);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NotifyCheck = new System.Windows.Forms.CheckBox();
            this.BufCheck = new System.Windows.Forms.CheckBox();
            this.file = new System.Windows.Forms.Button();
            this.bynnc = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // NotifyCheck
            // 
            this.NotifyCheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NotifyCheck.Location = new System.Drawing.Point(0, 3);
            this.NotifyCheck.Name = "NotifyCheck";
            this.NotifyCheck.Size = new System.Drawing.Size(126, 24);
            this.NotifyCheck.TabIndex = 0;
            this.NotifyCheck.Text = "Уведомления";
            this.NotifyCheck.UseVisualStyleBackColor = true;
            this.NotifyCheck.CheckedChanged += new System.EventHandler(this.NotifyCheck_CheckedChanged);
            // 
            // BufCheck
            // 
            this.BufCheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BufCheck.Location = new System.Drawing.Point(0, 24);
            this.BufCheck.Name = "BufCheck";
            this.BufCheck.Size = new System.Drawing.Size(74, 24);
            this.BufCheck.TabIndex = 1;
            this.BufCheck.Text = "Буфер";
            this.BufCheck.UseVisualStyleBackColor = true;
            this.BufCheck.CheckedChanged += new System.EventHandler(this.BufCheck_CheckedChanged);
            // 
            // file
            // 
            this.file.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.file.Location = new System.Drawing.Point(0, 48);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(148, 29);
            this.file.TabIndex = 2;
            this.file.Text = "Файл";
            this.file.UseVisualStyleBackColor = true;
            this.file.Click += new System.EventHandler(this.file_Click);
            // 
            // bynnc
            // 
            this.bynnc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bynnc.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bynnc.Location = new System.Drawing.Point(0, 77);
            this.bynnc.Name = "bynnc";
            this.bynnc.Size = new System.Drawing.Size(148, 20);
            this.bynnc.TabIndex = 3;
            this.bynnc.Text = "v.1.0 by NNC";
            this.bynnc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(148, 103);
            this.Controls.Add(this.bynnc);
            this.Controls.Add(this.file);
            this.Controls.Add(this.BufCheck);
            this.Controls.Add(this.NotifyCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox NotifyCheck;
        private CheckBox BufCheck;
        private Button file;
        private Label bynnc;
        private OpenFileDialog openFileDialog1;
    }
}