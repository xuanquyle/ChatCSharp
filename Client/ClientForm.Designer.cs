namespace Client
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChatBox = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lstChatters = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbx_File = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Send2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChatBox
            // 
            this.txtChatBox.AllowDrop = true;
            this.txtChatBox.BackColor = System.Drawing.SystemColors.Window;
            this.txtChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChatBox.ForeColor = System.Drawing.Color.MidnightBlue;
            resources.ApplyResources(this.txtChatBox, "txtChatBox");
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.ReadOnly = true;
            this.txtChatBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtChatBox_DragDrop);
            this.txtChatBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtChatBox_DragEnter);
            // 
            // txtMessage
            // 
            this.txtMessage.AllowDrop = true;
            resources.ApplyResources(this.txtMessage, "txtMessage");
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // lstChatters
            // 
            this.lstChatters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstChatters.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lstChatters.FormattingEnabled = true;
            resources.ApplyResources(this.lstChatters, "lstChatters");
            this.lstChatters.Name = "lstChatters";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // lbx_File
            // 
            this.lbx_File.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbx_File.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbx_File.FormattingEnabled = true;
            resources.ApplyResources(this.lbx_File, "lbx_File");
            this.lbx_File.Name = "lbx_File";
            this.lbx_File.SelectedIndexChanged += new System.EventHandler(this.lbx_File_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // btn_Send2
            // 
            this.btn_Send2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btn_Send2, "btn_Send2");
            this.btn_Send2.ForeColor = System.Drawing.Color.White;
            this.btn_Send2.Name = "btn_Send2";
            this.btn_Send2.UseVisualStyleBackColor = false;
            this.btn_Send2.Click += new System.EventHandler(this.btn_Send2_Click);
            // 
            // Client
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_Send2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbx_File);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstChatters);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChatBox);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SGSClient_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtChatBox;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstChatters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbx_File;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Send2;
    }
}

