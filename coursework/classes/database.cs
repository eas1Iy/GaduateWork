using coursework.dialogs;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace coursework.classes
{
    public class database
    {
        #region Переменные
        static string host = "localhost"; // sql11.freesqldatabase.com
        static string user = "mysql"; // sql11399548
        static string pass = "mysql"; // SpTZ3a*{четыре последние буквы у разработчика}*
        static string db = "database"; // sql11399548
        static int port = 3306;
        //
        public double size;
        MySqlDataAdapter dataAdapter;
        DataTable bufferTable;
        #endregion

        #region Подключение
        MySqlConnection connection = new MySqlConnection($"server={host};port={port};username={user};password={pass};charset=utf8;database={db};Persist Security Info=True;");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        #endregion

        #region Заполнение
        public DataTable fillBook()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT `id_book`, students.id_student, students.FIO, " +
                                                   "warns.id_warn, warns.sickness, " +
                                                   "help.id_help, help.help, " +
                                                   "doctors.id_doctor, doctors.FIO, " +
                                                   "Spravka_From, Spravka_To, Date " +
                                                   "From `book` " +
                                                   "Inner Join students on students.id_student=book.id_student " +
                                                   "Inner Join warns on warns.id_warn=book.id_warn " +
                                                   "Inner Join help on help.id_help=book.id_help " +
                                                   "Inner Join doctors on doctors.id_doctor=book.id_doctor", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillGroups()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT `id_group`,Number, teachers.id_teacher, specialty.id_specialty,teachers.FIO, specialty.name,Date_Join,specialty.cypher FROM `groups` " +
                                                   "Inner Join teachers on teachers.id_teacher=groups.id_teacher " +
                                                   "Inner Join specialty on specialty.id_specialty=groups.id_specialty", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillStudents()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT `id_student`, groups.id_group, groups.Number, " +
                                                   "specialty.id_specialty, specialty.cypher, " +
                                                   "FIO, Blood, Gender, DateBirth, Adres, Telephone, Others FROM `students` " +
                                                   "Inner Join groups on groups.id_group=students.id_group " +
                                                   "Inner Join specialty on groups.id_specialty=specialty.id_specialty", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillTeatchers()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM `teachers`", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillKey()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM `keys`", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillWarns()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM `warns`", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillHelp()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM `help`", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillDoctors()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM `doctors`", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public DataTable fillSpecialty()
        {
            bufferTable = new DataTable();
            openConnection();
            try
            {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM `specialty`", connection);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                closeConnection();
            }
            return bufferTable;
        }
        public int getSizeDb()
        {
            openConnection();
            string sql = "SELECT sum( data_length + index_length )/1024/1024 'Data Base Size in MB' FROM information_schema.TABLES Where table_schema='" + db + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            size = Convert.ToDouble(reader[0]);
            int intSize = Convert.ToInt32(Math.Round(size, 1) * 10);

            closeConnection();
            return intSize;
        }
        public void combobox(Guna.UI2.WinForms.Guna2ComboBox c, string query, string displaymember, string valuemember)
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                c.DataSource = datatable;
                c.DisplayMember = displaymember;
                c.ValueMember = valuemember;
                //c.SelectedIndex = 0;
            }
        }
        #endregion

        #region Добавление
        public void BookAdd(int id_student, int id_warn, int id_help, int id_doctor, DateTime Spravka_From, DateTime Spravka_To, DateTime Date)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `book`(`id_student`,`id_warn`,`id_help`,`id_doctor`, `Spravka_From`, `Spravka_To`,`Date`) VALUES (@учащийся,@жалоба,@лечение,@доктор, @справкаС, @справкаПО, @Дата)";

                cmd.Parameters.Add("@учащийся", MySqlDbType.Int32);
                cmd.Parameters["@учащийся"].Value = id_student;

                cmd.Parameters.Add("@жалоба", MySqlDbType.Int32);
                cmd.Parameters["@жалоба"].Value = id_warn;

                cmd.Parameters.Add("@лечение", MySqlDbType.Int32);
                cmd.Parameters["@лечение"].Value = id_help;

                cmd.Parameters.Add("@доктор", MySqlDbType.Int32);
                cmd.Parameters["@доктор"].Value = id_doctor;

                cmd.Parameters.Add("@справкаС", MySqlDbType.DateTime);
                cmd.Parameters["@справкаС"].Value = Spravka_From;

                cmd.Parameters.Add("@справкаПО", MySqlDbType.DateTime);
                cmd.Parameters["@справкаПО"].Value = Spravka_To;

                cmd.Parameters.Add("@Дата", MySqlDbType.DateTime);
                cmd.Parameters["@Дата"].Value = Date;

                cmd.ExecuteNonQuery();
                this.Alert("Запись успешно добавленна.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();

        }
        public void GroupAdd(int id_teacher, int id_specialty, string Number, DateTime Date_Join)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;


                cmd.CommandText = "INSERT INTO `groups`(`id_teacher`, `id_specialty`, `Number`, `Date_Join`) VALUES (@куратор, @специальность, @номер, @годПоступления)";

                cmd.Parameters.Add("@куратор", MySqlDbType.Int32);
                cmd.Parameters["@куратор"].Value = id_teacher;

                cmd.Parameters.Add("@специальность", MySqlDbType.Int32);
                cmd.Parameters["@специальность"].Value = id_specialty;

                cmd.Parameters.Add("@номер", MySqlDbType.VarChar);
                cmd.Parameters["@номер"].Value = Number;

                cmd.Parameters.Add("@годПоступления", MySqlDbType.DateTime);
                cmd.Parameters["@годПоступления"].Value = Date_Join;

                cmd.ExecuteNonQuery();
                this.Alert("Группа успешно добавленна.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void studentAdd(int id_group, string FIO, string Blood, string Gender, DateTime DateBirth, string Adres, string Telephone, string Others)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;


                cmd.CommandText = "INSERT INTO `students`(`id_group`, `FIO`, `Blood`, `Gender`,`DateBirth`,`Adres`,`Telephone`,`Others`) VALUES (@группа, @фио, @кровь, @пол,@рождение,@адрес,@телефон,@другое)";

                cmd.Parameters.Add("@группа", MySqlDbType.Int32);
                cmd.Parameters["@группа"].Value = id_group;

                cmd.Parameters.Add("@фио", MySqlDbType.VarChar);
                cmd.Parameters["@фио"].Value = FIO;

                cmd.Parameters.Add("@кровь", MySqlDbType.VarChar);
                cmd.Parameters["@кровь"].Value = Blood;

                cmd.Parameters.Add("@пол", MySqlDbType.VarChar);
                cmd.Parameters["@пол"].Value = Gender;

                cmd.Parameters.Add("@рождение", MySqlDbType.DateTime);
                cmd.Parameters["@рождение"].Value = DateBirth;

                cmd.Parameters.Add("@адрес", MySqlDbType.VarChar);
                cmd.Parameters["@адрес"].Value = Adres;

                cmd.Parameters.Add("@телефон", MySqlDbType.VarChar);
                cmd.Parameters["@телефон"].Value = Telephone;

                cmd.Parameters.Add("@другое", MySqlDbType.VarChar);
                cmd.Parameters["@другое"].Value = Others;

                cmd.ExecuteNonQuery();
                this.Alert("Учащийся успешно добавлен.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void TeacherAdd(string FIO, string number, string password) // edit - true(создание) ; edit - false(регистрация)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO `teachers`(`FIO`, `telephone`,`password`) VALUES (@FIO,@number,@password)";

                cmd.Parameters.Add("@FIO", MySqlDbType.VarChar);
                cmd.Parameters["@FIO"].Value = FIO;

                cmd.Parameters.Add("@number", MySqlDbType.VarChar);
                cmd.Parameters["@number"].Value = number;

                cmd.Parameters.Add("@password", MySqlDbType.VarChar);
                cmd.Parameters["@password"].Value = password;

                cmd.ExecuteNonQuery();
                this.Alert("Учитель успешно добавлен.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void KeyAdd(string key)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO `keys`(`key`) VALUES (@key)";

                cmd.Parameters.Add("@key", MySqlDbType.VarChar);
                cmd.Parameters["@key"].Value = key;

                cmd.ExecuteNonQuery();
                this.Alert("Ключ доступа успешно добавлен.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void warnAdd(string warn)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO `warns`(`sickness`) VALUES (@warn)";

                cmd.Parameters.Add("@warn", MySqlDbType.VarChar);
                cmd.Parameters["@warn"].Value = warn;

                cmd.ExecuteNonQuery();
                this.Alert("Жалоба успешно добавленна.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void helpAdd(string help)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO `help`(`help`) VALUES (@help)";

                cmd.Parameters.Add("@help", MySqlDbType.VarChar);
                cmd.Parameters["@help"].Value = help;

                cmd.ExecuteNonQuery();
                this.Alert("Лечение успешно добавленно.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void doctorAdd(string FIO, string password)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO `doctors`(`FIO`,`password`) VALUES (@FIO,@password)";

                cmd.Parameters.Add("@FIO", MySqlDbType.VarChar);
                cmd.Parameters["@FIO"].Value = FIO;

                cmd.Parameters.Add("@password", MySqlDbType.VarChar);
                cmd.Parameters["@password"].Value = password;

                cmd.ExecuteNonQuery();
                this.Alert("Фельдшер успешно добавлен.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void specialtyAdd(string name, string cypher)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO `specialty`(`name`,`cypher`) VALUES (@nm,@cp)";

                cmd.Parameters.Add("@nm", MySqlDbType.VarChar);
                cmd.Parameters["@nm"].Value = name;

                cmd.Parameters.Add("@cp", MySqlDbType.VarChar);
                cmd.Parameters["@cp"].Value = cypher;

                cmd.ExecuteNonQuery();
                this.Alert("Специальность успешно добавленна.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка добавления.", MessageBoxButtons.OK);
                this.Alert("Запись не добавлена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        #endregion

        #region Редактирование
        public void editBook(DataGridView table, string id, int id_student, int id_warn, int id_help, int id_doctor, DateTime Spravka_From, DateTime Spravka_To, DateTime Date)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `book` SET `id_student`=@учащийся,`id_warn`=@жалоба,`id_help`=@лечение,`id_doctor`=@доктор,`Spravka_From`=@справкаС,`Spravka_To`=@справкаПО,`Date`=@Дата WHERE `id_book`=" + row[id];

                        cmd.Parameters.Add("@учащийся", MySqlDbType.Int32);
                        cmd.Parameters["@учащийся"].Value = id_student;

                        cmd.Parameters.Add("@жалоба", MySqlDbType.Int32);
                        cmd.Parameters["@жалоба"].Value = id_warn;

                        cmd.Parameters.Add("@лечение", MySqlDbType.Int32);
                        cmd.Parameters["@лечение"].Value = id_help;

                        cmd.Parameters.Add("@доктор", MySqlDbType.Int32);
                        cmd.Parameters["@доктор"].Value = id_doctor;

                        cmd.Parameters.Add("@справкаС", MySqlDbType.DateTime);
                        cmd.Parameters["@справкаС"].Value = Spravka_From;

                        cmd.Parameters.Add("@справкаПО", MySqlDbType.DateTime);
                        cmd.Parameters["@справкаПО"].Value = Spravka_To;

                        cmd.Parameters.Add("@Дата", MySqlDbType.DateTime);
                        cmd.Parameters["@Дата"].Value = Date;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editGroups(DataGridView table, string id, int id_teatcher, int id_specialty, string name, DateTime yearJoin)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `groups` SET `id_teacher`=@учитель, `id_specialty`=@специальность,`Number`=@name,`Date_Join`=@year WHERE `id_group`=" + row[id];

                        cmd.Parameters.Add("@учитель", MySqlDbType.Int32);
                        cmd.Parameters["@учитель"].Value = id_teatcher;

                        cmd.Parameters.Add("@специальность", MySqlDbType.Int32);
                        cmd.Parameters["@специальность"].Value = id_specialty;

                        cmd.Parameters.Add("@name", MySqlDbType.VarChar);
                        cmd.Parameters["@name"].Value = name;

                        cmd.Parameters.Add("@year", MySqlDbType.DateTime);
                        cmd.Parameters["@year"].Value = yearJoin;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editStudents(DataGridView table, string id, int id_group, string FIO, string Blood, string Gender, DateTime DateBirth, string Adres, string Telephone, string Others)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `students` SET `id_group`=@группа, `FIO`=@фио,`Blood`=@кровь,`Gender`=@пол,`DateBirth`=@рождение,`Adres`=@адрес,`Telephone`=@телефон,`Others`=@другое  WHERE `id_student`=" + row[id];

                        cmd.Parameters.Add("@группа", MySqlDbType.Int32);
                        cmd.Parameters["@группа"].Value = id_group;

                        cmd.Parameters.Add("@фио", MySqlDbType.VarChar);
                        cmd.Parameters["@фио"].Value = FIO;

                        cmd.Parameters.Add("@кровь", MySqlDbType.VarChar);
                        cmd.Parameters["@кровь"].Value = Blood;

                        cmd.Parameters.Add("@пол", MySqlDbType.VarChar);
                        cmd.Parameters["@пол"].Value = Gender;

                        cmd.Parameters.Add("@рождение", MySqlDbType.DateTime);
                        cmd.Parameters["@рождение"].Value = DateBirth;

                        cmd.Parameters.Add("@адрес", MySqlDbType.VarChar);
                        cmd.Parameters["@адрес"].Value = Adres;

                        cmd.Parameters.Add("@телефон", MySqlDbType.VarChar);
                        cmd.Parameters["@телефон"].Value = Telephone;

                        cmd.Parameters.Add("@другое", MySqlDbType.VarChar);
                        cmd.Parameters["@другое"].Value = Others;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editTeatchers(DataGridView table, string id, string FIO, string number, string password)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `teachers` SET `FIO`=@фио,`telephone`=@телефон,`password`=@пароль WHERE `id_teacher`=" + row[id];

                        cmd.Parameters.Add("@фио", MySqlDbType.VarChar);
                        cmd.Parameters["@фио"].Value = FIO;

                        cmd.Parameters.Add("@телефон", MySqlDbType.VarChar);
                        cmd.Parameters["@телефон"].Value = number;

                        cmd.Parameters.Add("@пароль", MySqlDbType.VarChar);
                        cmd.Parameters["@пароль"].Value = password;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editKeys(DataGridView table, string find, string key)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `keys` SET `key`=@ключ WHERE `id_key`=" + row[find];

                        cmd.Parameters.Add("@ключ", MySqlDbType.VarChar);
                        cmd.Parameters["@ключ"].Value = key;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editWarn(DataGridView table, string id, string warn)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `warns` SET `sickness`=@warn WHERE `id_warn`=" + row[id];

                        cmd.Parameters.Add("@warn", MySqlDbType.VarChar);
                        cmd.Parameters["@warn"].Value = warn;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editHelp(DataGridView table, string id, string help)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `help` SET `help`=@help WHERE `id_help`=" + row[id];

                        cmd.Parameters.Add("@help", MySqlDbType.VarChar);
                        cmd.Parameters["@help"].Value = help;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editDoctors(DataGridView table, string id, string FIO, string password)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `doctors` SET `FIO`=@FIO,`password`=@password WHERE `id_doctor`=" + row[id];

                        cmd.Parameters.Add("@FIO", MySqlDbType.VarChar);
                        cmd.Parameters["@FIO"].Value = FIO;

                        cmd.Parameters.Add("@password", MySqlDbType.VarChar);
                        cmd.Parameters["@password"].Value = password;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void editSpecialty(DataGridView table, string id, string name, string cypher)
        {
            openConnection();
            try
            {
                foreach (DataGridViewCell oneCell in table.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        DataRow row = (table.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;

                        cmd.CommandText = "UPDATE `specialty` SET `name`=@nm,`cypher`=@cp WHERE `id_specialty`=" + row[id];

                        cmd.Parameters.Add("@nm", MySqlDbType.VarChar);
                        cmd.Parameters["@nm"].Value = name;

                        cmd.Parameters.Add("@cp", MySqlDbType.VarChar);
                        cmd.Parameters["@cp"].Value = cypher;

                        cmd.ExecuteNonQuery();
                    }
                }
                //
                this.Alert("Запись успешно сохранена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка редактирования.", MessageBoxButtons.OK);
                this.Alert("Запись не сохранена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void updateProfile(bool teacher, bool updatePass,int id, string FIO, string password, string number)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                if (teacher == true)
                {
                    if (updatePass == true)
                    cmd.CommandText = "UPDATE `teachers` SET `FIO`=@фио,`telephone`=@телефон,`password`=@пароль WHERE `id_teacher`=" + id;
                    else
                    cmd.CommandText = "UPDATE `teachers` SET `FIO`=@фио,`telephone`=@телефон WHERE `id_teacher`=" + id;

                    cmd.Parameters.Add("@фио", MySqlDbType.VarChar);
                    cmd.Parameters["@фио"].Value = FIO;

                    cmd.Parameters.Add("@телефон", MySqlDbType.VarChar);
                    cmd.Parameters["@телефон"].Value = number;

                    cmd.Parameters.Add("@пароль", MySqlDbType.VarChar);
                    cmd.Parameters["@пароль"].Value = password;
                }
                else
                {
                    if (updatePass == true)
                        cmd.CommandText = "UPDATE `doctors` SET `FIO`=@фио,`password`=@пароль WHERE `id_doctor`=" + id;
                    else
                        cmd.CommandText = "UPDATE `doctors` SET `FIO`=@фио WHERE `id_doctor`=" + id;

                    cmd.Parameters.Add("@фио", MySqlDbType.VarChar);
                    cmd.Parameters["@фио"].Value = FIO;

                    cmd.Parameters.Add("@пароль", MySqlDbType.VarChar);
                    cmd.Parameters["@пароль"].Value = password;
                }
                cmd.ExecuteNonQuery();
                this.Alert("Профиль успешно сохранен.", frmNotification.enmType.Success);
                closeConnection();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка проверки ключа.", MessageBoxButtons.OK);
                closeConnection();
            }
        }
        #endregion

        #region Другое
        public string getProfile(int id)
        {
            string number;
            openConnection();
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter selectif = new MySqlDataAdapter($"SELECT `telephone` FROM `teachers` WHERE `id_teacher`=" + id, connection);
                selectif.Fill(dt);
                number = dt.Rows[0][0].ToString();

                closeConnection();
                return number;
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка проверки ключа.", MessageBoxButtons.OK);
                closeConnection();
                return "error";
            }
        }
        public string getPassword(bool teacher, int id)
        {
            openConnection();
            try
            {
                string password;
                DataTable dt = new DataTable();
                if (teacher == true)
                {
                    MySqlDataAdapter selectif = new MySqlDataAdapter($"SELECT `password` FROM `teachers` WHERE `id_teacher`=" +id, connection);
                    selectif.Fill(dt);
                    password = dt.Rows[0][0].ToString();

                    closeConnection();
                    return password;
                }
                else 
                {
                    MySqlDataAdapter selectif = new MySqlDataAdapter($"SELECT `password` FROM `doctors` WHERE `id_doctor`=" +id, connection);
                    selectif.Fill(dt);
                    password = dt.Rows[0][0].ToString();

                    closeConnection();
                    return password;
                }
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка проверки ключа.", MessageBoxButtons.OK);
                closeConnection();
                return "error";
            }
        }
        public bool keyExist(string key)
        {
            openConnection();
            try
            {
                MySqlDataAdapter selectif = new MySqlDataAdapter("SELECT `key` FROM `keys`", connection);
                DataTable dt = new DataTable();
                selectif.Fill(dt);
                bool exists = dt.AsEnumerable().Where(c => c.Field<string>("key").Equals(key)).Count() > 0;
                if (exists == true)
                {
                    updateKey(key);
                    closeConnection();
                    return true;
                }
                else
                {
                    this.Alert("Ошибка, ключ не найден.", frmNotification.enmType.Error);
                    closeConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка проверки ключа.", MessageBoxButtons.OK);
                closeConnection();
                return false;
            }

        }
        public void updateKey(string key)
        {
            openConnection();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "DELETE FROM `keys` WHERE `key`=@ключ";

                cmd.Parameters.Add("@ключ", MySqlDbType.VarChar);
                cmd.Parameters["@ключ"].Value = key;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show($"<font color='#6B7BCF'><b>Подробнее о ошибке:</b></font><br><br> {ex.Message} <br><br><b><font color='#6B7BCF'>Проверьте соединение с интернетом, возможно оно не стабильно.</b></font>", "Ошибка.", MessageBoxButtons.OK);
            }
            closeConnection();
        }
        public void deleteRow(DataGridView tables, string id, string table)
        {
            openConnection();
            try
            {
                DataRow row = (tables.SelectedRows[0].DataBoundItem as DataRowView).Row;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "DELETE FROM `" + table + "` WHERE `" + id + "` = " + row[id];

                cmd.ExecuteNonQuery();
                this.Alert("Запись успешно удалена.", frmNotification.enmType.Success);
            }
            catch (Exception ex)
            {
                _2DMessageBox.Show(ex.Message, "Ошибка удаления.", MessageBoxButtons.OK);
                this.Alert("Запись не удалена, ошибка.", frmNotification.enmType.Error);
            }
            closeConnection();
        }
        public void Alert(string msg, frmNotification.enmType type)
        {
            frmNotification frm = new frmNotification();
            frm.showAlert(msg, type);
        }
        #endregion
    }
}
