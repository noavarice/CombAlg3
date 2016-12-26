namespace CombAlg3
{
    partial class FormMain
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
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.buttonStartExhaustive = new System.Windows.Forms.Button();
            this.labelExhaustiveResultText = new System.Windows.Forms.Label();
            this.buttonStartGenetic = new System.Windows.Forms.Button();
            this.labelGenericResultText = new System.Windows.Forms.Label();
            this.labelExhaustiveResult = new System.Windows.Forms.Label();
            this.labelGeneticResult = new System.Windows.Forms.Label();
            this.labelStartTownText = new System.Windows.Forms.Label();
            this.numericUpDownStartTown = new System.Windows.Forms.NumericUpDown();
            this.labelExhaustivePathLengthText = new System.Windows.Forms.Label();
            this.labelExhaustivePathLength = new System.Windows.Forms.Label();
            this.labelGeneticPathLengthText = new System.Windows.Forms.Label();
            this.labelGeneticPathLength = new System.Windows.Forms.Label();
            this.labelExhaustiveTotalTimeText = new System.Windows.Forms.Label();
            this.labelExhaustiveTotalTime = new System.Windows.Forms.Label();
            this.labelGeneticTotalTimeText = new System.Windows.Forms.Label();
            this.labelGeneticTotalTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartTown)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.AllowUserToResizeColumns = false;
            this.dataGridViewMain.AllowUserToResizeRows = false;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.ColumnHeadersVisible = false;
            this.dataGridViewMain.Location = new System.Drawing.Point(104, 12);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowHeadersVisible = false;
            this.dataGridViewMain.RowTemplate.Height = 24;
            this.dataGridViewMain.Size = new System.Drawing.Size(324, 296);
            this.dataGridViewMain.TabIndex = 0;
            this.dataGridViewMain.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellValidated);
            this.dataGridViewMain.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewMain_CellValidating);
            this.dataGridViewMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMain_CellValueChanged);
            this.dataGridViewMain.Enter += new System.EventHandler(this.dataGridViewMain_Enter);
            this.dataGridViewMain.Leave += new System.EventHandler(this.dataGridViewMain_Leave);
            this.dataGridViewMain.MouseEnter += new System.EventHandler(this.dataGridViewMain_MouseEnter);
            this.dataGridViewMain.MouseLeave += new System.EventHandler(this.dataGridViewMain_MouseLeave);
            // 
            // buttonStartExhaustive
            // 
            this.buttonStartExhaustive.AutoSize = true;
            this.buttonStartExhaustive.Location = new System.Drawing.Point(76, 347);
            this.buttonStartExhaustive.Name = "buttonStartExhaustive";
            this.buttonStartExhaustive.Size = new System.Drawing.Size(89, 27);
            this.buttonStartExhaustive.TabIndex = 1;
            this.buttonStartExhaustive.Text = "Exhaustive";
            this.buttonStartExhaustive.UseVisualStyleBackColor = true;
            this.buttonStartExhaustive.Click += new System.EventHandler(this.buttonStartExhaustive_Click);
            // 
            // labelExhaustiveResultText
            // 
            this.labelExhaustiveResultText.AutoSize = true;
            this.labelExhaustiveResultText.Location = new System.Drawing.Point(24, 398);
            this.labelExhaustiveResultText.Name = "labelExhaustiveResultText";
            this.labelExhaustiveResultText.Size = new System.Drawing.Size(119, 17);
            this.labelExhaustiveResultText.TabIndex = 2;
            this.labelExhaustiveResultText.Text = "Exhaustive result:";
            // 
            // buttonStartGenetic
            // 
            this.buttonStartGenetic.Location = new System.Drawing.Point(362, 347);
            this.buttonStartGenetic.Name = "buttonStartGenetic";
            this.buttonStartGenetic.Size = new System.Drawing.Size(89, 27);
            this.buttonStartGenetic.TabIndex = 3;
            this.buttonStartGenetic.Text = "Genetic";
            this.buttonStartGenetic.UseVisualStyleBackColor = true;
            this.buttonStartGenetic.Click += new System.EventHandler(this.buttonStartGenetic_Click);
            // 
            // labelGenericResultText
            // 
            this.labelGenericResultText.AutoSize = true;
            this.labelGenericResultText.Location = new System.Drawing.Point(287, 398);
            this.labelGenericResultText.Name = "labelGenericResultText";
            this.labelGenericResultText.Size = new System.Drawing.Size(112, 17);
            this.labelGenericResultText.TabIndex = 4;
            this.labelGenericResultText.Text = "Genetic result:   ";
            // 
            // labelExhaustiveResult
            // 
            this.labelExhaustiveResult.AutoSize = true;
            this.labelExhaustiveResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExhaustiveResult.Location = new System.Drawing.Point(139, 399);
            this.labelExhaustiveResult.Name = "labelExhaustiveResult";
            this.labelExhaustiveResult.Size = new System.Drawing.Size(13, 17);
            this.labelExhaustiveResult.TabIndex = 5;
            this.labelExhaustiveResult.Text = "-";
            // 
            // labelGeneticResult
            // 
            this.labelGeneticResult.AutoSize = true;
            this.labelGeneticResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGeneticResult.Location = new System.Drawing.Point(383, 398);
            this.labelGeneticResult.Name = "labelGeneticResult";
            this.labelGeneticResult.Size = new System.Drawing.Size(13, 17);
            this.labelGeneticResult.TabIndex = 6;
            this.labelGeneticResult.Text = "-";
            // 
            // labelStartTownText
            // 
            this.labelStartTownText.AutoSize = true;
            this.labelStartTownText.Location = new System.Drawing.Point(101, 315);
            this.labelStartTownText.Name = "labelStartTownText";
            this.labelStartTownText.Size = new System.Drawing.Size(75, 17);
            this.labelStartTownText.TabIndex = 7;
            this.labelStartTownText.Text = "Start town:";
            // 
            // numericUpDownStartTown
            // 
            this.numericUpDownStartTown.Location = new System.Drawing.Point(198, 313);
            this.numericUpDownStartTown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownStartTown.Name = "numericUpDownStartTown";
            this.numericUpDownStartTown.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownStartTown.TabIndex = 8;
            // 
            // labelExhaustivePathLengthText
            // 
            this.labelExhaustivePathLengthText.AutoSize = true;
            this.labelExhaustivePathLengthText.Location = new System.Drawing.Point(24, 417);
            this.labelExhaustivePathLengthText.Name = "labelExhaustivePathLengthText";
            this.labelExhaustivePathLengthText.Size = new System.Drawing.Size(84, 17);
            this.labelExhaustivePathLengthText.TabIndex = 9;
            this.labelExhaustivePathLengthText.Text = "Path length:";
            // 
            // labelExhaustivePathLength
            // 
            this.labelExhaustivePathLength.AutoSize = true;
            this.labelExhaustivePathLength.Location = new System.Drawing.Point(115, 416);
            this.labelExhaustivePathLength.Name = "labelExhaustivePathLength";
            this.labelExhaustivePathLength.Size = new System.Drawing.Size(13, 17);
            this.labelExhaustivePathLength.TabIndex = 10;
            this.labelExhaustivePathLength.Text = "-";
            // 
            // labelGeneticPathLengthText
            // 
            this.labelGeneticPathLengthText.AutoSize = true;
            this.labelGeneticPathLengthText.Location = new System.Drawing.Point(287, 416);
            this.labelGeneticPathLengthText.Name = "labelGeneticPathLengthText";
            this.labelGeneticPathLengthText.Size = new System.Drawing.Size(84, 17);
            this.labelGeneticPathLengthText.TabIndex = 11;
            this.labelGeneticPathLengthText.Text = "Path length:";
            // 
            // labelGeneticPathLength
            // 
            this.labelGeneticPathLength.AutoSize = true;
            this.labelGeneticPathLength.Location = new System.Drawing.Point(368, 416);
            this.labelGeneticPathLength.Name = "labelGeneticPathLength";
            this.labelGeneticPathLength.Size = new System.Drawing.Size(13, 17);
            this.labelGeneticPathLength.TabIndex = 12;
            this.labelGeneticPathLength.Text = "-";
            // 
            // labelExhaustiveTotalTimeText
            // 
            this.labelExhaustiveTotalTimeText.AutoSize = true;
            this.labelExhaustiveTotalTimeText.Location = new System.Drawing.Point(24, 438);
            this.labelExhaustiveTotalTimeText.Name = "labelExhaustiveTotalTimeText";
            this.labelExhaustiveTotalTimeText.Size = new System.Drawing.Size(74, 17);
            this.labelExhaustiveTotalTimeText.TabIndex = 13;
            this.labelExhaustiveTotalTimeText.Text = "Total time:";
            // 
            // labelExhaustiveTotalTime
            // 
            this.labelExhaustiveTotalTime.AutoSize = true;
            this.labelExhaustiveTotalTime.Location = new System.Drawing.Point(105, 438);
            this.labelExhaustiveTotalTime.Name = "labelExhaustiveTotalTime";
            this.labelExhaustiveTotalTime.Size = new System.Drawing.Size(13, 17);
            this.labelExhaustiveTotalTime.TabIndex = 14;
            this.labelExhaustiveTotalTime.Text = "-";
            // 
            // labelGeneticTotalTimeText
            // 
            this.labelGeneticTotalTimeText.AutoSize = true;
            this.labelGeneticTotalTimeText.Location = new System.Drawing.Point(287, 438);
            this.labelGeneticTotalTimeText.Name = "labelGeneticTotalTimeText";
            this.labelGeneticTotalTimeText.Size = new System.Drawing.Size(74, 17);
            this.labelGeneticTotalTimeText.TabIndex = 15;
            this.labelGeneticTotalTimeText.Text = "Total time:";
            // 
            // labelGeneticTotalTime
            // 
            this.labelGeneticTotalTime.AutoSize = true;
            this.labelGeneticTotalTime.Location = new System.Drawing.Point(359, 438);
            this.labelGeneticTotalTime.Name = "labelGeneticTotalTime";
            this.labelGeneticTotalTime.Size = new System.Drawing.Size(13, 17);
            this.labelGeneticTotalTime.TabIndex = 16;
            this.labelGeneticTotalTime.Text = "-";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 461);
            this.Controls.Add(this.labelGeneticTotalTime);
            this.Controls.Add(this.labelGeneticTotalTimeText);
            this.Controls.Add(this.labelExhaustiveTotalTime);
            this.Controls.Add(this.labelExhaustiveTotalTimeText);
            this.Controls.Add(this.labelGeneticPathLength);
            this.Controls.Add(this.labelGeneticPathLengthText);
            this.Controls.Add(this.labelExhaustivePathLength);
            this.Controls.Add(this.labelExhaustivePathLengthText);
            this.Controls.Add(this.numericUpDownStartTown);
            this.Controls.Add(this.labelStartTownText);
            this.Controls.Add(this.labelGeneticResult);
            this.Controls.Add(this.labelExhaustiveResult);
            this.Controls.Add(this.labelGenericResultText);
            this.Controls.Add(this.buttonStartGenetic);
            this.Controls.Add(this.labelExhaustiveResultText);
            this.Controls.Add(this.buttonStartExhaustive);
            this.Controls.Add(this.dataGridViewMain);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 465);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trailing Salesman";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartTown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button buttonStartExhaustive;
        private System.Windows.Forms.Label labelExhaustiveResultText;
        private System.Windows.Forms.Button buttonStartGenetic;
        private System.Windows.Forms.Label labelGenericResultText;
        private System.Windows.Forms.Label labelExhaustiveResult;
        private System.Windows.Forms.Label labelGeneticResult;
        private System.Windows.Forms.Label labelStartTownText;
        private System.Windows.Forms.NumericUpDown numericUpDownStartTown;
        private System.Windows.Forms.Label labelExhaustivePathLengthText;
        private System.Windows.Forms.Label labelExhaustivePathLength;
        private System.Windows.Forms.Label labelGeneticPathLengthText;
        private System.Windows.Forms.Label labelGeneticPathLength;
        private System.Windows.Forms.Label labelExhaustiveTotalTimeText;
        private System.Windows.Forms.Label labelExhaustiveTotalTime;
        private System.Windows.Forms.Label labelGeneticTotalTimeText;
        private System.Windows.Forms.Label labelGeneticTotalTime;
    }
}

