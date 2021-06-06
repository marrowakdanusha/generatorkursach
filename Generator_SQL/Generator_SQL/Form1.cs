using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Generator_SQL
{
    public partial class Form1 : Form
    {
        string[] first_name = { "Кирилл", "Майкл", "Василий", "Егор", "Аннетто", "Никита", "Кирилл", "Владимир", "Богдан", "Максим", "Дмитрий", "Ярослав", "Евгений", "Даниил" };
        string[] last_name = { "Бакалин", "Белычев", "Глазков", "Голуб", "Зайцев", "Коренко", "Коржевич", "Кумской", "Левшин", "Леонов", "Овчаренко", "Решетняк", "Овсянников", "Чумарин" };
        string[] patronymic = { "Максимович", "Александрович", "Евгеньевич", "Валерьевич", "Ярославович", "Сергеевич", "Дмитриевич", "Владимирович", "Владиславович", "Юрьевич" };
        string[] city = {"Донецк","Кировоград", "Днепропетровск", "Киев", "Воронеж","Житомир","Ровно","Осло", "Оттава", "Алушта", "Алупка", "Астана", "Владивосток" };
        string[] socialstatus= { "Служащий", "Пенсионер", "Студент", "Безработный", "Школьник", "Молодая_мама", "Домохозяйка", "Специалист", "Рабочий", "Руководитель", "Священник"};
        string[] adress = { "Щорса", "Артёма", "Арбат", " Абакумова", "Баумана", "Ветеринарная", "Возрождения", "Горбачевского", "Героическая", "Градостроителей", "Днепродзержинская", "Землянская", "Коммунаров", "Комсомольский", "Щетинина" };
        string[] job = { "Слесарь", "Актёр", "Киберспортмен", "Служанка", "Преподаватель", "Фотограф", "Архитектор", "Дизайнер", "Художник", "Повар", "Режиссер", "Астронафт", "Президент", "Мэр", "Кинокритик", "Музыкант", "Журналист", "Священник", "Программист",};
        string[] day = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17","18","19","20","21","22","23","24","25","26","27","28","29","30","31" };
        string[] month = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        string[] year = { "2003", "2002", "2000", "1999", "1998", "1997", "1995", "1992", "1989", "1986", "1984", "1956", "1978", "1990", "2001", "1996", "1994", "1960", "1962", "1975", "1974", "1971", "1963", "1967", "1969", "1979", "1957", "1950", "1966", "1978", "1959", "1977"};

        bool connect;
        NpgsqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var connString = $"Host=127.0.0.1;Username=postgres;Password=Denxds2000EDGE;Database=Hostel";
            connection = new NpgsqlConnection(connString);
            try
            {
                await connection.OpenAsync();
                connect = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Вход в БД не был выполнен.Проверьте параметры");
                connect = false;
                Environment.Exit(0);
            }

            if (connect == true)
            { 

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand GEN_SQL=new NpgsqlCommand();
            Random rnd = new Random();
            DataTable data = new DataTable();
            DataTable data1 = new DataTable();
            NpgsqlDataAdapter reader;
            switch (comboBox1.SelectedItem)
            {
                case "Клиенты":
                    for (int i = 0; i < 10500; i++)
                    {
                        GEN_SQL = new NpgsqlCommand($"INSERT INTO client(surname_client, name_client, patronymic_client, id_city, adress, id_socialstatus, job, birthday) VALUES ('{last_name[rnd.Next(1, last_name.Length)]}','{first_name[rnd.Next(1, first_name.Length)]}','{patronymic[rnd.Next(1, patronymic.Length)]}',{rnd.Next(1,6)},'{adress[rnd.Next(1, adress.Length)]}',{rnd.Next(4,12)},'{job[rnd.Next(1, job.Length)]}', '{day[rnd.Next(1, day.Length)]}.{month[rnd.Next(1, month.Length)]}.{year[rnd.Next(1, year.Length)]}')", connection);
                        try
                        {
                            GEN_SQL.ExecuteNonQuery();
                        }
                        catch (Exception exp) { continue; }
                    }
                    break;
            }

                    MessageBox.Show("всё готово");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            
        }

        private void очиститьБазуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string deleteRowSQL="",Update_ID="";
            NpgsqlCommand deleteCommand;
            NpgsqlCommand updateCommand;
            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
            updateCommand= new NpgsqlCommand(Update_ID, connection);

                            Update_ID = "ALTER SEQUENCE autoschool_id_autoschool_seq RESTART WITH 1" + ";" +
                                        "UPDATE autoschool SET id_autoschool = DEFAULT";
                            deleteRowSQL = "DELETE FROM autoschool";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand.ExecuteNonQuery();
                            Update_ID = "ALTER SEQUENCE district_id_district_seq RESTART WITH 1" + ";" +
                                        "UPDATE district SET id_district = DEFAULT";
                            deleteRowSQL = " DELETE FROM district";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE type_of_property_id_type_of_property_seq RESTART WITH 1" + ";" +
                            "UPDATE type_of_property SET id_type_of_property = DEFAULT";
                            deleteRowSQL = $" DELETE FROM type_of_property";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE category_id_category_seq RESTART WITH 1" + ";" +
                            "UPDATE category SET id_category = DEFAULT";
                            deleteRowSQL = $" DELETE FROM category";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE socialstate_id_social_state_seq RESTART WITH 1" + ";" +
                            "UPDATE socialstate SET id_social_state = DEFAULT";
                            deleteRowSQL = $" DELETE FROM socialstate";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE automodel_id_seq RESTART WITH 1" + ";" +
                            "UPDATE automodel SET id_automodel = DEFAULT";
                            deleteRowSQL = $" DELETE FROM automodel";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE student_id_student_seq RESTART WITH 1" + ";" +
                            "UPDATE student SET id_student = DEFAULT";
                            deleteRowSQL = " DELETE FROM student";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE employee_id_employee_seq RESTART WITH 1" + ";" +
                            "UPDATE employee SET id_employee = DEFAULT";
                            deleteRowSQL = " DELETE FROM employee";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE automodel_notes_id_autonotes_seq RESTART WITH 1" + ";" +
                            "UPDATE automodel_notes SET id_autonotes = DEFAULT";
                            deleteRowSQL = " DELETE FROM automodel_notes";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE cource_id_cource_seq RESTART WITH 1" + ";" +
                            "UPDATE cource SET id_cource = DEFAULT";
                            deleteRowSQL = " DELETE FROM cource";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE lessons_id_lesson_seq RESTART WITH 1" + ";" +
                            "UPDATE lessons SET id_lesson = DEFAULT";
                            deleteRowSQL = " DELETE FROM lessons";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE type_auto_id_typeauto_seq RESTART WITH 1" + ";" +
                            "UPDATE type_auto SET id_typeauto = DEFAULT";
                            deleteRowSQL = " DELETE FROM type_auto";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();

                            Update_ID = "ALTER SEQUENCE groups_id_group_seq RESTART WITH 1" + ";" +
                            "UPDATE groups SET id_group = DEFAULT";
                            deleteRowSQL = $" DELETE FROM groups";
                            deleteCommand = new NpgsqlCommand(deleteRowSQL, connection);
                            deleteCommand.ExecuteNonQuery();
                            updateCommand = new NpgsqlCommand(Update_ID, connection);
                            updateCommand.ExecuteNonQuery();
                            MessageBox.Show("Все данные из базы удалены!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
