
namespace astronaut_adventures
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.eseguiRegistrati = new System.Windows.Forms.Button();
            this.eseguiAccesso = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.partita = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
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
            this.label1.TabIndex = 5;
            this.label1.Text = "atronaut adventures";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(266, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "  username";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(266, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = " password";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(411, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(411, 192);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 26);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::astronaut_adventures.Properties.Resources.freccia;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eseguiRegistrati
            // 
            this.eseguiRegistrati.BackColor = System.Drawing.Color.White;
            this.eseguiRegistrati.Location = new System.Drawing.Point(267, 273);
            this.eseguiRegistrati.Name = "eseguiRegistrati";
            this.eseguiRegistrati.Size = new System.Drawing.Size(110, 29);
            this.eseguiRegistrati.TabIndex = 11;
            this.eseguiRegistrati.Text = "registrati";
            this.eseguiRegistrati.UseVisualStyleBackColor = false;
            this.eseguiRegistrati.Click += new System.EventHandler(this.eseguiRegistrati_Click);
            // 
            // eseguiAccesso
            // 
            this.eseguiAccesso.BackColor = System.Drawing.Color.White;
            this.eseguiAccesso.Location = new System.Drawing.Point(426, 271);
            this.eseguiAccesso.Name = "eseguiAccesso";
            this.eseguiAccesso.Size = new System.Drawing.Size(110, 29);
            this.eseguiAccesso.TabIndex = 12;
            this.eseguiAccesso.Text = "accedi";
            this.eseguiAccesso.UseVisualStyleBackColor = false;
            this.eseguiAccesso.Click += new System.EventHandler(this.eseguiAccesso_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(350, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 13;
            // 
            // partita
            // 
            this.partita.BackColor = System.Drawing.Color.Gray;
            this.partita.Location = new System.Drawing.Point(411, 340);
            this.partita.Name = "partita";
            this.partita.Size = new System.Drawing.Size(162, 29);
            this.partita.TabIndex = 14;
            this.partita.Text = "vai al gioco";
            this.partita.UseVisualStyleBackColor = false;
            this.partita.Click += new System.EventHandler(this.partita_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.Maroon;
            this.logout.Location = new System.Drawing.Point(230, 340);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(162, 29);
            this.logout.TabIndex = 15;
            this.logout.Text = "logout";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::astronaut_adventures.Properties.Resources.sfondo_form2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.partita);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eseguiAccesso);
            this.Controls.Add(this.eseguiRegistrati);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button eseguiRegistrati;
        private System.Windows.Forms.Button eseguiAccesso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button partita;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Timer timer;
    }
}