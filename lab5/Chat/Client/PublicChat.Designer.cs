namespace Client
{
    partial class PublicChat
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
            this.userList = new System.Windows.Forms.ListBox();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChat = new System.Windows.Forms.ToolStripMenuItem();
            this.txtReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.txtInputMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userList.BackColor = System.Drawing.SystemColors.Info;
            this.userList.ContextMenuStrip = this.Menu;
            this.userList.FormattingEnabled = true;
            this.userList.ItemHeight = 20;
            this.userList.Location = new System.Drawing.Point(624, 12);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(187, 424);
            this.userList.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateChat});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(179, 34);
            // 
            // privateChat
            // 
            this.privateChat.Name = "privateChat";
            this.privateChat.Size = new System.Drawing.Size(178, 30);
            this.privateChat.Text = "Private Chat";
            this.privateChat.Click += new System.EventHandler(this.privateChat_Click);
            // 
            // txtReceivedMsg
            // 
            this.txtReceivedMsg.Location = new System.Drawing.Point(13, 12);
            this.txtReceivedMsg.Name = "txtReceivedMsg";
            this.txtReceivedMsg.ReadOnly = true;
            this.txtReceivedMsg.Size = new System.Drawing.Size(605, 335);
            this.txtReceivedMsg.TabIndex = 1;
            this.txtReceivedMsg.Text = "";
            this.txtReceivedMsg.TextChanged += new System.EventHandler(this.txtReceivedMsg_TextChanged);
            // 
            // txtInputMsg
            // 
            this.txtInputMsg.Location = new System.Drawing.Point(13, 368);
            this.txtInputMsg.Multiline = true;
            this.txtInputMsg.Name = "txtInputMsg";
            this.txtInputMsg.Size = new System.Drawing.Size(425, 68);
            this.txtInputMsg.TabIndex = 2;
            this.txtInputMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_EnterKeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(445, 368);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(173, 68);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // PublicChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(823, 462);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInputMsg);
            this.Controls.Add(this.txtReceivedMsg);
            this.Controls.Add(this.userList);
            this.Name = "PublicChat";
            this.Text = "\"Public Chat\"";
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.RichTextBox txtReceivedMsg;
        private System.Windows.Forms.TextBox txtInputMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem privateChat;
    }
}