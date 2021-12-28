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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.file = new System.Windows.Forms.Button();
            this.bynnc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox1.Location = new System.Drawing.Point(0, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Уведомления";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox2.Location = new System.Drawing.Point(0, 24);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Буфер";
            this.checkBox2.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(148, 103);
            this.Controls.Add(this.bynnc);
            this.Controls.Add(this.file);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button file;
        private Label bynnc;
    }
}