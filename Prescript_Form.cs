using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Milk_factory
{
    public partial class Prescript_Form : Form
    {
        public SqlConnection con;

        public Prescript_Form()
        {
            InitializeComponent();

            form_cleaner();
            combo1_loader("Все");
        }

        double to_dbl(string combo)
        {
            double rtn = 0;

            try { rtn = System.Convert.ToDouble(combo.Replace(".", ",")); } catch { }

            return Math.Round(rtn, 3);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox16.Text += to_dbl("аав").ToString() + "\n";
            clear_cointer();
            dataGridView1.Rows.Clear();   

            add_grid();
            button2.Enabled = true;
        }

        bool catch_data()
        {
            bool catch_data = false;
            double a = 0; try { a = System.Convert.ToDouble(richTextBox1.Text); }
            catch { }
            double b = 0; try { b = System.Convert.ToDouble(richTextBox2.Text); }
            catch { }
            double c = 0; try { c = System.Convert.ToDouble(richTextBox4.Text); }
            catch { }
            double d = 0; try { d = System.Convert.ToDouble(richTextBox7.Text); }
            catch { }
            double e = 0; try { e = System.Convert.ToDouble(richTextBox9.Text); }
            catch { }
            
            if (a != 0 && (b != 0 || c != 0) && (d != 0 || e != 0)) { catch_data = true; }

            return catch_data;
        }
        void next_start()
        {
            //richTextBox16.Text += "function working\n";
            if (catch_data() == true) { button1.Enabled = true; }
            else { button1.Enabled = false; }

            clear_enabler();
        }
        void clear_enabler()
        {
            double cups = (to_dbl(richTextBox1.Text) / 0.15);
            label9.Text = Math.Round(cups, 0).ToString() + " штук";

            double a = to_dbl(richTextBox2.Text);
            double b = to_dbl(richTextBox4.Text);

            if (a != 0 && b == 0) { richTextBox4.Enabled = false; } else { richTextBox4.Enabled = true; }
            if (b != 0 && a == 0) { richTextBox2.Enabled = false; } else { richTextBox2.Enabled = true; }
            //if (b == 0 && a == 0) { richTextBox2.Enabled = false; } else { richTextBox2.Enabled = true; }

            double c = to_dbl(richTextBox7.Text);
            double d = to_dbl(richTextBox9.Text);

            if (c != 0 && d == 0) { richTextBox9.Enabled = false; } else { richTextBox9.Enabled = true; }
            if (d != 0 && c == 0) { richTextBox7.Enabled = false; } else { richTextBox7.Enabled = true; }

            double m = to_dbl(richTextBox5.Text);
            double n = to_dbl(richTextBox3.Text);

            if (m != 0 && n == 0) { richTextBox3.Enabled = false; } else { richTextBox3.Enabled = true; }
            if (n != 0 && m == 0) { richTextBox5.Enabled = false; } else { richTextBox5.Enabled = true; }

            double p = to_dbl(richTextBox6.Text);
            double r = to_dbl(richTextBox8.Text);

            if (p != 0 && r == 0) { richTextBox8.Enabled = false; } else { richTextBox8.Enabled = true; }
            if (r != 0 && p == 0) { richTextBox6.Enabled = false; } else { richTextBox6.Enabled = true; }

            
        }
        void clear_cointer()
        {
            double a = to_dbl(richTextBox2.Text);
            double b = to_dbl(richTextBox4.Text);

            if (a != 0) { richTextBox4.Text = (100 - a).ToString(); } else { richTextBox4.Enabled = false; }
            if (b != 0) { richTextBox2.Text = (100 - b).ToString(); } else { richTextBox2.Enabled = false; }

            double c = to_dbl(richTextBox7.Text);
            double d = to_dbl(richTextBox9.Text);

            double dry = to_dbl(richTextBox2.Text);

            double fat_dry = 0;
            if (richTextBox7.Text != string.Empty) { fat_dry = to_dbl(richTextBox7.Text); }

            double fat_product = 0;
            if (richTextBox9.Text != string.Empty) { fat_product = to_dbl(richTextBox9.Text); }

            if (c != 0) { richTextBox9.Text = Math.Round((fat_dry * dry / 100), 3).ToString(); } else { richTextBox9.Enabled = false; }
            if (d != 0) { richTextBox7.Text = Math.Round((fat_product * 100 / dry), 3).ToString(); } else { richTextBox7.Enabled = false; }

            if (to_dbl(richTextBox9.Text) >= 100 || to_dbl(richTextBox7.Text) >= 100)
            {
                richTextBox7.Enabled = true;
                richTextBox9.Enabled = true;
                richTextBox7.Clear();
                richTextBox9.Clear();
            }
            //Дополнительные параметры
            double m = to_dbl(richTextBox3.Text);
            double n = to_dbl(richTextBox5.Text);

            if (m != 0) { richTextBox5.Text = (100 - m).ToString(); } else { richTextBox5.Enabled = false; }
            if (n != 0) { richTextBox3.Text = (100 - n).ToString(); } else { richTextBox3.Enabled = false; }

            double p = to_dbl(richTextBox6.Text);
            double r = to_dbl(richTextBox8.Text);

            double dry2 = to_dbl(richTextBox3.Text);

            double fat_dry2 = 0;
            if (richTextBox6.Text != string.Empty) { fat_dry2 = to_dbl(richTextBox6.Text); }

            double fat_product2 = 0;
            if (richTextBox8.Text != string.Empty) { fat_product2 = to_dbl(richTextBox8.Text); }

            if (p != 0) { richTextBox8.Text = Math.Round((fat_dry2 * dry2 / 100), 3).ToString(); } else { richTextBox8.Enabled = false; }
            if (r != 0) { richTextBox6.Text = Math.Round((fat_product2 * 100 / dry2), 3).ToString(); } else { richTextBox6.Enabled = false; }

            if (to_dbl(richTextBox8.Text) >= 100 || to_dbl(richTextBox6.Text) >= 100)
            {
                richTextBox6.Enabled = true;
                richTextBox8.Enabled = true;
                richTextBox6.Clear();
                richTextBox8.Clear();
            }
        }     
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            next_start(); 
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }
        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }
        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }
        private void richTextBox9_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }
        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }
        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }
        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }
        private void richTextBox8_TextChanged(object sender, EventArgs e)
        {
            next_start();
        }

//Заполнение гридов данными
        double qty_cost(string name, int ID_goods)
        {
            double cost = 0;

            SqlCommand c = new SqlCommand("select sum, dds, qty from goods where ID = " + ID_goods + " and name = '" + name + "';", con);
            SqlDataReader cs = c.ExecuteReader();
            cs.Read();
            double sum = cs.GetDouble(0);
            double dds = cs.GetDouble(1);
            double qty = cs.GetDouble(2);
            cs.Close();

            if (dds != 0)
            {
                cost = (sum / qty) / 6 * 5;
            }
            else
            {
                cost = sum / qty;
            }

            return Math.Round(cost, 2);
        }
        void add_grid()
        {
            //      int count = dataGridView1.Rows.Count - 1;//считать число строк с гриде
            //      dataGridView1.Rows[1].Cells["Общая_цена"].Value = "555"; //вставлять значение
            //      dataGridView1.Rows.Remove(dataGridView1.Rows[1]);//удаляет нужную строку
            //      double a = 0;
            //     for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            //     {
            //         a += System.Convert.ToDouble(dataGridView1.Rows[m].Cells["Общая_цена"].Value.ToString());//получение нужного значения   
            //     }
            //     richTextBox1.Text += a + "\n";
            SqlCommand b = new SqlCommand("select count(*) from goods where subgroup = 'Консерванты' or subgroup = 'Загустители' or subgroup = 'Сырье' or subgroup ='Добавки' or subgroup = 'Химикаты';", con);
            SqlDataReader cb = b.ExecuteReader();
            cb.Read();
            int counts = cb.GetInt32(0);
            cb.Close();

            string[,] array = new string[5, counts];
            
            string dry = string.Empty;
            string fat = string.Empty;
            string cal = string.Empty;
            string protein = string.Empty;
            string carbonates = string.Empty;
            string pH = string.Empty;

            int cnt = 0;

            SqlCommand c = new SqlCommand("select name, subgroup, qty, cost, ID from goods where subgroup = 'Консерванты' or subgroup = 'Загустители' or subgroup = 'Сырье' or subgroup ='Добавки' or subgroup = 'Химикаты';", con);
            SqlDataReader cs = c.ExecuteReader();
            while (cs.Read())
            {
                array[0, cnt] = cs.GetString(0).TrimEnd();//name
                array[1, cnt] = cs.GetString(1).TrimEnd();//subgroup
                array[2, cnt] = cs.GetDouble(2).ToString();//qty
                array[3, cnt] = cs.GetDouble(3).ToString();//cost
                array[4, cnt] = cs.GetInt32(4).ToString();//ID

                cnt += 1;
            }
            cs.Close();

            for (int q = 0; q < counts; q++)
            {
                //richTextBox16.Text += array[0, q] + "\n";
                dataGridView1.Rows.Add(false, array[0, q].TrimEnd(), "", "", "", info_before("fat", System.Convert.ToInt32(array[4, q]), array[0, q]), info_before("dry", System.Convert.ToInt32(array[4, q]), array[0, q]), info_before("cal", System.Convert.ToInt32(array[4, q]), array[0, q]), info_before("protein", System.Convert.ToInt32(array[4, q]), array[0, q]), info_before("carbonates", System.Convert.ToInt32(array[4, q]), array[0, q]), "0"/*NaCl добавить потом*/, info_before("pH", System.Convert.ToInt32(array[4, q]), array[0, q]), array[1, q].TrimEnd(), array[2, q].ToString(), qty_cost(array[0, q], System.Convert.ToInt32(array[4, q])), array[4, q].ToString());
                
                dry = string.Empty;
                fat = string.Empty;
                cal = string.Empty;
                protein = string.Empty;
                carbonates = string.Empty;
                pH = string.Empty;
            }
        }
        void repeat_grid_cleaner()
        {
            int cnt_array = dataGridView1.Rows.Count - 1;
            string[] repeat_mass = new string[cnt_array];
            int[] del_array = new int[cnt_array];
            int cnt = 0;
            bool v = false;

            for (int m = 0, n = cnt_array; m < n; m++)
            {
                string name = dataGridView1.Rows[m].Cells["Наименование"].Value.ToString();
                //richTextBox16.Text += m + " " + name + "\n";
                v = false;

                for (int r = 0; r < cnt_array; r++)
                {
                    if (name == repeat_mass[r])
                    {
                        //richTextBox16.Text += m + " " + name + " array " + repeat_mass[r] + "\n";
                        for (int t = 0; t < cnt_array; t++)
                        {
                            if (m == del_array[t])
                            {
                                v = true;
                            }
                        }
                        if (v != true)
                        {
                            cnt += 1;
                            del_array[cnt] = m;
                        }
                    }
                }
                repeat_mass[m] = name;
            }
            for (int d = cnt_array - 1; d > 0; d--)
            {                
                if (del_array[d] != 0)
                {
                    //richTextBox16.Text += del_array[d] + "\n";
                    dataGridView1.Rows.Remove(dataGridView1.Rows[del_array[d]]);//удаляет нужную строку
                }
            }
        }
        double info_before(string cell, int ID, string name)
        {
            double info = 0;

            SqlCommand c = new SqlCommand("select eik from goods where ID = " + ID + ";", con);
            SqlDataReader cs = c.ExecuteReader();
            cs.Read();
            int eik = cs.GetInt32(0);
            cs.Close();

            SqlCommand f = new SqlCommand("select count(*) from analyzes where (" + cell + " is not null and " + cell + " <> 0) and name = '" + name + "' and eik = '" + eik.ToString() + "';", con);
            SqlDataReader fs = f.ExecuteReader();
            fs.Read();
            int count = fs.GetInt32(0);
            fs.Close();

            if (count != 0)
            {
                SqlCommand b = new SqlCommand("select max(make_date) from analyzes where (" + cell + " is not null and " + cell + " <> 0) and name = '" + name + "' and eik = '" + eik.ToString() + "';", con);
                SqlDataReader bs = b.ExecuteReader();
                bs.Read();
                DateTime make_date = bs.GetDateTime(0);
                bs.Close();

                SqlCommand a = new SqlCommand("select " + cell + " from analyzes where name = '" + name + "' and eik = '" + eik.ToString() + "' and make_date = '" + make_date + "';", con);
                SqlDataReader ds = a.ExecuteReader();
                ds.Read();
                info = ds.GetDouble(0);
                ds.Close();
            }

            return info;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 2)
            {
                int ID = System.Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                string name = dataGridView1.Rows[e.RowIndex].Cells["Наименование"].Value.ToString();
                //richTextBox16.Text += ID + " - " + name + "\n";

                if (e.ColumnIndex != 3 && e.ColumnIndex != 4)
                {

                    Prescript_fnflizes F = new Prescript_fnflizes(ID, name);
                    F.ShowDialog();

                    dataGridView1.Rows[e.RowIndex].Cells["Сухое"].Value = F.dry;
                    dataGridView1.Rows[e.RowIndex].Cells["Жир"].Value = F.fat;
                    dataGridView1.Rows[e.RowIndex].Cells["Калории"].Value = F.cal;
                    dataGridView1.Rows[e.RowIndex].Cells["Белок"].Value = F.protein;
                    dataGridView1.Rows[e.RowIndex].Cells["Углеводы"].Value = F.carbohydrates;
                    dataGridView1.Rows[e.RowIndex].Cells["pH"].Value = F.pH;
                }
                else
                {

                    Prescript_min_max F = new Prescript_min_max();
                    F.mainForm = this;
                    F.ShowDialog();

                    //richTextBox16.Text += "Выбран максимум " + max_border + " и минимум " + min_border + "\n";

                    dataGridView1.Rows[e.RowIndex].Cells["Мин"].Value = min_border;
                    dataGridView1.Rows[e.RowIndex].Cells["Макс"].Value = max_border;

                }
            }
        
        }
        public double min_border = 0;
        public double max_border = 0;
        

//Сохранение и загрузка рецептур
        private void button2_Click(object sender, EventArgs e)
        {
            clear_cointer();
            richTextBox17.Visible = true;

            if (checkBox1.Checked == true)
            {
                if (richTextBox17.Enabled == false)
                {
                    //Введение наименования
                    richTextBox17.Enabled = true;
                }
                if (richTextBox17.Text != "" && richTextBox17.Enabled == true && comboBox2.Text != "Все" && comboBox1.Text == "")//comboBox2.Text != "Используемые"
                {
                    //Сама процедура сохранения
                    prescript_saver();

                    richTextBox17.Clear();
                    richTextBox17.Enabled = false;
                    richTextBox17.Visible = false;
                    richTextBox2.Text = "";
                    richTextBox7.Text = "";
                }
                else
                {
                    richTextBox16.Text += "Не все поля заполнены\n";
                }
            }
            else 
            { 
                //Прописать процедуру сохранения изменений в рецепте
                SqlCommand c = new SqlCommand("select count(*) from prescript where name = '" + richTextBox17.Text + "';", con);
                SqlDataReader cs = c.ExecuteReader();
                cs.Read();
                int cnt = cs.GetInt32(0);
                cs.Close();

                if (cnt != 0)
                {
                    SqlCommand d = new SqlCommand("select ID, group_of from prescript where name = '" + richTextBox17.Text + "';", con);
                    SqlDataReader cd = d.ExecuteReader();
                    cd.Read();
                    int ID_for_change = cd.GetInt32(0);
                    comboBox2.Text = cd.GetString(1).TrimEnd();
                    cd.Close();

                    using (SqlCommand ins = new SqlCommand("delete from prescript_components where ID = " + ID_for_change + ";", con))
                    {
                        ins.ExecuteNonQuery();
                    }
                    
                    grid_saver(ID_for_change);
                    clear_cointer();

                    string wet = to_dbl(richTextBox4.Text).ToString().Replace(",",".");
                    string dry = to_dbl(richTextBox2.Text).ToString().Replace(",", ".");
                    string fat = to_dbl(richTextBox9.Text).ToString().Replace(",", ".");
                    string fat_dry = to_dbl(richTextBox7.Text).ToString().Replace(",", ".");
                    string cal = to_dbl(richTextBox11.Text).ToString().Replace(",", ".");
                    string protein = to_dbl(richTextBox13.Text).ToString().Replace(",", ".");
                    string carbohedrates = to_dbl(richTextBox15.Text).ToString().Replace(",", ".");

                    using (SqlCommand com = new SqlCommand("update prescript set carbohydrates = " + carbohedrates + ", protein = " + protein + ", cal = " + cal + ", fat_dry = " + fat_dry + ", fat = " + fat + ", dry = " + dry + ",wet = " + wet + ", make_date = '" + DateTime.Now + "' where ID = " + ID_for_change + ";", con))
                    {
                        com.ExecuteNonQuery();
                    }
                }
            }
        }
        void form_cleaner()
        {
            label1.Text = "Количество ( кг. )";
            label3.Text = "Влага";
            label4.Text = "Жир в сухом веществе";
            label9.Text = string.Empty;
            label2.Text = string.Empty;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox5.Checked = true;
            button1.Enabled = false;
            button2.Enabled = false;
            richTextBox17.Visible = false;
            richTextBox17.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            dataGridView1.Rows.Clear();
            richTextBox1.Text = "100";
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
            richTextBox7.Clear();
            richTextBox8.Clear();
            richTextBox9.Clear();
            richTextBox10.Clear();
            richTextBox11.Clear();
            richTextBox12.Clear();
            richTextBox13.Clear();
            richTextBox14.Clear();
            richTextBox15.Clear();
            comboBox2.Items.Add("Все");
            comboBox2.Items.Add("Используемые");
            comboBox2.Items.Add("Эксперимент");
            comboBox2.Items.Add("Расчеты");
            comboBox2.Items.Add("Конкуренты");
            comboBox2.Text = "Все";
        }
        void prescript_saver()
        {
            SqlCommand c = new SqlCommand("select count(*) from prescript;", con);
            SqlDataReader cs = c.ExecuteReader();
            cs.Read();
            int ID_prescript = cs.GetInt32(0);
            cs.Close();
            
            if (ID_prescript == 0)
            {
                ID_prescript = 1;
            }
            else
            {
                SqlCommand d = new SqlCommand("select max(ID) from prescript;", con);
                SqlDataReader cd = d.ExecuteReader();
                cd.Read();
                ID_prescript = cd.GetInt32(0) + 1;
                cd.Close();
            }

            string name = ID_prescript.ToString() + "_" + richTextBox17.Text;
            string group_of = richTextBox17.Text;

            double wet = to_dbl(richTextBox4.Text);
            double dry = to_dbl(richTextBox2.Text);
            double fat = to_dbl(richTextBox9.Text);
            double fat_dry = to_dbl(richTextBox7.Text);
            double cal = to_dbl(richTextBox11.Text);
            double protein = to_dbl(richTextBox13.Text);
            double carbonates = to_dbl(richTextBox15.Text);

            double wet2 = to_dbl(richTextBox5.Text);
            double dry2 = to_dbl(richTextBox3.Text);
            double fat2 = to_dbl(richTextBox8.Text);
            double fat_dry2 = to_dbl(richTextBox6.Text);
            double cal2 = to_dbl(richTextBox10.Text);
            double protein2 = to_dbl(richTextBox12.Text);
            double carbonates2 = to_dbl(richTextBox14.Text);

            using (SqlCommand ins = new SqlCommand("INSERT INTO prescript (fat2, dry2, wet2, fat_dry2, cal2, protein2, carbohydrates2, fat, wet, dry, fat_dry, protein, cal, carbohydrates, name, ID, group_of, make_date) VALUES (" + fat2.ToString().Replace(",", ".") + ", " + dry2.ToString().Replace(",", ".") + ", " + wet2.ToString().Replace(",", ".") + ", " + fat_dry2.ToString().Replace(",", ".") + ", " + cal2.ToString().Replace(",", ".") + "," + protein2.ToString().Replace(",", ".") + ", " + carbonates2.ToString().Replace(",", ".") + ", " + fat.ToString().Replace(",", ".") + ", " + wet.ToString().Replace(",", ".") + ", " + dry.ToString().Replace(",", ".") + ", " + fat_dry.ToString().Replace(",", ".") + ", " + protein.ToString().Replace(",", ".") + ", " + cal.ToString().Replace(",", ".") + ", " + carbonates.ToString().Replace(",", ".") + ", '" + name + "', " + ID_prescript + ", '" + comboBox2.Text + "', '" + DateTime.Now + "');", con))
            {
                ins.ExecuteNonQuery();
            }
            grid_saver(ID_prescript);
       
        }
        void grid_saver(int ID_prescript)
        {
            double fat = 0;
            double dry = 0;
            double protein = 0;
            double cal = 0;
            double carbohydrates = 0;
            double pH = 0;
            string subgroup = string.Empty;
            double min = 0;
            double max = 0;
            double qty = 0;
            string name = string.Empty;
                        
            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    fat = to_dbl(dataGridView1.Rows[m].Cells["Жир"].Value.ToString());
                    dry = to_dbl(dataGridView1.Rows[m].Cells["Сухое"].Value.ToString());
                    cal = to_dbl(dataGridView1.Rows[m].Cells["Калории"].Value.ToString());
                    carbohydrates = to_dbl(dataGridView1.Rows[m].Cells["Углеводы"].Value.ToString());
                    protein = to_dbl(dataGridView1.Rows[m].Cells["Белок"].Value.ToString());
                    pH = to_dbl(dataGridView1.Rows[m].Cells["pH"].Value.ToString());
                    subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();
                    min = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                    max = to_dbl(dataGridView1.Rows[m].Cells["Макс"].Value.ToString());
                    qty = to_dbl(dataGridView1.Rows[m].Cells["Вес"].Value.ToString());
                    name = dataGridView1.Rows[m].Cells["Наименование"].Value.ToString();

                    using (SqlCommand ins = new SqlCommand("INSERT INTO prescript_components (qty, name, fat, dry, protein, cal, carbohydrates, pH, ID, subgroup, make_date, min_at, max_at) VALUES (" + qty.ToString().Replace(",", ".") + ", '" + name + "'," + fat.ToString().Replace(",", ".") + ", " + dry.ToString().Replace(",", ".") + ", " + protein.ToString().Replace(",", ".") + ", " + cal.ToString().Replace(",", ".") + ", " + carbohydrates.ToString().Replace(",", ".") + ", " + pH.ToString().Replace(",", ".") + ", " + ID_prescript.ToString() + ", '" + subgroup + "', '" + DateTime.Now + "', " + min.ToString().Replace(",", ".") + ", " + max.ToString().Replace(",", ".") + ");", con))
                    {
                        ins.ExecuteNonQuery();
                    }
                }                
            }
            richTextBox16.Text += "Запись сделана\n";
        }
        void combo1_loader(string combo2)
        {
            string obl = @"Data Source=VAIO\SQLEXPRESS;Initial Catalog=milk_factory;Integrated Security=True;";
            SqlConnection on = new SqlConnection(obl);
            on.Open();

            comboBox1.Items.Clear();
            
            if (combo2 == "Все" || combo2 == "")
            {
                SqlCommand c = new SqlCommand("select name from prescript;", on);
                SqlDataReader cs = c.ExecuteReader();
                while (cs.Read())
                {
                    comboBox1.Items.Add(cs.GetString(0));
                }
                cs.Close();
            }
            else
            {
                SqlCommand c = new SqlCommand("select name from prescript where group_of = '" + combo2 + "';", on);
                SqlDataReader cs = c.ExecuteReader();
                while (cs.Read())
                {
                    comboBox1.Items.Add(cs.GetString(0));
                }
                cs.Close();
            }

            on.Close();
        }
        void prescript_loader()
        {
            SqlCommand c = new SqlCommand("select wet, dry, fat, fat_dry, cal, protein, carbohydrates, ID, dry2, wet2, fat_dry2, fat2, cal2, protein2, carbohydrates2 from prescript where name = '" + comboBox1.Text + "';", con);
            SqlDataReader cs = c.ExecuteReader();
            cs.Read();
            richTextBox4.Text = cs.GetDouble(0).ToString();
            richTextBox2.Text = cs.GetDouble(1).ToString();     
            richTextBox9.Text = cs.GetDouble(2).ToString();
            richTextBox7.Text = cs.GetDouble(3).ToString();
            richTextBox11.Text = cs.GetDouble(4).ToString();
            richTextBox13.Text = cs.GetDouble(5).ToString();
            richTextBox15.Text = cs.GetDouble(6).ToString();
            richTextBox3.Text = cs.GetDouble(8).ToString();
            richTextBox5.Text = cs.GetDouble(9).ToString();
            richTextBox6.Text = cs.GetDouble(10).ToString();
            richTextBox8.Text = cs.GetDouble(11).ToString();
            richTextBox10.Text = cs.GetDouble(12).ToString();
            richTextBox12.Text = cs.GetDouble(13).ToString();
            richTextBox14.Text = cs.GetDouble(14).ToString();
            int ID_pres = cs.GetInt32(7);
            cs.Close();

            dataGridView1.Rows.Clear();
            add_grid();

            labeling_grid(ID_pres);

            richTextBox2.Enabled = true;
            richTextBox9.Enabled = true;
            richTextBox3.Enabled = true;
            richTextBox8.Enabled = true;

            richTextBox17.Visible = true;
            richTextBox17.Text = comboBox1.Text;

            button2.Enabled = true;

        }
        void labeling_grid(int ID_pres)
        {
            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                string name = dataGridView1.Rows[m].Cells["Наименование"].Value.ToString();

                SqlCommand c = new SqlCommand("select count(*) from prescript_components where ID = " + ID_pres + " and name = '" + name + "';", con);
                SqlDataReader cs = c.ExecuteReader();
                cs.Read();
                int cnt = cs.GetInt32(0);
                cs.Close();

                if (cnt != 0)
                {
                    dataGridView1.Rows[m].Cells["Статус"].Value = true;

                    double max = 0;
                    double min = 0;
                    double qty = 0;
                    
                    SqlCommand d = new SqlCommand("select max_at, min_at, qty from prescript_components where ID = " + ID_pres + " and name = '" + name + "';", con);
                    SqlDataReader cd = d.ExecuteReader();
                    while (cd.Read())
                    {
                        if (max < cd.GetDouble(0)) { max = cd.GetDouble(0); };
                        if (min < cd.GetDouble(1)) { min = cd.GetDouble(1); };
                        if (qty < cd.GetDouble(2)) { qty = cd.GetDouble(2); };
                    }
                    cd.Close();

                    //richTextBox16.Text += name + " min " + min + " max " + max + "\n";

                    dataGridView1.Rows[m].Cells["Мин"].Value = min;
                    dataGridView1.Rows[m].Cells["Макс"].Value = max;

                    if (qty != 0) { dataGridView1.Rows[m].Cells["Вес"].Value = qty; }
                }
            }
            dataGridView1.Sort(Статус, System.ComponentModel.ListSortDirection.Descending);

            
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            combo1_loader(comboBox2.Text);
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            prescript_loader();
            if (comboBox2.Text != "Используемые") { repeat_grid_cleaner(); }
            label2.Text = "Себeстоимость " + Math.Round((set_min_and_cost() / 100 * to_dbl(richTextBox1.Text)),2) + " стаканчика " + Math.Round((set_min_and_cost() / 100 * to_dbl(richTextBox1.Text) * 0.15 / 100), 2) + "\n";            
        }

//Подсчет материальных балансов
        int grid_cointer(string column)
        {
            int cnt = 0;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (dataGridView1.Rows[m].Cells["subgroup"].Value.ToString() == column && System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    cnt += 1;
                }
            }

            return cnt;
        }
        void prescript_cointer()
        {
            if (grid_cointer("Химикаты") != 0 && grid_cointer("Сырье") != 0)// && grid_cointer("Добавки") != 0
            {
                //richTextBox16.Text += "К расчету все указано\n";
                richTextBox16.Clear();

                repeat_grid_cleaner();

                //set_min();
                param_array();

                //double min_fat = to_dbl(richTextBox8.Text); if (min_fat == 0) { min_fat = to_dbl(richTextBox9.Text); }
                //double min_dry = to_dbl(richTextBox3.Text); if (min_dry == 0) { min_dry = to_dbl(richTextBox2.Text); }
                //double min_protein = to_dbl(richTextBox12.Text); if (min_protein == 0) { min_protein = to_dbl(richTextBox13.Text); }

                //richTextBox16.Text += (min_fat - lost_column("Жир")) + " Жир\n";
                //richTextBox16.Text += (min_dry - lost_column("Сухое")) + " Сухое\n";
                //richTextBox16.Text += (min_protein - lost_column("Белок")) + " Белок\n";//lost_column("Белок")


                //richTextBox16.Text += "cost lost param single = " + cost_lost_param_single("Сухое") + "\n";
                //richTextBox16.Text += "cost lost param single = " + cost_lost_param_single("Жир") + "\n";
                //richTextBox16.Text += "cost lost param single = " + cost_lost_param_single("Белок") + "\n";

                //cost_lost_param_single("Сухое");

            }
            else
            {
                richTextBox16.Text += "Не все указано в достаточном количестве\n";
            }
        }
        double cost_lost_param_single(string column, ref string name, ref double change_param)
        {
            double a = 0;
            double max = 0;
            
            if (column == "Жир") { max = to_dbl(richTextBox8.Text); if (max == 0) { max = to_dbl(richTextBox9.Text); } }
            if (column == "Сухое") { max = to_dbl(richTextBox3.Text); if (max == 0) { max = to_dbl(richTextBox2.Text); } }
            if (column == "Белок") { max = to_dbl(richTextBox12.Text); if (max == 0) { max = to_dbl(richTextBox13.Text); } }
            if (column == "Углеводы") { max = to_dbl(richTextBox14.Text); if (max == 0) { max = to_dbl(richTextBox15.Text); } }
            if (column == "Калории") { max = to_dbl(richTextBox10.Text); if (max == 0) { max = to_dbl(richTextBox11.Text); } }
            if (column == "NaCl") { max = to_dbl(richTextBox19.Text); if (max == 0) { max = to_dbl(richTextBox18.Text); } }

            double lost = max - lost_column(column);

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                double min_grid = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                double index = to_dbl(dataGridView1.Rows[m].Cells[column].Value.ToString());
                double cost_qty = to_dbl(dataGridView1.Rows[m].Cells["cost"].Value.ToString());
                string name_grid = dataGridView1.Rows[m].Cells["Наименование"].Value.ToString();

                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true && index > 1 && (dataGridView1.Rows[m].Cells["subgroup"].Value.ToString() == "Сырье" || dataGridView1.Rows[m].Cells["subgroup"].Value.ToString() == "Добавки"))
                {
                    double b = lost * 100 / index;

                    double cost = b * cost_qty;
                    if (a == 0) { a = cost; change_param = (min_grid - b); name = name_grid; }
                    if (a != 0 && a > cost) { a = cost; change_param = (min_grid - b); name = name_grid; }

                    richTextBox16.Text += column + " " + name_grid + " " + lost + " b " + b + " cost " + cost + "\n";
                }
            }

            //richTextBox16.Text += column + " name " + name + " lost " + lost + " change param = " + change_param + " min cost = " + a + "\n";
            
            return a;
        }
        int parametr_cointer()
        {
            int a = 0;

            if (checkBox2.Checked == true) { a += 1; }
            if (checkBox3.Checked == true) { a += 1; }
            if (checkBox4.Checked == true) { a += 1; }
            if (checkBox5.Checked == true) { a += 1; }
            if (checkBox6.Checked == true) { a += 1; }
            if (checkBox7.Checked == true) { a += 1; }

            return a;
        }
        void param_array()
        {
            int cnt = 0;
            int par_cnt = parametr_cointer();
            string[] column_array = new string[par_cnt];

            if (checkBox2.Checked == true) 
            {
                column_array[cnt] = "Сухое";
                cnt += 1;
            }
            if (checkBox3.Checked == true)
            {
                column_array[cnt] = "Жир";
                cnt += 1;
            }
            if (checkBox4.Checked == true)
            {
                column_array[cnt] = "Калории";
                cnt += 1;
            }
            if (checkBox5.Checked == true)
            {
                column_array[cnt] = "Белок";
                cnt += 1;
            }
            if (checkBox6.Checked == true)
            {
                column_array[cnt] = "Углеводы";
                cnt += 1;
            }
            if (checkBox7.Checked == true)
            {
                column_array[cnt] = "NaCl";
                cnt += 1;
            }

            string name_array = string.Empty;
            double change_param_array = 0;
            string column = string.Empty;
            double cost = 0;

            for (int a = 0; a < column_array.Length; a++)
            {
                string name = string.Empty;
                double change_param = 0;
                double d = cost_lost_param_single(column_array[a], ref name, ref change_param);

                if (cost == 0) { cost = d; name_array = name; column = column_array[a]; change_param_array = change_param; }
                if (cost != 0 && d < cost) { cost = d; name_array = name; column = column_array[a]; change_param_array = change_param; }
            }
            richTextBox16.Text += "\n" + column + " " + name_array + " cost " + cost + " change param " + change_param_array + "\n";

            if (name_array != string.Empty)
            {
                grid_MM_added(change_param_array, 0, name_array);
            }
        }
        double set_min_and_cost()
        {
            double cost = 0;
            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {

                    double min = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                    cost += to_dbl(dataGridView1.Rows[m].Cells["cost"].Value.ToString()) * min;
                    //richTextBox16.Text += m + " min " + min + "\n";
                    dataGridView1.Rows[m].Cells["Вес"].Value = min;

                }
            }
            return cost;
        }
        double lost_column(string column)
        {
            double lost = 0;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                double min = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                double index = to_dbl(dataGridView1.Rows[m].Cells[column].Value.ToString());

                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    lost += Math.Round((min / 100 * index), 3);                
                }
            }

            return lost;
        }

        //Группа функций для корректировки границ Минимума и Максимума
        void min_max_cointer(string column, string subgroup, ref double in_min, ref double in_max)
        {
            double index = 0;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                double min = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                double max = to_dbl(dataGridView1.Rows[m].Cells["Макс"].Value.ToString());
                index = to_dbl(dataGridView1.Rows[m].Cells[column].Value.ToString());

                if (dataGridView1.Rows[m].Cells["subgroup"].Value.ToString() == subgroup && System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    //richTextBox16.Text += dataGridView1.Rows[m].Cells["Наименование"].Value.ToString() + " " + dataGridView1.Rows[m].Cells["Мин"].Value.ToString() + " " + dataGridView1.Rows[m].Cells["Макс"].Value.ToString() + " " + "\n";
                    if (in_max < max) { in_max = Math.Round((max / 100 * index), 3); }
                    if (in_min > min && min != 0) { in_min = Math.Round((min / 100 * index), 3); }
                }
            }
            if (in_min == 100) { in_min = 0; }

        }
        void min_max_sum(string column, string subgroup, ref double in_min, ref double in_max)
        {
            double index = 0;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                double min = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                double max = to_dbl(dataGridView1.Rows[m].Cells["Макс"].Value.ToString());
                index = to_dbl(dataGridView1.Rows[m].Cells[column].Value.ToString());

                if (dataGridView1.Rows[m].Cells["subgroup"].Value.ToString() == subgroup && System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    in_max += Math.Round((max / 100 * index), 3);
                    in_min += Math.Round((min / 100 * index), 3);
                }
            }
        }
        void border_cointer(string name, string column, double min_param, double max_param, ref double out_min, ref double out_max)
        {
            //Считаем минимумы и максимумы без учета указанного
            double min = 0;
            double max = 0;
            double index = 0;
            double max_name = 0;
            double min_name = 0;
            double index_name = 0;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {

                    string name_grid = dataGridView1.Rows[m].Cells["Наименование"].Value.ToString();
                    string subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();


                    if (name != name_grid)
                    {
                        index = to_dbl(dataGridView1.Rows[m].Cells[column].Value.ToString());
                        min += to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString()) / 100 * index;
                        max += to_dbl(dataGridView1.Rows[m].Cells["Макс"].Value.ToString()) / 100 * index;

                    }
                    else
                    {
                        index_name = to_dbl(dataGridView1.Rows[m].Cells[column].Value.ToString());
                        max_name = to_dbl(dataGridView1.Rows[m].Cells["Макс"].Value.ToString()) / 100 * index_name;
                        min_name = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString()) / 100 * index_name;
                    }
                }
            }

            min = Math.Round(min, 3);
            max = Math.Round(max, 3);

            //richTextBox16.Text += "max sum = " + max + " min sum = " + min + " max name = " + max_name + " min name = " + min_name + "\n";
            
            //Считаем недостающее количество max и min
            double lost_min = min_param - max;
            double lost_max = max_param - min;

            //richTextBox16.Text += "min lost = " + lost_min + " max lost = " + lost_max + "\n";

            //Условие корректности полученных Мин и Макс
            if (lost_min > 0 && lost_max > 0)
            {
                //Корректируем значения по уже имеющимся в условии Мин и Макс
                //richTextBox16.Text += "min name = " + min_name + " max name = " + max_name + "\n";
                //richTextBox16.Text += "min lost = " + lost_min + " max lost = " + lost_max + "\n";
                if (max_name < lost_max && max_name != 0) { lost_max = max_name; }
                if (min_name > lost_min) { lost_min = min_name; }
                //richTextBox16.Text += "min lost = " + lost_min + " max lost = " + lost_max + "\n";

                //Вычисляем значения в процентах из сухого вещества
                double perc_max = Math.Round((lost_max / index_name * 100), 3);
                double perc_min = Math.Round((lost_min / index_name * 100), 3);
                //richTextBox16.Text += name + " Perc min = " + perc_min + " perc max = " + perc_max + "\n";
                out_min = perc_min;
                out_max = perc_max;
            }
            else
            {
                richTextBox16.Text += name + " Некорректный параметр min " + lost_min + " max " + lost_max + "\n";
                if (lost_min < 0) { out_min = 0; }
                
            }


        }
        void param(string column, ref double min_param, ref double max_param)
        {
            if (column == "Сухое")
            {
                min_param = to_dbl(richTextBox2.Text);
                max_param = to_dbl(richTextBox3.Text);
                if (max_param < min_param) { max_param = min_param; }
            }
            else if (column == "Жир")
            {
                min_param = to_dbl(richTextBox9.Text);
                max_param = to_dbl(richTextBox8.Text);
                if (max_param < min_param) { max_param = min_param; }
            }
            else if (column == "Калории")
            {
                min_param = to_dbl(richTextBox11.Text);
                max_param = to_dbl(richTextBox10.Text);
                if (max_param < min_param) { max_param = min_param; }
            }
            else if (column == "Белок")
            {
                min_param = to_dbl(richTextBox13.Text);
                max_param = to_dbl(richTextBox12.Text);
                if (max_param < min_param) { max_param = min_param; }
            }
            else if (column == "Углеводы")
            {
                min_param = to_dbl(richTextBox15.Text);
                max_param = to_dbl(richTextBox14.Text);
                if (max_param < min_param) { max_param = min_param; }
            }
            else if (column == "NaCl")
            {
                min_param = to_dbl(richTextBox18.Text);
                max_param = to_dbl(richTextBox19.Text);
                if (max_param < min_param) { max_param = min_param; }
            }
            else 
            {
                richTextBox16.Text += column + " Нет такого параметра (колонки) для расчета\n";
            }
            
        }
        void border_cicle(string column)
        {
            double min_param = 0;
            double max_param = 0;
            param(column, ref min_param, ref max_param);

            if (min_param != 0 && max_param != 0)
            {

                int cnt = 0;
                for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
                {
                    if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                    {
                        string subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();
                        if (subgroup == "Сырье" || subgroup == "Добавки") { cnt += 1; }
                    }
                }

                //richTextBox16.Text += cnt + "\n";

                string[,] array = new string[3, cnt];
                int array_cnt = 0;

                double out_min = 0;
                double out_max = 0;

                for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
                {
                    if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                    {
                        string subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();
                        if (subgroup == "Сырье" || subgroup == "Добавки")
                        {
                            string name = dataGridView1.Rows[m].Cells["Наименование"].Value.ToString();
                            border_cointer(name, column, min_param, max_param, ref out_min, ref out_max);

                            //richTextBox16.Text += name + " min param = " + min_param + " max param = " + max_param + " status " + dataGridView1.Rows[m].Cells["Статус"].Value + "\n";

                            array[0, array_cnt] = name;
                            array[1, array_cnt] = out_min.ToString();
                            array[2, array_cnt] = out_max.ToString();

                            array_cnt += 1;

                            out_max = 0;
                            out_min = 0;
                        }
                    }
                }

                for (int r = 0; r < cnt; r++)
                {
                    richTextBox16.Text += array[0, r] + " min " + array[1, r] + " max " + array[2, r] + "\n";
                    
                    string name = array[0, r];
                    double min = to_dbl(array[1, r]);
                    double max = to_dbl(array[2, r]);

                    //if (column == "Сухое")
                    //{
                        grid_MM_added(min, max, name);
                    //}

                }
            }
            else { richTextBox16.Text += "Параметр не указан\n"; }
        }
        void grid_MM_added(double min, double max, string name)
        {
            bool stop = false;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n || stop != true; m++)
            {
                string name_array = dataGridView1.Rows[m].Cells["Наименование"].Value.ToString();
                if (name_array == name) 
                {
                    if (min != 0)
                    {
                        dataGridView1.Rows[m].Cells["Мин"].Value = min;
                    }
                    if (max != 0)
                    {
                        dataGridView1.Rows[m].Cells["Макс"].Value = max;
                    }
                    stop = true;
                }
            }
        }
        void dry_wet_cointer(string column)
        {
            //Считаем сухие вещества на соли-плавители
            double salt_min = 100;
            double salt_max = 0;
            min_max_cointer(column, "Химикаты", ref salt_min, ref salt_max);
            //richTextBox16.Text += "Соли - плавитеи min " + salt_min + " max " + salt_max + "\n";
            //Считаем сухие вещества на консерванты
            double pres_min = 100;
            double pres_max = 0;
            min_max_cointer(column, "Консерванты", ref pres_min, ref pres_max);
            //richTextBox16.Text += "Консерванты min " + pres_min + " max " + pres_max + "\n";
            //Считаем сухие вещества на загустители
            double thickeners_min = 100;
            double thickeners_max = 0;
            min_max_cointer(column, "Загустители", ref thickeners_min, ref thickeners_max);
            //richTextBox16.Text += "Загустители min " + thickeners_min + " max " + thickeners_max + "\n";
            //Считаем сумму сухих веществ на добавках
            double add_min = 0;
            double add_max = 0;
            min_max_sum(column, "Добавки", ref add_min, ref add_max);
            //richTextBox16.Text += "Добавки min " + add_min + " max " + add_max + "\n";
            double main_min = 0;
            double main_max = 0;
            min_max_sum(column, "Сырье", ref main_min, ref main_max);
            //richTextBox16.Text += "Сырье min " + main_min + " max " + main_max + "\n";

            double total_min = main_min + add_min + pres_min + thickeners_min + salt_min;
            double total_max = main_max + add_max + pres_max + thickeners_max + salt_max;
            richTextBox16.Text += "\n" + column + " Итого min " + total_min + " max " + total_max + "\n\n";

            //double a1 = 0;
            //double a2 = 0;
            //border_cointer("1Л_Сметана-UHT36%", "Сухое", 60, 60, ref a1, ref a2);

            //richTextBox16.Text += "\n";
            
            border_cicle(column);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear_cointer();
            //prescript_cointer();

            grid_array(5);
            border_for_recurse(10);
            grid_array(1);
            border_for_recurse(4);
            grid_array(0.5);
            //border_for_recurse(2);
            //grid_array(0.1);
            //border_for_recurse(0.5);
            //grid_array(0.02);
            //border_for_recurse(0.1);
            //grid_array(0.01);
            //border_for_recurse(0.02);
            //grid_array(0.005);
            //border_for_recurse(0.002);
            //grid_array(0.001);
            label2.Text = "Себeстоимость " + Math.Round((set_min_and_cost() / 100 * to_dbl(richTextBox1.Text)), 2) + " стаканчика " + Math.Round((set_min_and_cost() / 100 * to_dbl(richTextBox1.Text) * 0.15 / 100), 2) + "\n";

        }

        //SOLVER
        void border_for_recurse(double border)
        {
            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    string subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();
                    double min = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                    double max = to_dbl(dataGridView1.Rows[m].Cells["Макс"].Value.ToString()); if (max == 0) { max = 100; }

                    if (subgroup == "Сырье" || subgroup == "Добавки")
                    {
                        if (min - border >= 0)
                        {
                            dataGridView1.Rows[m].Cells["Мин"].Value = min - border;
                        }
                        if (max >= (min + border))
                        {
                            dataGridView1.Rows[m].Cells["Макс"].Value = min + border;
                        }
                    }
                }
            }
        }
        int grid_array_cnt() 
        {
            int cnt = 0;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    string subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();
                    if (subgroup == "Сырье" || subgroup == "Добавки")
                    { cnt += 1; }
                }
            }

            return cnt;
        }
        void grid_array(double step)
        {
            //richTextBox16.Clear();
            //repeat_grid_cleaner();

            int cnt = grid_array_cnt();
            double[,] grid_array = new double[10, cnt];
            double[,] start_array = new double[2, cnt];

            int cointer = 0;

            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    string subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();
                    double min = to_dbl(dataGridView1.Rows[m].Cells["Мин"].Value.ToString());
                    double max = to_dbl(dataGridView1.Rows[m].Cells["Макс"].Value.ToString()); if (max == 0) { max = 100; }
                    double dry = to_dbl(dataGridView1.Rows[m].Cells["Сухое"].Value.ToString());
                    double fat = to_dbl(dataGridView1.Rows[m].Cells["Жир"].Value.ToString());
                    double cal = to_dbl(dataGridView1.Rows[m].Cells["Калории"].Value.ToString());
                    double protein = to_dbl(dataGridView1.Rows[m].Cells["Белок"].Value.ToString());
                    double carbohydrates = to_dbl(dataGridView1.Rows[m].Cells["Углеводы"].Value.ToString());
                    double NaCl = to_dbl(dataGridView1.Rows[m].Cells["NaCl"].Value.ToString());
                    double cost = to_dbl(dataGridView1.Rows[m].Cells["cost"].Value.ToString());

                    if (subgroup == "Сырье" || subgroup == "Добавки")
                    {
                        grid_array[0, cointer] = m;//name
                        start_array[0, cointer] = m;
                        grid_array[1, cointer] = min;
                        start_array[1, cointer] = min;
                        grid_array[2, cointer] = max;
                        grid_array[3, cointer] = dry;
                        grid_array[4, cointer] = fat;
                        grid_array[5, cointer] = cal;
                        grid_array[6, cointer] = protein;
                        grid_array[7, cointer] = carbohydrates;
                        grid_array[8, cointer] = NaCl;
                        grid_array[9, cointer] = cost;

                        cointer += 1;
                    }
                }
            }

            //Подсчитаем минимумы и максимумы без Сырья и Добавок
            double dry_min = 0; double dry_max = 0; another_min_max(ref dry_min, ref dry_max, "Сухое");
            double fat_min = 0; double fat_max = 0; another_min_max(ref fat_min, ref fat_max, "Жир");
            double cal_min = 0; double cal_max = 0; another_min_max(ref cal_min, ref cal_max, "Калории");
            double protein_min = 0; double protein_max = 0; another_min_max(ref protein_min, ref protein_max, "Белок");
            double carbo_min = 0; double carbo_max = 0; another_min_max(ref carbo_min, ref carbo_max, "Углеводы");
            double NaCl_min = 0; double NaCl_max = 0; another_min_max(ref NaCl_min, ref NaCl_max, "NaCl");

            //Подсчитаем минимумы и максимумы заданных параметров рецепта
            double par_dry_min = 0; double par_dry_max = 0; param("Сухое", ref par_dry_min, ref par_dry_max);
            double par_fat_min = 0; double par_fat_max = 0; param("Жир", ref par_fat_min, ref par_fat_max);
            double par_cal_min = 0; double par_cal_max = 0; param("Калории", ref par_cal_min, ref par_cal_max);
            double par_protein_min = 0; double par_protein_max = 0; param("Белок", ref par_protein_min, ref par_protein_max);
            double par_carbo_min = 0; double par_carbo_max = 0; param("Углеводы", ref par_carbo_min, ref par_carbo_max);
            double par_NaCl_min = 0; double par_NaCl_max = 0; param("NaCl", ref par_NaCl_min, ref par_NaCl_max);

            //Загрузка массива с параметрами
            int cnt_par = 0;
            int par_cnt = parametr_cointer();
            double[,] column_array = new double[5, par_cnt];

            if (checkBox2.Checked == true) { column_array[0, cnt_par] = 3; column_array[1, cnt_par] = dry_min; column_array[2, cnt_par] = dry_max; column_array[3, cnt_par] = par_dry_min; column_array[4, cnt_par] = par_dry_max; cnt_par += 1; }//"Сухое"
            if (checkBox3.Checked == true) { column_array[0, cnt_par] = 4; column_array[1, cnt_par] = fat_min; column_array[2, cnt_par] = fat_max; column_array[3, cnt_par] = par_fat_max; column_array[4, cnt_par] = par_fat_max; cnt_par += 1; }//"Жир"
            if (checkBox4.Checked == true) { column_array[0, cnt_par] = 5; column_array[1, cnt_par] = cal_min; column_array[2, cnt_par] = cal_max; column_array[3, cnt_par] = par_cal_min; column_array[4, cnt_par] = par_cal_max; cnt_par += 1; }//"Калории"
            if (checkBox5.Checked == true) { column_array[0, cnt_par] = 6; column_array[1, cnt_par] = protein_min; column_array[2, cnt_par] = protein_max; column_array[3, cnt_par] = par_protein_min; column_array[4, cnt_par] = par_protein_max; cnt_par += 1; }//"Белок"
            if (checkBox6.Checked == true) { column_array[0, cnt_par] = 7; column_array[1, cnt_par] = carbo_min; column_array[2, cnt_par] = carbo_max; column_array[3, cnt_par] = par_carbo_min; column_array[4, cnt_par] = par_carbo_max; cnt_par += 1; }//"Углеводы"
            if (checkBox7.Checked == true) { column_array[0, cnt_par] = 8; column_array[1, cnt_par] = NaCl_min; column_array[2, cnt_par] = NaCl_max; column_array[3, cnt_par] = par_NaCl_min; column_array[4, cnt_par] = par_NaCl_max; cnt_par += 1; }//"NaCl"

            //for (int t = 0; t < cnt_par; t++) { richTextBox16.Text += column_array[0, t] + " another min " + column_array[1, t] + " another max " + column_array[2, t] + " par_min " + column_array[3, t] + " par max " + column_array[4, t] + "\n"; }

            DateTime t1 = DateTime.Now;

            //Корректируем Мин и Макс для ускорения метода рекурсии
            //double out_min = 0;
            //double out_max = 0;
            //array_border_cointer(grid_array, cnt, 1, 3, column_array[3, 0], column_array[4, 0], ref out_min, ref out_max, column_array[1, 0], column_array[2, 0]);
            //richTextBox16.Text += " out min " + out_min + " out max " + out_max + "\n";


            //array_lost_column(grid_array, cnt, column_array[0, 0], column_array[1, 0], column_array[3, 0], column_array[4, 0]);
            //richTextBox16.Text += "\n" + column_cicle(grid_array, cnt, column_array, par_cnt) + "\n";


            //Запускаем саму функцию рекурсии

            int array_no = 0;
            recurse(start_array, ref grid_array, cnt, grid_array[0, 0], grid_array[1, 0], grid_array[2, 0], step, array_no, column_array, par_cnt, ref match_cointer);

            //for (int r = 0; r < cnt; r++)
            //{
            //    richTextBox16.Text += start_array[0, r] + " " + start_array[1, r] + "\n";
            //}


            richTextBox16.Text += step + " match cointer " + match_cointer + "\n";

            //Пробная часть перебора массива
            //richTextBox16.Text += "\n";
            //for (int a = 0; a < cnt; a++) 
            //{
            //    richTextBox16.Text += "Номер продукта в массиве " + grid_array[0, a].ToString() + " min " + grid_array[1, a].ToString() + " max " + grid_array[2, a].ToString() + "\n";
            //array_border_cointer();
            //}

            //Функция изменения массива
            //min_array_change(ref grid_array, cnt, 33, 3);


            DateTime t2 = DateTime.Now;
            double raise = t2.Subtract(t1).TotalMilliseconds;
            double raise_1 = t2.Subtract(t1).TotalMinutes;

            label2.Text = "Себeстоимость " + Math.Round((set_min_and_cost() / 100 * to_dbl(richTextBox1.Text)), 2) + " стаканчика " + Math.Round((set_min_and_cost() / 100 * to_dbl(richTextBox1.Text) * 0.15 / 100), 2) + "\n";

            richTextBox16.Text += "Время выполнения функции в миллисекундах " + Math.Round(raise, 3) + " в минутах " + Math.Round(raise_1, 3) + " лучшее значение " + match_cointer + "\n";
        }
        void array_border_cointer(double [,] grid_array, int cnt, double name, double column, double min_param, double max_param, ref double out_min, ref double out_max, double another_min, double another_max)
        {
            //Считаем минимумы и максимумы без учета указанного
            double min = 0;
            double max = 0;
            double index = 0;
            double max_name = 0;
            double min_name = 0;
            double index_name = 0;

            for (int a = 0; a < cnt; a++)
            {
                double name_grid = grid_array[0, a];

                if (name_grid != name)
                {
                    index = grid_array[System.Convert.ToInt32(column), a];
                    //richTextBox16.Text += " index " + index + "\n";
                    min += grid_array[1, a] / 100 * index;
                    max += grid_array[2, a] / 100 * index;
                    richTextBox16.Text += "min " + grid_array[1, a] + " max " + grid_array[2, a] + " index " + index + "\n";
                }
                else 
                {
                    index_name = grid_array[System.Convert.ToInt32(column), a];
                    //richTextBox16.Text += " index name " + index_name + "\n";
                    min_name = grid_array[1, a] / 100 * index_name;
                    max_name = grid_array[2, a] / 100 * index_name;
                    richTextBox16.Text += "min name " + grid_array[1, a] + " max name " + grid_array[2, a] + " index name " + index_name + "\n";
                }
            }
            
            min = min + another_min;
            max = max + another_max;

            richTextBox16.Text += "max sum = " + max + " min sum = " + min + " max name = " + max_name + " min name = " + min_name + "\n";

            //Считаем недостающее количество max и min
            double lost_min = min_param - max;
            double lost_max = max_param - min;

            richTextBox16.Text += "min param " + min_param + " max param " + max_param + " min lost = " + lost_min + " max lost = " + lost_max + "\n";

            //Условие корректности полученных Мин и Макс
            if (lost_max > 0)//lost_min > 0 && 
            {
                //Корректируем значения по уже имеющимся в условии Мин и Макс
                richTextBox16.Text += "min name = " + min_name + " max name = " + max_name + "\n";
                richTextBox16.Text += "min lost = " + lost_min + " max lost = " + lost_max + "\n";
                if (max_name < lost_max && max_name != 0) { lost_max = max_name; }
                if (min_name > lost_min) { lost_min = min_name; }
                //richTextBox16.Text += "min lost = " + lost_min + " max lost = " + lost_max + "\n";

                //Вычисляем значения в процентах из сухого вещества
                double perc_max = Math.Round((lost_max / index_name * 100), 3);
                double perc_min = Math.Round((lost_min / index_name * 100), 3);
                richTextBox16.Text += name + " Perc min = " + perc_min + " perc max = " + perc_max + "\n";
                out_min = perc_min;
                out_max = perc_max;
            }
            else
            {
                richTextBox16.Text += name + " Некорректный параметр min " + lost_min + " max " + lost_max + "\n";
                if (lost_min < 0) { out_min = 0; }
            }
        }
        double column_cicle(double[,] grid_array, int cnt, double[,] column_array, int par_cnt)
        {
            double lost = 0;

            for (int a = 0; a < par_cnt; a++)
            {
                double cicle_cost = array_lost_column(grid_array, cnt, column_array[0, a], column_array[1, a], column_array[3, a], column_array[4, a]);
                //richTextBox16.Text += "Cost " + cicle_cost + " column nomer " + column_array[0, a] + " another min " + column_array[1, a] + " another max " + column_array[2, a] + " par_min " + column_array[3, a] + " par max " + column_array[4, a] + "\n";
                if (cicle_cost > lost) { lost = cicle_cost; }
            }
            //richTextBox16.Text += "Lost " + lost + "\n";
            
            return lost;
        }
        double array_lost_column(double[,] grid_array, int cnt, double column, double another_min, double min_param, double max_param)
        {
            //richTextBox16.Text += "column " + column + " another min " + another_min + " min param " + min_param + " max param " + max_param + "\n";
            double lost = 0;

            for (int a = 0; a < cnt; a++)
            {
                double index = grid_array[System.Convert.ToInt32(column), a];
                double min = grid_array[1, a] / 100 * index;
                //richTextBox16.Text += "index " + index + " min " + grid_array[1, a] + " qty min " + min + "\n";
                lost += min;
            }
            double total_min = lost + another_min;
            //richTextBox16.Text += "lost " + lost + " another min " + another_min + " total min " + total_min + "\n";
           
            double return_lost = 0;

            if (total_min >= min_param && total_min <= max_param) { return_lost = 0; }
            else if (total_min > max_param) { return_lost = total_min - max_param; }
            else if (total_min < min_param) { return_lost = min_param - total_min; }
            //richTextBox16.Text += "Return lost " + return_lost + "\n";
            return return_lost;
        }
        void another_min_max(ref double another_min, ref double another_max, string column)
        {
            //Считаем сухие вещества на соли-плавители
            double salt_min = 100;
            double salt_max = 0;
            min_max_cointer(column, "Химикаты", ref salt_min, ref salt_max);
            //richTextBox16.Text += "Соли - плавитеи min " + salt_min + " max " + salt_max + "\n";
            //Считаем сухие вещества на консерванты
            double pres_min = 100;
            double pres_max = 0;
            min_max_cointer(column, "Консерванты", ref pres_min, ref pres_max);
            //richTextBox16.Text += "Консерванты min " + pres_min + " max " + pres_max + "\n";
            //Считаем сухие вещества на загустители
            double thickeners_min = 100;
            double thickeners_max = 0;
            min_max_cointer(column, "Загустители", ref thickeners_min, ref thickeners_max);
            //richTextBox16.Text += "Загустители min " + thickeners_min + " max " + thickeners_max + "\n";
            
            //Эту часть кода тут не применяем
            /*//Считаем сумму сухих веществ на добавках
            double add_min = 0;
            double add_max = 0;
            min_max_sum(column, "Добавки", ref add_min, ref add_max);
            //richTextBox16.Text += "Добавки min " + add_min + " max " + add_max + "\n";
            double main_min = 0;
            double main_max = 0;
            min_max_sum(column, "Сырье", ref main_min, ref main_max);
            //richTextBox16.Text += "Сырье min " + main_min + " max " + main_max + "\n";*/

            another_min = pres_min + thickeners_min + salt_min;//main_min + add_min + 
            another_max = pres_max + thickeners_max + salt_max;//main_max + add_max + 
            //richTextBox16.Text += "\n" + column + " Итого min " + another_min + " max " + another_max + "\n\n";
        }
        void min_array_change(ref double[,] grid_array, int cnt, double min, double name)
        {
            bool stop = false;
            for (int a = 0; a < cnt || stop == false; a++) 
            {
                if (name == grid_array[0, a]) 
                {
                    stop = true;
                    grid_array[1, a] = min;
                }
            }
        }
        double match_cointer = 100;
        double selected_cost = 0;
        //double m_cnt = 0;
        void recurse(double [,]start_array, ref double[,] grid_array, int cnt, double name, double min, double max, double step, int array_no, double[,] column_array, int par_cnt, ref double match_cointer)
        {
            for (min = coint_start_array(name, start_array, cnt, step); min <= max; min += step)
            {
                if (array_no < cnt)
                {
                    //richTextBox16.Text = " name № " + name + " min " + min + " max " + max + "\n";
                    min_array_change(ref grid_array, cnt, min, name);

                    recurse(start_array, ref grid_array, cnt, grid_array[0, array_no], grid_array[1, array_no], grid_array[2, array_no], step, array_no + 1, column_array, par_cnt, ref match_cointer);
                }
                else
                {
                    min_array_change(ref grid_array, cnt, min, name);

                    //richTextBox16.Text += " name № " + name + " min " + min + "\n";
                    //расчет баланса текущего массива
                    double s = column_cicle(grid_array, cnt, column_array, par_cnt);
                    //if (s < match_cointer)
                    //{
                    //    match_cointer = s;
                    //    save_var(grid_array);
                    //}

                    if (s <= 1)
                    {
                        //save_var(grid_array);
                        double cost = variant_cost(grid_array, cnt);



                        for (int a = 0; a < cnt; a++)
                        {
                            richTextBox16.Text += "Номер продукта в массиве " + grid_array[0, a].ToString() + " min " + grid_array[1, a].ToString() + " max " + grid_array[2, a].ToString() + "\n";
                        }



                        if (selected_cost == 0)
                        {
                            selected_cost = cost;
                            richTextBox16.Text += "first cost " + cost + "\n";
                        }
                        if (selected_cost > cost)
                        {
                            save_var(grid_array);
                            selected_cost = cost;

                            if (cost < 379)
                            {
                                richTextBox16.Text += selected_cost + "\n";
                            }
                        }
                    }

                    //if (s < 0.74)
                    //{ 
                    //    m_cnt += 1;
                    //    richTextBox16.Text += s + " m cnt " + m_cnt + " var cost " + variant_cost(grid_array, cnt) + "\n";
                    //}
                    
                }

            }

        }
        double variant_cost(double[,] grid_array, int cnt)
        {
            double var_cost = 0;

            for (int a = 0; a < cnt; a++) 
            {
                var_cost += grid_array[1, a] * grid_array[9, a];
            }

            return var_cost;
        }
        void save_var(double[,] grid_array)
        {
            int cnt = 0;
            for (int m = 0, n = dataGridView1.Rows.Count - 1; m < n; m++)
            {
                if (System.Convert.ToBoolean(dataGridView1.Rows[m].Cells["Статус"].Value) == true)
                {
                    string subgroup = dataGridView1.Rows[m].Cells["subgroup"].Value.ToString();
                    
                    if (subgroup == "Сырье" || subgroup == "Добавки")
                    {
                        dataGridView1.Rows[m].Cells["Мин"].Value = grid_array[1, cnt];
                        cnt += 1;
                    }
                }
            }
        }
        double coint_start_array(double name, double[,] start_array, int cnt, double step)
        {
            double z = 0;
            bool stop = false;

            for (int a = 0; a < cnt || stop != true; a++) 
            {
                if (start_array[0, a] == name) 
                {
                    stop = true;
                    z = start_array[1, a];
                    //start_array[1, a] = z + step;
                }
            }

            return z;
        }
        bool array_print(double[,] grid_array, int cnt, double name, double min)
        {
            bool have = false;
            for (int a = 0; a < cnt; a++) 
            {
                if (grid_array[0, a] == name && grid_array[1, a] == min) 
                {
                    have = true;
                }
            }
            //richTextBox16.Text += "\n";
            return have;
        }

    }
}
