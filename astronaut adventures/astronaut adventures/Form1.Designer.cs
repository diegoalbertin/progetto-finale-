
namespace astronaut_adventures
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.partitaVelocebtn = new System.Windows.Forms.Button();
            this.aiutobtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.accedioregistrati = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mostraClassifica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // partitaVelocebtn
            // 
            this.partitaVelocebtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.partitaVelocebtn.Location = new System.Drawing.Point(332, 130);
            this.partitaVelocebtn.Name = "partitaVelocebtn";
            this.partitaVelocebtn.Size = new System.Drawing.Size(178, 24);
            this.partitaVelocebtn.TabIndex = 0;
            this.partitaVelocebtn.Text = "partita veloce";
            this.partitaVelocebtn.UseVisualStyleBackColor = true;
            this.partitaVelocebtn.Click += new System.EventHandler(this.partitaVelocebtn_Click);
            // 
            // aiutobtn
            // 
            this.aiutobtn.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aiutobtn.Location = new System.Drawing.Point(332, 290);
            this.aiutobtn.Name = "aiutobtn";
            this.aiutobtn.Size = new System.Drawing.Size(178, 23);
            this.aiutobtn.TabIndex = 3;
            this.aiutobtn.Text = "aiuto";
            this.aiutobtn.UseVisualStyleBackColor = true;
            this.aiutobtn.Click += new System.EventHandler(this.aiutobtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(250, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "atronaut adventures";
            // 
            // accedioregistrati
            // 
            this.accedioregistrati.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accedioregistrati.Location = new System.Drawing.Point(332, 210);
            this.accedioregistrati.Name = "accedioregistrati";
            this.accedioregistrati.Size = new System.Drawing.Size(178, 23);
            this.accedioregistrati.TabIndex = 6;
            this.accedioregistrati.Text = "accedi o registrati";
            this.accedioregistrati.UseVisualStyleBackColor = true;
            this.accedioregistrati.Click += new System.EventHandler(this.accedioregistrati_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(314, 116);
            this.dataGridView1.TabIndex = 7;
            // 
            // mostraClassifica
            // 
            this.mostraClassifica.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mostraClassifica.Location = new System.Drawing.Point(332, 370);
            this.mostraClassifica.Name = "mostraClassifica";
            this.mostraClassifica.Size = new System.Drawing.Size(178, 23);
            this.mostraClassifica.TabIndex = 3;
            this.mostraClassifica.Text = "mostra classifica";
            this.mostraClassifica.UseVisualStyleBackColor = true;
            this.mostraClassifica.Click += new System.EventHandler(this.mostraClassifica_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::astronaut_adventures.Properties.Resources.sfondo_home;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mostraClassifica);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.accedioregistrati);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aiutobtn);
            this.Controls.Add(this.partitaVelocebtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(816, 488);
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button partitaVelocebtn;
        private System.Windows.Forms.Button aiutobtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button accedioregistrati;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button mostraClassifica;
    }
}

