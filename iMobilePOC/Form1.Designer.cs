
namespace iMobilePOC2
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
            this.btnDeviceInfo = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnRecv = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtRecv = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeviceInfo
            // 
            this.btnDeviceInfo.Location = new System.Drawing.Point(0, 0);
            this.btnDeviceInfo.Name = "btnDeviceInfo";
            this.btnDeviceInfo.Size = new System.Drawing.Size(150, 23);
            this.btnDeviceInfo.TabIndex = 0;
            this.btnDeviceInfo.Text = "Get Device Info";
            this.btnDeviceInfo.UseVisualStyleBackColor = true;
            this.btnDeviceInfo.Click += new System.EventHandler(this.btnDeviceInfo_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(349, 397);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(477, 397);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnRecv
            // 
            this.btnRecv.Location = new System.Drawing.Point(477, 443);
            this.btnRecv.Name = "btnRecv";
            this.btnRecv.Size = new System.Drawing.Size(75, 23);
            this.btnRecv.TabIndex = 3;
            this.btnRecv.Text = "Recv";
            this.btnRecv.UseVisualStyleBackColor = true;
            this.btnRecv.Click += new System.EventHandler(this.btnRecv_Click);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Enabled = false;
            this.txtDisplay.Location = new System.Drawing.Point(275, 0);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisplay.Size = new System.Drawing.Size(560, 365);
            this.txtDisplay.TabIndex = 4;
            // 
            // txtSend
            // 
            this.txtSend.Enabled = false;
            this.txtSend.Location = new System.Drawing.Point(619, 398);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(198, 22);
            this.txtSend.TabIndex = 5;
            // 
            // txtRecv
            // 
            this.txtRecv.Enabled = false;
            this.txtRecv.Location = new System.Drawing.Point(619, 443);
            this.txtRecv.Name = "txtRecv";
            this.txtRecv.Size = new System.Drawing.Size(198, 22);
            this.txtRecv.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 469);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 17);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status : No Device";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 527);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtRecv);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnRecv);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDeviceInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeviceInfo;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnRecv;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtRecv;
        private System.Windows.Forms.Label lblStatus;
    }
}

