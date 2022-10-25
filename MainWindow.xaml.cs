using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfApp_CW1_24._10._2022
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open()
        {
            var openFileDialog = new OpenFileDialog();//ОТКРЫТИЕ ФАЙЛА
            if (openFileDialog.ShowDialog() ?? false)
            {
                using (var reader = new StreamReader(openFileDialog.FileName))
                {
                    textBox.Text = reader.ReadToEnd();
                }
            }
        }
        private void New()
        {
            textBox.Text = string.Empty;
        }
        private void Cut()
        {//Clipboard - БУФЕР ОБМЕНА \\ Clipboard.SetText -ЗАПИСЬ В БУФЕР ОБМЕНА
            Clipboard.SetText(textBox.SelectedText);
            textBox.SelectedText = string.Empty;//В ВЫДЕЛЕННОМ МЕСТЕ ВОЗВРАЩАЕТ ПУСТУЮ СТРОКУ
            
        }
        private void Copy()
        {
            Clipboard.SetText(textBox.SelectedText);//Clipboard.SetText - ЗАПИСЬ В БУФЕР ОБМЕНА
        }
        private void Past()
        {
            if (Clipboard.ContainsText())//ЕСЛИ В БУФЕР ОБМЕНА ХРАНИТСЯ ТЕКСТ
            {
                textBox.SelectedText = Clipboard.GetText();//ВОЗРАЩАЕТ ТЕКСТ ИЗ БУФЕРА ОБМЕНА
            }
        }
        private void AlignLeft()
        {
            textBox.TextAlignment = TextAlignment.Left;
        }
        private void AlignCenter()
        {
            textBox.TextAlignment = TextAlignment.Center;
        }
        private void AlignRight()
        {
            textBox.TextAlignment = TextAlignment.Right;
        }
        private void UpdateCaretPosition()//ОБНОВЛЯЕТ ТЕКУЩУЮ ПОЗИЦИЮ КУРСОРА
        {//GetLineIndexFromCharacterIndex -возвращает индекс строки и колонны
            int row = textBox.GetLineIndexFromCharacterIndex(textBox.CaretIndex);
            int column = textBox.CaretIndex - textBox.GetLineIndexFromCharacterIndex(row);

            currentColumn.Text = $"Col {column + 1}";
            currentLine.Text = $"Ln {row + 1}";
        }

        private void OnClickNew(object sender, EventArgs e) { New(); }
        private void OnClickOpen(object sender, EventArgs e) { Open(); }
        private void OnClickExit(object sender, EventArgs e) { Close(); }
        private void OnSelectionChanged(object sender, RoutedEventArgs e){UpdateCaretPosition(); }
        private void OnClickCut(object sender, EventArgs e) { Cut(); }
        private void OnClickCopy(object sender, EventArgs e) { Copy(); }
        private void OnClickPaste(object sender, EventArgs e) { Past(); }
        private void OnClickAlignLeft(object sender, EventArgs e) { AlignLeft(); }
        private void OnClickAlignCenter(object sender, EventArgs e) { AlignCenter(); }
        private void OnClickAlignRight(object sender, EventArgs e) { AlignRight(); }
    }
}
