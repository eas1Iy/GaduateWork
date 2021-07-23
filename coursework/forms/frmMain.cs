using coursework.classes;
using coursework.dialogs;
using coursework.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework.forms
{
    public partial class frmMain : Form
    {
        #region Переменные
        public string userName; // Имя пользователя
        public string status; // developer ; Куратор ; Фельдшер
        public int id_user;
        public string oldPassword;
        public string newPassword;
        public string telephone;

        public string sizeDataBase;
        database db = new database();
        //
        public bool first;

        public bool frmExistSpravka;
        public bool frmExist;

        public int progress;
        //
        public bool programLoad;
        public bool dark;
        //
        public bool resize, stat, pc, lowpc, monitor, updates;
        //
        #endregion

        #region Начало
        public frmMain()
        {
            InitializeComponent();
            programLoad = false;
            label_version.Text = "version: " + Application.ProductVersion;

            dark = Convert.ToBoolean(Settings.Default["dark"]);
            if (dark == true) { ThemeSwitch.Checked = true; Theme(false); }
            else { ThemeSwitch.Checked = false; Theme(true); }
        }

        void main_Load(object sender, EventArgs e)
        {
            tabFix();
            //
            statusCheck();
            loadAll();
            //
            frmExistSpravka = false;
            frmExist = false;
        }
        void statusCheck()
        {
            if (status == "Фельдшер")
            {
                button_use_group.Enabled = false;
                button_delGroup.Enabled = false;
                //
                button_use_teacher.Enabled = false;
                button_delTeacher.Enabled = false;
                //
                textBox_teacherPassword.Visible = false;
                button_gotoKeys.Visible = false;
            }
            else if (status == "Куратор")
            {
                button_delBook.Enabled = false;
                button_use_book.Enabled = false;
                //
                button_delTeacher.Enabled = false;
                button_use_teacher.Enabled = false;
                //
                //
                button_delWarn.Enabled = false;
                button_delHelp.Enabled = false;
                button_useWarn.Enabled = false;
                button_useHelp.Enabled = false;
                //
                textBox_teacherPassword.Visible = false;
                button_gotoKeys.Visible = false;
            }
            else if (status == "developer")
            {

            }
            else
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Сбой авторизации, использование программы невозможно.<br><br><b><font color='#6B7BCF'>Попробуйте пройти авторизацию заново.</b></font>", "Ошибка авторизации.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
        //
        void tabFix()
        {
            tab.Multiline = true;
            tab.Appearance = TabAppearance.FlatButtons;
            tab.ItemSize = new System.Drawing.Size(0, 1);
            tab.SizeMode = TabSizeMode.Fixed;
            tab.TabStop = false;
        }

        #endregion

        #region Загрузка
        async void loadAll()
        {
            //
            first = Convert.ToBoolean(Settings.Default["firstStart"]);
            progress = Convert.ToInt32(Settings.Default["progress"]);
            // Настройки
            resize = Convert.ToBoolean(Settings.Default["resizeToggle"]);
            stat = Convert.ToBoolean(Settings.Default["statToggle"]);
            pc = Convert.ToBoolean(Settings.Default["pcToggle"]);
            lowpc = Convert.ToBoolean(Settings.Default["lowToggle"]);
            monitor = Convert.ToBoolean(Settings.Default["monitorToggle"]);
            updates = Convert.ToBoolean(Settings.Default["updatesToggle"]);
            //
            ResizeSwitch.Checked = resize;
            StatisticSwitch.Checked = stat;
            PCSwitch.Checked = pc;
            LowPCSwitch.Checked = lowpc;
            MonitorSwitch.Checked = monitor;
            UpdatesSwitch.Checked = updates;
            //

            if (progress >= 100)
                progress = 100;

            progressBar_progress.Value = progress;

            if (first == true)
            {
                if ((_2DMessageBox.Show("Программа запущена впервые, желаете ли вы попасть в раздел помощь?", "Помощь в использовании.", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    button_Help.Checked = true;
                    tab.SelectedIndex = 8;

                    Settings.Default["firstStart"] = false;
                }
                else
                {
                    tab.SelectedIndex = 0;
                    Settings.Default["firstStart"] = false;
                }
                Settings.Default.Save();
            }
            //
            LOADING.Visible = true;
            label_username.Text = userName;
            label_userStatus.Text = status;
            tooltipUpdate();
            //FixDate();
            //
            loadProfile();

            // НУЖЕН ИНТЕРНЕТ
            combo();

            await Task.Run(() =>
            {
                frmLoading ld = new frmLoading();
                FillAll();
                ld.load = false;
                ld.ShowDialog();
            });


            scranSettings();
            //
            LOADING.Visible = false;
        }

        void FixDate()
        {
            DateTime_spravkaFROM.MinDate = DateTime.Now;
            DateTime_spravkaTO.MinDate = DateTime.Now;
        }

        void loadProfile()
        {
            //
            if (status == "Куратор") { pictureBox_userAvatar.Image = Resources.image_teacher; picture_profile_logo.Image = Resources.image_teacherHight; oldPassword = db.getPassword(true, id_user); textBox_telephone.Text = db.getProfile(id_user); }
            else if (status == "Фельдшер") { pictureBox_userAvatar.Image = Resources.image_doctor; picture_profile_logo.Image = Resources.image_doctorHight; oldPassword = db.getPassword(false, id_user); panel_profile_others.Visible = false; }
            else { adminRoot(); }
            //
            TextBox_profile_FIO.Text = label_username.Text;
            label_profile_status.Text = label_userStatus.Text;
        }

        void adminRoot()
        {
            label_username.Text = "Администратор";
            lbl_admin.Visible = true;
            button_doctors.Visible = true;
            button_specialty.Visible = true;
            button_profile_save.Visible = false;
            panel_profile_password.Visible = false;
            panel_profile_others.Visible = false;
            BUTTON_EDIT_FIO.Visible = false;
            button_profile_logout.Location = button_profile_save.Location;
            pictureBox_userAvatar.Image = Resources.image_admin;
            picture_profile_logo.Image = Resources.image_adminHight;
            panel_settings_panel.Visible = true;
        }

        void tooltipUpdate()
        {
            HelpTip.SetToolTip(label_username, userName);
            HelpTip.SetToolTip(label_teacherGroup, label_teacherGroup.Text);
            HelpTip.SetToolTip(label_specialGroup, label_specialGroup.Text);
        }

        void loadPK()
        {
            ManagementObjectSearcher searcher8 =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Processor");

            string процессор = "", capacity2 = "", Caption = "";

            foreach (ManagementObject queryObj in searcher8.Get())
            {
                процессор = queryObj["Name"].ToString();
            }
            //
            ManagementObjectSearcher searcher11 =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_VideoController");

            foreach (ManagementObject queryObj in searcher11.Get())
            {
                Caption = queryObj["Caption"].ToString();
            }
            //
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            ManagementObjectCollection coll = query.Get();
            foreach (ManagementObject mo in coll)
            {
                capacity2 = Math.Round(Convert.ToDouble(mo["totalphysicalmemory"]) / 1024 / 1024 / 1024).ToString();
            }
            label_pc.Text = $"Характеристики вашей системы:<br>" +
                            $"Процессор: {процессор}<br>" +
                            $"Кол-во ОЗУ: {capacity2} ГБ<br>" +
                            $"Активный видео-адаптер: {Caption}";
        }

        void FillAll()
        {
            if (loadSize() == true)
            {
                fillBook();
                fillGroups();
                fillStudents();
                fillTeatchers();
                fillKeys();
                fillWarns();
                fillHelp();
                fillDoctors();
                fillSpecialty();
            }
            else
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Проблемы с интернет соединением.<br>Невозможно заполнить таблицы и списки. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillBook()
        {
            //
            try
            {
                table_book.DataSource = db.fillBook();

                table_book.Columns["id_book"].Visible = false;
                table_book.Columns["id_student"].Visible = false;
                table_book.Columns["id_warn"].Visible = false;
                table_book.Columns["id_help"].Visible = false;
                table_book.Columns["id_doctor"].Visible = false;

                table_book.Columns["sickness"].Visible = false;
                table_book.Columns["help"].Visible = false;
                table_book.Columns["FIO1"].Visible = false;
                table_book.Columns["Spravka_From"].Visible = false;
                table_book.Columns["Spravka_To"].Visible = false;

                table_book.Columns["FIO"].HeaderText = "Учащийся";
                table_book.Columns["Date"].HeaderText = "Дата посещения";

                table_book.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillGroups()
        {
            //
            try
            {
                table_groups.DataSource = db.fillGroups();

                table_groups.Columns["id_group"].Visible = false;
                table_groups.Columns["id_teacher"].Visible = false;
                table_groups.Columns["id_specialty"].Visible = false;

                table_groups.Columns["Number"].HeaderText = "Номер";
                table_groups.Columns["FIO"].HeaderText = "Куратор";
                table_groups.Columns["name"].HeaderText = "Специальность";
                table_groups.Columns["cypher"].HeaderText = "Шифр";


                table_groups.Columns["Date_Join"].Visible = false;

                table_groups.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillStudents()
        {
            //
            try
            {
                table_students.DataSource = db.fillStudents();

                table_students.Columns["id_student"].Visible = false;
                table_students.Columns["id_group"].Visible = false;
                table_students.Columns["id_specialty"].Visible = false;

                table_students.Columns["cypher"].Visible = false;
                table_students.Columns["Blood"].Visible = false;
                table_students.Columns["Adres"].Visible = false;
                table_students.Columns["Telephone"].Visible = false;
                table_students.Columns["Others"].Visible = false;

                table_students.Columns["FIO"].HeaderText = "Учащийся";
                table_students.Columns["Number"].HeaderText = "Группа";
                table_students.Columns["Gender"].HeaderText = "Пол";
                table_students.Columns["DateBirth"].HeaderText = "Дата рождения";

                table_students.Columns[8].DefaultCellStyle.Format = "MM/dd/yyyy"; // !! чтобы показывало только дату (без времени) !!

                table_students.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillTeatchers()
        {
            //
            try
            {
                table_teachers.DataSource = db.fillTeatchers();

                table_teachers.Columns["id_teacher"].Visible = false;
                table_teachers.Columns["password"].Visible = false;

                table_teachers.Columns["FIO"].HeaderText = "Фамилия Имя Отчество";
                table_teachers.Columns["telephone"].HeaderText = "Номер телефона";

                table_teachers.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillKeys()
        {
            try
            {
                table_keys.DataSource = db.fillKey();

                table_keys.Columns["id_key"].Visible = false;

                table_keys.Columns["key"].HeaderText = "Ключ";

                table_keys.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillWarns()
        {
            //
            try
            {
                table_warns.DataSource = db.fillWarns();

                table_warns.Columns["id_warn"].Visible = false;

                table_warns.Columns["sickness"].HeaderText = "Жалоба";

                table_warns.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillHelp()
        {
            //
            try
            {
                table_help.DataSource = db.fillHelp();

                table_help.Columns["id_help"].Visible = false;

                table_help.Columns["help"].HeaderText = "Лечение";

                table_help.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillDoctors()
        {
            //
            try
            {
                table_doctors.DataSource = db.fillDoctors();

                table_doctors.Columns["id_doctor"].Visible = false;
                table_doctors.Columns["password"].Visible = false;

                table_doctors.Columns["FIO"].HeaderText = "Фельдшер";

                table_doctors.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public void fillSpecialty()
        {
            //
            try
            {
                table_specialty.DataSource = db.fillSpecialty();

                table_specialty.Columns["id_specialty"].Visible = false;

                table_specialty.Columns["name"].HeaderText = "Наименование специальности";
                table_specialty.Columns["cypher"].HeaderText = "Шифр";

                table_specialty.Update();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        bool loadSize()
        {
            try
            {
                int SizeOfDb = db.getSizeDb();
                progressDataBaseSize.Value = SizeOfDb;
                progressDataBaseSize2.Value = progressDataBaseSize.Value;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool combo()
        {
            //
            // Заполнение комбо боксов //
            //
            try
            {
                db.combobox(ComboBox_book_student, "SELECT FIO,id_student FROM students", "FIO", "id_student");
                db.combobox(ComboBox_book_warn, "SELECT sickness,id_warn FROM warns", "sickness", "id_warn");
                db.combobox(ComboBox_book_help, "SELECT help,id_help FROM help", "help", "id_help");
                //
                db.combobox(ComboBox_group_speciality, "SELECT name,id_specialty FROM specialty", "name", "id_specialty");
                db.combobox(ComboBox_group_teacher, "SELECT FIO,id_teacher FROM teachers", "FIO", "id_teacher");
                //
                db.combobox(ComboBox_student_group, "SELECT Number,id_group FROM groups", "Number", "id_group");
                //
                if (status == "developer") { db.combobox(ComboBox_doctor, "SELECT FIO,id_doctor FROM doctors", "FIO", "id_doctor"); ComboBox_doctor.Visible = true; }

                programLoad = true;
                return true;
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка запуска.", MessageBoxButtons.OK);
                return false;
            }
        }
        #endregion

        #region Журнал
        void CheckBox_Now_Click(object sender, EventArgs e)
        {
            if (CheckBox_Spravka.Checked)
            {
                DateTime_spravkaFROM.Enabled = true;
                DateTime_spravkaTO.Enabled = true;
            }
            else
            {
                DateTime_spravkaFROM.Enabled = false;
                DateTime_spravkaTO.Enabled = false;
            }

        }
        void button_use_active_Click(object sender, EventArgs e)
        {
            if (ComboBox_book_student.SelectedIndex != -1 && DateTime_spravkaTO.Value != DateTime.Now && DateTime_spravkaFROM.Value != DateTime_spravkaTO.Value && DateTime_spravkaTO.Value > DateTime_spravkaFROM.Value)
            {
                if (button_bookAdd.Checked)
                {
                    //Добавление записи
                    if (status == "developer")
                        id_user = Convert.ToInt32(ComboBox_doctor.SelectedValue);

                    if (CheckBox_Spravka.Checked && DateTime_spravkaFROM.Value != DateTime_spravkaTO.Value)
                        db.BookAdd(Convert.ToInt32(ComboBox_book_student.SelectedValue),
                            Convert.ToInt32(ComboBox_book_warn.SelectedValue),
                            Convert.ToInt32(ComboBox_book_help.SelectedValue), id_user, DateTime_spravkaFROM.Value, DateTime_spravkaTO.Value, DateTime.Now);
                    else
                        db.BookAdd(Convert.ToInt32(ComboBox_book_student.SelectedValue),
                            Convert.ToInt32(ComboBox_book_warn.SelectedValue),
                            Convert.ToInt32(ComboBox_book_help.SelectedValue), id_user, Convert.ToDateTime(null), Convert.ToDateTime(null), DateTime.Now);
                }
                else if (button_editBook.Checked)
                {
                    //Редактирование записи
                    if (status == "developer")
                        id_user = Convert.ToInt32(ComboBox_doctor.SelectedValue);

                    if (CheckBox_Spravka.Checked && DateTime_spravkaFROM.Value != DateTime_spravkaTO.Value)
                        db.editBook(table_book, "id_book", Convert.ToInt32(ComboBox_book_student.SelectedValue),
                            Convert.ToInt32(ComboBox_book_warn.SelectedValue),
                            Convert.ToInt32(ComboBox_book_help.SelectedValue), id_user, DateTime_spravkaFROM.Value, DateTime_spravkaTO.Value, DateTime.Now);
                    else
                        db.editBook(table_book, "id_book", Convert.ToInt32(ComboBox_book_student.SelectedValue),
                            Convert.ToInt32(ComboBox_book_warn.SelectedValue),
                            Convert.ToInt32(ComboBox_book_help.SelectedValue), id_user, Convert.ToDateTime(null), Convert.ToDateTime(null), DateTime.Now);
                }
                FillAll();
                combo();
                progressUpp(1);
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }
        void button_addActive_Click(object sender, EventArgs e)
        {
            if (lowpc == false) { animator.ShowSync(panel_editBook); } else { panel_editBook.Visible = true; }
            button_use_book.Text = "Добавить";
        }

        void button_editActive_Click(object sender, EventArgs e)
        {
            if (lowpc == false) { animator.ShowSync(panel_editBook); } else { panel_editBook.Visible = true; }
            button_use_book.Text = "Сохранить";
        }

        void button_delActive_Click(object sender, EventArgs e)
        {
            deleteRow(table_book, "id_book", "book");
        }
        void table_active_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_bookView.Checked)
            {
                label_book_FIOstudent.Text = table_book.CurrentRow.Cells[2].Value.ToString();
                label_book_warn.Text = table_book.CurrentRow.Cells[4].Value.ToString();
                label_book_help.Text = table_book.CurrentRow.Cells[6].Value.ToString();
                label_book_FIOdoctor.Text = table_book.CurrentRow.Cells[8].Value.ToString();

                if (table_book.CurrentRow.Cells[9].Value.ToString() == "01.01.0001 0:00:00" || table_book.CurrentRow.Cells[9].Value == DBNull.Value)
                {
                    label_book_SpravkaFROM.Visible = false;
                    label_book_SpravkaTO.Visible = false;
                    button_book_export_spravka.Visible = false;
                    label_aboutSpravka.Text = "Справка не выдана.";
                }
                else
                {
                    label_book_SpravkaFROM.Visible = true;
                    label_book_SpravkaTO.Visible = true;
                    button_book_export_spravka.Visible = true;
                    label_aboutSpravka.Text = "Справка:";
                    label_book_SpravkaFROM.Text = table_book.CurrentRow.Cells[9].Value.ToString();
                    label_book_SpravkaTO.Text = table_book.CurrentRow.Cells[10].Value.ToString();
                }
                label_book_Date.Text = table_book.CurrentRow.Cells[11].Value.ToString();
            }
            if (button_editBook.Checked)
            {
                ComboBox_book_student.SelectedValue = table_book.CurrentRow.Cells[1].Value;
                ComboBox_book_warn.SelectedValue = table_book.CurrentRow.Cells[3].Value;
                ComboBox_book_help.SelectedValue = table_book.CurrentRow.Cells[5].Value;

                if (table_book.CurrentRow.Cells[9].Value.ToString() == "01.01.0001 0:00:00" || table_book.CurrentRow.Cells[9].Value == DBNull.Value)
                {
                    CheckBox_Spravka.Checked = false;
                    DateTime_spravkaFROM.Enabled = false;
                    DateTime_spravkaTO.Enabled = false;
                    button_book_export_spravka.Visible = false;
                }
                else
                {
                    CheckBox_Spravka.Checked = true;
                    DateTime_spravkaFROM.Enabled = true;
                    DateTime_spravkaTO.Enabled = true;
                    button_book_export_spravka.Visible = true;
                    DateTime_spravkaFROM.Value = Convert.ToDateTime(table_book.CurrentRow.Cells[9].Value);
                    DateTime_spravkaTO.Value = Convert.ToDateTime(table_book.CurrentRow.Cells[10].Value);
                }
            }
        }
        void button_cancel_active_Click(object sender, EventArgs e)
        {
            if (lowpc == false) animator.HideSync(panel_editBook); else panel_editBook.Visible = false;

            button_bookView.Checked = true;
            ComboBox_book_student.SelectedValue = 0;
            ComboBox_book_warn.SelectedValue = 0;
            ComboBox_book_help.SelectedValue = 0;

            CheckBox_Spravka.Checked = true;
            DateTime_spravkaFROM.Value = DateTime.Now;
            DateTime_spravkaTO.Value = DateTime.Now;
        }
        void button_active_import_Click(object sender, EventArgs e)
        {
            import(button_book_export, table_book, "Журнал учёта");
            //
        }
        void button_bookView_Click(object sender, EventArgs e)
        {
            if (lowpc == false) { animator.HideSync(panel_editBook); } else { panel_editBook.Visible = false; }
        }
        void button_book_export_spravka_Click(object sender, EventArgs e)
        {
            if (button_editBook.Checked)
            { button_book_export_spravka.Enabled = false;  exportSpravka(); table_book.Update(); }
            else this.Alert("Выберите режим редактирования, для того чтобы вывести на печать справку.", frmNotification.enmType.Info);
        }

        async void exportSpravka()
        {
            frmImport import = new frmImport();
            import.spravka = true;
            //
            import.studentFIO = ComboBox_book_student.Text;
            import.doctorFIO = ComboBox_doctor.Text;
            import.dateFrom = DateTime_spravkaFROM.Value.ToString();
            import.dateTo = DateTime_spravkaTO.Value.ToString();
            //
            import.Show();

            tipoSsilka:
            if (import.Visible == true)
            {
                await Task.Delay(2500);
                goto tipoSsilka;
            } else { button_book_export_spravka.Enabled = true; }
        }
        #endregion

        #region Группы
        void button_viewGroup_Click(object sender, EventArgs e)
        {
            if (lowpc == false) { animator.HideSync(panel_editGroup); } else { panel_editGroup.Visible = false; }
        }
        void button_use_group_Click(object sender, EventArgs e)
        {
            if (textBox_numberGroups.Text.Length > 1 && ComboBox_group_speciality.SelectedIndex != -1 && ComboBox_group_teacher.SelectedIndex != -1)
            {
                if (button_addGroup.Checked)
                {
                    //Добавление группы
                    db.GroupAdd(Convert.ToInt32(ComboBox_group_teacher.SelectedValue), Convert.ToInt32(ComboBox_group_speciality.SelectedValue), textBox_numberGroups.Text, DateTimePicker_groups.Value);
                }
                else if (button_editGroup.Checked)
                {
                    //Редактирование группы
                    db.editGroups(table_groups, "id_group", Convert.ToInt32(ComboBox_group_teacher.SelectedValue), Convert.ToInt32(ComboBox_group_speciality.SelectedValue), textBox_numberGroups.Text, DateTimePicker_groups.Value);
                }
                FillAll();
                combo();
                progressUpp(1);
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }


        }
        void button_addGroup_Click(object sender, EventArgs e)
        {
            label_groups_edit.Text = "Добавление:";
            button_use_group.Text = "Добавить";
            if (lowpc == false) animator.ShowSync(panel_editGroup); else { panel_editGroup.Visible = true; }
        }

        void button_editGroup_Click(object sender, EventArgs e)
        {
            label_groups_edit.Text = "Редактирование:";
            button_use_group.Text = "Сохранить";
            if (lowpc == false) animator.ShowSync(panel_editGroup); else { panel_editGroup.Visible = true; }
        }
        void button_delGroup_Click(object sender, EventArgs e)
        {
            deleteRow(table_groups, "id_group", "groups");
        }
        void table_groups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_editGroup.Checked)
            {
                ComboBox_group_teacher.SelectedValue = Convert.ToInt32(table_groups.CurrentRow.Cells[2].Value);
                ComboBox_group_speciality.SelectedValue = Convert.ToInt32(table_groups.CurrentRow.Cells[3].Value);

                textBox_numberGroups.Text = table_groups.CurrentRow.Cells[1].Value.ToString();
                DateTimePicker_groups.Value = Convert.ToDateTime(table_groups.CurrentRow.Cells[6].Value);
            }
            else if (button_viewGroup.Checked)
            {
                string numberGroup = table_groups.CurrentRow.Cells[7].Value.ToString() + table_groups.CurrentRow.Cells[1].Value.ToString();
                var t = (DateTime)table_groups.CurrentRow.Cells[6].Value - DateTime.Now;
                string daysTotal = Convert.ToString(t.Days);
                daysTotal = daysTotal.Replace('-', ' ');


                label_Проучились.Text = $"Проучились уже:<b><font color='#6B7BCF'>{daysTotal}</font></b> Дней(-я)";

                label_numberGroup.Text = numberGroup;

                label_teacherGroup.Text = table_groups.CurrentRow.Cells[4].Value.ToString();

                label_specialGroup.Text = table_groups.CurrentRow.Cells[5].Value.ToString();

                // label_DateJoin.Text = table_groups.CurrentRow.Cells[6].Value.ToString();

                label_DateJoin.Text = ((DateTime)table_groups.CurrentRow.Cells[6].Value).ToShortDateString();


                tooltipUpdate();
            }
        }
        void button_cancel_group_Click(object sender, EventArgs e)
        {
            button_viewGroup_Click(sender, e); button_viewGroup.Checked = true;

            ComboBox_group_speciality.SelectedValue = 0;
            ComboBox_group_teacher.SelectedValue = 0;
            ComboBox_group_teacher.SelectedValue = 0;

            textBox_numberGroups.Text = "";
            DateTimePicker_groups.Value = DateTime.Now;
        }
        void button_groups_import_Click(object sender, EventArgs e)
        {
            import(button_groups_import,table_groups, "Группы");
        }
        #endregion

        #region Учащиеся
        void button_viewStudent_Click(object sender, EventArgs e)
        {
            if (lowpc == false) { animator.HideSync(panel_editStudents); } else { panel_editStudents.Visible = false; }
        }
        void button_use_student_Click(object sender, EventArgs e)
        {
            if (textBox_studentFIO.Text.Length > 5 && ComboBox_student_group.SelectedIndex != -1 && ComboBox_student_Blood.SelectedIndex != -1 && ComboBox_student_Gender.SelectedIndex != -1 && textBox_student_Adres.Text.Length > 5 && DateTimePicker_student_birth.Value != DateTime.Now)
            {
                string gender = "";
                string blood = "";
                if (ComboBox_student_Gender.SelectedIndex == 0) { gender = "Мужской"; } else { gender = "Женский"; }
                if (ComboBox_student_Blood.SelectedIndex == 0) { blood = "I"; }
                else if (ComboBox_student_Blood.SelectedIndex == 1) { blood = "II"; }
                else if (ComboBox_student_Blood.SelectedIndex == 2) { blood = "III"; }
                else if (ComboBox_student_Blood.SelectedIndex == 3) { blood = "IV"; }

                if (button_addStudent.Checked)
                {
                    //Добавление учащегося
                    db.studentAdd(Convert.ToInt32(ComboBox_student_group.SelectedValue), textBox_studentFIO.Text, blood, gender, DateTimePicker_student_birth.Value, textBox_student_Adres.Text, textBox_student_Telephone.Text, textBox_student_Others.Text);
                }
                else if (button_editStudent.Checked)
                {
                    //Редактирование учащегося
                    db.editStudents(table_students, "id_student", Convert.ToInt32(ComboBox_student_group.SelectedValue), textBox_studentFIO.Text, blood, gender, DateTimePicker_student_birth.Value, textBox_student_Adres.Text, textBox_student_Telephone.Text, textBox_student_Others.Text);
                }
                FillAll();
                combo();
                progressUpp(1);
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }
        void button_addStudent_Click(object sender, EventArgs e)
        {
            button_use_student.Text = "Добавить";
            if (lowpc == false) animator.ShowSync(panel_editStudents); else { panel_editStudents.Visible = true; }
        }

        void button_editStudent_Click(object sender, EventArgs e)
        {
            button_use_student.Text = "Сохранить";
            if (lowpc == false) animator.ShowSync(panel_editStudents); else { panel_editStudents.Visible = true; }
        }
        void button_delStudent_Click(object sender, EventArgs e)
        {
            deleteRow(table_students, "id_student", "students");
        }
        void table_students_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_editStudent.Checked)
            {
                ComboBox_student_group.SelectedValue = Convert.ToInt32(table_students.CurrentRow.Cells[1].Value);

                if (table_students.CurrentRow.Cells[7].Value.ToString() == "Мужской") { ComboBox_student_Gender.SelectedIndex = 0; } else { ComboBox_student_Gender.SelectedIndex = 1; }

                if (table_students.CurrentRow.Cells[6].Value.ToString() == "I") ComboBox_student_Blood.SelectedIndex = 0;
                else if (table_students.CurrentRow.Cells[6].Value.ToString() == "II") ComboBox_student_Blood.SelectedIndex = 1;
                else if (table_students.CurrentRow.Cells[6].Value.ToString() == "III") ComboBox_student_Blood.SelectedIndex = 2;
                else if (table_students.CurrentRow.Cells[6].Value.ToString() == "IV") ComboBox_student_Blood.SelectedIndex = 3;

                textBox_studentFIO.Text = table_students.CurrentRow.Cells[5].Value.ToString();
                textBox_student_Telephone.Text = table_students.CurrentRow.Cells[10].Value.ToString();
                textBox_student_Others.Text = table_students.CurrentRow.Cells[11].Value.ToString();
                textBox_student_Adres.Text = table_students.CurrentRow.Cells[9].Value.ToString();

                DateTimePicker_student_birth.Value = Convert.ToDateTime(table_students.CurrentRow.Cells[8].Value);
            }
            else if (button_viewStudent.Checked)
            {
                string group = table_students.CurrentRow.Cells[4].Value.ToString() + table_students.CurrentRow.Cells[2].Value.ToString();

                label_studentFIO.Text = table_students.CurrentRow.Cells[5].Value.ToString();
                label_studentGroup.Text = group;
                label_student_Blood.Text = table_students.CurrentRow.Cells[6].Value.ToString();
                label_student_Gender.Text = table_students.CurrentRow.Cells[7].Value.ToString();

                label_student_DateBirth.Text = ((DateTime)table_students.CurrentRow.Cells[8].Value).ToShortDateString();


                label_student_Adres.Text = table_students.CurrentRow.Cells[9].Value.ToString();
                label_student_Telephone.Text = table_students.CurrentRow.Cells[10].Value.ToString();
                label_student_Others.Text = table_students.CurrentRow.Cells[11].Value.ToString();
            }
        }
        void button_cancel_student_Click(object sender, EventArgs e)
        {
            button_viewStudent_Click(null, e);

            button_viewStudent.Checked = true;

            ComboBox_student_group.SelectedValue = -1;
            ComboBox_student_Gender.SelectedValue = -1;

            DateTimePicker_student_birth.Value = DateTime.Now;

            textBox_studentFIO.Text = "";
            textBox_student_Adres.Text = "";
            textBox_student_Others.Text = "";
            textBox_student_Telephone.Text = "";
        }

        void button_students_import_Click_1(object sender, EventArgs e)
        {
            import(button_students_import,table_students, "Учащиеся");
        }
        #endregion

        #region Кураторы
        void button_addTeacher_Click(object sender, EventArgs e)
        {
            label_teachers_edit.Text = "Добавление:";
            button_use_teacher.Text = "Добавить";
        }

        void button_editTeacher_Click(object sender, EventArgs e)
        {
            label_teachers_edit.Text = "Редактирование:";
            button_use_teacher.Text = "Сохранить";
        }
        //
        void button_use_teacher_Click(object sender, EventArgs e)
        {
            if (textBox_teacherFIO.Text.Length > 5 && textBox_teacherNumber.Text.Length > 6)
            {
                if (button_addTeacher.Checked)
                {
                    //Добавление куратора+
                    db.TeacherAdd(textBox_teacherFIO.Text, textBox_teacherNumber.Text, textBox_teacherPassword.Text);
                }
                else if (button_editTeacher.Checked)
                {
                    //Редактирование куратора
                    db.editTeatchers(table_teachers, "id_teacher", textBox_teacherFIO.Text, textBox_teacherNumber.Text, textBox_teacherPassword.Text);
                }
                FillAll();
                combo();
                progressUpp(1);
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }

        void button_delTeacher_Click(object sender, EventArgs e)
        {
            deleteRow(table_teachers, "id_teacher", "teachers");
        }

        void button_cancel_teacher_Click(object sender, EventArgs e)
        {
            if (button_editTeacher.Checked)
            { button_addTeacher_Click(sender, e); button_addTeacher.Checked = true; }

            textBox_teacherFIO.Text = "";
            textBox_teacherNumber.Text = "";
            textBox_teacherPassword.Text = "";
        }
        void table_teachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_editTeacher.Checked)
            {
                textBox_teacherFIO.Text = table_teachers.CurrentRow.Cells[1].Value.ToString();
                textBox_teacherNumber.Text = table_teachers.CurrentRow.Cells[2].Value.ToString();
                textBox_teacherPassword.Text = table_teachers.CurrentRow.Cells[3].Value.ToString();
            }
        }
        void button_teachers_import_Click(object sender, EventArgs e)
        {
            import(button_teachers_import,table_teachers, "Кураторы");
        }
        void button_gotoKeys_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 8;
        }
        #endregion

        #region Симптомы
        void button_editWarn_Click(object sender, EventArgs e)
        {
            button_useWarn.Text = "Сохранить";
        }

        void button_addWarn_Click(object sender, EventArgs e)
        {
            button_useWarn.Text = "Добавить";
        }

        void button_addHelp_Click(object sender, EventArgs e)
        {
            button_useHelp.Text = "Добавить";
        }

        void button_editHelp_Click(object sender, EventArgs e)
        {
            button_useHelp.Text = "Сохранить";
        }
        void table_warns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_editWarn.Checked)
            {
                textBox_Warn.Text = table_warns.CurrentRow.Cells[1].Value.ToString();
            }
        }

        void table_help_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_editHelp.Checked)
            {
                textBox_Help.Text = table_help.CurrentRow.Cells[1].Value.ToString();
            }
        }

        void button_cancelWarn_Click(object sender, EventArgs e)
        {
            button_addWarn.Checked = true;
            textBox_Warn.Text = "";
        }

        void button_cancelHelp_Click(object sender, EventArgs e)
        {
            button_addHelp.Checked = true;
            textBox_Help.Text = "";
        }

        void button_delWarn_Click(object sender, EventArgs e)
        {
            deleteRow(table_warns, "id_warn", "warns");
        }

        void button_useWarn_Click(object sender, EventArgs e)
        {
            if (textBox_Warn.Text.Length > 5)
            {
                if (button_addWarn.Checked)
                {
                    // Добавление жалобы
                    db.warnAdd(textBox_Warn.Text);
                }
                else if (button_editWarn.Checked)
                {
                    //Редактирование жалобы
                    db.editWarn(table_warns, "id_warn", textBox_Warn.Text);
                }
                FillAll();
                combo();
                progressUpp(1);
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }

        void button_exportWarn_Click(object sender, EventArgs e)
        {
            import(button_exportWarn,table_warns, "Жалобы");
        }

        void button_delHelp_Click(object sender, EventArgs e)
        {
            deleteRow(table_help, "id_help", "help");
        }

        void button_useHelp_Click(object sender, EventArgs e)
        {
            if (textBox_Help.Text.Length > 5)
            {
                if (button_addHelp.Checked)
                {
                    // Добавление лечения
                    db.helpAdd(textBox_Help.Text);
                    FillAll();
                    combo();
                    progressUpp(1);
                }
                else if (button_editHelp.Checked)
                {
                    //Редактирование лечения
                    db.editHelp(table_help, "id_help", textBox_Help.Text);
                    FillAll();
                    combo();
                    progressUpp(1);
                }
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }

        void button_exportHelp_Click(object sender, EventArgs e)
        {
            import(button_exportHelp,table_help, "Лечения");
        }
        #endregion

        #region Ключи
        void button_addKeys_Click(object sender, EventArgs e)
        {
            label_keys_edit.Text = "Добавление:";
            button_use_keys.Text = "Добавить";
        }
        void button_editKeys_Click(object sender, EventArgs e)
        {
            label_keys_edit.Text = "Редактирование:";
            button_use_keys.Text = "Сохранить";
        }
        void button_use_keys_Click(object sender, EventArgs e)
        {
            if (textBox_key.Text.Length > 5)
            {
                if (button_addKeys.Checked)
                {
                    // Добавление ключа
                    db.KeyAdd(textBox_key.Text);
                    fillKeys();
                    progressUpp(1);
                }
                else if (button_editKeys.Checked)
                {
                    //Редактирование ключа
                    db.editKeys(table_keys, "id_key", textBox_key.Text);
                    fillKeys();
                    progressUpp(1);
                }
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }

        void button_delKeys_Click(object sender, EventArgs e)
        {
            deleteRow(table_keys, "id_key", "keys");
        }


        void button_cancel_keys_Click(object sender, EventArgs e)
        {
            if (button_editKeys.Checked)
            { button_addKeys_Click(sender, e); button_addKeys.Checked = true; }

            textBox_key.Text = "";
        }

        void button_import_keys_Click(object sender, EventArgs e)
        {
            import(button_import_keys,table_keys, "Ключи");
        }

        void table_keys_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_editKeys.Checked)
            {
                textBox_key.Text = table_keys.CurrentRow.Cells[1].Value.ToString();
            }
        }

        string GenerateKeyPart()
        {
            string result = "";
            for (int i = 1; i <= 5; i++) result += KEY_CHARS[rnd.Next(0, KEY_CHARS.Length)];
            return result;
        }
        const String KEY_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random rnd = new Random();
        private void button_randomKey_Click(object sender, EventArgs e)
        {
            textBox_key.Text = GenerateKeyPart() + "-" + GenerateKeyPart() + "-" + GenerateKeyPart() + "-" + GenerateKeyPart();
        }
        #endregion

        #region Профиль
        void pictureBox_userAvatar_Click_1(object sender, EventArgs e)
        {
            tab.SelectedIndex = 9;
        }
        void button_profile_save_Click(object sender, EventArgs e)
        {
            frmRegister rg = new frmRegister();
            if (textBox_oldPassword.Text == oldPassword)
            {
                if (textBox_newPassword.Text.Length == 0 && textBox_newPassword2.Text.Length == 0 && rg.noSimplePass(textBox_newPassword.Text) == true && textBox_newPassword.Text != textBox_newPassword2.Text && textBox_newPassword.Text != textBox_telephone.Text)
                {
                    if (TextBox_profile_FIO.Text.Length > 5)
                    {
                        if (textBox_newPassword.Text == textBox_newPassword2.Text)
                        {
                            if (status == "Куратор")
                            { db.updateProfile(true, false, id_user, TextBox_profile_FIO.Text, textBox_newPassword.Text, textBox_telephone.Text); FillAll(); combo(); }
                            else if (status == "Фельдшер")
                            { db.updateProfile(false, false, id_user, TextBox_profile_FIO.Text, textBox_newPassword.Text, null); FillAll(); combo(); }
                            else { }
                        }
                        else { this.Alert("Новый пароль и его повтор, не совпадают.", frmNotification.enmType.Error); }
                    }
                    else _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, корректно заполните все поля.", "Ошибка.", MessageBoxButtons.OK);
                }
                else
                {
                    if (textBox_newPassword.Text == textBox_newPassword2.Text)
                        if (TextBox_profile_FIO.Text.Length > 5 && textBox_newPassword.Text.Length > 2)
                        {
                            if (status == "Куратор")
                                db.updateProfile(true, true, id_user, TextBox_profile_FIO.Text, textBox_newPassword.Text, textBox_telephone.Text);
                            else if (status == "Фельдшер")
                                db.updateProfile(false, true, id_user, TextBox_profile_FIO.Text, textBox_newPassword.Text, null);
                            else { }
                        }
                        else { _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, корректно заполните все поля.", "Ошибка.", MessageBoxButtons.OK); }
                    else { this.Alert("Новый пароль и его повтор, не совпадают.", frmNotification.enmType.Error); }
                }
            }
            else { _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, введите верный 'Текущий пароль', для сохранения данных.", "Ошибка.", MessageBoxButtons.OK); }
        }

        void button_profile_logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        void BUTTON_EDIT_FIO_Click(object sender, EventArgs e)
        {
            TextBox_profile_FIO.Enabled = !TextBox_profile_FIO.Enabled;
        }

        void BUTTON_EDIT_PASSWORD_Click(object sender, EventArgs e)
        {
            textBox_oldPassword.Enabled = !textBox_oldPassword.Enabled;
            textBox_newPassword.Enabled = !textBox_newPassword.Enabled;
            textBox_newPassword2.Enabled = !textBox_newPassword2.Enabled;
        }

        void BUTTON_EDIT_OTHER_Click(object sender, EventArgs e)
        {
            textBox_telephone.Enabled = !textBox_telephone.Enabled;
        }
        #endregion

        #region Доктора
        void button_addDoctors_Click(object sender, EventArgs e)
        {
            label_editDoctors.Text = "Добавление:";
            button_use_doctors.Text = "Добавить";
        }

        void button_editDoctors_Click(object sender, EventArgs e)
        {
            label_editDoctors.Text = "Редактирование:";
            button_use_doctors.Text = "Сохранить";
        }

        void button_delDoctors_Click(object sender, EventArgs e)
        {
            deleteRow(table_doctors, "id_doctor", "doctors");
        }

        void table_doctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_editDoctors.Checked)
            {
                textBox_doctors_FIO.Text = table_doctors.CurrentRow.Cells[1].Value.ToString();
                textBox_doctors_password.Text = table_doctors.CurrentRow.Cells[2].Value.ToString();
            }
        }

        void button_doctors_export_Click(object sender, EventArgs e)
        {
            import(button_doctors_export,table_doctors, "Фельдшеры");
        }

        void button_use_doctors_Click(object sender, EventArgs e)
        {
            frmRegister rg = new frmRegister();
            if (textBox_doctors_FIO.Text.Length > 5 && rg.noSimplePass(textBox_doctors_password.Text) == true)
            {
                if (button_addDoctors.Checked)
                {
                    // Добавление ключа
                    db.doctorAdd(textBox_doctors_FIO.Text, textBox_doctors_password.Text);
                }
                else if (button_editDoctors.Checked)
                {
                    //Редактирование ключа
                    db.editDoctors(table_doctors, "id_doctor", textBox_doctors_FIO.Text, textBox_doctors_password.Text);
                }
                FillAll();
                combo();
                progressUpp(1);
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Укажите настоящее ФИО и не простой пароль!</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }

        void button_cancel_doctors_Click(object sender, EventArgs e)
        {
            if (button_editDoctors.Checked)
            { button_addDoctors_Click(sender, e); button_addDoctors.Checked = true; }

            textBox_doctors_FIO.Text = "";
            textBox_doctors_password.Text = "";
        }
        #endregion

        #region Специальности
        void table_specialty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button_edit_specialty.Checked)
            {
                textBox_specialty_name.Text = table_specialty.CurrentRow.Cells[1].Value.ToString();
                textBox_specialty_cypher.Text = table_specialty.CurrentRow.Cells[2].Value.ToString();
            }
        }

        void button_add_specialty_Click(object sender, EventArgs e)
        {
            label_edit_specialty.Text = "Добавление:";
            button_use_specialty.Text = "Добавить";
        }

        void button_edit_specialty_Click(object sender, EventArgs e)
        {
            label_edit_specialty.Text = "Редактирование:";
            button_use_specialty.Text = "Сохранить";
        }

        void button_del_specialty_Click(object sender, EventArgs e)
        {
            deleteRow(table_specialty, "id_specialty", "specialty");
        }

        void button_export_specialty_Click(object sender, EventArgs e)
        {
            import(button_export_specialty,table_specialty, "Специальности");
        }

        void button_use_specialty_Click(object sender, EventArgs e)
        {
            if (textBox_specialty_name.Text.Length > 5 && textBox_specialty_cypher.Text.Length < 10)
            {
                if (button_add_specialty.Checked)
                {
                    // Добавление ключа
                    db.specialtyAdd(textBox_specialty_name.Text, textBox_specialty_cypher.Text);
                }
                else if (button_edit_specialty.Checked)
                {
                    //Редактирование ключа
                    db.editSpecialty(table_specialty, "id_specialty", textBox_specialty_name.Text, textBox_specialty_cypher.Text);
                }
                FillAll();
                combo();
                progressUpp(1);
            }
            else
            {
                _2DMessageBox.Show("<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> Пожалуйста, заполните все поля, корректно. <br><br><b><font color='#6B7BCF'>Укажите настоящую специальности и шифр не более 10 символов.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
        }

        void button_cancel_specialty_Click(object sender, EventArgs e)
        {
            if (button_edit_specialty.Checked)
            { button_add_specialty_Click(sender, e); button_add_specialty.Checked = true; }

            textBox_specialty_name.Text = "";
            textBox_specialty_cypher.Text = "";
        }
        #endregion

        #region Настройки
        public void scranSettings()
        {
            //
            button_resize.Visible = resize; // растягивание формы

            if (stat == true) { panel_stat.Visible = true; } // Статистика
            else { panel_stat.Visible = false; }

            if (pc == true) loadPK(); // Характеристика ПК
            else label_pc.Text = "Характеристика ПК, отключена в настройках программы..";

            if (updates == true) AutoUpdates(true); // Обновления
            else AutoUpdates(false);

            if (lowpc == true) lowPCmethod(true); // Слабый ПК
            else lowPCmethod(false);

            if (monitor == true) HightMonitor(true); // Монитор
            else HightMonitor(false);
        }

        public void lowPCmethod(bool enabled)
        {
            if (enabled == true)
            {
                panel_up.Visible = true;
                panel_left.Visible = true;
                panel_right.Visible = true;
                tab.Visible = true;
                //
                foreach (TabPage item in tab.Controls.OfType<TabPage>())
                {

                    foreach (Guna.UI2.WinForms.Guna2TextBox textBox in item.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                    {
                        textBox.Animated = false;
                    }

                    foreach (Guna.UI2.WinForms.Guna2Button кнопкаТипа in item.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
                    {
                        кнопкаТипа.Animated = false;
                    }

                    foreach (Guna.UI2.WinForms.Guna2ComboBox comboBox in item.Controls.OfType<Guna.UI2.WinForms.Guna2ComboBox>())
                    {
                        comboBox.Animated = false;
                    }

                    foreach (Guna.UI2.WinForms.Guna2ShadowPanel item2 in item.Controls.OfType<Guna.UI2.WinForms.Guna2ShadowPanel>())
                    {
                        item2.ShadowShift = 0;
                        // Переключатели
                        foreach (Guna.UI2.WinForms.Guna2ToggleSwitch item4 in item2.Controls.OfType<Guna.UI2.WinForms.Guna2ToggleSwitch>())
                        {
                            item4.Animated = false;
                        }
                    }

                }
                foreach (Guna.UI2.WinForms.Guna2Panel panel in this.Controls.OfType<Guna.UI2.WinForms.Guna2Panel>())
                {
                    foreach (Guna.UI2.WinForms.Guna2Button кнопкаТипа in panel.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
                    {
                        кнопкаТипа.Animated = false;
                    }
                }
            }
            else
            {
                animator.ShowSync(panel_up);
                animator.ShowSync(panel_left);
                animator.ShowSync(panel_right);
                animator.ShowSync(tab);
            }
        }

        public void HightMonitor(bool enabled)
        {
            if (enabled == true) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }


        public void AutoUpdates(bool enabled)
        {
            int border;
            int width, height, lbl_Width, lbl_height;
            List<Guna.UI2.WinForms.Guna2Button> listEditButtons = new List<Guna.UI2.WinForms.Guna2Button>()
            {
                button_Main,button_book,button_groups,button_teatchers,
                button_simptoms,button_doctors,button_specialty,button_Settings,
                button_Help

            };
            List<Label> listEditLabels = new List<Label>()
            {
                lbl_1,lbl_2,lbl_admin,lbl_others

            };
            if (enabled == false)
            {
                border = 14;
                //
                width = 206;
                height = 34;
                //
                lbl_Width = 210;
                lbl_height = 26;
                foreach (Guna.UI2.WinForms.Guna2Button item in listEditButtons.OfType<Guna.UI2.WinForms.Guna2Button>())
                {
                    item.BorderRadius = border;
                    item.Size = new System.Drawing.Size(width, height);
                }
                foreach (Label item in listEditLabels.OfType<Label>())
                {
                    item.Size = new System.Drawing.Size(lbl_Width, lbl_height);
                }
                button_Main.Location = new System.Drawing.Point(9, 92);
                button_book.Location = new System.Drawing.Point(9, 157);
                button_groups.Location = new System.Drawing.Point(9, 197);
                button_teatchers.Location = new System.Drawing.Point(9, 263);
                button_simptoms.Location = new System.Drawing.Point(9, 303);
                button_doctors.Location = new System.Drawing.Point(9, 454);
                button_specialty.Location = new System.Drawing.Point(9, 494);
                button_Settings.Location = new System.Drawing.Point(9, 560);
                button_Help.Location = new System.Drawing.Point(9, 600);
                //
                lbl_1.Location = new System.Drawing.Point(6, 129);
                lbl_2.Location = new System.Drawing.Point(6, 234);
                lbl_admin.Location = new System.Drawing.Point(6, 425);
                lbl_others.Location = new System.Drawing.Point(6, 531);
                //
                line_upperProfile.Visible = true;
            }

            else
            {
                border = 20;
                //
                width = 181;
                height = 45;
                //
                lbl_Width = 155;
                lbl_height = 26;
                foreach (Guna.UI2.WinForms.Guna2Button item in listEditButtons.OfType<Guna.UI2.WinForms.Guna2Button>())
                {
                    item.BorderRadius = border;
                    item.Size = new System.Drawing.Size(width, height);
                }
                foreach (Label item in listEditLabels.OfType<Label>())
                {
                    item.Size = new System.Drawing.Size(lbl_Width, lbl_height);
                }
                button_Main.Location = new System.Drawing.Point(31, 80);
                button_book.Location = new System.Drawing.Point(31, 158);
                button_groups.Location = new System.Drawing.Point(31, 209);
                button_teatchers.Location = new System.Drawing.Point(31, 286);
                button_simptoms.Location = new System.Drawing.Point(31, 337);
                button_doctors.Location = new System.Drawing.Point(31, 450);
                button_specialty.Location = new System.Drawing.Point(31, 500);
                button_Settings.Location = new System.Drawing.Point(31, 570);
                button_Help.Location = new System.Drawing.Point(31, 620);
                //
                lbl_1.Location = new System.Drawing.Point(40, 129);
                lbl_2.Location = new System.Drawing.Point(40, 257);
                lbl_admin.Location = new System.Drawing.Point(40, 425);
                lbl_others.Location = new System.Drawing.Point(40, 541);
                //
                line_upperProfile.Visible = false;
            }
        }

        void ResizeSwitch_Click(object sender, EventArgs e)
        {
            resize = ResizeSwitch.Checked;
            scranSettings();
        }

        void StatisticSwitch_Click(object sender, EventArgs e)
        {
            stat = StatisticSwitch.Checked;
            scranSettings();
        }

        void PCSwitch_Click(object sender, EventArgs e)
        {
            pc = PCSwitch.Checked;
            scranSettings();
        }

        void LowPCSwitch_Click(object sender, EventArgs e)
        {
            if (LowPCSwitch.Checked == true)
            {
                if (_2DMessageBox.Show("При включении режима 'Слабый ПК', возможны более долгие загрузки! <br><br>Вы уверены что хотите включить этот режим? <br><font size=10px>(программа будет перезагружена автоматически)</font>", "Слабый ПК", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lowpc = LowPCSwitch.Checked;
                    scranSettings();
                    Application.Restart();
                }
                else { LowPCSwitch.Checked = false; lowpc = false; }
            }
            else
            {
                if (_2DMessageBox.Show("Для более коректной работы при отключении данного режима, необходимо перезагрузить программу! <br><br>Хотите это сделать сейчас?", "Слабый ПК", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lowpc = LowPCSwitch.Checked;
                    scranSettings();
                    Application.Restart();
                }
                else { }
            }
        }

        void MonitorSwitch_Click(object sender, EventArgs e)
        {
            monitor = MonitorSwitch.Checked;
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
            //scranSettings();
        }

        void UpdatesSwitch_Click(object sender, EventArgs e)
        {
            if (_2DMessageBox.Show("Вы уверены что хотите включить/отключить режим Больших кнопок?<br><br>* Для этого необходимо перезагрузить программу", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                updates = UpdatesSwitch.Checked;
                AutoUpdates(UpdatesSwitch.Checked);
                Application.Restart();
            }
            else
            {
                UpdatesSwitch.Checked = !UpdatesSwitch.Checked;
            }
        }
        public bool panelLeft = true;
        void button_hidePanel_Click(object sender, EventArgs e)
        {
            button_hideLeftPanel.Enabled = false;
            panel_up.Enabled = false;
            List<Guna.UI2.WinForms.Guna2Button> listEditButtons = new List<Guna.UI2.WinForms.Guna2Button>()
            {
                button_Main,button_book,button_groups,button_teatchers,
                button_simptoms,button_doctors,button_specialty,button_Settings,
                button_Help

            };
            List<Label> listEditLabels = new List<Label>()
            {
                lbl_1,lbl_2,lbl_others,label_username,label_userStatus

            };
            if (panelLeft == true)
            {
                button_resize.Enabled = false;
                button_hideLeftPanel.Text = "Показать левую панель";
                //
                panel_left.Visible = false;
                //
                panel_left.Size = new Size(68, 735);
                button_hideLeftPanel.Image = Resources.icon_showPanel;
                //
                if (button_resize.FillColor == Color.White) label_NameProject.Text = "<font color='#FFFFFF'>W</font><b><font color='#6B7BCF'>A</font>";
                else label_NameProject.Text = "W<b><font color='#6B7BCF'>A</font>";
                //
                foreach (Guna.UI2.WinForms.Guna2Button item in listEditButtons.OfType<Guna.UI2.WinForms.Guna2Button>())
                {
                    item.ImageAlign = HorizontalAlignment.Center;
                    item.Size = new Size(40, 35);
                    item.BorderRadius = 15;
                    item.ImageOffset = new System.Drawing.Point(0, 0); // 12 ; 0
                    item.Text = "";
                }
                foreach (Label item in listEditLabels.OfType<Label>())
                {
                    item.Visible = false;
                }
                lbl_admin.Visible = false;
                //
                button_Main.Location = new System.Drawing.Point(13, 92);
                button_book.Location = new System.Drawing.Point(13, 157);
                button_groups.Location = new System.Drawing.Point(13, 197);
                button_teatchers.Location = new System.Drawing.Point(13, 263);
                button_simptoms.Location = new System.Drawing.Point(13, 303);
                button_doctors.Location = new System.Drawing.Point(13, 454);
                button_specialty.Location = new System.Drawing.Point(13, 494);
                button_Settings.Location = new System.Drawing.Point(13, 560);
                button_Help.Location = new System.Drawing.Point(13, 600);

                panel_left.Visible = true;
                button_resize.Enabled = true;
                panelLeft = false;
            }
            else
            {
                button_resize.Enabled = false;
                panel_left.Visible = false;

                if (status == "developer")
                    lbl_admin.Visible = true;
                else lbl_admin.Visible = false;

                button_hideLeftPanel.Text = "Спрятать левую панель";
                panel_left.Size = new Size(222, 735);
                button_hideLeftPanel.Image = Resources.icon_hidePanel;
                //
                if (button_resize.FillColor == Color.White) label_NameProject.Text = "<font color='#FFFFFF'>Wellness</font><b><font color='#6B7BCF'>App</font>";
                else label_NameProject.Text = "Wellness<b><font color='#6B7BCF'>App</font>";
                //
                foreach (Guna.UI2.WinForms.Guna2Button item in listEditButtons.OfType<Guna.UI2.WinForms.Guna2Button>())
                {
                    item.ImageAlign = HorizontalAlignment.Left;
                    item.ImageOffset = new Point(12, 0);
                }
                foreach (Label item in listEditLabels.OfType<Label>())
                {
                    item.Visible = true;
                }
                button_Main.Text = "Главная";
                button_book.Text = "Журнал учёта";
                button_groups.Text = "Группы";
                button_teatchers.Text = "Кураторы";
                button_simptoms.Text = "Ж/Л";
                button_doctors.Text = "Фельдшеры";
                button_specialty.Text = "Специальности";
                button_Settings.Text = "Настройки";
                button_Help.Text = "Помощь";
                //
                AutoUpdates(true);
                //
                panel_left.Visible = true;
                button_resize.Enabled = true;
                panelLeft = true;
            }
            button_hideLeftPanel.Enabled = true;
            panel_up.Enabled = true;
        }

        public bool panelRight = true;
        void button_hideRightPanel_Click(object sender, EventArgs e)
        {
            button_hideRightPanel.Enabled = false;
            panel_up.Enabled = false;
            if (panelRight == true)
            {
                panel_right.Visible = false;
                frmSettings.ResizeForm = true;
                panel_right.Size = new Size(0, 0);
                button_hideRightPanel.Image = Resources.icon_showPanel;
                button_hideRightPanel.Text = "Показать правую панель";
                panelRight = false;
            }
            else
            {
                panel_right.Size = new Size(205, 698);
                frmSettings.ResizeForm = false;
                button_hideRightPanel.Image = Resources.icon_hidePanel;
                button_hideRightPanel.Text = "Спрятать правую панель";
                panelRight = true;
                panel_right.Visible = true;
            }
            button_hideRightPanel.Enabled = true;
            panel_up.Enabled = true;
        }
        async void button_settingsRestart_Click(object sender, EventArgs e)
        {
            if (_2DMessageBox.Show("Вы уверены что хотите перезагрузить программу?", "Перезапуск", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 1; i < 5; i++)
                {
                    await Task.Delay(1000);
                    this.Alert($"Программа будет перезагружена через: {i} секунду(-ы).", frmNotification.enmType.Info);
                }
                Application.Restart();

                Settings.Default["progress"] = progress;
                Settings.Default["dark"] = dark;

                Settings.Default.Save();
            }
        }

        void button_settingsLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void button_settingsAboutDEV_Click(object sender, EventArgs e)
        {
            _2DMessageBox.Show("<font color='#6B7BCF'><b>О разработчике:</b></font><br><br> Бельдей Егор Григорьевич<br>Ученик Молодеченского Торгово-экономического колледжа<br>Язык программирования: C# <br><br><b><font color='#6B7BCF'>©2017-2021.</b></font>",
                "О разработчике.", MessageBoxButtons.OK);
        }

        async void button_settingsAboutApp_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 7;
            button_Help.Checked = true;
            Color cl = label_aboutApp.ForeColor;

            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(500);
                label_aboutApp.ForeColor = Color.FromArgb(107, 123, 207);
                await Task.Delay(500);
                label_aboutApp.ForeColor = cl;
            }
        }
        #endregion

        #region Помощь
        // ОПА A ТУТ НИЧЕГО НЕТ)))
        #endregion

        #region Переходы
        private void label_username_DoubleClick(object sender, EventArgs e)
        {
            tab.SelectedIndex = 4;
        }
        void button_vk_Click(object sender, EventArgs e)
        {
            Process.Start("https://vk.com/eas1ly");
        }

        private void button_instagramm_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/eas1ly/");
        }

        private void button_telegram_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/eas1ly");
        }

        private void button_twitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/044eas1ly");
        }
        void button_Main_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        void button_active_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 5;
        }

        void button_groups_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 2;
        }

        void button_teatchers_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 4;
        }

        void button_like_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 11;
        }
        void button_Help_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 7;
        }

        void button_students_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 3;
        }
        void button_spravka_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 10;
        }

        void button_book_AddWarn_Click_1(object sender, EventArgs e)
        {
            tab.SelectedIndex = 5;
            button_simptoms.Checked = true;
        }

        void button_book_AddHelp_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 5;
            button_simptoms.Checked = true;
        }
        void button_book_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 1;
        }
        #endregion

        #region Другое
        public void deleteRow(DataGridView table, string id, string tableDB)
        {
            if (_2DMessageBox.Show("Вы уверены что хотите удалить запись?<br><br>" +
                                    "Учтите что удалятся все связанные с ней данные!", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Thread(() =>
                {
                    Invoke((Action)(() =>
                    {
                        foreach (DataGridViewCell oneCell in table.SelectedCells)
                        {
                            if (oneCell.Selected)
                            {
                                db.deleteRow(table, id, tableDB);
                                table.Rows.RemoveAt(oneCell.RowIndex);
                                FillAll();
                            }
                        }
                    }));
                }).Start();
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default["progress"] = progress;
            Settings.Default["dark"] = dark;
            //
            Settings.Default["resizeToggle"] = resize;
            Settings.Default["statToggle"] = stat;
            Settings.Default["pcToggle"] = pc;
            Settings.Default["lowToggle"] = lowpc;
            Settings.Default["monitorToggle"] = monitor;
            Settings.Default["updatesToggle"] = updates;

            Settings.Default.Save();

            Application.Exit();
        }

        public void Alert(string msg, frmNotification.enmType type)
        {
            frmNotification frm = new frmNotification();
            frm.showAlert(msg, type);
        }

        void button_Settings_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 6;
        }

        void progressBar_progress_ValueChanged(object sender, EventArgs e)
        {
            progress = progressBar_progress.Value;
        }

        async void progressUpp(int kol)
        {
            for (int i = 0; i < kol; i++)
            {
                if (progressBar_progress.Value != 100)
                    progressBar_progress.Value++;

                await Task.Delay(500);
            }
        }
        async void import(Guna.UI2.WinForms.Guna2Button button,DataGridView table, string table_name)
        {
            button.Enabled = false;

            frmImport importForm = new frmImport();

            importForm.spravka = false;
            importForm.table = table;
            importForm.table_name = table_name;
            importForm.Show();
            frmExist = true;

            ln1:
            if (importForm.Visible == true)
            {
                await Task.Delay(3000);
                goto ln1;
            } else { button.Enabled = true; }
        }

        void checkInternet_Tick(object sender, EventArgs e)
        {
            //LOADING.Visible = true;
            //new Thread(() =>
            //{
            //    Invoke((Action)(() =>
            //    {
            //        if (Internet.CheckConnection()) { }
            //        else
            //        {
            //            _2DMessageBox.Show("<font color='#6B7BCF'><b>Упс... найдена проблема:</b></font><br><br> Вы пытаетесь использовать программу без доступа к интернету. <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно отсутстует или оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            //            Application.Exit();
            //        }
            //    }));
            //}).Start();
        }

        void TIMER2_Tick(object sender, EventArgs e)
        {
            LOADING.Visible = false;
        }

        void ThemeChanger(Color cl_borderText, Color cl_panel, Color cl_label, Color cl_buttonHold, Color cl_buttronPress, Color cl_mainPanel, Color cl_resizeBox, Color cl_progressBar, string NameProject)
        {
            // PANEL
            foreach (Guna.UI2.WinForms.Guna2Panel panel in this.Controls.OfType<Guna.UI2.WinForms.Guna2Panel>())
            {
                panel.BackColor = cl_panel;
                panel.ForeColor = cl_label;
            }
            foreach (Guna.UI2.WinForms.Guna2Button item in panel_left.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                item.FillColor = cl_panel;
                item.ForeColor = cl_label;
                //
                item.CheckedState.FillColor = cl_buttronPress;
                item.HoverState.FillColor = cl_buttonHold;
            }
            //TAB
            foreach (TabPage item in tab.Controls.OfType<TabPage>())
            {
                foreach (Guna.UI2.WinForms.Guna2Panel pn in item.Controls.OfType<Guna.UI2.WinForms.Guna2Panel>())
                {
                    foreach (Guna.UI2.WinForms.Guna2DataGridView table in pn.Controls.OfType<Guna.UI2.WinForms.Guna2DataGridView>())
                    {
                        table.BackgroundColor = cl_panel;
                        table.GridColor = cl_panel;

                        table.ThemeStyle.RowsStyle.ForeColor = cl_label;
                        table.ThemeStyle.AlternatingRowsStyle.BackColor = cl_panel;
                        table.ThemeStyle.BackColor = cl_panel;
                        table.ThemeStyle.RowsStyle.BackColor = cl_panel;

                        table.ThemeStyle.RowsStyle.SelectionBackColor = cl_mainPanel; // Выбр строчка
                        table.ThemeStyle.RowsStyle.SelectionForeColor = cl_label; // Выбр текст в строчке
                    }
                }
                item.BackColor = cl_mainPanel;
                foreach (Guna.UI2.WinForms.Guna2DataGridView table in item.Controls.OfType<Guna.UI2.WinForms.Guna2DataGridView>())
                {
                    table.BackgroundColor = cl_panel;
                    table.GridColor = cl_panel;

                    table.ThemeStyle.RowsStyle.ForeColor = cl_label;
                    table.ThemeStyle.AlternatingRowsStyle.BackColor = cl_panel;
                    table.ThemeStyle.BackColor = cl_panel;
                    table.ThemeStyle.RowsStyle.BackColor = cl_panel;

                    table.ThemeStyle.RowsStyle.SelectionBackColor = cl_mainPanel; // Выбр строчка
                    table.ThemeStyle.RowsStyle.SelectionForeColor = cl_label; // Выбр текст в строчке
                }
                foreach (Guna.UI2.WinForms.Guna2TextBox textBox in item.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                {
                    textBox.DisabledState.BorderColor = cl_borderText;
                    textBox.DisabledState.FillColor = cl_panel;
                    textBox.DisabledState.ForeColor = cl_label;

                    textBox.ForeColor = cl_label;
                    textBox.FillColor = cl_panel;
                    textBox.BorderColor = cl_borderText;
                }
                foreach (Guna.UI2.WinForms.Guna2DateTimePicker time in item.Controls.OfType<Guna.UI2.WinForms.Guna2DateTimePicker>())
                {
                    time.BorderColor = cl_borderText;
                    time.FillColor = cl_panel;
                }
                foreach (Guna.UI2.WinForms.Guna2ComboBox comboBox in item.Controls.OfType<Guna.UI2.WinForms.Guna2ComboBox>())
                {
                    comboBox.BorderColor = cl_borderText;
                    comboBox.FillColor = cl_panel;
                }
                foreach (Guna.UI2.WinForms.Guna2ShadowPanel item2 in item.Controls.OfType<Guna.UI2.WinForms.Guna2ShadowPanel>())
                {
                    item2.FillColor = cl_panel;
                    foreach (Guna.UI2.WinForms.Guna2DataGridView table in item2.Controls.OfType<Guna.UI2.WinForms.Guna2DataGridView>())
                    {
                        table.BackgroundColor = cl_panel;
                        table.GridColor = cl_panel;

                        table.ThemeStyle.RowsStyle.ForeColor = cl_label;
                        table.ThemeStyle.AlternatingRowsStyle.BackColor = cl_panel;
                        table.ThemeStyle.BackColor = cl_panel;
                        table.ThemeStyle.RowsStyle.BackColor = cl_panel;

                        table.ThemeStyle.RowsStyle.SelectionBackColor = cl_mainPanel; // Выбр строчка
                        table.ThemeStyle.RowsStyle.SelectionForeColor = cl_label; // Выбр текст в строчке
                    }
                    foreach (Guna.UI2.WinForms.Guna2TextBox textBox in item2.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                    {
                        textBox.DisabledState.BorderColor = cl_borderText;
                        textBox.DisabledState.FillColor = cl_panel;
                        textBox.DisabledState.ForeColor = cl_label;

                        textBox.FillColor = cl_panel;
                        textBox.ForeColor = cl_label;
                        textBox.BorderColor = cl_borderText;
                    }
                    foreach (Guna.UI2.WinForms.Guna2HtmlLabel item3 in item2.Controls.OfType<Guna.UI2.WinForms.Guna2HtmlLabel>())
                    {
                        item3.ForeColor = cl_label;
                    }
                    // Переключатели
                    foreach (Guna.UI2.WinForms.Guna2ToggleSwitch item4 in item2.Controls.OfType<Guna.UI2.WinForms.Guna2ToggleSwitch>())
                    {
                        item4.UncheckedState.FillColor = cl_mainPanel;
                    }
                }
                foreach (Guna.UI2.WinForms.Guna2Panel gunaPanel in item.Controls.OfType<Guna.UI2.WinForms.Guna2Panel>())
                {
                    foreach (Guna.UI2.WinForms.Guna2TextBox textBox in gunaPanel.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                    {
                        textBox.FillColor = cl_panel;
                        textBox.BorderColor = cl_borderText;
                    }

                    foreach (Guna.UI2.WinForms.Guna2DateTimePicker time in gunaPanel.Controls.OfType<Guna.UI2.WinForms.Guna2DateTimePicker>())
                    {
                        time.BorderColor = cl_borderText;
                        time.FillColor = cl_panel;
                    }

                    foreach (Guna.UI2.WinForms.Guna2ComboBox comboBox in gunaPanel.Controls.OfType<Guna.UI2.WinForms.Guna2ComboBox>())
                    {
                        comboBox.BorderColor = cl_borderText;
                        comboBox.FillColor = cl_panel;
                    }
                }
            }
            // other controls
            label_NameProject.Text = NameProject;
            label_2Teacher2.Text = NameProject;
            //
            label_userStatus.ForeColor = cl_label;
            label_username.ForeColor = cl_label;
            //
            CheckBox_Spravka.ForeColor = cl_label;
            //
            panel_up.BackColor = cl_panel;
            //
            //
            button_resize.FillColor = cl_resizeBox;
            //
            panel_sizeDB.FillColor = cl_mainPanel;
            panel_stat.FillColor = cl_mainPanel;
            guna2Panel6.FillColor = cl_mainPanel;
            //
            progressDataBaseSize2.FillColor = cl_progressBar;
            progressBar_progress.FillColor = cl_progressBar;
            progressDataBaseSize.FillColor = cl_progressBar;
            //
            this.BackColor = cl_panel;
            //
            ShadowPanel_main1.FillColor = cl_panel;

            ShadowPanel_main2.FillColor = cl_panel;

            ShadowPanel_main3.FillColor = cl_panel;

            ShadowPanel_main4.FillColor = cl_panel;
            // 
            HelpTip.BackColor = cl_panel;
            HelpTip.ForeColor = cl_label;
            //
            List<Guna.UI2.WinForms.Guna2HtmlLabel> listLabels;

            listLabels = new List<Guna.UI2.WinForms.Guna2HtmlLabel>()
            {
                label_headActive,label_groupsList,label_teachersList,label_warns,label_helps,label_studentsList,
                label_listKeys,lbl_contacts,lbl_statistics,label_groups_edit,label_teachers_edit,label_teachers_edit,label_keys_edit,
                label_aboutProject,label_database,label_pc,label_Message,label_dev,guna2HtmlLabel1,guna2HtmlLabel3,guna2HtmlLabel8,label_listDoctors,
                label_editDoctors,label_listSpecialty,label_edit_specialty

            };
            foreach (Guna.UI2.WinForms.Guna2HtmlLabel item in listLabels.OfType<Guna.UI2.WinForms.Guna2HtmlLabel>())
            {
                item.ForeColor = cl_label;
            }
            // BUTTONS
            List<Guna.UI2.WinForms.Guna2Button> listButtons;

            listButtons = new List<Guna.UI2.WinForms.Guna2Button>()
            {
                button_bookAdd,button_editBook,button_delBook,
                button_viewGroup,button_addGroup,button_editGroup,button_delGroup,
                button_viewStudent,button_addStudent,button_editStudent,button_delStudent,
                button_addTeacher,button_editTeacher,button_delTeacher,
                button_bookAdd,button_editBook,button_delBook,
                button_addKeys,button_editKeys,button_delKeys,
                button_addWarn,button_editWarn,button_delWarn,
                button_addHelp,button_editHelp,button_delHelp,
                button_exportHelp,
                button_book_export,
                button_students,
                button_groups_import,
                button_students_import,
                button_teachers_import,
                button_gotoKeys,
                button_import_keys,
                button_randomKey,
                button_book_AddWarn,
                button_bookView,
                button_book_AddHelp,
                button_exportWarn,
                button_profile_save,
                button_profile_logout,
                button_book_export_spravka,
                button_addDoctors,button_editDoctors,button_delDoctors,button_doctors_export,
                button_add_specialty,button_edit_specialty,button_del_specialty,button_export_specialty,
                button_hideLeftPanel,button_hideRightPanel

            };
            foreach (Guna.UI2.WinForms.Guna2Button item in listButtons.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                item.CheckedState.FillColor = cl_panel;
                item.HoverState.FillColor = cl_buttonHold;
                item.FillColor = cl_mainPanel;
                item.ForeColor = cl_label;
            }
        }
        void Theme(bool light)
        {
            if (light == false)
            {
                if (panel_left.Size == new Size(222, 735))
                ThemeChanger(Color.FromArgb(52, 52, 55), Color.FromArgb(45, 45, 48), Color.FromArgb(241, 241, 241), Color.FromArgb(62, 62, 64), Color.FromArgb(27, 27, 28),
                    Color.FromArgb(28, 28, 28), Color.White, Color.LightGray, "<font color='#FFFFFF'>Wellness</font><b><font color='#6B7BCF'>App</font>");
                else ThemeChanger(Color.FromArgb(52, 52, 55), Color.FromArgb(45, 45, 48), Color.FromArgb(241, 241, 241), Color.FromArgb(62, 62, 64), Color.FromArgb(27, 27, 28),
                    Color.FromArgb(28, 28, 28), Color.White, Color.LightGray, "<font color='#FFFFFF'>W</font><b><font color='#6B7BCF'>A</font>");

                dark = true;
            }
            else
            {
                if (panel_left.Size == new Size(222, 735))
                    ThemeChanger(Color.FromArgb(213, 218, 223), Color.White, Color.Black, Color.White, Color.FromArgb(225, 229, 245), Color.FromArgb(239, 242, 252),
                    Color.Black, Color.White, "Wellness<b><font color='#6B7BCF'>App</font>");
                else ThemeChanger(Color.FromArgb(213, 218, 223), Color.White, Color.Black, Color.White, Color.FromArgb(225, 229, 245), Color.FromArgb(239, 242, 252),
                    Color.Black, Color.White, "W<b><font color='#6B7BCF'>A</font>");
                dark = false;
            }
            Settings.Default["dark"] = dark;
            Settings.Default.Save();
        }

        void ThemeSwitch_Click(object sender, EventArgs e)
        {
            if (ThemeSwitch.Checked == true)
                Theme(false);
            else
                Theme(true);
        }

        void label_darkTheme_Click(object sender, EventArgs e)
        {
            ThemeSwitch.Checked = true;
            Theme(false);
        }

        void label_lightTheme_Click(object sender, EventArgs e)
        {
            ThemeSwitch.Checked = false;
            Theme(true);
        }
        void panel_up_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        void button_settingsPath_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Environment.CurrentDirectory);
        }
        #endregion
    }
}
