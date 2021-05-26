namespace TransferEmployeesToEmployeeRequestWindowsApplication
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.lastTransfer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.allTransfers = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.transferQueue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(170, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "آخرین انتقال انجام شده";
            // 
            // lastTransfer
            // 
            this.lastTransfer.AutoSize = true;
            this.lastTransfer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lastTransfer.Location = new System.Drawing.Point(12, 9);
            this.lastTransfer.Name = "lastTransfer";
            this.lastTransfer.Size = new System.Drawing.Size(15, 20);
            this.lastTransfer.TabIndex = 0;
            this.lastTransfer.Text = "_";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(243, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "منتقل شده";
            // 
            // allTransfers
            // 
            this.allTransfers.AutoSize = true;
            this.allTransfers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.allTransfers.Location = new System.Drawing.Point(12, 63);
            this.allTransfers.Name = "allTransfers";
            this.allTransfers.Size = new System.Drawing.Size(18, 20);
            this.allTransfers.TabIndex = 0;
            this.allTransfers.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(221, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "در صف انتقال";
            // 
            // transferQueue
            // 
            this.transferQueue.AutoSize = true;
            this.transferQueue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.transferQueue.Location = new System.Drawing.Point(12, 127);
            this.transferQueue.Name = "transferQueue";
            this.transferQueue.Size = new System.Drawing.Size(18, 20);
            this.transferQueue.TabIndex = 0;
            this.transferQueue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(265, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "خطا ها";
            // 
            // errorLog
            // 
            this.errorLog.Location = new System.Drawing.Point(12, 214);
            this.errorLog.Multiline = true;
            this.errorLog.Name = "errorLog";
            this.errorLog.Size = new System.Drawing.Size(304, 89);
            this.errorLog.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 315);
            this.Controls.Add(this.errorLog);
            this.Controls.Add(this.transferQueue);
            this.Controls.Add(this.allTransfers);
            this.Controls.Add(this.lastTransfer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "انتقال رکورد ها بین جداول";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastTransfer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label allTransfers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label transferQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox errorLog;
    }
}