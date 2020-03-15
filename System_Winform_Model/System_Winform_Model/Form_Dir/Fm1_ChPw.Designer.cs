namespace System_Winform_Model.Form_Dir
{
    partial class Fm1_ChPw
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
            this.btn_ChPw = new System.Windows.Forms.Button();
            this.PassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ChPw
            // 
            this.btn_ChPw.Location = new System.Drawing.Point(108, 141);
            this.btn_ChPw.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ChPw.Name = "btn_ChPw";
            this.btn_ChPw.Size = new System.Drawing.Size(103, 38);
            this.btn_ChPw.TabIndex = 69;
            this.btn_ChPw.Text = "修改";
            this.btn_ChPw.UseVisualStyleBackColor = true;
            this.btn_ChPw.Click += new System.EventHandler(this.btn_ChPw_Click);
            // 
            // PassWord
            // 
            this.PassWord.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PassWord.Location = new System.Drawing.Point(108, 93);
            this.PassWord.Margin = new System.Windows.Forms.Padding(4);
            this.PassWord.MaxLength = 20;
            this.PassWord.Name = "PassWord";
            this.PassWord.PasswordChar = '*';
            this.PassWord.Size = new System.Drawing.Size(101, 25);
            this.PassWord.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 67;
            this.label3.Text = "密碼";
            // 
            // Fm1_ChPw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 273);
            this.Controls.Add(this.btn_ChPw);
            this.Controls.Add(this.PassWord);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Fm1_ChPw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "變更密碼";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ChPw;
        private System.Windows.Forms.TextBox PassWord;
        private System.Windows.Forms.Label label3;
    }
}