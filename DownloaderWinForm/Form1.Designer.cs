namespace DownloaderWinForm
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
            btn_download = new Button();
            txtBox_uri = new TextBox();
            lbl_uri = new Label();
            lbl_title = new Label();
            btn_pause = new Button();
            SuspendLayout();
            // 
            // btn_download
            // 
            btn_download.Location = new Point(222, 229);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(137, 37);
            btn_download.TabIndex = 0;
            btn_download.Text = "Download";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btn_download_Click;
            // 
            // txtBox_uri
            // 
            txtBox_uri.Location = new Point(222, 175);
            txtBox_uri.Name = "txtBox_uri";
            txtBox_uri.Size = new Size(348, 23);
            txtBox_uri.TabIndex = 1;
            txtBox_uri.TextChanged += txtBox_uri_TextChanged;
            // 
            // lbl_uri
            // 
            lbl_uri.AutoSize = true;
            lbl_uri.Location = new Point(222, 157);
            lbl_uri.Name = "lbl_uri";
            lbl_uri.Size = new Size(25, 15);
            lbl_uri.TabIndex = 2;
            lbl_uri.Text = "URI";
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(346, 22);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(92, 15);
            lbl_title.TabIndex = 3;
            lbl_title.Text = "File Downloader";
            // 
            // btn_pause
            // 
            btn_pause.Location = new Point(423, 229);
            btn_pause.Name = "btn_pause";
            btn_pause.Size = new Size(137, 37);
            btn_pause.TabIndex = 4;
            btn_pause.Text = "Pause";
            btn_pause.UseVisualStyleBackColor = true;
            btn_pause.Click += btn_pause_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_pause);
            Controls.Add(lbl_title);
            Controls.Add(lbl_uri);
            Controls.Add(txtBox_uri);
            Controls.Add(btn_download);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_download;
        private TextBox txtBox_uri;
        private Label lbl_uri;
        private Label lbl_title;
        private Button btn_pause;
    }
}
