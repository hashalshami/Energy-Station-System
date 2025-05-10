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

namespace EnergyStationSystem.SystemConfigForms
{
    public partial class Subscribers : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        private void ClearFields()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtNote.Text = "";
            txtContractID.Text = "";
            txtMeter.Text = "";
            txtAmountSubscription.Text = Properties.Settings.Default.AutomaticSubscriptionAmount;
        }
        private void LoadSubscribers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    string querySubscriber = "SELECT id, name FROM Subscriber";
                    SqlDataAdapter daSubscriber = new SqlDataAdapter(querySubscriber, con);
                    DataTable dtSubscriber = new DataTable();
                    daSubscriber.Fill(dtSubscriber);

                    cmbSubscriber.DataSource = dtSubscriber;
                    cmbSubscriber.DisplayMember = "name";
                    cmbSubscriber.ValueMember = "id";
                    cmbSubscriber.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ عند الاتصال: " + ex.Message);
            }
        }

        private void LoadBlocks(int regionId)
        {
            try
            {
                if (cmbRegion.SelectedValue != null || cmbRegion.SelectedValue != DBNull.Value)
                {
                    //int regionId = Convert.ToInt32(cmbRegion.SelectedValue);
                    using (SqlConnection con = new SqlConnection(db.connectionString))
                    {
                        string queryBlocks = "SELECT id, name FROM Blocks WHERE region_id = @region_id";
                        SqlCommand cmdBlocks = new SqlCommand(queryBlocks, con);
                        cmdBlocks.Parameters.AddWithValue("@region_id", regionId);

                        SqlDataAdapter daBlocks = new SqlDataAdapter(cmdBlocks);
                        DataTable dtBlocks = new DataTable();
                        daBlocks.Fill(dtBlocks);

                        cmbBlock.DataSource = dtBlocks;
                        cmbBlock.DisplayMember = "name";
                        cmbBlock.ValueMember = "id";
                        cmbBlock.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ تحميل المربعات : " + ex.Message);
            }
        }

        private void LoadCoins()
        {

        }
        private void LoadContractTypes()
        {

        }
        

        private void LoadData()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(db.connectionString))
                {
                    con.Open();
                    // AccountTypes
                    string queryAccountType = "SELECT id, name FROM AccountTypes ORDER BY id";
                    SqlDataAdapter daAccountType = new SqlDataAdapter(queryAccountType, con);
                    DataTable dtAccountType = new DataTable();
                    daAccountType.Fill(dtAccountType);

                    cmbAccountType.DataSource = dtAccountType;
                    cmbAccountType.DisplayMember = "name";
                    cmbAccountType.ValueMember = "id";
                    cmbAccountType.SelectedIndex = 0;

                    // Coins
                    string queryCoins = "SELECT id, name FROM Coins ORDER BY id";
                    SqlDataAdapter daCoins = new SqlDataAdapter(queryCoins, con);
                    DataTable dtCoins = new DataTable();
                    daCoins.Fill(dtCoins);

                    cmbCoin.DataSource = dtCoins;
                    cmbCoin.DisplayMember = "name";
                    cmbCoin.ValueMember = "id";
                    cmbCoin.SelectedIndex = 0;

                    // ContractTypes
                    string queryContractTypes = "SELECT id, name FROM ContractTypes ORDER BY id";
                    SqlDataAdapter daContractTypes = new SqlDataAdapter(queryContractTypes, con);
                    DataTable dtContractTypes = new DataTable();
                    daContractTypes.Fill(dtContractTypes);

                    cmbContractType.DataSource = dtContractTypes;
                    cmbContractType.DisplayMember = "name";
                    cmbContractType.ValueMember = "id";
                    cmbContractType.SelectedIndex = 0;

                    // MeterStatus
                    string queryMeterStatus = "SELECT id, name FROM MeterStatus ";
                    SqlDataAdapter daMeterStatus = new SqlDataAdapter(queryMeterStatus, con);
                    DataTable dtMeterStatus = new DataTable();
                    daMeterStatus.Fill(dtMeterStatus);

                    cmbMeterStatus.DataSource = dtMeterStatus;
                    cmbMeterStatus.DisplayMember = "name";
                    cmbMeterStatus.ValueMember = "id";
                    cmbMeterStatus.SelectedValue = 1;

                    // Regions
                    string queryRegions = "SELECT id, name FROM Regions";
                    SqlDataAdapter daRegions = new SqlDataAdapter(queryRegions, con);
                    DataTable dtRegions = new DataTable();
                    daRegions.Fill(dtRegions);

                    cmbRegion.DataSource = dtRegions;
                    cmbRegion.DisplayMember = "name";
                    cmbRegion.ValueMember = "id";
                    cmbRegion.SelectedIndex = 0;

                    // Blocks
                    LoadBlocks(Convert.ToInt32(cmbRegion.SelectedValue));

                    // SubscriptionTypes
                    string querySubscriptionTypes = "SELECT id, name FROM SubscriptionTypes ORDER BY id";
                    SqlDataAdapter daSubscriptionTypes = new SqlDataAdapter(querySubscriptionTypes, con);
                    DataTable dtSubscriptionTypes = new DataTable();
                    daSubscriptionTypes.Fill(dtSubscriptionTypes);

                    cmbSubscriptionType.DataSource = dtSubscriptionTypes;
                    cmbSubscriptionType.DisplayMember = "name";
                    cmbSubscriptionType.ValueMember = "id";
                    cmbSubscriptionType.SelectedIndex = 0;
                    

                    
                    ////////////

                    //SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Collectors", con);
                    //DataTable dt = new DataTable();
                    //adapter.Fill(dt);
                    //BindingSource bs = new BindingSource();
                    //bs.DataSource = dt;
                    //dataGridView1.DataSource = bs;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ عند الاتصال: " + ex.Message);
            }
        }
        public Subscribers()
        {
            InitializeComponent();
        }

        private void Subscribers_Load(object sender, EventArgs e)
        {
            ClearFields();
            LoadData();
        }
        
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBlocks(Convert.ToInt32(cmbRegion.SelectedValue));
        }
    }
}
