namespace QuanLiShopQuanAo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcMặtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcChiTiếtĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcKháchHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcNhânViênToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcĐơnHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiThựcHiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTittle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panelDN = new System.Windows.Forms.Panel();
            this.menuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelDN.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.xemDanhMụcToolStripMenuItem,
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem,
            this.thôngTinToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(808, 27);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhậpToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            this.đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            this.đăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.đăngNhậpToolStripMenuItem.Text = "Đăng Nhập";
            this.đăngNhậpToolStripMenuItem.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click_1);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // xemDanhMụcToolStripMenuItem
            // 
            this.xemDanhMụcToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.xemDanhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcKháchHàngToolStripMenuItem,
            this.danhMụcNhânViênToolStripMenuItem,
            this.danhMụcMặtHàngToolStripMenuItem,
            this.danhMụcĐơnHàngToolStripMenuItem,
            this.danhMụcChiTiếtĐơnHàngToolStripMenuItem});
            this.xemDanhMụcToolStripMenuItem.Enabled = false;
            this.xemDanhMụcToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemDanhMụcToolStripMenuItem.Name = "xemDanhMụcToolStripMenuItem";
            this.xemDanhMụcToolStripMenuItem.Size = new System.Drawing.Size(112, 23);
            this.xemDanhMụcToolStripMenuItem.Text = "Xem danh mục";
            this.xemDanhMụcToolStripMenuItem.Click += new System.EventHandler(this.xemDanhMụcToolStripMenuItem_Click);
            // 
            // danhMụcKháchHàngToolStripMenuItem
            // 
            this.danhMụcKháchHàngToolStripMenuItem.Name = "danhMụcKháchHàngToolStripMenuItem";
            this.danhMụcKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.danhMụcKháchHàngToolStripMenuItem.Text = "Danh mục Khách Hàng";
            this.danhMụcKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.danhMụcKháchHàngToolStripMenuItem_Click);
            // 
            // danhMụcNhânViênToolStripMenuItem
            // 
            this.danhMụcNhânViênToolStripMenuItem.Name = "danhMụcNhânViênToolStripMenuItem";
            this.danhMụcNhânViênToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.danhMụcNhânViênToolStripMenuItem.Text = "Danh mục Nhân Viên";
            this.danhMụcNhânViênToolStripMenuItem.Click += new System.EventHandler(this.danhMụcNhânViênToolStripMenuItem_Click);
            // 
            // danhMụcMặtHàngToolStripMenuItem
            // 
            this.danhMụcMặtHàngToolStripMenuItem.Name = "danhMụcMặtHàngToolStripMenuItem";
            this.danhMụcMặtHàngToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.danhMụcMặtHàngToolStripMenuItem.Text = "Danh mục Mặt Hàng";
            this.danhMụcMặtHàngToolStripMenuItem.Click += new System.EventHandler(this.danhMụcMặtHàngToolStripMenuItem_Click);
            // 
            // danhMụcĐơnHàngToolStripMenuItem
            // 
            this.danhMụcĐơnHàngToolStripMenuItem.Name = "danhMụcĐơnHàngToolStripMenuItem";
            this.danhMụcĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.danhMụcĐơnHàngToolStripMenuItem.Text = "Danh mục Đơn Hàng";
            this.danhMụcĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.danhMụcĐơnHàngToolStripMenuItem_Click);
            // 
            // danhMụcChiTiếtĐơnHàngToolStripMenuItem
            // 
            this.danhMụcChiTiếtĐơnHàngToolStripMenuItem.Name = "danhMụcChiTiếtĐơnHàngToolStripMenuItem";
            this.danhMụcChiTiếtĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.danhMụcChiTiếtĐơnHàngToolStripMenuItem.Text = "Danh mục Chi Tiết Đơn Hàng";
            this.danhMụcChiTiếtĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.danhMụcChiTiếtĐơnHàngToolStripMenuItem_Click);
            // 
            // quảnLýDanhMụcĐơnHàngToolStripMenuItem
            // 
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcKháchHàngToolStripMenuItem1,
            this.danhMụcNhânViênToolStripMenuItem1,
            this.danhMụcĐơnHàngToolStripMenuItem1,
            this.danhMụcSảnPhẩmToolStripMenuItem,
            this.danhToolStripMenuItem});
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem.Enabled = false;
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem.Name = "quảnLýDanhMụcĐơnHàngToolStripMenuItem";
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(189, 23);
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem.Text = "Quản lý danh mục đơn hàng";
            this.quảnLýDanhMụcĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýDanhMụcĐơnHàngToolStripMenuItem_Click);
            // 
            // danhMụcKháchHàngToolStripMenuItem1
            // 
            this.danhMụcKháchHàngToolStripMenuItem1.Name = "danhMụcKháchHàngToolStripMenuItem1";
            this.danhMụcKháchHàngToolStripMenuItem1.Size = new System.Drawing.Size(256, 24);
            this.danhMụcKháchHàngToolStripMenuItem1.Text = "Danh mục Khách Hàng";
            this.danhMụcKháchHàngToolStripMenuItem1.Click += new System.EventHandler(this.danhMụcKháchHàngToolStripMenuItem1_Click);
            // 
            // danhMụcNhânViênToolStripMenuItem1
            // 
            this.danhMụcNhânViênToolStripMenuItem1.Name = "danhMụcNhânViênToolStripMenuItem1";
            this.danhMụcNhânViênToolStripMenuItem1.Size = new System.Drawing.Size(256, 24);
            this.danhMụcNhânViênToolStripMenuItem1.Text = "Danh mục Nhân Viên";
            this.danhMụcNhânViênToolStripMenuItem1.Click += new System.EventHandler(this.danhMụcNhânViênToolStripMenuItem1_Click);
            // 
            // danhMụcĐơnHàngToolStripMenuItem1
            // 
            this.danhMụcĐơnHàngToolStripMenuItem1.Name = "danhMụcĐơnHàngToolStripMenuItem1";
            this.danhMụcĐơnHàngToolStripMenuItem1.Size = new System.Drawing.Size(256, 24);
            this.danhMụcĐơnHàngToolStripMenuItem1.Text = "Danh mục Mặt Hàng";
            this.danhMụcĐơnHàngToolStripMenuItem1.Click += new System.EventHandler(this.danhMụcĐơnHàngToolStripMenuItem1_Click);
            // 
            // danhMụcSảnPhẩmToolStripMenuItem
            // 
            this.danhMụcSảnPhẩmToolStripMenuItem.Name = "danhMụcSảnPhẩmToolStripMenuItem";
            this.danhMụcSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.danhMụcSảnPhẩmToolStripMenuItem.Text = "Danh mục Đơn Hàng";
            this.danhMụcSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.danhMụcSảnPhẩmToolStripMenuItem_Click);
            // 
            // danhToolStripMenuItem
            // 
            this.danhToolStripMenuItem.Name = "danhToolStripMenuItem";
            this.danhToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.danhToolStripMenuItem.Text = "Danh mục Chi Tiết Đơn Hàng";
            this.danhToolStripMenuItem.Click += new System.EventHandler(this.danhToolStripMenuItem_Click);
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ngườiThựcHiệnToolStripMenuItem});
            this.thôngTinToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
            this.thôngTinToolStripMenuItem.Text = "Thông tin";
            // 
            // ngườiThựcHiệnToolStripMenuItem
            // 
            this.ngườiThựcHiệnToolStripMenuItem.Name = "ngườiThựcHiệnToolStripMenuItem";
            this.ngườiThựcHiệnToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.ngườiThựcHiệnToolStripMenuItem.Text = "Người thực hiện";
            this.ngườiThựcHiệnToolStripMenuItem.Click += new System.EventHandler(this.ngườiThựcHiệnToolStripMenuItem_Click);
            // 
            // lbTittle
            // 
            this.lbTittle.AutoSize = true;
            this.lbTittle.BackColor = System.Drawing.SystemColors.Window;
            this.lbTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTittle.ForeColor = System.Drawing.Color.Red;
            this.lbTittle.Location = new System.Drawing.Point(242, 98);
            this.lbTittle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTittle.Name = "lbTittle";
            this.lbTittle.Size = new System.Drawing.Size(424, 37);
            this.lbTittle.TabIndex = 7;
            this.lbTittle.Text = "QUẢN LÍ SHOP QUẦN ÁO";
            this.lbTittle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbTittle.UseMnemonic = false;
            this.lbTittle.Click += new System.EventHandler(this.label3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 75;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(90, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(358, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ĐĂNG NHẬP VÀO HỆ THỐNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(150, 101);
            this.txtPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(128, 26);
            this.txtPass.TabIndex = 2;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(150, 45);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(128, 26);
            this.txtUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.Image = global::QuanLiShopQuanAo.Properties.Resources.Close_24;
            this.btnLogin.Location = new System.Drawing.Point(240, 221);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(96, 42);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.Image = global::QuanLiShopQuanAo.Properties.Resources.Exit;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(356, 221);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(92, 42);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panelDN
            // 
            this.panelDN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panelDN.Controls.Add(this.btnThoat);
            this.panelDN.Controls.Add(this.btnLogin);
            this.panelDN.Controls.Add(this.groupBox1);
            this.panelDN.Enabled = false;
            this.panelDN.Location = new System.Drawing.Point(171, 192);
            this.panelDN.Margin = new System.Windows.Forms.Padding(2);
            this.panelDN.Name = "panelDN";
            this.panelDN.Size = new System.Drawing.Size(521, 278);
            this.panelDN.TabIndex = 8;
            this.panelDN.Visible = false;
            this.panelDN.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDN_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLiShopQuanAo.Properties.Resources.BacgroundMain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(808, 529);
            this.Controls.Add(this.panelDN);
            this.Controls.Add(this.lbTittle);
            this.Controls.Add(this.menuStrip2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOPE TO PASS SHOP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelDN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcMặtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcChiTiếtĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýDanhMụcĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcKháchHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcNhânViênToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcĐơnHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngườiThựcHiệnToolStripMenuItem;
        private System.Windows.Forms.Label lbTittle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panelDN;
    }
}

