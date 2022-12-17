namespace ApplicationWindowsSide
{
    partial class form_ApplicationWindowsSide
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_TerminateConnection = new System.Windows.Forms.Button();
            this.bt_InitializeConnection = new System.Windows.Forms.Button();
            this.bt_SendLightSignal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_TerminateConnection
            // 
            this.bt_TerminateConnection.Location = new System.Drawing.Point(12, 50);
            this.bt_TerminateConnection.Name = "bt_TerminateConnection";
            this.bt_TerminateConnection.Size = new System.Drawing.Size(75, 23);
            this.bt_TerminateConnection.TabIndex = 0;
            this.bt_TerminateConnection.Text = "Terminate";
            this.bt_TerminateConnection.UseVisualStyleBackColor = true;
            this.bt_TerminateConnection.Click += new System.EventHandler(this.bt_TerminateConnection_Click);
            // 
            // bt_InitializeConnection
            // 
            this.bt_InitializeConnection.Location = new System.Drawing.Point(12, 12);
            this.bt_InitializeConnection.Name = "bt_InitializeConnection";
            this.bt_InitializeConnection.Size = new System.Drawing.Size(75, 23);
            this.bt_InitializeConnection.TabIndex = 1;
            this.bt_InitializeConnection.Text = "Connect";
            this.bt_InitializeConnection.UseVisualStyleBackColor = true;
            this.bt_InitializeConnection.Click += new System.EventHandler(this.bt_InitializeConnection_Click);
            // 
            // bt_SendLightSignal
            // 
            this.bt_SendLightSignal.Location = new System.Drawing.Point(107, 12);
            this.bt_SendLightSignal.Name = "bt_SendLightSignal";
            this.bt_SendLightSignal.Size = new System.Drawing.Size(181, 158);
            this.bt_SendLightSignal.TabIndex = 2;
            this.bt_SendLightSignal.Text = "Turn Light on";
            this.bt_SendLightSignal.UseVisualStyleBackColor = true;
            this.bt_SendLightSignal.Click += new System.EventHandler(this.bt_SendLightSignal_Click);
            // 
            // form_ApplicationWindowsSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 177);
            this.Controls.Add(this.bt_SendLightSignal);
            this.Controls.Add(this.bt_InitializeConnection);
            this.Controls.Add(this.bt_TerminateConnection);
            this.Name = "form_ApplicationWindowsSide";
            this.Text = "WindowsSide";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_TerminateConnection;
        private System.Windows.Forms.Button bt_InitializeConnection;
        private System.Windows.Forms.Button bt_SendLightSignal;
    }
}

