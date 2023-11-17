namespace SimpleIterationMethodSolver
{
    public partial class Form1 : Form
    {
        // ErrorProvider ��� ����������� ���������� ��� ������� ����� � ���������� ������
        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // �������� �������� ������� ����� �����������
            if (ValidateInput())
            {
                try
                {
                    // ���������� �������� �������
                    if (TryParseInput(out double initialGuess, out double tolerance, out int maxIterations))
                    {
                        // ������ ������ ������ �������� �� ����������� ����������
                        double result = SimpleIterationMethod(initialGuess, tolerance, maxIterations);
                        DisplayResult(result);
                    }
                }
                catch (Exception ex)
                {
                    // ������� ������� �� ��������� ����������� ��� �������
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            // �������� �������� ������� ����� ����������� ����������
            if (ValidateInput())
            {
                try
                {
                    // ���������� �������� �������
                    if (TryParseInput(out double initialGuess, out double tolerance, out int maxIterations))
                    {
                        // ������ ������ ������ �������� �� ���������� ���������� � ��������� ����
                        double result = SimpleIterationMethod(initialGuess, tolerance, maxIterations);

                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "������� ����� (*.txt)|*.txt|�� ����� (*.*)|*.*",
                            Title = "�������� ���������� � ����",
                            DefaultExt = "txt"
                        };

                        // ����� ���������� ���� ��� ������ ����� ��� ���������� ����������
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string outputFilePath = saveFileDialog.FileName;

                            // ���������� ���������� �� ��������� ����������� ��� ����
                            SaveResultsToFile(outputFilePath, initialGuess, tolerance, maxIterations, result);
                            DisplayResult(result);
                            ShowSuccessMessage("���������� ������ ���������");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // ������� ������� �� ��������� ����������� ��� �������
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // ��������� ���������� � �������� ����
        private void DisplayResult(double result) => txtResult.Text = $"{result:F6}";

        // ��������� ����������� ��� ������� � �������� ����
        private void ShowErrorMessage(string message) => MessageBox.Show($"�������: {message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // ��������� ����������� ��� ���� � �������� ����
        private void ShowSuccessMessage(string message) => MessageBox.Show(message, "����", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // �������� �������� ������� ����� ����������� ��� ����������� ����������
        private bool ValidateInput()
        {
            return ValidateDoubleInput(txtInitialGuess, "��������� ����������") &&
                   ValidateDoubleInput(txtTolerance, "�������") &&
                   ValidateIntInput(txtMaxIterations, "����. ������� ��������");
        }

        // �������� ��������� �������� ���� double
        private bool ValidateDoubleInput(TextBox textBox, string fieldName)
        {
            if (!double.TryParse(textBox.Text, out _))
            {
                // ������������ ������� �� ��������� ����������� ��� �������
                SetErrorAndReturnFalse(textBox, $"{fieldName} ������� ���� ������.");
            }

            return true;
        }

        // �������� ��������� �������� ���� int
        private bool ValidateIntInput(TextBox textBox, string fieldName)
        {
            if (!int.TryParse(textBox.Text, out _))
            {
                // ������������ ������� �� ��������� ����������� ��� �������
                SetErrorAndReturnFalse(textBox, $"{fieldName} ������� ���� ����� ������.");
            }

            return true;
        }

        // ������������ ������� �� ��������� ����������� ��� �������
        private void SetErrorAndReturnFalse(TextBox textBox, string errorMessage)
        {
            errorProvider.SetError(textBox, errorMessage);
            ShowErrorMessage(errorMessage);
        }

        // ���������� �������� ������� � ��������� ����
        private bool TryParseInput(out double initialGuess, out double tolerance, out int maxIterations)
        {
            initialGuess = tolerance = 0.0;
            maxIterations = 0;

            // ���������� �� �������� �������� �������
            if (!double.TryParse(txtInitialGuess.Text, out initialGuess) ||
                !double.TryParse(txtTolerance.Text, out tolerance) ||
                !int.TryParse(txtMaxIterations.Text, out maxIterations))
            {
                // ��������� ����������� ��� �������
                ShowErrorMessage("������� ��� ��������� �������� �������.");
                return false;
            }

            return true;
        }

        // ����� ������ ��������
        private double SimpleIterationMethod(double initialGuess, double tolerance, int maxIterations)
        {
            double x0 = initialGuess;
            int iteration = 0;

            // ��������� �������� �� ���������� ����������� ������� ��� ��������� �������
            while (iteration < maxIterations)
            {
                double x1 = Function(x0);
                double error = Math.Abs(x1 - x0);

                // �������� �� ���������� ��������� �������
                if (error < tolerance)
                {
                    return x1;
                }

                x0 = x1;
                iteration++;
            }

            // �������, ���� ����� �� ����� �� ������ �� �������� ������� ��������
            throw new InvalidOperationException("����� �� ����� �� ������ �� �������� ������� ��������.");
        }

        // �������, ��� ����������� ����� ������ ��������
        private double Function(double x)
        {
            return Math.Pow(x, 3) - 1.2 * x + 1;
        }

        // ���������� ���������� � ��������� ����
        private void SaveResultsToFile(string filePath, double initialGuess, double tolerance, int maxIterations, double result)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // ����� ��������� ��������
                writer.WriteLine("��������� ��������:");
                writer.WriteLine($"��������� ����������: {initialGuess}");
                writer.WriteLine($"������ �������: {tolerance}");
                writer.WriteLine($"����������� ������� ��������: {maxIterations}");
                writer.WriteLine();

                // ����� ������� �� ����������
                writer.WriteLine("������� �� ���������:");
                writer.WriteLine("�������: x^3 - 1.2x + 1");
                writer.WriteLine($"����'������: {result:F6}");
            }
        }

        // ������� ��䳿 ������������ �����
        private void Form1_Load(object sender, EventArgs e) => txtFunction.Text = $"x^3 - 1.2x + 1";
    }
}
