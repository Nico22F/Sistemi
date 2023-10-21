namespace Sistemi
{
    partial class Finestra22F
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.add_ip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add_ip
            // 
            this.add_ip.Location = new System.Drawing.Point(420, 132);
            this.add_ip.Name = "add_ip";
            this.add_ip.Size = new System.Drawing.Size(166, 40);
            this.add_ip.TabIndex = 0;
            this.add_ip.Text = "Inserisci indirizzo IP";
            this.add_ip.UseVisualStyleBackColor = true;
            this.add_ip.Click += new System.EventHandler(this.add_ip_Click);
            // 
            // Finestra22F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 653);
            this.Controls.Add(this.add_ip);
            this.Name = "Finestra22F";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_ip;
    }
}

