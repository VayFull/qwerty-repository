namespace VisualFOrms
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.padj = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.TextBox();
            this.chat = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // padj
            // 
            this.padj.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.padj.Location = new System.Drawing.Point(0, 505);
            this.padj.Name = "padj";
            this.padj.Size = new System.Drawing.Size(779, 39);
            this.padj.TabIndex = 1;
            this.padj.Text = "Отправить";
            this.padj.UseVisualStyleBackColor = true;
            this.padj.Click += new System.EventHandler(this.button2_Click);
            // 
            // name
            // 
            this.name.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(129, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(650, 27);
            this.name.TabIndex = 2;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // message
            // 
            this.message.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.message.Location = new System.Drawing.Point(129, 3);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(650, 27);
            this.message.TabIndex = 3;
            this.message.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // chat
            // 
            this.chat.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom) |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.chat.Location = new System.Drawing.Point(12, 12);
            this.chat.Multiline = true;
            this.chat.Name = "chat";
            this.chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chat.Size = new System.Drawing.Size(755, 420);
            this.chat.TabIndex = 4;
            this.chat.Text = "Чат:";
            this.chat.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chat);
            this.panel1.Controls.Add(this.padj);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 544);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.name);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 471);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 34);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.message);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 438);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(779, 33);
            this.panel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Пользователь";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сообщение";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(779, 544);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button padj;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.TextBox chat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

