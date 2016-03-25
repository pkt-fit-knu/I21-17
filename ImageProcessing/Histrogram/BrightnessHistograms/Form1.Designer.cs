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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.defaultImage = new System.Windows.Forms.PictureBox();
            this.enchancedImage = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.ChartOriginal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartEnchanced = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.defaultImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enchancedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEnchanced)).BeginInit();
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
            // ChartOriginal
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartOriginal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartOriginal.Legends.Add(legend1);
            this.ChartOriginal.Location = new System.Drawing.Point(12, 406);
            this.ChartOriginal.Name = "ChartOriginal";
            this.ChartOriginal.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Brightness";
            this.ChartOriginal.Series.Add(series1);
            this.ChartOriginal.Size = new System.Drawing.Size(500, 443);
            this.ChartOriginal.TabIndex = 5;
            // 
            // ChartEnchanced
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartEnchanced.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartEnchanced.Legends.Add(legend2);
            this.ChartEnchanced.Location = new System.Drawing.Point(518, 406);
            this.ChartEnchanced.Name = "ChartEnchanced";
            this.ChartEnchanced.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Brightness";
            this.ChartEnchanced.Series.Add(series2);
            this.ChartEnchanced.Size = new System.Drawing.Size(500, 443);
            this.ChartEnchanced.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.ChartEnchanced);
            this.Controls.Add(this.ChartOriginal);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.enchancedImage);
            this.Controls.Add(this.defaultImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.defaultImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enchancedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEnchanced)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        public System.Windows.Forms.PictureBox defaultImage;
        public System.Windows.Forms.PictureBox enchancedImage;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartOriginal;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartEnchanced;
    }
}

