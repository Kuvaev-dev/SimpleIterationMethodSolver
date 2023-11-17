namespace SimpleIterationMethodSolver
{
    public partial class Form1 : Form
    {
        // ErrorProvider для відображення повідомлень про помилки поруч з текстовими полями
        private readonly ErrorProvider errorProvider = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Перевірка введених значень перед обчисленням
            if (ValidateInput())
            {
                try
                {
                    // Зчитування введених значень
                    if (TryParseInput(out double initialGuess, out double tolerance, out int maxIterations))
                    {
                        // Виклик методу простої ітерації та відображення результату
                        double result = SimpleIterationMethod(initialGuess, tolerance, maxIterations);
                        DisplayResult(result);
                    }
                }
                catch (Exception ex)
                {
                    // Обробка винятку та виведення повідомлення про помилку
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            // Перевірка введених значень перед збереженням результатів
            if (ValidateInput())
            {
                try
                {
                    // Зчитування введених значень
                    if (TryParseInput(out double initialGuess, out double tolerance, out int maxIterations))
                    {
                        // Виклик методу простої ітерації та збереження результатів у текстовий файл
                        double result = SimpleIterationMethod(initialGuess, tolerance, maxIterations);

                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "Текстові файли (*.txt)|*.txt|Всі файли (*.*)|*.*",
                            Title = "Зберегти результати у файл",
                            DefaultExt = "txt"
                        };

                        // Показ діалогового вікна для вибору файлу для збереження результатів
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string outputFilePath = saveFileDialog.FileName;

                            // Збереження результатів та виведення повідомлення про успіх
                            SaveResultsToFile(outputFilePath, initialGuess, tolerance, maxIterations, result);
                            DisplayResult(result);
                            ShowSuccessMessage("Результати успішно збережено");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обробка винятку та виведення повідомлення про помилку
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        // Виведення результату у текстове поле
        private void DisplayResult(double result) => txtResult.Text = $"{result:F6}";

        // Виведення повідомлення про помилку у діалогове вікно
        private void ShowErrorMessage(string message) => MessageBox.Show($"Помилка: {message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // Виведення повідомлення про успіх у діалогове вікно
        private void ShowSuccessMessage(string message) => MessageBox.Show(message, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Валідація введених значень перед обчисленням або збереженням результатів
        private bool ValidateInput()
        {
            return ValidateDoubleInput(txtInitialGuess, "Початкове наближення") &&
                   ValidateDoubleInput(txtTolerance, "Точність") &&
                   ValidateIntInput(txtMaxIterations, "Макс. кількість ітерацій");
        }

        // Валідація введеного значення типу double
        private bool ValidateDoubleInput(TextBox textBox, string fieldName)
        {
            if (!double.TryParse(textBox.Text, out _))
            {
                // Встановлення помилки та виведення повідомлення про помилку
                SetErrorAndReturnFalse(textBox, $"{fieldName} повинно бути числом.");
            }

            return true;
        }

        // Валідація введеного значення типу int
        private bool ValidateIntInput(TextBox textBox, string fieldName)
        {
            if (!int.TryParse(textBox.Text, out _))
            {
                // Встановлення помилки та виведення повідомлення про помилку
                SetErrorAndReturnFalse(textBox, $"{fieldName} повинно бути цілим числом.");
            }

            return true;
        }

        // Встановлення помилки та виведення повідомлення про помилку
        private void SetErrorAndReturnFalse(TextBox textBox, string errorMessage)
        {
            errorProvider.SetError(textBox, errorMessage);
            ShowErrorMessage(errorMessage);
        }

        // Зчитування введених значень з текстових полів
        private bool TryParseInput(out double initialGuess, out double tolerance, out int maxIterations)
        {
            initialGuess = tolerance = 0.0;
            maxIterations = 0;

            // Зчитування та перевірка введених значень
            if (!double.TryParse(txtInitialGuess.Text, out initialGuess) ||
                !double.TryParse(txtTolerance.Text, out tolerance) ||
                !int.TryParse(txtMaxIterations.Text, out maxIterations))
            {
                // Виведення повідомлення про помилку
                ShowErrorMessage("Помилка при зчитуванні введених значень.");
                return false;
            }

            return true;
        }

        // Метод простої ітерації
        private double SimpleIterationMethod(double initialGuess, double tolerance, int maxIterations)
        {
            double x0 = initialGuess;
            int iteration = 0;

            // Виконання ітерацій до досягнення максимальної кількості або необхідної точності
            while (iteration < maxIterations)
            {
                double x1 = Function(x0);
                double error = Math.Abs(x1 - x0);

                // Перевірка на досягнення необхідної точності
                if (error < tolerance)
                {
                    return x1;
                }

                x0 = x1;
                iteration++;
            }

            // Виняток, якщо метод не зійшов до рішення за вказаною кількістю ітерацій
            throw new InvalidOperationException("Метод не зійшов до рішення за вказаною кількістю ітерацій.");
        }

        // Функція, яку використовує метод простої ітерації
        private double Function(double x)
        {
            return Math.Pow(x, 3) - 1.2 * x + 1;
        }

        // Збереження результатів у текстовий файл
        private void SaveResultsToFile(string filePath, double initialGuess, double tolerance, int maxIterations, double result)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Запис параметрів ітерації
                writer.WriteLine("Параметри ітерації:");
                writer.WriteLine($"Початкове наближення: {initialGuess}");
                writer.WriteLine($"Бажана точність: {tolerance}");
                writer.WriteLine($"Максимальна кількість ітерацій: {maxIterations}");
                writer.WriteLine();

                // Запис функції та результату
                writer.WriteLine("Функція та результат:");
                writer.WriteLine("Функція: x^3 - 1.2x + 1");
                writer.WriteLine($"Розв'язання: {result:F6}");
            }
        }

        // Обробка події завантаження форми
        private void Form1_Load(object sender, EventArgs e) => txtFunction.Text = $"x^3 - 1.2x + 1";
    }
}
