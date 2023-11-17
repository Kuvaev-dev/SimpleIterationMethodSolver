namespace SimpleIterationMethodSolver
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
            label1 = new Label();
            txtInitialGuess = new TextBox();
            label2 = new Label();
            txtTolerance = new TextBox();
            txtMaxIterations = new TextBox();
            label3 = new Label();
            btnCalculate = new Button();
            btnSaveResults = new Button();
            label4 = new Label();
            txtFunction = new TextBox();
            label5 = new Label();
            txtResult = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 101);
            label1.Name = "label1";
            label1.Size = new Size(181, 15);
            label1.TabIndex = 0;
            label1.Text = "Введіть початкове наближення:";
            // 
            // txtInitialGuess
            // 
            txtInitialGuess.Location = new Point(64, 119);
            txtInitialGuess.Name = "txtInitialGuess";
            txtInitialGuess.Size = new Size(341, 23);
            txtInitialGuess.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 163);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 2;
            label2.Text = "Введіть точність:";
            // 
            // txtTolerance
            // 
            txtTolerance.Location = new Point(64, 181);
            txtTolerance.Name = "txtTolerance";
            txtTolerance.Size = new Size(341, 23);
            txtTolerance.TabIndex = 3;
            // 
            // txtMaxIterations
            // 
            txtMaxIterations.Location = new Point(64, 246);
            txtMaxIterations.Name = "txtMaxIterations";
            txtMaxIterations.Size = new Size(341, 23);
            txtMaxIterations.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 228);
            label3.Name = "label3";
            label3.Size = new Size(225, 15);
            label3.TabIndex = 4;
            label3.Text = "Введіть максимальну кількість ітерацій:";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(255, 363);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 23);
            btnCalculate.TabIndex = 6;
            btnCalculate.Text = "Розрахувати";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnSaveResults
            // 
            btnSaveResults.Location = new Point(64, 363);
            btnSaveResults.Name = "btnSaveResults";
            btnSaveResults.Size = new Size(150, 23);
            btnSaveResults.TabIndex = 7;
            btnSaveResults.Text = "Зберегти результати";
            btnSaveResults.UseVisualStyleBackColor = true;
            btnSaveResults.Click += btnSaveResults_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 289);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 9;
            label4.Text = "Результати:";
            // 
            // txtFunction
            // 
            txtFunction.Location = new Point(64, 60);
            txtFunction.Name = "txtFunction";
            txtFunction.ReadOnly = true;
            txtFunction.Size = new Size(341, 23);
            txtFunction.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 42);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 10;
            label5.Text = "Функція:";
            // 
            // txtResult
            // 
            txtResult.Location = new Point(64, 307);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(341, 23);
            txtResult.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(473, 444);
            Controls.Add(txtResult);
            Controls.Add(txtFunction);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnSaveResults);
            Controls.Add(btnCalculate);
            Controls.Add(txtMaxIterations);
            Controls.Add(label3);
            Controls.Add(txtTolerance);
            Controls.Add(label2);
            Controls.Add(txtInitialGuess);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(489, 483);
            MinimumSize = new Size(489, 483);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Метод простої ітерації";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtInitialGuess;
        private Label label2;
        private TextBox txtTolerance;
        private TextBox txtMaxIterations;
        private Label label3;
        private Button btnCalculate;
        private Button btnSaveResults;
        private Label label4;
        private TextBox txtFunction;
        private Label label5;
        private TextBox txtResult;
    }
}