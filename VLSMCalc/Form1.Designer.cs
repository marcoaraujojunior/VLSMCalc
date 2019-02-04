namespace VLSMCalc
{
    partial class FrmVlsm
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
            this.txtNetwork = new System.Windows.Forms.TextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Network:";
            // 
            // txtNetwork
            // 
            this.txtNetwork.Location = new System.Drawing.Point(81, 6);
            this.txtNetwork.Name = "txtNetwork";
            this.txtNetwork.Size = new System.Drawing.Size(125, 22);
            this.txtNetwork.TabIndex = 0;
            this.txtNetwork.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNetwork_KeyUp);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(212, 6);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(87, 25);
            this.btnCalc.TabIndex = 998;
            this.btnCalc.Text = "&Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(305, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 999;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FrmVlsm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(389, 45);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.txtNetwork);
            this.Controls.Add(this.label1);
            this.Name = "FrmVlsm";
            this.Text = "VLSM Calc";
            this.Load += new System.EventHandler(this.FrmVlsm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNetwork;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnReset;
    }
}

