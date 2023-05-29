namespace SquarePuzzleGame
{
    partial class Login
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
            this.btnGozAt = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblError = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHightPoint = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGozAt
            // 
            this.btnGozAt.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGozAt.FlatAppearance.BorderSize = 2;
            this.btnGozAt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGozAt.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.btnGozAt.Location = new System.Drawing.Point(32, 22);
            this.btnGozAt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGozAt.Name = "btnGozAt";
            this.btnGozAt.Size = new System.Drawing.Size(232, 94);
            this.btnGozAt.TabIndex = 18;
            this.btnGozAt.Text = "Resmi Seç";
            this.btnGozAt.UseVisualStyleBackColor = true;
            this.btnGozAt.Click += new System.EventHandler(this.btnGozAt_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(32, 223);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(232, 94);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "Başla";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(35, 340);
            this.lblError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(82, 26);
            this.lblError.TabIndex = 20;
            this.lblError.Text = "lblError";
            this.lblError.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.lblPoint, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHightPoint, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(54, 121);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(191, 54);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // lblHightPoint
            // 
            this.lblHightPoint.AutoSize = true;
            this.lblHightPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHightPoint.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHightPoint.Location = new System.Drawing.Point(2, 0);
            this.lblHightPoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHightPoint.Name = "lblHightPoint";
            this.lblHightPoint.Size = new System.Drawing.Size(187, 34);
            this.lblHightPoint.TabIndex = 0;
            this.lblHightPoint.Text = "En Yüksek Skor";
            this.lblHightPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(189, 188);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.MaxLength = 15;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(76, 20);
            this.txtName.TabIndex = 22;
            this.txtName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "İsminiz (İsteğe Bağlı):";
            this.label1.Visible = false;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPoint.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.Location = new System.Drawing.Point(2, 34);
            this.lblPoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(187, 20);
            this.lblPoint.TabIndex = 2;
            this.lblPoint.Text = "0";
            this.lblPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(298, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnGozAt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kare Puzzle Oyunu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGozAt;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHightPoint;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPoint;
    }
}