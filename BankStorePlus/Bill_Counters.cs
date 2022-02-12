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
    /// Логика взаимодействия для окна администратора (таблица Bill_Counters)
    /// </summary>
    public partial class Bill_Counters : Form
    {
        private string id;
        public Bill_Counters()
        {
            InitializeComponent();

            // загрузка данных
            DGV_Bill_Counters.Columns.Add("ID", "№ ");
            DGV_Bill_Counters.Columns.Add("name", "Наименование");
            DGV_Bill_Counters.Columns.Add("brand", "Бренд");
            DGV_Bill_Counters.Columns.Add("spbanc", "Скорость пересчета банкнот (в минуту)");
            DGV_Bill_Counters.Columns.Add("epl", "Емкость подающего лотка (банкнот)");
            DGV_Bill_Counters.Columns.Add("typvol", "Тип валют");
            DGV_Bill_Counters.Columns.Add("price", "Цена");

            ConnectorDB resorcesDBBC = new ConnectorDB();
            resorcesDBBC.openConnection();
            string resorcessqlBC = "SELECT IDBC, Bill_Counters_name, brand.Brand_name, Bill_Counters_ScorBac, Bill_Counters_ObemLotka, valuta_index.Valuta_type, Bill_Counters_price FROM bill_counters as bc INNER JOIN Brand AS brand ON brand.Brand_id = bc.Bill_Counters_brand INNER JOIN valuta_index AS valuta_index ON valuta_index.Valuta_id = bc.Bill_Counters_Valuta";
            MySqlCommand sqlCommandBC = new MySqlCommand(resorcessqlBC, resorcesDBBC.getConnection());
            MySqlDataReader dataReaderRBC = sqlCommandBC.ExecuteReader();
            while (dataReaderRBC.Read()) 
            {
                DGV_Bill_Counters.Rows.Add(dataReaderRBC[0].ToString(), dataReaderRBC[1].ToString(), dataReaderRBC[2].ToString(), dataReaderRBC[3].ToString(), dataReaderRBC[4].ToString(), dataReaderRBC[5].ToString(), dataReaderRBC[6].ToString());
            }
            dataReaderRBC.Close();

            //загрузка ресурсов
            string brand = "SELECT Brand_name FROM brand";
            MySqlCommand commandBrand = new MySqlCommand(brand, resorcesDBBC.getConnection());
            MySqlDataReader dataReaderBrand = commandBrand.ExecuteReader();
            while (dataReaderBrand.Read())
            {
                comboBoxD_BC_brend.Items.Add(dataReaderBrand[0].ToString());
                comboBoxR_BC_brend.Items.Add(dataReaderBrand[0].ToString());
            }
            dataReaderBrand.Close();

            string vol = "SELECT Valuta_type FROM valuta_index;";
            MySqlCommand commandValuta = new MySqlCommand(vol, resorcesDBBC.getConnection());
            MySqlDataReader dataReaderValuta = commandValuta.ExecuteReader();
            while (dataReaderValuta.Read()) 
            {
                comboBoxD_BC_vol.Items.Add(dataReaderValuta[0].ToString());
                comboBoxR_BC_vol.Items.Add(dataReaderValuta[0].ToString());
            }
            dataReaderValuta.Close();

            resorcesDBBC.closeConnection();
        }

        private void DGV_Bill_Counters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (DGV_Bill_Counters.Rows[e.RowIndex].Cells[0].Value).ToString();

            ConnectorDB connectorP = new ConnectorDB();
            connectorP.openConnection();
            string sqlpros = "SELECT * FROM bill_counters WHERE IDBC = " + id;
            MySqlCommand sqlCommandPros = new MySqlCommand(sqlpros, connectorP.getConnection());
            MySqlDataReader mySqlDataPros = sqlCommandPros.ExecuteReader(); 
            while (mySqlDataPros.Read()) 
            {
                textBoxR_BC_name.Text = mySqlDataPros[1].ToString();
                labelP_BC_name.Text = "Наименование\n" + mySqlDataPros[1].ToString();

                comboBoxR_BC_brend.SelectedIndex = Int32.Parse(mySqlDataPros[2].ToString());
                labelP_BC_brand.Text = "Бренд\n" + comboBoxR_BC_brend.Items[comboBoxR_BC_brend.SelectedIndex].ToString();

                textBoxR_BC_spk.Text = mySqlDataPros[3].ToString();
                labelP_BC_Skorper.Text = "Скорость пересчета банкнот\n(в минуту)\n" + mySqlDataPros[3].ToString();

                textBoxR_BC_epl.Text = mySqlDataPros[4].ToString();
                labelP_BC_epl.Text = "Емкость подающего лотка\n(банкнот)\n" + mySqlDataPros[4].ToString();

                comboBoxR_BC_vol.SelectedIndex = Int32.Parse(mySqlDataPros[5].ToString());
                labelP_BC_Vol.Text = "Тип валют\n" + comboBoxR_BC_vol.Items[comboBoxR_BC_vol.SelectedIndex].ToString();

                textBoxR_BC_cen.Text = mySqlDataPros[6].ToString();
                labelP_BC_cen.Text = "Цена (.руб)\n" + mySqlDataPros[6].ToString();
            }
            mySqlDataPros.Close();
            connectorP.closeConnection();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            ConnectorDB connectorDelBC = new ConnectorDB();
            connectorDelBC.openConnection();
            MySqlCommand commandDelBCZap = new MySqlCommand("DELETE FROM bill_counters WHERE bill_counters.IDBC = @idbcdelzap", connectorDelBC.getConnection());
            commandDelBCZap.Parameters.Add("@idbcdelzap", MySqlDbType.Int32).Value = Int32.Parse(id);
            if (commandDelBCZap.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("OK");
                DGV_Bill_Counters.Rows.Clear();
                string ubnovsqlBC = "SELECT IDBC, Bill_Counters_name, brand.Brand_name, Bill_Counters_ScorBac, Bill_Counters_ObemLotka, valuta_index.Valuta_type, Bill_Counters_price FROM bill_counters as bc INNER JOIN Brand AS brand ON brand.Brand_id = bc.Bill_Counters_brand INNER JOIN valuta_index AS valuta_index ON valuta_index.Valuta_id = bc.Bill_Counters_Valuta";
                MySqlCommand CommandBC = new MySqlCommand(ubnovsqlBC, connectorDelBC.getConnection());
                MySqlDataReader ObnovdRRBC = CommandBC.ExecuteReader();
                while (ObnovdRRBC.Read())
                {
                    DGV_Bill_Counters.Rows.Add(ObnovdRRBC[0].ToString(), ObnovdRRBC[1].ToString(), ObnovdRRBC[2].ToString(), ObnovdRRBC[3].ToString(), ObnovdRRBC[4].ToString(), ObnovdRRBC[5].ToString(), ObnovdRRBC[6].ToString());
                }
                ObnovdRRBC.Close();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            connectorDelBC.closeConnection();
        }

        private void buttonDobav_Click(object sender, EventArgs e)
        {
            ConnectorDB connectorDobavDB = new ConnectorDB();
            connectorDobavDB.openConnection();
            MySqlCommand sqlCommandDobavZap = new MySqlCommand("INSERT INTO bill_counters (Bill_Counters_name, Bill_Counters_brand, Bill_Counters_ScorBac, Bill_Counters_ObemLotka, Bill_Counters_Valuta, Bill_Counters_price) VALUES (@bcname, @bcbrand, @bcsb, @bcol, @bcvol, @bccen)", connectorDobavDB.getConnection());
            sqlCommandDobavZap.Parameters.Add("@bcname", MySqlDbType.VarChar).Value = textBoxD_BC_name.Text;
            sqlCommandDobavZap.Parameters.Add("@bcbrand", MySqlDbType.Int32).Value = comboBoxD_BC_brend.SelectedIndex;
            sqlCommandDobavZap.Parameters.Add("@bcsb", MySqlDbType.Int32).Value = textBoxD_BC_spk.Text;
            sqlCommandDobavZap.Parameters.Add("@bcol", MySqlDbType.Int32).Value = textBoxD_BC_epl.Text;
            sqlCommandDobavZap.Parameters.Add("@bcvol", MySqlDbType.Int32).Value = comboBoxD_BC_vol.SelectedIndex;
            sqlCommandDobavZap.Parameters.Add("@bccen", MySqlDbType.Decimal).Value = textBoxD_BC_cen.Text;
            if (sqlCommandDobavZap.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("OK");
                DGV_Bill_Counters.Rows.Clear();
                string DubnovsqlBC = "SELECT IDBC, Bill_Counters_name, brand.Brand_name, Bill_Counters_ScorBac, Bill_Counters_ObemLotka, valuta_index.Valuta_type, Bill_Counters_price FROM bill_counters as bc INNER JOIN Brand AS brand ON brand.Brand_id = bc.Bill_Counters_brand INNER JOIN valuta_index AS valuta_index ON valuta_index.Valuta_id = bc.Bill_Counters_Valuta";
                MySqlCommand CommandBC = new MySqlCommand(DubnovsqlBC, connectorDobavDB.getConnection());
                MySqlDataReader DObnovdRRBC = CommandBC.ExecuteReader();
                while (DObnovdRRBC.Read())
                {
                    DGV_Bill_Counters.Rows.Add(DObnovdRRBC[0].ToString(), DObnovdRRBC[1].ToString(), DObnovdRRBC[2].ToString(), DObnovdRRBC[3].ToString(), DObnovdRRBC[4].ToString(), DObnovdRRBC[5].ToString(), DObnovdRRBC[6].ToString());
                }
                DObnovdRRBC.Close();
            }
            else 
            {
                MessageBox.Show("ERROR");
            }
            connectorDobavDB.closeConnection();
        }

        private void buttonRedac_Click(object sender, EventArgs e)
        {
            ConnectorDB connectorDBRedac = new ConnectorDB();
            connectorDBRedac.openConnection(); 
            MySqlCommand mySqlRedac = new MySqlCommand("UPDATE bill_counters SET Bill_Counters_name = @newnamebc, Bill_Counters_brand = @newbrandbc, Bill_Counters_ScorBac = @newbcsb, Bill_Counters_ObemLotka = @newolbc, Bill_Counters_Valuta = @newbcvol, Bill_Counters_price = @newcenbc WHERE bill_counters.IDBC = @id", connectorDBRedac.getConnection());
            mySqlRedac.Parameters.Add("@newnamebc", MySqlDbType.VarChar).Value = textBoxR_BC_name.Text;
            mySqlRedac.Parameters.Add("@newbrandbc", MySqlDbType.Int32).Value = comboBoxR_BC_brend.SelectedIndex;
            mySqlRedac.Parameters.Add("@newbcsb", MySqlDbType.Int32).Value = textBoxD_BC_spk.Text;
            mySqlRedac.Parameters.Add("@newolbc", MySqlDbType.Int32).Value = textBoxR_BC_epl.Text;
            mySqlRedac.Parameters.Add("@newbcvol", MySqlDbType.Int32).Value = comboBoxR_BC_vol.SelectedIndex;
            mySqlRedac.Parameters.Add("@newcenbc", MySqlDbType.Decimal).Value = textBoxR_BC_cen.Text;
            mySqlRedac.Parameters.Add("@id", MySqlDbType.Int32).Value = Int32.Parse(id);
            if (mySqlRedac.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("OK");
                DGV_Bill_Counters.Rows.Clear();
                string RubnovsqlBC = "SELECT IDBC, Bill_Counters_name, brand.Brand_name, Bill_Counters_ScorBac, Bill_Counters_ObemLotka, valuta_index.Valuta_type, Bill_Counters_price FROM bill_counters as bc INNER JOIN Brand AS brand ON brand.Brand_id = bc.Bill_Counters_brand INNER JOIN valuta_index AS valuta_index ON valuta_index.Valuta_id = bc.Bill_Counters_Valuta";
                MySqlCommand RCommandBC = new MySqlCommand(RubnovsqlBC, connectorDBRedac.getConnection());
                MySqlDataReader RObnovdRRBC = RCommandBC.ExecuteReader();
                while (RObnovdRRBC.Read())
                {
                    DGV_Bill_Counters.Rows.Add(RObnovdRRBC[0].ToString(), RObnovdRRBC[1].ToString(), RObnovdRRBC[2].ToString(), RObnovdRRBC[3].ToString(), RObnovdRRBC[4].ToString(), RObnovdRRBC[5].ToString(), RObnovdRRBC[6].ToString());
                }
                RObnovdRRBC.Close();
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

        private void SaveExeliExcelToolStripMenuItem_Click(object sender, EventArgs e)
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


                for (int i = 0; i < DGV_Bill_Counters.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < DGV_Bill_Counters.Columns.Count; j++)
                    {
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV_Bill_Counters.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV_Bill_Counters.Rows[i].Cells[j].Value.ToString();
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
