
namespace Auto_Mate_Form
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GizleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Gizle = new System.Windows.Forms.ToolStripMenuItem();
            this.KarsiUrunKontrolBaslat = new System.Windows.Forms.Button();
            this._KarsiUrunKontrolprogressBar = new System.Windows.Forms.ProgressBar();
            this.KarsiUrunKontrolProgressQuantity = new System.Windows.Forms.Label();
            this.KarsiUrunKontrolbaglanti_bildirim = new System.Windows.Forms.RichTextBox();
            this.KarsiUrunKontrolurun_degisikligi = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KarsiUrunKontrolDurdur = new System.Windows.Forms.Button();
            this.BildirimIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.GosterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Göster = new System.Windows.Forms.ToolStripMenuItem();
            this.TümünüDurdurButon = new System.Windows.Forms.Button();
            this.ÇıkışButon = new System.Windows.Forms.Button();
            this.ÜrünBulBaşlat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ÜrünBulDurdur = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BağlantıHataları = new System.Windows.Forms.RichTextBox();
            this.UrunBulDurum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GizleMenu.SuspendLayout();
            this.GosterMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GizleMenu
            // 
            this.GizleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Gizle});
            this.GizleMenu.Name = "contextMenuStrip1";
            this.GizleMenu.Size = new System.Drawing.Size(100, 26);
            // 
            // Gizle
            // 
            this.Gizle.Name = "Gizle";
            this.Gizle.Size = new System.Drawing.Size(99, 22);
            this.Gizle.Text = "Gizle";
            this.Gizle.Click += new System.EventHandler(this.PencereGizle_Click);
            // 
            // KarsiUrunKontrolBaslat
            // 
            this.KarsiUrunKontrolBaslat.Location = new System.Drawing.Point(56, 128);
            this.KarsiUrunKontrolBaslat.Name = "KarsiUrunKontrolBaslat";
            this.KarsiUrunKontrolBaslat.Size = new System.Drawing.Size(176, 39);
            this.KarsiUrunKontrolBaslat.TabIndex = 1;
            this.KarsiUrunKontrolBaslat.Text = "Başlat";
            this.KarsiUrunKontrolBaslat.UseVisualStyleBackColor = true;
            this.KarsiUrunKontrolBaslat.Click += new System.EventHandler(this.KarsiUrunKontrolBaslatButon_Click);
            // 
            // _KarsiUrunKontrolprogressBar
            // 
            this._KarsiUrunKontrolprogressBar.Location = new System.Drawing.Point(56, 75);
            this._KarsiUrunKontrolprogressBar.Name = "_KarsiUrunKontrolprogressBar";
            this._KarsiUrunKontrolprogressBar.Size = new System.Drawing.Size(286, 47);
            this._KarsiUrunKontrolprogressBar.TabIndex = 2;
            // 
            // KarsiUrunKontrolProgressQuantity
            // 
            this.KarsiUrunKontrolProgressQuantity.BackColor = System.Drawing.Color.Transparent;
            this.KarsiUrunKontrolProgressQuantity.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KarsiUrunKontrolProgressQuantity.ForeColor = System.Drawing.SystemColors.Info;
            this.KarsiUrunKontrolProgressQuantity.Location = new System.Drawing.Point(12, 37);
            this.KarsiUrunKontrolProgressQuantity.Name = "KarsiUrunKontrolProgressQuantity";
            this.KarsiUrunKontrolProgressQuantity.Size = new System.Drawing.Size(366, 35);
            this.KarsiUrunKontrolProgressQuantity.TabIndex = 4;
            this.KarsiUrunKontrolProgressQuantity.Text = "Aktif Değil";
            this.KarsiUrunKontrolProgressQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KarsiUrunKontrolbaglanti_bildirim
            // 
            this.KarsiUrunKontrolbaglanti_bildirim.BackColor = System.Drawing.SystemColors.Window;
            this.KarsiUrunKontrolbaglanti_bildirim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KarsiUrunKontrolbaglanti_bildirim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KarsiUrunKontrolbaglanti_bildirim.EnableAutoDragDrop = true;
            this.KarsiUrunKontrolbaglanti_bildirim.Location = new System.Drawing.Point(13, 193);
            this.KarsiUrunKontrolbaglanti_bildirim.Name = "KarsiUrunKontrolbaglanti_bildirim";
            this.KarsiUrunKontrolbaglanti_bildirim.ReadOnly = true;
            this.KarsiUrunKontrolbaglanti_bildirim.Size = new System.Drawing.Size(365, 95);
            this.KarsiUrunKontrolbaglanti_bildirim.TabIndex = 5;
            this.KarsiUrunKontrolbaglanti_bildirim.Text = "";
            // 
            // KarsiUrunKontrolurun_degisikligi
            // 
            this.KarsiUrunKontrolurun_degisikligi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KarsiUrunKontrolurun_degisikligi.Location = new System.Drawing.Point(12, 432);
            this.KarsiUrunKontrolurun_degisikligi.Name = "KarsiUrunKontrolurun_degisikligi";
            this.KarsiUrunKontrolurun_degisikligi.Size = new System.Drawing.Size(365, 98);
            this.KarsiUrunKontrolurun_degisikligi.TabIndex = 6;
            this.KarsiUrunKontrolurun_degisikligi.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(145, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bağlantı Durumu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(145, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ürün Değişikleri";
            // 
            // KarsiUrunKontrolDurdur
            // 
            this.KarsiUrunKontrolDurdur.Location = new System.Drawing.Point(238, 128);
            this.KarsiUrunKontrolDurdur.Name = "KarsiUrunKontrolDurdur";
            this.KarsiUrunKontrolDurdur.Size = new System.Drawing.Size(104, 39);
            this.KarsiUrunKontrolDurdur.TabIndex = 9;
            this.KarsiUrunKontrolDurdur.Text = "Durdur";
            this.KarsiUrunKontrolDurdur.UseVisualStyleBackColor = true;
            this.KarsiUrunKontrolDurdur.Click += new System.EventHandler(this.KarsiUrunKontrolDurdurButon_Click);
            // 
            // BildirimIcon
            // 
            this.BildirimIcon.ContextMenuStrip = this.GosterMenu;
            this.BildirimIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("BildirimIcon.Icon")));
            this.BildirimIcon.Text = "Auto-Mate";
            // 
            // GosterMenu
            // 
            this.GosterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Göster});
            this.GosterMenu.Name = "GosterMenu";
            this.GosterMenu.Size = new System.Drawing.Size(109, 26);
            // 
            // Göster
            // 
            this.Göster.Name = "Göster";
            this.Göster.Size = new System.Drawing.Size(108, 22);
            this.Göster.Text = "Göster";
            this.Göster.Click += new System.EventHandler(this.Goster_Click);
            // 
            // TümünüDurdurButon
            // 
            this.TümünüDurdurButon.Location = new System.Drawing.Point(923, 507);
            this.TümünüDurdurButon.Name = "TümünüDurdurButon";
            this.TümünüDurdurButon.Size = new System.Drawing.Size(116, 23);
            this.TümünüDurdurButon.TabIndex = 10;
            this.TümünüDurdurButon.Text = "Tümünü Durdur";
            this.TümünüDurdurButon.UseVisualStyleBackColor = true;
            this.TümünüDurdurButon.Click += new System.EventHandler(this.TümünüDurdurButon_Click);
            // 
            // ÇıkışButon
            // 
            this.ÇıkışButon.Location = new System.Drawing.Point(1045, 507);
            this.ÇıkışButon.Name = "ÇıkışButon";
            this.ÇıkışButon.Size = new System.Drawing.Size(75, 23);
            this.ÇıkışButon.TabIndex = 11;
            this.ÇıkışButon.Text = "Çıkış";
            this.ÇıkışButon.UseVisualStyleBackColor = true;
            this.ÇıkışButon.Click += new System.EventHandler(this.ÇıkışButon_Click);
            // 
            // ÜrünBulBaşlat
            // 
            this.ÜrünBulBaşlat.Location = new System.Drawing.Point(477, 128);
            this.ÜrünBulBaşlat.Name = "ÜrünBulBaşlat";
            this.ÜrünBulBaşlat.Size = new System.Drawing.Size(134, 39);
            this.ÜrünBulBaşlat.TabIndex = 12;
            this.ÜrünBulBaşlat.Text = "Başlat";
            this.ÜrünBulBaşlat.UseVisualStyleBackColor = true;
            this.ÜrünBulBaşlat.Click += new System.EventHandler(this.ÜrünBulBaşlat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(104, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 28);
            this.label3.TabIndex = 13;
            this.label3.Text = "Karşı Ürün Kontrolü";
            // 
            // ÜrünBulDurdur
            // 
            this.ÜrünBulDurdur.Location = new System.Drawing.Point(617, 128);
            this.ÜrünBulDurdur.Name = "ÜrünBulDurdur";
            this.ÜrünBulDurdur.Size = new System.Drawing.Size(103, 39);
            this.ÜrünBulDurdur.TabIndex = 14;
            this.ÜrünBulDurdur.Text = "Durdur";
            this.ÜrünBulDurdur.UseVisualStyleBackColor = true;
            this.ÜrünBulDurdur.Click += new System.EventHandler(this.ÜrünBulDurdur_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(442, 193);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(304, 95);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(145, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Bağlantı Hataları";
            // 
            // BağlantıHataları
            // 
            this.BağlantıHataları.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BağlantıHataları.Location = new System.Drawing.Point(12, 313);
            this.BağlantıHataları.Name = "BağlantıHataları";
            this.BağlantıHataları.Size = new System.Drawing.Size(365, 94);
            this.BağlantıHataları.TabIndex = 16;
            this.BağlantıHataları.Text = "";
            // 
            // UrunBulDurum
            // 
            this.UrunBulDurum.AutoSize = true;
            this.UrunBulDurum.BackColor = System.Drawing.Color.Transparent;
            this.UrunBulDurum.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UrunBulDurum.ForeColor = System.Drawing.SystemColors.Window;
            this.UrunBulDurum.Location = new System.Drawing.Point(533, 40);
            this.UrunBulDurum.Name = "UrunBulDurum";
            this.UrunBulDurum.Size = new System.Drawing.Size(131, 28);
            this.UrunBulDurum.TabIndex = 18;
            this.UrunBulDurum.Text = "Ürün Durumu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(533, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 28);
            this.label5.TabIndex = 19;
            this.label5.Text = "Yeni ürün bul";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1132, 542);
            this.ContextMenuStrip = this.GizleMenu;
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UrunBulDurum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BağlantıHataları);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ÜrünBulDurdur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ÜrünBulBaşlat);
            this.Controls.Add(this.ÇıkışButon);
            this.Controls.Add(this.TümünüDurdurButon);
            this.Controls.Add(this.KarsiUrunKontrolDurdur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KarsiUrunKontrolurun_degisikligi);
            this.Controls.Add(this.KarsiUrunKontrolbaglanti_bildirim);
            this.Controls.Add(this.KarsiUrunKontrolProgressQuantity);
            this.Controls.Add(this._KarsiUrunKontrolprogressBar);
            this.Controls.Add(this.KarsiUrunKontrolBaslat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto-Mate by Brankhos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Load);
            this.GizleMenu.ResumeLayout(false);
            this.GosterMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip GizleMenu;
        private System.Windows.Forms.ToolStripMenuItem Gizle;
        private System.Windows.Forms.Button KarsiUrunKontrolBaslat;
        private System.Windows.Forms.ProgressBar _KarsiUrunKontrolprogressBar;
        private System.Windows.Forms.Label KarsiUrunKontrolProgressQuantity;
        private System.Windows.Forms.RichTextBox KarsiUrunKontrolbaglanti_bildirim;
        private System.Windows.Forms.RichTextBox KarsiUrunKontrolurun_degisikligi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button KarsiUrunKontrolDurdur;
        public System.Windows.Forms.NotifyIcon BildirimIcon;
        private System.Windows.Forms.ContextMenuStrip GosterMenu;
        private System.Windows.Forms.ToolStripMenuItem Göster;
        private System.Windows.Forms.Button TümünüDurdurButon;
        private System.Windows.Forms.Button ÇıkışButon;
        private System.Windows.Forms.Button ÜrünBulBaşlat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ÜrünBulDurdur;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox BağlantıHataları;
        private System.Windows.Forms.Label UrunBulDurum;
        private System.Windows.Forms.Label label5;
    }
}

