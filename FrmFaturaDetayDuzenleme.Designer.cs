namespace Ticari_Otomasyon
{
    partial class FrmFaturaDetayDuzenleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFaturaDetayDuzenleme));
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.btnDetayGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetaySil = new DevExpress.XtraEditors.SimpleButton();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.txtFaturaId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtFiyat = new DevExpress.XtraEditors.TextEdit();
            this.txtUrunAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtMiktar = new DevExpress.XtraEditors.TextEdit();
            this.txtUrunId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.btnDetayGuncelle);
            this.groupControl5.Controls.Add(this.btnDetaySil);
            this.groupControl5.Controls.Add(this.txtTutar);
            this.groupControl5.Controls.Add(this.txtFaturaId);
            this.groupControl5.Controls.Add(this.labelControl15);
            this.groupControl5.Controls.Add(this.labelControl7);
            this.groupControl5.Controls.Add(this.txtFiyat);
            this.groupControl5.Controls.Add(this.txtUrunAdi);
            this.groupControl5.Controls.Add(this.txtMiktar);
            this.groupControl5.Controls.Add(this.txtUrunId);
            this.groupControl5.Controls.Add(this.labelControl11);
            this.groupControl5.Controls.Add(this.labelControl10);
            this.groupControl5.Controls.Add(this.labelControl8);
            this.groupControl5.Controls.Add(this.labelControl9);
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new System.Drawing.Size(592, 492);
            this.groupControl5.TabIndex = 1;
            this.groupControl5.Text = "groupControl5";
            // 
            // btnDetayGuncelle
            // 
            this.btnDetayGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetayGuncelle.Appearance.Options.UseFont = true;
            this.btnDetayGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDetayGuncelle.ImageOptions.Image")));
            this.btnDetayGuncelle.Location = new System.Drawing.Point(172, 248);
            this.btnDetayGuncelle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetayGuncelle.Name = "btnDetayGuncelle";
            this.btnDetayGuncelle.Size = new System.Drawing.Size(289, 38);
            this.btnDetayGuncelle.TabIndex = 37;
            this.btnDetayGuncelle.Text = "GÜNCELLE";
            this.btnDetayGuncelle.Click += new System.EventHandler(this.btnDetayGuncelle_Click);
            // 
            // btnDetaySil
            // 
            this.btnDetaySil.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetaySil.Appearance.Options.UseFont = true;
            this.btnDetaySil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDetaySil.ImageOptions.Image")));
            this.btnDetaySil.Location = new System.Drawing.Point(171, 290);
            this.btnDetaySil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetaySil.Name = "btnDetaySil";
            this.btnDetaySil.Size = new System.Drawing.Size(289, 38);
            this.btnDetaySil.TabIndex = 36;
            this.btnDetaySil.Text = "SİL";
            this.btnDetaySil.Click += new System.EventHandler(this.btnDetaySil_Click);
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(172, 184);
            this.txtTutar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTutar.Properties.Appearance.Options.UseFont = true;
            this.txtTutar.Size = new System.Drawing.Size(289, 28);
            this.txtTutar.TabIndex = 4;
            // 
            // txtFaturaId
            // 
            this.txtFaturaId.Enabled = false;
            this.txtFaturaId.Location = new System.Drawing.Point(171, 216);
            this.txtFaturaId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFaturaId.Name = "txtFaturaId";
            this.txtFaturaId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaturaId.Properties.Appearance.Options.UseFont = true;
            this.txtFaturaId.Size = new System.Drawing.Size(289, 28);
            this.txtFaturaId.TabIndex = 5;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(104, 187);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(59, 21);
            this.labelControl15.TabIndex = 34;
            this.labelControl15.Text = "TUTAR:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(71, 219);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(92, 21);
            this.labelControl7.TabIndex = 33;
            this.labelControl7.Text = "FATURA ID:";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(172, 152);
            this.txtFiyat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiyat.Properties.Appearance.Options.UseFont = true;
            this.txtFiyat.Size = new System.Drawing.Size(289, 28);
            this.txtFiyat.TabIndex = 3;
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(172, 88);
            this.txtUrunAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrunAdi.Properties.Appearance.Options.UseFont = true;
            this.txtUrunAdi.Size = new System.Drawing.Size(289, 28);
            this.txtUrunAdi.TabIndex = 1;
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(172, 120);
            this.txtMiktar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiktar.Properties.Appearance.Options.UseFont = true;
            this.txtMiktar.Size = new System.Drawing.Size(289, 28);
            this.txtMiktar.TabIndex = 2;
            // 
            // txtUrunId
            // 
            this.txtUrunId.Enabled = false;
            this.txtUrunId.Location = new System.Drawing.Point(172, 56);
            this.txtUrunId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUrunId.Name = "txtUrunId";
            this.txtUrunId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrunId.Properties.Appearance.Options.UseFont = true;
            this.txtUrunId.Size = new System.Drawing.Size(289, 28);
            this.txtUrunId.TabIndex = 0;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(111, 155);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(52, 21);
            this.labelControl11.TabIndex = 27;
            this.labelControl11.Text = "FİYAT:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(96, 123);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(67, 21);
            this.labelControl10.TabIndex = 25;
            this.labelControl10.Text = "MİKTAR:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(90, 59);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(73, 21);
            this.labelControl8.TabIndex = 17;
            this.labelControl8.Text = "URUN ID:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(79, 91);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(84, 21);
            this.labelControl9.TabIndex = 19;
            this.labelControl9.Text = "ÜRÜN ADI:";
            // 
            // FrmFaturaDetayDuzenleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(599, 505);
            this.Controls.Add(this.groupControl5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFaturaDetayDuzenleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FATURA DETAY DÜZENLEME";
            this.Load += new System.EventHandler(this.FrmFaturaDetayDuzenleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrunId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.SimpleButton btnDetayGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnDetaySil;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.TextEdit txtFaturaId;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtFiyat;
        private DevExpress.XtraEditors.TextEdit txtUrunAdi;
        private DevExpress.XtraEditors.TextEdit txtMiktar;
        private DevExpress.XtraEditors.TextEdit txtUrunId;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}