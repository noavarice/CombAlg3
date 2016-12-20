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
            this.labelExhaustiveResult = new System.Windows.Forms.Label();
            this.labelGeneticResult = new System.Windows.Forms.Label();
            this.labelStartTownText = new System.Windows.Forms.Label();
            this.numericUpDownStartTown = new System.Windows.Forms.NumericUpDown();
            this.labelExecutionTime = new System.Windows.Forms.Label();
            this.labelExhaustiveExecutionTime = new System.Windows.Forms.Label();
            this.labelGeneticExecutionTime = new System.Windows.Forms.Label();
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
            this.dataGridViewMain.Location = new System.Drawing.Point(36, 12);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowHeadersVisible = false;
            this.dataGridViewMain.RowTemplate.Height = 24;
            this.dataGridViewMain.Size = new System.Drawing.Size(324, 306);
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
            this.buttonStartExhaustive.Location = new System.Drawing.Point(60, 370);
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
            this.labelExhaustiveResultText.Location = new System.Drawing.Point(-1, 399);
            this.labelExhaustiveResultText.Name = "labelExhaustiveResultText";
            this.labelExhaustiveResultText.Size = new System.Drawing.Size(52, 17);
            this.labelExhaustiveResultText.TabIndex = 2;
            this.labelExhaustiveResultText.Text = "Result:";
            // 
            // buttonStartGenetic
            // 
            this.buttonStartGenetic.Location = new System.Drawing.Point(252, 370);
            this.buttonStartGenetic.Name = "buttonStartGenetic";
            this.buttonStartGenetic.Size = new System.Drawing.Size(89, 27);
            this.buttonStartGenetic.TabIndex = 3;
            this.buttonStartGenetic.Text = "Genetic";
            this.buttonStartGenetic.UseVisualStyleBackColor = true;
            this.buttonStartGenetic.Click += new System.EventHandler(this.buttonStartGenetic_Click);
            // 
            // labelExhaustiveResult
            // 
            this.labelExhaustiveResult.AutoSize = true;
            this.labelExhaustiveResult.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExhaustiveResult.Location = new System.Drawing.Point(57, 400);
            this.labelExhaustiveResult.Name = "labelExhaustiveResult";
            this.labelExhaustiveResult.Size = new System.Drawing.Size(16, 17);
            this.labelExhaustiveResult.TabIndex = 5;
            this.labelExhaustiveResult.Text = "-";
            // 
            // labelGeneticResult
            // 
            this.labelGeneticResult.AutoSize = true;
            this.labelGeneticResult.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGeneticResult.Location = new System.Drawing.Point(251, 400);
            this.labelGeneticResult.Name = "labelGeneticResult";
            this.labelGeneticResult.Size = new System.Drawing.Size(16, 17);
            this.labelGeneticResult.TabIndex = 6;
            this.labelGeneticResult.Text = "-";
            // 
            // labelStartTownText
            // 
            this.labelStartTownText.AutoSize = true;
            this.labelStartTownText.Location = new System.Drawing.Point(33, 321);
            this.labelStartTownText.Name = "labelStartTownText";
            this.labelStartTownText.Size = new System.Drawing.Size(75, 17);
            this.labelStartTownText.TabIndex = 7;
            this.labelStartTownText.Text = "Start town:";
            // 
            // numericUpDownStartTown
            // 
            this.numericUpDownStartTown.Location = new System.Drawing.Point(130, 319);
            this.numericUpDownStartTown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownStartTown.Name = "numericUpDownStartTown";
            this.numericUpDownStartTown.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownStartTown.TabIndex = 8;
            // 
            // labelExecutionTime
            // 
            this.labelExecutionTime.AutoSize = true;
            this.labelExecutionTime.Location = new System.Drawing.Point(-1, 427);
            this.labelExecutionTime.Name = "labelExecutionTime";
            this.labelExecutionTime.Size = new System.Drawing.Size(43, 17);
            this.labelExecutionTime.TabIndex = 9;
            this.labelExecutionTime.Text = "Time:";
            // 
            // labelExhaustiveExecutionTime
            // 
            this.labelExhaustiveExecutionTime.AutoSize = true;
            this.labelExhaustiveExecutionTime.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExhaustiveExecutionTime.Location = new System.Drawing.Point(57, 427);
            this.labelExhaustiveExecutionTime.Name = "labelExhaustiveExecutionTime";
            this.labelExhaustiveExecutionTime.Size = new System.Drawing.Size(16, 17);
            this.labelExhaustiveExecutionTime.TabIndex = 10;
            this.labelExhaustiveExecutionTime.Text = "-";
            // 
            // labelGeneticExecutionTime
            // 
            this.labelGeneticExecutionTime.AutoSize = true;
            this.labelGeneticExecutionTime.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGeneticExecutionTime.Location = new System.Drawing.Point(251, 427);
            this.labelGeneticExecutionTime.Name = "labelGeneticExecutionTime";
            this.labelGeneticExecutionTime.Size = new System.Drawing.Size(16, 17);
            this.labelGeneticExecutionTime.TabIndex = 11;
            this.labelGeneticExecutionTime.Text = "-";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 465);
            this.Controls.Add(this.labelGeneticExecutionTime);
            this.Controls.Add(this.labelExhaustiveExecutionTime);
            this.Controls.Add(this.labelExecutionTime);
            this.Controls.Add(this.numericUpDownStartTown);
            this.Controls.Add(this.labelStartTownText);
            this.Controls.Add(this.labelGeneticResult);
            this.Controls.Add(this.labelExhaustiveResult);
            this.Controls.Add(this.buttonStartGenetic);
            this.Controls.Add(this.labelExhaustiveResultText);
            this.Controls.Add(this.buttonStartExhaustive);
            this.Controls.Add(this.dataGridViewMain);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Label labelExhaustiveResult;
        private System.Windows.Forms.Label labelGeneticResult;
        private System.Windows.Forms.Label labelStartTownText;
        private System.Windows.Forms.NumericUpDown numericUpDownStartTown;
        private System.Windows.Forms.Label labelExecutionTime;
        private System.Windows.Forms.Label labelExhaustiveExecutionTime;
        private System.Windows.Forms.Label labelGeneticExecutionTime;
    }
}

