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
    /// Логика взаимодействия для окна администратора (таблица Currency_Detectors)
    /// </summary>
    public partial class Currency_Detectors : Form
    {
        public string id;
        public Currency_Detectors()
        {
            InitializeComponent();

            // загрузка данных
            DGV_Currency_Detectors.Columns.Add("ID", "№ ");
            DGV_Currency_Detectors.Columns.Add("name", "Наименование");
            DGV_Currency_Detectors.Columns.Add("brand", "Бренд");
            DGV_Currency_Detectors.Columns.Add("TypeDetector", "Тип детектора");
            DGV_Currency_Detectors.Columns.Add("sensorgps", "Вид детекции");
            DGV_Currency_Detectors.Columns.Add("battery", "Аккумулятор");
            DGV_Currency_Detectors.Columns.Add("price", "Цена");

            ConnectorDB DGVCD = new ConnectorDB();
            DGVCD.openConnection();
            string sqlCD = "SELECT IDCD, Currency_Detectors_name, brand.Brand_name, TypeDetector.TypeDetector_name, Currency_Detectors_sensorgps, battery.YesNo_name, Currency_Detectors_price FROM Currency_Detectors AS CurrencyDetectors INNER JOIN Brand AS brand ON brand.Brand_id = CurrencyDetectors.Currency_Detectors_brand INNER JOIN TypeDetector AS TypeDetector ON TypeDetector.TypeDetector_id = CurrencyDetectors.Currency_Detectors_TypeDetector INNER JOIN YesNo AS battery ON battery.YesNo_id = CurrencyDetectors.Currency_Detectors_battery";
            MySqlCommand commandCD = new MySqlCommand(sqlCD, DGVCD.getConnection());
            MySqlDataReader readerCD = commandCD.ExecuteReader();
            while (readerCD.Read()) 
            {
                DGV_Currency_Detectors.Rows.Add(readerCD[0].ToString(), readerCD[1].ToString(), readerCD[2].ToString(), readerCD[3].ToString(), readerCD[4].ToString(), readerCD[5].ToString(), readerCD[6].ToString());
            }
            readerCD.Close();
            DGVCD.closeConnection();

            //загрузка ресурсов
            ConnectorDB resourcesCD = new ConnectorDB();
            resourcesCD.openConnection();
            string brand = "SELECT Brand_name FROM brand";
            MySqlCommand commandBrand = new MySqlCommand(brand, resourcesCD.getConnection());
            MySqlDataReader dataReaderBrand = commandBrand.ExecuteReader();
            while (dataReaderBrand.Read()) 
            {
                comboBoxBrend.Items.Add(dataReaderBrand[0].ToString());
                comboBoxEdB.Items.Add(dataReaderBrand[0].ToString());
            }
            dataReaderBrand.Close();

            string TypeDet = "SELECT TypeDetector_name FROM typedetector";
            MySqlCommand commandTypeDet = new MySqlCommand(TypeDet, resourcesCD.getConnection());
            MySqlDataReader dataReaderTD = commandTypeDet.ExecuteReader();
            while (dataReaderTD.Read()) 
            {
                comboBoxTD.Items.Add(dataReaderTD[0].ToString());
                comboBoxEdTD.Items.Add(dataReaderTD[0].ToString());
            }
            dataReaderTD.Close();

            string yesno = "SELECT YesNo_name FROM yesno";
            MySqlCommand commandYN = new MySqlCommand(yesno, resourcesCD.getConnection());
            MySqlDataReader dataReaderYN = commandYN.ExecuteReader();
            while (dataReaderYN.Read()) 
            {
                comboBoxYN.Items.Add(dataReaderYN[0].ToString());
                comboBoxEdAc.Items.Add(dataReaderYN[0].ToString());
            }
            dataReaderYN.Close();
            resourcesCD.closeConnection();
        }

        private void buttonDobav_Click(object sender, EventArgs e)
        {
            string namein = textBoxName.Text;
            string vidDect = textBoxVD.Text;
            string cenain = textBoxCena.Text;

            if (namein.Length >= 1 || vidDect.Length >= 1 || cenain.Length >= 1) 
            {
                ConnectorDB connector = new ConnectorDB();
                MySqlCommand ComNewCD = new MySqlCommand("INSERT INTO `currency_detectors` (`Currency_Detectors_name`, `Currency_Detectors_brand`, `Currency_Detectors_TypeDetector`, `Currency_Detectors_sensorgps`, `Currency_Detectors_battery`, `Currency_Detectors_price`) VALUES (@cdname, @cdbrand, @cdtd, @cdds, @sdyn, @cdcen);", connector.getConnection());
                
                ComNewCD.Parameters.Add("@cdname", MySqlDbType.VarChar).Value = textBoxName.Text;
                ComNewCD.Parameters.Add("@cdbrand", MySqlDbType.Int32).Value = comboBoxBrend.SelectedIndex;
                ComNewCD.Parameters.Add("@cdtd", MySqlDbType.Int32).Value = comboBoxTD.SelectedIndex;
                ComNewCD.Parameters.Add("@cdds", MySqlDbType.VarChar).Value = textBoxVD.Text.ToString();
                ComNewCD.Parameters.Add("@sdyn", MySqlDbType.Int32).Value = comboBoxYN.SelectedIndex;
                ComNewCD.Parameters.Add("@cdcen", MySqlDbType.Decimal).Value = textBoxCena.Text;

                connector.openConnection();
                if (ComNewCD.ExecuteNonQuery() == 1) 
                {
                    MessageBox.Show("Детектора валют \n > " + namein + " < \n создан!");
                    DGV_Currency_Detectors.Rows.Clear();
                    string sqlCD = "SELECT IDCD, Currency_Detectors_name, brand.Brand_name, TypeDetector.TypeDetector_name, Currency_Detectors_sensorgps, battery.YesNo_name, Currency_Detectors_price FROM Currency_Detectors AS CurrencyDetectors INNER JOIN Brand AS brand ON brand.Brand_id = CurrencyDetectors.Currency_Detectors_brand INNER JOIN TypeDetector AS TypeDetector ON TypeDetector.TypeDetector_id = CurrencyDetectors.Currency_Detectors_TypeDetector INNER JOIN YesNo AS battery ON battery.YesNo_id = CurrencyDetectors.Currency_Detectors_battery";
                    MySqlCommand newCD = new MySqlCommand(sqlCD, connector.getConnection());
                    MySqlDataReader rnewCD = newCD.ExecuteReader();
                    while (rnewCD.Read())
                    {
                        DGV_Currency_Detectors.Rows.Add(rnewCD[0].ToString(), rnewCD[1].ToString(), rnewCD[2].ToString(), rnewCD[3].ToString(), rnewCD[4].ToString(), rnewCD[5].ToString(), rnewCD[6].ToString());
                    }
                    rnewCD.Close();
                } 
                    else 
                        MessageBox.Show("Что то пошло не так");

                connector.closeConnection();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void DGV_Currency_Detectors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (DGV_Currency_Detectors.Rows[e.RowIndex].Cells[0].Value).ToString();

            ConnectorDB connectorECD = new ConnectorDB();
            connectorECD.openConnection();
            string EditSqlCD = "SELECT * FROM currency_detectors WHERE IDCD = " + id;
            MySqlCommand commandESCD = new MySqlCommand(EditSqlCD, connectorECD.getConnection());
            MySqlDataReader dataReaderEcD = commandESCD.ExecuteReader();
            while (dataReaderEcD.Read()) 
            {
                textBoxEdn.Text = dataReaderEcD[1].ToString();
                labelPn.Text = "Наименование \n" + dataReaderEcD[1].ToString();

                comboBoxEdB.SelectedIndex = Int32.Parse(dataReaderEcD[2].ToString());
                labelPb.Text = "Бренд \n" + comboBoxEdB.Items[comboBoxEdB.SelectedIndex].ToString();

                comboBoxEdTD.SelectedIndex = Int32.Parse(dataReaderEcD[3].ToString());
                labelPtd.Text = "Тип детектора \n" + comboBoxEdTD.Items[comboBoxEdTD.SelectedIndex].ToString();

                textBoxEDVD.Text = dataReaderEcD[4].ToString();
                labelPvd.Text = "Вид детекции \n" + dataReaderEcD[4].ToString(); 
                
                comboBoxEdAc.SelectedIndex = Int32.Parse(dataReaderEcD[5].ToString());
                labelPac.Text = "Аккумулятор \n" + comboBoxEdAc.Items[comboBoxEdAc.SelectedIndex].ToString();

                textBoxEDCen.Text = dataReaderEcD[6].ToString();
                labelPc.Text = "Цена (.руб) \n" + dataReaderEcD[6].ToString();
            }
            dataReaderEcD.Close();
            connectorECD.closeConnection();
        }

        private void buttonObnovit_Click(object sender, EventArgs e)
        {
            string EBN = textBoxEdn.Text;
            string EDVD = textBoxEDVD.Text;
            string EDC = textBoxEDCen.Text;

            ConnectorDB cUPECD = new ConnectorDB();
            
            //string upcd = "UPDATE currency_detectors SET Currency_Detectors_name = '@cdname', Currency_Detectors_brand = '@cdbrand', Currency_Detectors_TypeDetector = '@cdtd', Currency_Detectors_sensorgps = '@cdds', Currency_Detectors_battery = '@sdyn', Currency_Detectors_price = '@cdcen' WHERE currency_detectors.IDCD = " + id;
            MySqlCommand ComUPCD = new MySqlCommand("UPDATE currency_detectors SET Currency_Detectors_name = @cdname, Currency_Detectors_brand = @cdbrand, Currency_Detectors_TypeDetector = @cdtd, Currency_Detectors_sensorgps = @cdds, Currency_Detectors_battery = @sdyn, Currency_Detectors_price = @cdcen WHERE currency_detectors.IDCD = @idcd", cUPECD.getConnection());

            ComUPCD.Parameters.Add("@idcd", MySqlDbType.Int32).Value = id;
            ComUPCD.Parameters.Add("@cdname", MySqlDbType.VarChar).Value = EBN;
            ComUPCD.Parameters.Add("@cdbrand", MySqlDbType.Int32).Value = comboBoxEdB.SelectedIndex;
            ComUPCD.Parameters.Add("@cdtd", MySqlDbType.Int32).Value = comboBoxEdTD.SelectedIndex;
            ComUPCD.Parameters.Add("@cdds", MySqlDbType.VarChar).Value = EDVD;
            ComUPCD.Parameters.Add("@sdyn", MySqlDbType.Int32).Value = comboBoxEdAc.SelectedIndex;
            ComUPCD.Parameters.Add("@cdcen", MySqlDbType.Decimal).Value = EDC;

            cUPECD.openConnection();
            if (ComUPCD.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("Ok");
                DGV_Currency_Detectors.Rows.Clear();
                string sqlUPCD = "SELECT IDCD, Currency_Detectors_name, brand.Brand_name, TypeDetector.TypeDetector_name, Currency_Detectors_sensorgps, battery.YesNo_name, Currency_Detectors_price FROM Currency_Detectors AS CurrencyDetectors INNER JOIN Brand AS brand ON brand.Brand_id = CurrencyDetectors.Currency_Detectors_brand INNER JOIN TypeDetector AS TypeDetector ON TypeDetector.TypeDetector_id = CurrencyDetectors.Currency_Detectors_TypeDetector INNER JOIN YesNo AS battery ON battery.YesNo_id = CurrencyDetectors.Currency_Detectors_battery";
                MySqlCommand newCD = new MySqlCommand(sqlUPCD, cUPECD.getConnection());
                MySqlDataReader unewCD = newCD.ExecuteReader();
                while (unewCD.Read())
                {
                    DGV_Currency_Detectors.Rows.Add(unewCD[0].ToString(), unewCD[1].ToString(), unewCD[2].ToString(), unewCD[3].ToString(), unewCD[4].ToString(), unewCD[5].ToString(), unewCD[6].ToString());
                }
                unewCD.Close();
            }
            cUPECD.closeConnection();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            ConnectorDB dBZapDEl = new ConnectorDB();
            string delCD = "DELETE FROM currency_detectors WHERE currency_detectors.IDCD = " + id;
            MySqlCommand CDdel = new MySqlCommand(delCD, dBZapDEl.getConnection());
            dBZapDEl.openConnection();
            if (CDdel.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("OK");
                DGV_Currency_Detectors.Rows.Clear();
                string sqlUPCD = "SELECT IDCD, Currency_Detectors_name, brand.Brand_name, TypeDetector.TypeDetector_name, Currency_Detectors_sensorgps, battery.YesNo_name, Currency_Detectors_price FROM Currency_Detectors AS CurrencyDetectors INNER JOIN Brand AS brand ON brand.Brand_id = CurrencyDetectors.Currency_Detectors_brand INNER JOIN TypeDetector AS TypeDetector ON TypeDetector.TypeDetector_id = CurrencyDetectors.Currency_Detectors_TypeDetector INNER JOIN YesNo AS battery ON battery.YesNo_id = CurrencyDetectors.Currency_Detectors_battery";
                MySqlCommand newCD = new MySqlCommand(sqlUPCD, dBZapDEl.getConnection());
                MySqlDataReader unewCD = newCD.ExecuteReader();
                while (unewCD.Read())
                {
                    DGV_Currency_Detectors.Rows.Add(unewCD[0].ToString(), unewCD[1].ToString(), unewCD[2].ToString(), unewCD[3].ToString(), unewCD[4].ToString(), unewCD[5].ToString(), unewCD[6].ToString());
                }
                unewCD.Close();
            }
            dBZapDEl.closeConnection();
        }

        private void buttonnazad_Click(object sender, EventArgs e)
        {
            AdminPanelWindow panelWindow = new AdminPanelWindow();
            panelWindow.Show();
            this.Close();
        }

        private void SaveExcelToolStripMenuItem_Click(object sender, EventArgs e)
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


                for (int i = 0; i < DGV_Currency_Detectors.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < DGV_Currency_Detectors.Columns.Count; j++)
                    {
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV_Currency_Detectors.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = DGV_Currency_Detectors.Rows[i].Cells[j].Value.ToString();
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
