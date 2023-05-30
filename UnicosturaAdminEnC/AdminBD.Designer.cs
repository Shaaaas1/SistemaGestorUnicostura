namespace UnicosturaAdminEnC
{
    partial class AdminBD
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
            this.Btn_AdminTallas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_AdminTallas
            // 
            this.Btn_AdminTallas.Location = new System.Drawing.Point(30, 43);
            this.Btn_AdminTallas.Name = "Btn_AdminTallas";
            this.Btn_AdminTallas.Size = new System.Drawing.Size(227, 100);
            this.Btn_AdminTallas.TabIndex = 0;
            this.Btn_AdminTallas.Text = "Administrar Tallas";
            this.Btn_AdminTallas.UseVisualStyleBackColor = true;
            this.Btn_AdminTallas.Click += new System.EventHandler(this.Btn_AdminTallas_Click);
            // 
            // AdminBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_AdminTallas);
            this.Name = "AdminBD";
            this.Text = "AdminBD";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_AdminTallas;
    }
}