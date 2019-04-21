namespace Client
{
    partial class PrivateChat
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtInputMsg = new System.Windows.Forms.TextBox();
            this.txtReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(454, 369);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(163, 68);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtInputMsg
            // 
            this.txtInputMsg.Location = new System.Drawing.Point(12, 369);
            this.txtInputMsg.Multiline = true;
            this.txtInputMsg.Name = "txtInputMsg";
            this.txtInputMsg.Size = new System.Drawing.Size(425, 68);
            this.txtInputMsg.TabIndex = 5;
            this.txtInputMsg.TextChanged += new System.EventHandler(this.txtInputMsg_TextChanged);
            this.txtInputMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_EnterKeyDown);
            // 
            // txtReceivedMsg
            // 
            this.txtReceivedMsg.Enabled = false;
            this.txtReceivedMsg.Location = new System.Drawing.Point(12, 12);
            this.txtReceivedMsg.Name = "txtReceivedMsg";
            this.txtReceivedMsg.ReadOnly = true;
            this.txtReceivedMsg.Size = new System.Drawing.Size(605, 335);
            this.txtReceivedMsg.TabIndex = 4;
            this.txtReceivedMsg.Text = "";
            this.txtReceivedMsg.TextChanged += new System.EventHandler(this.txtReceivedMsg_TextChanged);
            // 
            // PrivateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(643, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInputMsg);
            this.Controls.Add(this.txtReceivedMsg);
            this.Name = "PrivateChat";
            this.Text = "PrivateChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtInputMsg;
        public System.Windows.Forms.RichTextBox txtReceivedMsg;
    }
}