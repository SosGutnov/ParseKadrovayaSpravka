
namespace ParseKadrovayaSpravka
{
    partial class FormSelectionFile
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
            this.buttonSFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSFile
            // 
            this.buttonSFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSFile.Location = new System.Drawing.Point(137, 141);
            this.buttonSFile.Name = "buttonSFile";
            this.buttonSFile.Size = new System.Drawing.Size(177, 50);
            this.buttonSFile.TabIndex = 1;
            this.buttonSFile.Text = "Выбрать файл";
            this.buttonSFile.UseVisualStyleBackColor = true;
            this.buttonSFile.Click += new System.EventHandler(this.buttonSFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Пожалуйста выберите файл нагрузок";
            // 
            // FormSelectionFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 232);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSFile);
            this.Name = "FormSelectionFile";
            this.Text = "Выбор файла";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button buttonSFile;
        private System.Windows.Forms.Label label1;
    }
}