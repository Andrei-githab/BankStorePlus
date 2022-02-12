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
    /// Логика взаимодействия для пользовательского окна UserWindow
    /// </summary>
    public partial class UserWindow : Form
    {
        public UserWindow()
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
            resorcesDBBC.closeConnection();

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
            resorcesDBCC.closeConnection();
        }

        private void DGV_Currency_Detectors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idcd = (DGV_Currency_Detectors.Rows[e.RowIndex].Cells[0].Value).ToString();
            // отображение данных
            ConnectorDB connectorECD = new ConnectorDB();
            connectorECD.openConnection();
            string EditSqlCD = "SELECT IDCD, Currency_Detectors_name, brand.Brand_name, TypeDetector.TypeDetector_name, Currency_Detectors_sensorgps, battery.YesNo_name, Currency_Detectors_price FROM Currency_Detectors AS CurrencyDetectors INNER JOIN Brand AS brand ON brand.Brand_id = CurrencyDetectors.Currency_Detectors_brand INNER JOIN TypeDetector AS TypeDetector ON TypeDetector.TypeDetector_id = CurrencyDetectors.Currency_Detectors_TypeDetector INNER JOIN YesNo AS battery ON battery.YesNo_id = CurrencyDetectors.Currency_Detectors_battery WHERE IDCD = " + idcd;
            MySqlCommand commandESCD = new MySqlCommand(EditSqlCD, connectorECD.getConnection());
            MySqlDataReader dataReaderEcD = commandESCD.ExecuteReader();
            while (dataReaderEcD.Read())
            {
                labelPn.Text = "Наименование \n" + dataReaderEcD[1].ToString();

                labelPb.Text = "Бренд \n" + dataReaderEcD[2].ToString();
                
                labelPtd.Text = "Тип детектора \n" + dataReaderEcD[3].ToString();

                labelPvd.Text = "Вид детекции \n" + dataReaderEcD[4].ToString();

                labelPac.Text = "Аккумулятор \n" + dataReaderEcD[5].ToString();

                labelPc.Text = "Цена (.руб) \n" + dataReaderEcD[6].ToString();
            }
            dataReaderEcD.Close();
            connectorECD.closeConnection();
        }

        private void DGV_Bill_Counters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idbc = (DGV_Bill_Counters.Rows[e.RowIndex].Cells[0].Value).ToString();
            // отображение данных
            ConnectorDB connectorP = new ConnectorDB();
            connectorP.openConnection();
            string sqlpros = "SELECT IDBC, Bill_Counters_name, brand.Brand_name, Bill_Counters_ScorBac, Bill_Counters_ObemLotka, valuta_index.Valuta_type, Bill_Counters_price FROM bill_counters as bc INNER JOIN Brand AS brand ON brand.Brand_id = bc.Bill_Counters_brand INNER JOIN valuta_index AS valuta_index ON valuta_index.Valuta_id = bc.Bill_Counters_Valuta WHERE IDBC = " + idbc;
            MySqlCommand sqlCommandPros = new MySqlCommand(sqlpros, connectorP.getConnection());
            MySqlDataReader mySqlDataPros = sqlCommandPros.ExecuteReader();
            while (mySqlDataPros.Read())
            {
                labelP_BC_name.Text = "Наименование\n" + mySqlDataPros[1].ToString();

                labelP_BC_brand.Text = "Бренд\n" + mySqlDataPros[2].ToString();

                labelP_BC_Skorper.Text = "Скорость пересчета банкнот\n(в минуту)\n" + mySqlDataPros[3].ToString();

                labelP_BC_epl.Text = "Емкость подающего лотка\n(банкнот)\n" + mySqlDataPros[4].ToString();

                labelP_BC_Vol.Text = "Тип валют\n" + mySqlDataPros[5].ToString();

                labelP_BC_cen.Text = "Цена (.руб)\n" + mySqlDataPros[6].ToString();
            }
            mySqlDataPros.Close();
            connectorP.closeConnection();
        }

        private void DGV_Сoin_Сounters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string idcc = (DGV_Сoin_Сounters.Rows[e.RowIndex].Cells[0].Value).ToString();
            // отображение данных
            ConnectorDB connectorP = new ConnectorDB();
            connectorP.openConnection();
            string sqlP = "SELECT IDCC, Coin_Counters_name, brand.Brand_name, Coin_Counters_ScorSch, Coin_Counters_ObemBunker, Coin_Counters_price FROM coin_counters AS CoinCounters INNER JOIN Brand AS brand ON brand.Brand_id = CoinCounters.Coin_Counters_brand WHERE IDCC = " + idcc;
            MySqlCommand mySqlP = new MySqlCommand(sqlP, connectorP.getConnection());
            MySqlDataReader dataReaderPros = mySqlP.ExecuteReader();
            while (dataReaderPros.Read())
            {
                labelPNCC.Text = "Наименование\n" + dataReaderPros[1].ToString();

                labelPBCC.Text = "Бренд\n" + dataReaderPros[2].ToString();

                labelPCCCC.Text = "Скорость счета (в минуту)\n" + dataReaderPros[3].ToString();

                labelPEBZCC.Text = "Емкость бункера загрузки (монет)\n" + dataReaderPros[4].ToString();

                labelPCCC.Text = "Цена(руб.)\n" + dataReaderPros[5].ToString();
            }
            dataReaderPros.Close();
            connectorP.closeConnection();
        }
    }
}
