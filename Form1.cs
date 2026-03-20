using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proj7
{
    public partial class Form1 : Form
    {
        private int buttonCount = 0;
        private int labelCount = 0;
        private int textBoxCount = 0;

        private Button originalButton;
        private Label originalLabel;
        private TextBox originalTextBox;
        private Label counterLabel;

        public Form1()
        {
            InitializeComponent();

            CreateOriginalElements();
            UpdateCounter();
        }

        private void CreateOriginalElements()
        {
            originalButton = new Button();
            originalButton.Text = "Кнопка";
            originalButton.Size = new Size(100, 30);
            originalButton.Location = new Point(50, 50);
            originalButton.Click += OriginalElement_Click;
            Controls.Add(originalButton);

            originalLabel = new Label();
            originalLabel.Text = "Метка";
            originalLabel.AutoSize = true;
            originalLabel.Location = new Point(50, 100);
            originalLabel.Click += OriginalElement_Click;
            Controls.Add(originalLabel);

            originalTextBox = new TextBox();
            originalTextBox.Text = "Поле ввода";
            originalTextBox.Size = new Size(150, 20);
            originalTextBox.Location = new Point(50, 130);
            originalTextBox.Click += OriginalElement_Click;
            Controls.Add(originalTextBox);

            counterLabel = new Label();
            counterLabel.AutoSize = true;
            counterLabel.Location = new Point(50, 170);
            counterLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            Controls.Add(counterLabel);
        }

        private void OriginalElement_Click(object sender, EventArgs e)
        {
            Point randomLocation = GetRandomLocation();

            if (sender is Button)
            {
                CreateNewButton(randomLocation);
            }
            else if (sender is Label)
            {
                CreateNewLabel(randomLocation);
            }
            else if (sender is TextBox)
            {
                CreateNewTextBox(randomLocation);
            }

            UpdateCounter();
        }

        private void CreateNewButton(Point location)
        {
            Button newButton = new Button();
            buttonCount++;
            newButton.Text = $"Кнопка {buttonCount}";
            newButton.Size = originalButton.Size;
            newButton.Location = location;
            Controls.Add(newButton);
        }

        private void CreateNewLabel(Point location)
        {
            Label newLabel = new Label();
            labelCount++;
            newLabel.Text = $"Метка {labelCount}";
            newLabel.AutoSize = true;
            newLabel.Location = location;
            Controls.Add(newLabel);
        }

        private void CreateNewTextBox(Point location)
        {
            TextBox newTextBox = new TextBox();
            textBoxCount++;
            newTextBox.Text = $"Поле {textBoxCount}";
            newTextBox.Size = originalTextBox.Size;
            newTextBox.Location = location;
            Controls.Add(newTextBox);
        }

        private Point GetRandomLocation()
        {
            Random rand = new Random();
            int x = rand.Next(200, ClientSize.Width - 150);
            int y = rand.Next(50, ClientSize.Height - 50);
            return new Point(x, y);
        }

        private void UpdateCounter()
        {
            counterLabel.Text = $"Кнопок: {buttonCount}  Меток: {labelCount}  Полей: {textBoxCount}";
        }
    }
}