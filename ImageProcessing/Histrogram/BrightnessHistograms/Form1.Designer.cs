namespace BrightnessHistograms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.defaultImage = new System.Windows.Forms.PictureBox();
            this.enchancedImage = new System.Windows.Forms.PictureBox();
            this.enchancedHisto = new System.Windows.Forms.PictureBox();
            this.defaultHisto = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.defaultImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enchancedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enchancedHisto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultHisto)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultImage
            // 
            this.defaultImage.Location = new System.Drawing.Point(12, 25);
            this.defaultImage.Name = "defaultImage";
            this.defaultImage.Size = new System.Drawing.Size(500, 375);
            this.defaultImage.TabIndex = 0;
            this.defaultImage.TabStop = false;
            // 
            // enchancedImage
            // 
            this.enchancedImage.Location = new System.Drawing.Point(518, 25);
            this.enchancedImage.Name = "enchancedImage";
            this.enchancedImage.Size = new System.Drawing.Size(500, 375);
            this.enchancedImage.TabIndex = 1;
            this.enchancedImage.TabStop = false;
            // 
            // enchancedHisto
            // 
            this.enchancedHisto.Location = new System.Drawing.Point(518, 406);
            this.enchancedHisto.Name = "enchancedHisto";
            this.enchancedHisto.Size = new System.Drawing.Size(400, 443);
            this.enchancedHisto.TabIndex = 3;
            this.enchancedHisto.TabStop = false;
            // 
            // defaultHisto
            // 
            this.defaultHisto.Location = new System.Drawing.Point(12, 406);
            this.defaultHisto.Name = "defaultHisto";
            this.defaultHisto.Size = new System.Drawing.Size(400, 443);
            this.defaultHisto.TabIndex = 2;
            this.defaultHisto.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(1122, 25);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Enchance";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.enchancedHisto);
            this.Controls.Add(this.defaultHisto);
            this.Controls.Add(this.enchancedImage);
            this.Controls.Add(this.defaultImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.defaultImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enchancedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enchancedHisto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultHisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        public System.Windows.Forms.PictureBox defaultImage;
        public System.Windows.Forms.PictureBox enchancedImage;
        public System.Windows.Forms.PictureBox enchancedHisto;
        public System.Windows.Forms.PictureBox defaultHisto;
    }
}

