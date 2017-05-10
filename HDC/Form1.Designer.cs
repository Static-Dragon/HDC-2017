
namespace HDC {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btn_conn = new System.Windows.Forms.Button();
            this.txtbx_Host = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_uName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.txtbx_passwd = new System.Windows.Forms.TextBox();
            this.txtbx_port = new HDC.NumericTextBox();
            this.btn_discon = new System.Windows.Forms.Button();
            this.btn_quit = new System.Windows.Forms.Button();
            this.lbl_boatStatus = new System.Windows.Forms.Label();
            this.u = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anchorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dd_manualAnchor = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drpdwn_Debug = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_UIUpdate = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer_roboTick = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_conn
            // 
            this.btn_conn.Location = new System.Drawing.Point(534, 376);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(75, 23);
            this.btn_conn.TabIndex = 0;
            this.btn_conn.Text = "Connect";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txtbx_Host
            // 
            this.txtbx_Host.Location = new System.Drawing.Point(13, 47);
            this.txtbx_Host.Name = "txtbx_Host";
            this.txtbx_Host.Size = new System.Drawing.Size(100, 20);
            this.txtbx_Host.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username";
            // 
            // txtbx_uName
            // 
            this.txtbx_uName.Location = new System.Drawing.Point(13, 133);
            this.txtbx_uName.Name = "txtbx_uName";
            this.txtbx_uName.Size = new System.Drawing.Size(100, 20);
            this.txtbx_uName.TabIndex = 6;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(16, 160);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 7;
            this.Password.Text = "Password";
            // 
            // txtbx_passwd
            // 
            this.txtbx_passwd.Location = new System.Drawing.Point(13, 177);
            this.txtbx_passwd.Name = "txtbx_passwd";
            this.txtbx_passwd.Size = new System.Drawing.Size(100, 20);
            this.txtbx_passwd.TabIndex = 8;
            this.txtbx_passwd.UseSystemPasswordChar = true;
            // 
            // txtbx_port
            // 
            this.txtbx_port.AllowSpace = false;
            this.txtbx_port.Location = new System.Drawing.Point(13, 90);
            this.txtbx_port.Name = "txtbx_port";
            this.txtbx_port.Size = new System.Drawing.Size(100, 20);
            this.txtbx_port.TabIndex = 4;
            // 
            // btn_discon
            // 
            this.btn_discon.Location = new System.Drawing.Point(534, 405);
            this.btn_discon.Name = "btn_discon";
            this.btn_discon.Size = new System.Drawing.Size(75, 23);
            this.btn_discon.TabIndex = 9;
            this.btn_discon.Text = "Disconnect";
            this.btn_discon.UseVisualStyleBackColor = true;
            this.btn_discon.Click += new System.EventHandler(this.btn_discon_Click);
            // 
            // btn_quit
            // 
            this.btn_quit.Location = new System.Drawing.Point(615, 405);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(75, 23);
            this.btn_quit.TabIndex = 10;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // lbl_boatStatus
            // 
            this.lbl_boatStatus.AutoSize = true;
            this.lbl_boatStatus.Location = new System.Drawing.Point(10, 221);
            this.lbl_boatStatus.Name = "lbl_boatStatus";
            this.lbl_boatStatus.Size = new System.Drawing.Size(31, 13);
            this.lbl_boatStatus.TabIndex = 11;
            this.lbl_boatStatus.Text = "Blah:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.manualToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anchorToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // anchorToolStripMenuItem
            // 
            this.anchorToolStripMenuItem.Name = "anchorToolStripMenuItem";
            this.anchorToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.anchorToolStripMenuItem.Text = "Anchor";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dd_manualAnchor});
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // dd_manualAnchor
            // 
            this.dd_manualAnchor.Name = "dd_manualAnchor";
            this.dd_manualAnchor.Size = new System.Drawing.Size(113, 22);
            this.dd_manualAnchor.Text = "Anchor";
            this.dd_manualAnchor.Click += new System.EventHandler(this.dd_manualAnchor_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drpdwn_Debug});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // drpdwn_Debug
            // 
            this.drpdwn_Debug.Name = "drpdwn_Debug";
            this.drpdwn_Debug.Size = new System.Drawing.Size(109, 22);
            this.drpdwn_Debug.Text = "Debug";
            this.drpdwn_Debug.Click += new System.EventHandler(this.drpdwn_Debug_Click);
            // 
            // timer_UIUpdate
            // 
            this.timer_UIUpdate.Interval = 6000;
            this.timer_UIUpdate.Tick += new System.EventHandler(this.timer_UIUpdate_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(703, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 457);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbl_boatStatus);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.btn_discon);
            this.Controls.Add(this.txtbx_passwd);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.txtbx_uName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbx_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_Host);
            this.Controls.Add(this.btn_conn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_conn;
        private System.Windows.Forms.TextBox txtbx_Host;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private NumericTextBox txtbx_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_uName;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox txtbx_passwd;
        private System.Windows.Forms.Button btn_discon;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Label lbl_boatStatus;
        private System.ComponentModel.BackgroundWorker u;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anchorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dd_manualAnchor;
        private System.Windows.Forms.Timer timer_UIUpdate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drpdwn_Debug;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_roboTick;
    }
}

