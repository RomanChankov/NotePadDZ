using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urok3NotePad
{
    public partial class Form1 : Form
    {
        Font saveFont;
        Color saveColor;

        public Form1()
        {
            InitializeComponent();
            statusLabel.Text = $"Количество символов: 0";
            //Загружаем коллекцию системных шрифтов
            var fontsCollection= new InstalledFontCollection();
            var fonts = fontsCollection.Families;
            foreach ( var f in fonts) 
            {
                fontList.Items.Add(f.Name);
            }
        }
        //Загрузка текста из файла
        private void loadFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы(*.*)|*.*|Текстовый файл(*.txt)|*.txt";
            open.FilterIndex = 2;
            if(open.ShowDialog() == DialogResult.OK )
            {
                using (StreamReader reader= File.OpenText(open.FileName))
                {
                    richTextBox1.Text = reader.ReadToEnd();
                }
            }
        }
        //Сохранение текста в файл
        private void saveFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Все файлы(*.*)|*.*|Текстовый файл(*.txt)|*.txt";
            save.FilterIndex = 2;
            if(save.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter writer= new StreamWriter(save.FileName))
                {
                    writer.WriteLine(richTextBox1.Text);
                }
            }
        }
        //Изменение счетчика символов в строке состояния
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            statusLabel.Text = $"Количество символов: {richTextBox1.Text.Length}";
        }

        private void cutBtn()
        {
            richTextBox1.SelectedText.Any();
        }
        private void copyBtn()
        {
            richTextBox1.Copy();
        }
        private void pasteBtn()
        {
            richTextBox1.Paste();
        }

        //Выравнивание по левому краю
        private void leftAlign()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        //Выравнивание по центру краю
        private void centerAlign()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        //Выравнивание по правому краю
        private void rightAlign()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        //Выравнивание по ширине
        private void justifyAlign()
        {
            richTextBox1.SelectionIndent = 0;
            richTextBox1.SelectionRightIndent = 0;
            richTextBox1.SelectionHangingIndent = 0;
        }
        //Жирное выделение
        private void boldText()
        {
            if(richTextBox1.SelectionFont.Bold!=true)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
            }
        }
        //Курсивное выделение
        private void italicText()
        {
            if (richTextBox1.SelectionFont.Italic != true)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
            }
        }
        //Подчеркнутое выделение
        private void underLinedText()
        {
            if (richTextBox1.SelectionFont.Underline != true)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
            }
        }
        //Уменьшение шрифта
        private void dicreaseText()
        {
            if (richTextBox1.SelectionFont.Size>1)
            { richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size - 1, richTextBox1.SelectionFont.Style);
            }
        }
        //Увеличеие шрифта
        private void increaseText()
        {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size + 1, richTextBox1.SelectionFont.Style);
        }
        //Выбор шрифта из списка
        private void fontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font((string)fontList.SelectedItem,richTextBox1.SelectionFont.Size,richTextBox1.SelectionFont.Style);
        }
        //Формат по образцу. Сохраняем шрифт и цвет текста
        private void formatPaint()
        {
            if(richTextBox1.SelectedText !="" )
            {
                saveFont = richTextBox1.SelectionFont;
                saveColor = richTextBox1.SelectionColor;
            }
        }
        //Смена стиля и цвета шрифта при выделении
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if(formatPaintButton.Checked ==true||formatPaintMenuItem.Checked ==true)
            {
                richTextBox1.SelectionFont = saveFont;
                richTextBox1.SelectionColor = saveColor;
            }
        }
        //Палитра цветов
        private void textColorButton_Click(object sender, EventArgs e)
        {
            var colorCollection = new ColorDialog();
            if(colorCollection.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor=colorCollection.Color;
            }
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void cutButton_Click(object sender, EventArgs e)
        {
            cutBtn();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            copyBtn();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            pasteBtn();
        }

        private void alignLeftButton_Click(object sender, EventArgs e)
        {
            leftAlign();
        }

        private void alignCenterButton_Click(object sender, EventArgs e)
        {
            centerAlign();
        }

        private void alignRightButton_Click(object sender, EventArgs e)
        {
            rightAlign();
        }

        private void alignJustifyButton_Click(object sender, EventArgs e)
        {
            justifyAlign();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            boldText();
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            italicText();
        }

        private void underLinedButton_Click(object sender, EventArgs e)
        {
            underLinedText();
        }

        private void dicreaseButton_Click(object sender, EventArgs e)
        {
            
            dicreaseText();
        }

        private void increaseButton_Click(object sender, EventArgs e)
        {
            increaseText();
        }
    }
}
