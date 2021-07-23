using coursework.classes;
using coursework.forms;
using coursework.Properties;
using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace coursework.dialogs
{
    public partial class frmImport : Form
    {
        #region Переменные
        public DataGridView table;
        // get set test
        //
        public string table_name;
        public string noSpravkaValue = "01.01.0001 0:00:00";
        //
        public bool spravka;
        public string studentFIO, dateFrom, dateTo, doctorFIO;
        //
        private Excel.Range excelcells;

        public bool dark;
        #endregion

        #region Начало
        public frmImport()
        {
            InitializeComponent();
            dark = Convert.ToBoolean(Settings.Default["dark"]);
            if (dark == true)
                Theme(true);
            else
                Theme(false);
        }

        async void frmImport_Load(object sender, EventArgs e)
        {
            //
            if (spravka == true)
            {
                button_import_word.Visible = false;
                button_import_exel.Location = new System.Drawing.Point(152, 49);
                label_import.Text = $"Экспорт <b><font color='#6B7BCF'>справки</font></b>";
                animator2.Show(label_import);
                animator.ShowSync(button_import_exel);
            }
            else
            {
                button_import_word.Visible = true;
                button_import_exel.Location = new System.Drawing.Point(82, 49);
                await Task.Delay(200);
                label_import.Text = $"Экспорт таблицы <b><font color='#6B7BCF'>{table_name}</font></b>";

                animator2.Show(label_import);
                animator.ShowSync(button_import_exel);
                animator.ShowSync(button_import_word);
            }
        }
        #endregion

        #region Справка
        void ExportSpravka(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                Excel.Application oApp2;
                Worksheet oSheet2;
                Workbook oBook2;

                oApp2 = new Excel.Application();
                oBook2 = oApp2.Workbooks.Add();
                oSheet2 = (Worksheet)oBook2.Worksheets.get_Item(1);

                oSheet2.Cells[2, 2] = "УО Молодеченский-торгово экономический колледж Белкоопсоюза";
                oSheet2.Cells[3, 4] = "";
                oSheet2.Cells[4, 4] = "Справка"; // D4
                oSheet2.Cells[6, 2] = "Дана:"; // B6
                oSheet2.Cells[6, 3] = $"{studentFIO}"; // C7
                oSheet2.Cells[7, 2] = "В том что он(она) освобождается от занятий:"; // B8
                oSheet2.Cells[8, 2] = $"{dateFrom} ПО {dateTo}"; // B8
                //
                oSheet2.Cells[10, 2] = $"Зав.З/п. ___________________"; // B10
                oSheet2.Cells[10, 5] = $"{doctorFIO}"; // E10

                Range ggg = oSheet2.get_Range("B2");
                ggg.Font.Size = 8;
                ggg.Font.Bold = true;
                ggg.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //
                Range rng1 = oSheet2.get_Range("D4");
                rng1.Font.Size = 11;
                rng1.Font.Bold = true;
                rng1.Font.Italic = true;
                rng1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //
                Range rng2 = oSheet2.get_Range("B6");
                rng2.Font.Size = 11;
                rng2.HorizontalAlignment = XlHAlign.xlHAlignRight;
                //
                Range rng3 = oSheet2.get_Range("C6");
                rng3.Font.Size = 11;
                rng3.Font.Italic = true;
                rng3.Font.OutlineFont = true;
                rng3.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //
                Range rng4 = oSheet2.get_Range("B8");
                rng4.Font.Size = 11;
                rng4.Font.Italic = true;
                rng4.Font.OutlineFont = true;
                rng4.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //
                Range rng5 = oSheet2.get_Range("E10");
                rng5.Font.Size = 11;
                rng5.Font.Italic = true;
                rng5.Font.OutlineFont = true;
                rng5.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                //
                excelcells = oSheet2.get_Range("B2", "G10");           
                excelcells.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous; // верхняя 
                excelcells.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous; // правая 
                excelcells.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous; // левая 
                excelcells.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous; // нижняя 
                //


                oBook2.SaveAs(filename);
                oBook2.Close();
                oApp2.Quit();

                this.Alert("Вывод успешно выполнен, пройдите по пути указанном в диалоге!", frmNotification.enmType.Success);
                SettingsNullMainForm(true);
                this.Close();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Попробуйте вывести ещё раз.</b></font>", "Ошибка вывода в EXEL.", MessageBoxButtons.OK);
                this.Close();
            }
        }

        #endregion 

        #region Удаление лишнего
        void deleteIdColumns(DataGridView dataGridView)
        {
            try
            {
                if (table_name == "Журнал учёта" && dataGridView.Columns.Contains("id_book") && dataGridView.Columns.Contains("id_student"))
                {
                    dataGridView.Columns["sickness"].HeaderText = "Жалоба";
                    dataGridView.Columns["help"].HeaderText = "Лечение";
                    dataGridView.Columns["FIO1"].HeaderText = "Фельдшер";
                    dataGridView.Columns["Spravka_From"].HeaderText = "Справка С";
                    dataGridView.Columns["Spravka_To"].HeaderText = "Справка ПО";

                    int rowCount = dataGridView.Rows.Count;
                    int cellCount = dataGridView.Columns.Count;

                    for (int j = 0; j < rowCount; j++)
                    {
                        if (dataGridView.Rows[j].Cells[8].Value.ToString() == noSpravkaValue)
                        { 
                            dataGridView.Rows[j].Cells[8].Value = DBNull.Value;
                        }
                        if (dataGridView.Rows[j].Cells[9].Value.ToString() == noSpravkaValue)
                        {
                            dataGridView.Rows[j].Cells[9].Value = DBNull.Value;
                        }
                    }
                }
                else if (table_name == "Группы" && dataGridView.Columns.Contains("id_group"))
                {
                    dataGridView.Columns[6].HeaderText = "Дата поступления";
                }
                else if (table_name == "Учащиеся" && dataGridView.Columns.Contains("id_student"))
                {
                    dataGridView.Columns[6].HeaderText = "Группа крови";
                    dataGridView.Columns[9].HeaderText = "Адрес";
                    dataGridView.Columns[10].HeaderText = "Телефон";
                    dataGridView.Columns[11].HeaderText = "Другое";
                }
                else if (table_name == "Кураторы" && dataGridView.Columns.Contains("id_teacher"))
                {
                    //dataGridView.Columns.Remove("id_teacher");
                    //dataGridView.Columns.Remove("password");
                }
                else if (table_name == "Жалобы" && dataGridView.Columns.Contains("id_warn"))
                {
                    //dataGridView.Columns.Remove("id_warn");
                }
                else if (table_name == "Лечения" && dataGridView.Columns.Contains("id_help"))
                {
                    //dataGridView.Columns.Remove("id_help");
                }
                else if (table_name == "Ключи" && dataGridView.Columns.Contains("id_key"))
                {
                    //dataGridView.Columns.Remove("id_key");
                }
                else if (table_name == "Фельдшеры" && dataGridView.Columns.Contains("id_doctor"))
                {
                    //dataGridView.Columns.Remove("id_doctor");
                }
                else if (table_name == "Специальности" && dataGridView.Columns.Contains("id_specialty"))
                {
                    //dataGridView.Columns.Remove("id_specialty");
                }
                else { }
                dataGridView.Update();
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка удаления, данные не были переданы.");
            }
        }
        #endregion

        #region Экспорт
        void importExel(DataGridView table, string filename)
        {
            try
            {
                string[] Alphabit = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                              "N", "O","P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

                string Range_Letter = Alphabit[table.Columns.Count];
                string Range_Row = (table.Rows.Count + 1).ToString();

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                Excel.Application oApp;
                Worksheet oSheet;
                Workbook oBook;

                oApp = new Excel.Application();
                oBook = oApp.Workbooks.Add();
                oSheet = (Worksheet)oBook.Worksheets.get_Item(1);


                for (int x = 0; x < table.Columns.Count; x++)
                {
                    oSheet.Cells[1, x + 2] = table.Columns[x].HeaderText;
                }


                for (int i = 0; i < table.Columns.Count; i++)
                {
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        oSheet.Cells[j + 2, i + 2] = table.Rows[j].Cells[i].Value;
                    }
                }

                //Формат
                Range rng1 = oSheet.get_Range("B1", Range_Letter + "1");
                rng1.Font.Size = 14;
                rng1.Font.Bold = true;
                rng1.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                rng1.Cells.Borders.Color = Color.Black;
                rng1.Font.Color = System.Drawing.Color.Black;
                rng1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rng1.Interior.Color = System.Drawing.Color.White;

                Range rng2 = oSheet.get_Range("B2", Range_Letter + Range_Row);
                rng2.WrapText = false;
                rng2.Font.Size = 12;
                rng2.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                rng2.Cells.Borders.Color = Color.Black;
                rng2.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng2.Interior.Color = Color.White;
                rng2.EntireColumn.AutoFit();
                rng2.EntireRow.AutoFit();

                oSheet.get_Range("B1", Range_Letter + "1").EntireRow.Insert(XlInsertShiftDirection.xlShiftDown, Missing.Value);
                oSheet.Cells[1, 3] = $"Вывод таблицы: {table_name} Дата вывода: {DateTime.Now}";
                Range rng3 = oSheet.get_Range("B1", Range_Letter + "1");
                rng3.Merge(Missing.Value);
                rng3.Font.Size = 16;
                rng3.Font.Color = Color.Black;
                rng3.VerticalAlignment = XlVAlign.xlVAlignCenter;
                rng3.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                rng3.Cells.Borders.Color = Color.Black;

                //
                if (table_name == "Журнал учёта")
                {
                    oSheet.Columns["B"].Hidden = true;
                    oSheet.Columns["C"].Hidden = true;
                    oSheet.Columns["E"].Hidden = true;
                    oSheet.Columns["G"].Hidden = true;
                    oSheet.Columns["I"].Hidden = true;
                }
                else if (table_name == "Группы")
                {
                    oSheet.Columns["B"].Hidden = true;
                    oSheet.Columns["D"].Hidden = true;
                    oSheet.Columns["E"].Hidden = true;
                }
                else if (table_name == "Учащиеся")
                {
                    oSheet.Columns["B"].Hidden = true;
                    oSheet.Columns["C"].Hidden = true;
                    oSheet.Columns["E"].Hidden = true;
                    oSheet.Columns["F"].Hidden = true;
                }
                else if (table_name == "Кураторы")
                {
                    oSheet.Columns["B"].Hidden = true;
                    oSheet.Columns["E"].Hidden = true;
                }
                else if (table_name == "Жалобы")
                {
                    oSheet.Columns["B"].Hidden = true;
                }
                else if (table_name == "Лечения")
                {
                    oSheet.Columns["B"].Hidden = true;
                }
                else if (table_name == "Ключи")
                {
                    oSheet.Columns["B"].Hidden = true;
                }
                else if (table_name == "Фельдшеры")
                {
                    oSheet.Columns["B"].Hidden = true;
                    oSheet.Columns["D"].Hidden = true;
                }
                else if (table_name == "Специальности")
                {
                    oSheet.Columns["B"].Hidden = true;
                }
                else { }
                //
                //

                oBook.SaveAs(filename);
                oBook.Close();
                oApp.Quit();

                this.Alert("Вывод успешно выполнен, пройдите по пути указанном в диалоге!", frmNotification.enmType.Success);
                SettingsNullMainForm(false);
                this.Close();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Попробуйте вывести ещё раз.</b></font>", "Ошибка вывода в EXEL.", MessageBoxButtons.OK);
                this.Close();
            }
        }

        void importWord(DataGridView DGV, string filename)
        {
            try
            {
                if (DGV.Rows.Count != 0)
                {
                    int RowCount = DGV.Rows.Count;
                    int ColumnCount = DGV.Columns.Count;
                    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                    int r = 0;
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        for (r = 0; r <= RowCount - 1; r++)
                        {
                            DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                        }
                    }

                    Word.Document oDoc = new Word.Document();
                    oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                    //oDoc.Application.Visible = true; // открытие ворда


                    dynamic oRange = oDoc.Content.Application.Selection.Range;
                    string oTemp = "";
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        for (int c = 0; c <= ColumnCount - 1; c++)
                        {
                            oTemp = oTemp + DataArray[r, c] + "\t";

                        }
                    }

                    oRange.Text = oTemp;
                    object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                    object ApplyBorders = true;
                    object AutoFit = true;
                    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                    oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                          Type.Missing, Type.Missing, ref ApplyBorders,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                    oRange.Select();

                    oDoc.Application.Selection.Tables[1].Select();
                    oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                    oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.InsertRowsAbove(1);
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();

                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                    }

                    //oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                    {
                        Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                        headerRange.Text = $"Вывод таблицы: {table_name}\nДата вывода: {DateTime.Now}";
                        headerRange.Font.Size = 16;
                        headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    Word.Table tbl = oDoc.Tables[oDoc.Tables.Count];
                    //
                    if (table_name == "Журнал учёта")
                    {
                        tbl.Columns[1].Delete();
                        tbl.Columns[1].Delete();
                        tbl.Columns[2].Delete();
                        tbl.Columns[3].Delete();
                        tbl.Columns[4].Delete();
                    }
                    else if (table_name == "Группы")
                    {
                        tbl.Columns[1].Delete();
                        tbl.Columns[2].Delete();
                        tbl.Columns[2].Delete();
                    }
                    else if (table_name == "Учащиеся")
                    {
                        tbl.Columns[1].Delete();
                        tbl.Columns[1].Delete();
                        tbl.Columns[2].Delete();
                        tbl.Columns[2].Delete();
                    }
                    else if (table_name == "Кураторы")
                    {
                        tbl.Columns[1].Delete();
                        tbl.Columns[3].Delete();
                    }
                    else if (table_name == "Жалобы")
                    {
                        tbl.Columns[1].Delete();
                    }
                    else if (table_name == "Лечения")
                    {
                        tbl.Columns[1].Delete();
                    }
                    else if (table_name == "Ключи")
                    {
                        tbl.Columns[1].Delete();
                    }
                    else if (table_name == "Фельдшеры")
                    {
                        tbl.Columns[2].Delete();
                    }
                    else if (table_name == "Специальности")
                    {
                        tbl.Columns[1].Delete();
                    }
                    else { }

                    tbl.AllowAutoFit = true;
                    tbl.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;

                    Word.Border[] borders = new Word.Border[6];//массив бордеров
                    borders[0] = tbl.Borders[Word.WdBorderType.wdBorderLeft];//левая граница 
                    borders[1] = tbl.Borders[Word.WdBorderType.wdBorderRight];//правая граница 
                    borders[2] = tbl.Borders[Word.WdBorderType.wdBorderTop];//нижняя граница 
                    borders[3] = tbl.Borders[Word.WdBorderType.wdBorderBottom];//верхняя граница
                    borders[4] = tbl.Borders[Word.WdBorderType.wdBorderHorizontal];//горизонтальная граница
                    borders[5] = tbl.Borders[Word.WdBorderType.wdBorderVertical];//вертикальная граница
                    foreach (Word.Border border in borders)
                    {
                        border.LineStyle = Word.WdLineStyle.wdLineStyleSingle;//ставим стиль границы 
                        border.Color = Word.WdColor.wdColorBlack;//задаем цвет границы
                    }
                    tbl.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto;
                    oDoc.SaveAs(filename);

                    //

                    this.Alert("Вывод успешно выполнен, пройдите по пути указанном в диалоге!", frmNotification.enmType.Success);
                    SettingsNullMainForm(false);
                    this.Close();
                } else 
                {
                    this.Alert("Вы пытаетесь экспортировать пустую таблицу? Так дело не пойдет..", frmNotification.enmType.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Попробуйте вывести ещё раз.</b></font>", "Ошибка вывода в WORD.", MessageBoxButtons.OK);
                this.Close();
            }
        }
        #endregion

        #region  Кнопки

        void button_import_exel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Title = "Вывод в Excel";
            save.Filter = "Excel (Xlsx)|*.xlsx";
            save.FileName = "название документа excel";

            if (save.ShowDialog() == DialogResult.OK)
            {
                if (spravka == true) ExportSpravka(save.FileName);
                else { deleteIdColumns(table); importExel(table, save.FileName); }
            }
        }

        void button_import_word_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Title = "Вывод в Word";
            save.Filter = "Word документ (*.docx)|*.docx";
            save.FileName = "название документа word";

            if (save.ShowDialog() == DialogResult.OK)
            {
                deleteIdColumns(table);
                importWord(table, save.FileName);
            }
        }

        void SettingsNullMainForm(bool spravka)
        {
            //frmMain main = new frmMain();
            //if (spravka == true)
            //main.frmExistSpravka = false;
            //else
            //main.frmExist = false;
        }

        void frmImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        void frmImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        #endregion

        #region Другое
        void ThemeChanger(Color cl_panel, Color cl_mainPanel, Color cl_label)
        {
            panel_up.BackColor = cl_panel;
            this.BackColor = cl_mainPanel;
            label_import.ForeColor = cl_label;

            foreach (Guna.UI2.WinForms.Guna2Button item in this.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                item.FillColor = cl_mainPanel;
                item.HoverState.FillColor = cl_panel;
            }
        }

        void Theme(bool dark)
        {
            if (dark == true)
            {
                ThemeChanger(Color.FromArgb(45, 45, 48), Color.FromArgb(27, 27, 28), Color.White);
            }
            else
            {
                ThemeChanger(Color.White, Color.FromArgb(239, 242, 252), Color.Black);
            }
        }


        public void Alert(string msg, frmNotification.enmType type)
        {
            frmNotification frm = new frmNotification();
            frm.showAlert(msg, type);
        }
        #endregion
    }
}
