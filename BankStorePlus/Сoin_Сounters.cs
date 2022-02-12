using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankStorePlus
{
    /// <summary>
    /// Логика взаимодействия для окна администратора (таблица Сoin_Сounters)
    /// </summary>
    public partial class Сoin_Сounters : Form
    {
        private string id;
        public Сoin_Сounters()
        {
            InitializeComponent();

            // загрузка данных
            DGV_Сoin_Сounters.Columns.Add("idcc", "№");
            DGV_Сoin_Сounters.Columns.Add("namecc", "Наименование");
            DGV_Сoin_Сounters.Columns.Add("brendcc", "Бренд");
            DGV_Сoin_Сounters.Columns.Add("ckchcc", "Скорость счета (в минуту)");
            DGV_Сoin_Сounters.Columns.Add("ebzcc", "Емкость бункера загрузки (монет)");
            DGV_Сoin_Сounters.Columns.Add("cencc", "Цена");

            ConnectorDB resorcesDBCC = new ConnectorDB();
            resorcesDBCC.openConnection();
            string resorcessqlCC = "SELECT IDCC, Coin_Counters_name, brand.Brand_name, Coin_Counters_ScorSch, Coin_Counters_ObemBunker, Coin_Counters_price FROM coin_counters AS CoinCounters INNER JOIN Brand AS brand ON brand.Brand_id = CoinCounters.Coin_Counters_brand";
            MySqlCommand sqlCommandCC = new MySqlCommand(resorcessqlCC, resorcesDBCC.getConnection());
            MySqlDataReader dataReaderCC = sqlCommandCC.ExecuteReader();
            while (dataReaderCC.Read())
            {
                DGV_Сoin_Сounters.Rows.Add(dataReaderCC[0].ToString(), dataReaderCC[1].ToString(), dataReaderCC[2].ToString(), dataReaderCC[3].ToString(), dataReaderCC[4].ToString(), dataReaderCC[5].ToString());
            }
            dataReaderCC.Close();

            //загрузка ресурсов
            string brand = "SELECT Brand_name FROM brand";
            MySqlCommand commandBrand = new MySqlCommand(brand, resorcesDBCC.getConnection());
            MySqlDataReader dataBrand = commandBrand.ExecuteReader();
            while (dataBrand.Read())
            {
                comboBoxR_brand_CC.Items.Add(dataBrand[0].ToString());
                comboBoxD_brand_CC.Items.Add(dataBrand[0].ToString());
            }
            dataBrand.Close();

            resorcesDBCC.closeConnection();
        }

        private void DGV_Сoin_Сounters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (DGV_Сoin_Сounters.Rows[e.RowIndex].Cells[0].Value).ToString();

            ConnectorDB connectorP = new ConnectorDB();
            connectorP.openConnection();
            string sqlP = "SELECT * FROM coin_counters WHERE IDCC = " + id;
            MySqlCommand mySqlP = new MySqlCommand(sqlP, connectorP.getConnection());
            MySqlDataReader dataReaderPros = mySqlP.ExecuteReader();
            while (dataReaderPros.Read()) 
            {
                labelPNCC.Text = "Наименование\n" + dataReaderPros[1].ToString();
                textBoxR_name_CC.Text = dataReaderPros[1].ToString();

                comboBoxR_brand_CC.SelectedIndex = Int32.Parse(dataReaderPros[2].ToString());
                labelPBCC.Text = "Бренд\n" + comboBoxR_brand_CC.Items[comboBoxR_brand_CC.SelectedIndex].ToString();

                labelPCCCC.Text = "Скорость счета (в минуту)\n" + dataReaderPros[3].ToString();
                textBoxR_CC_CC.Text = dataReaderPros[3].ToString();

                labelPEBZCC.Text = "Емкость бункера загрузки (монет)\n" + dataReaderPros[4].ToString();
                textBoxR_EBZ_CC.Text = dataReaderPros[4].ToString();

                labelPCCC.Text = "Цена(руб.)\n" + dataReaderPros[5].ToString();
                textBoxR_cen_CC.Text = dataReaderPros[5].ToString();
            }
            dataReaderPros.Close();
            connectorP.closeConnection();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            ConnectorDB dBDell = new ConnectorDB();
            dBDell.openConnection();
            MySqlCommand commandDell = new MySqlCommand("DELETE FROM coin_counters WHERE coin_counters.IDCC = @idbcdelzap", dBDell.getConnection());
            commandDell.Parameters.Add("@idbcdelzap", MySqlDbType.Int32).Value = Int32.Parse(id);
            if(commandDell.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("OK");
                DGV_Сoin_Сounters.Rows.Clear();
                string resorcessqlCC = "SELECT IDCC, Coin_Counters_name, brand.Brand_name, Coin_Counters_ScorSch, Coin_Counters_ObemBunker, Coin_Counters_price FROM coin_counters AS CoinCounters INNER JOIN Brand AS brand ON brand.Brand_id = CoinCounters.Coin_Counters_brand";
                MySqlCommand sqlCommandCC = new MySqlCommand(resorcessqlCC, dBDell.getConnection());
                MySqlDataReader dataReaderCC = sqlCommandCC.ExecuteReader();
                while (dataReaderCC.Read())
                {
                    DGV_Сoin_Сounters.Rows.Add(dataReaderCC[0].ToString(), dataReaderCC[1].ToString(), dataReaderCC[2].ToString(), dataReaderCC[3].ToString(), dataReaderCC[4].ToString(), dataReaderCC[5].ToString());
                }
                dataReaderCC.Close();
            } 
            else 
            {
                MessageBox.Show("ERROR");
            }
            dBDell.closeConnection();
        }

        private void buttonDobav_Click(object sender, EventArgs e)
        {
            ConnectorDB dBDabav = new ConnectorDB();
            dBDabav.openConnection();
            MySqlCommand sqlCommandDabav = new MySqlCommand("INSERT INTO coin_counters (Coin_Counters_name, Coin_Counters_brand, Coin_Counters_ScorSch, Coin_Counters_ObemBunker, Coin_Counters_price) VALUES (@nameCC, @brCC, @ebz, @obbunk, @cenCC)", dBDabav.getConnection());
            sqlCommandDabav.Parameters.Add("@nameCC", MySqlDbType.VarChar).Value = textBoxD_name_CC.Text;
            sqlCommandDabav.Parameters.Add("@brCC", MySqlDbType.Int32).Value = comboBoxD_brand_CC.SelectedIndex;
            sqlCommandDabav.Parameters.Add("@ebz", MySqlDbType.Int32).Value = textBoxD_CC_CC.Text;
            sqlCommandDabav.Parameters.Add("@obbunk", MySqlDbType.Int32).Value = textBoxD_EBZ_CC.Text;
            sqlCommandDabav.Parameters.Add("@cenCC", MySqlDbType.Decimal).Value = textBoxD_cen_CC.Text;
            if (sqlCommandDabav.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("OK");
                DGV_Сoin_Сounters.Rows.Clear();
                string resorcessqlCC = "SELECT IDCC, Coin_Counters_name, brand.Brand_name, Coin_Counters_ScorSch, Coin_Counters_ObemBunker, Coin_Counters_price FROM coin_counters AS CoinCounters INNER JOIN Brand AS brand ON brand.Brand_id = CoinCounters.Coin_Counters_brand";
                MySqlCommand sqlCommandCC = new MySqlCommand(resorcessqlCC, dBDabav.getConnection());
                MySqlDataReader dataReaderCC = sqlCommandCC.ExecuteReader();
                while (dataReaderCC.Read())
                {
                    DGV_Сoin_Сounters.Rows.Add(dataReaderCC[0].ToString(), dataReaderCC[1].ToString(), dataReaderCC[2].ToString(), dataReaderCC[3].ToString(), dataReaderCC[4].ToString(), dataReaderCC[5].ToString());
                }
                dataReaderCC.Close();
            } 
            else 
            {
                MessageBox.Show("ERROR");
            }
        }

        private void buttonRedac_Click(object sender, EventArgs e)
        {
            ConnectorDB dBRedac = new ConnectorDB();
            dBRedac.openConnection();
            MySqlCommand sqlCommandRedac = new MySqlCommand("UPDATE coin_counters SET Coin_Counters_name = @rname, Coin_Counters_brand = @rbrand, Coin_Counters_ScorSch = @rcc, Coin_Counters_ObemBunker = @rob, Coin_Counters_price = @rcen WHERE coin_counters.IDCC = @rid", dBRedac.getConnection());
            sqlCommandRedac.Parameters.Add("@rname", MySqlDbType.VarChar).Value = textBoxR_name_CC.Text;
            sqlCommandRedac.Parameters.Add("@rbrand", MySqlDbType.Int32).Value = comboBoxR_brand_CC.SelectedIndex;
            sqlCommandRedac.Parameters.Add("@rcc", MySqlDbType.Int32).Value = textBoxR_CC_CC.Text;
            sqlCommandRedac.Parameters.Add("@rob", MySqlDbType.Int32).Value = textBoxR_EBZ_CC.Text;
            sqlCommandRedac.Parameters.Add("@rcen", MySqlDbType.Decimal).Value = textBoxR_cen_CC.Text;
            sqlCommandRedac.Parameters.Add("@rid", MySqlDbType.Int32).Value = Int32.Parse(id);
            if (sqlCommandRedac.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("OK");
                DGV_Сoin_Сounters.Rows.Clear();
                string resorcessqlCC = "SELECT IDCC, Coin_Counters_name, brand.Brand_name, Coin_Counters_ScorSch, Coin_Counters_ObemBunker, Coin_Counters_price FROM coin_counters AS CoinCounters INNER JOIN Brand AS brand ON brand.Brand_id = CoinCounters.Coin_Counters_brand";
                MySqlCommand sqlCommandCC = new MySqlCommand(resorcessqlCC, dBRedac.getConnection());
                MySqlDataReader dataReaderCC = sqlCommandCC.ExecuteReader();
                while (dataReaderCC.Read())
                {
                    DGV_Сoin_Сounters.Rows.Add(dataReaderCC[0].ToString(), dataReaderCC[1].ToString(), dataReaderCC[2].ToString(), dataReaderCC[3].ToString(), dataReaderCC[4].ToString(), dataReaderCC[5].ToString());
                }
                dataReaderCC.Close();
            } 
            else 
            {
                MessageBox.Show("ERROR");
            }
        }

        private void buttonnazad_Click(object sender, EventArgs e)
        {
            AdminPanelWindow panelWindow = new AdminPanelWindow();
            panelWindow.Show();
            this.Close();
        }

        private void SaveExelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {

            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;


                for (int i = 0; i < DGV_Сoin_Сounters.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < DGV_Сoin_Сounters.Columns.Count; j++)
                    {
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV_Сoin_Сounters.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV_Сoin_Сounters.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }


                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.csv)|*.csv|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
    }
}
