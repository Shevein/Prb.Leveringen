using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prb.Leveringen.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string supplier;
        string contractNumber;
        string descriptionMaterial;
        string quantity;
        int deliveries;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtSupplier.Focus();
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = false;
        }

        private void BtnDelivery_Click(object sender, RoutedEventArgs e)
        {
            DataFromInput();
        }

        private void DataFromInput()
        {
            supplier = txtSupplier.Text;
            contractNumber = txtContractNumber.Text;
            descriptionMaterial = txtDescription.Text;
            quantity = txtQuantity.Text;

            lblOverview.Content = ($"- Leverancier : {supplier}\n- ContractNummer : {contractNumber}\n- Beschrijving Materiaal : {descriptionMaterial}\n- Hoeveelheid : {quantity} ");

            btnSave.IsEnabled = true;
            btnDelete.IsEnabled = true;

            if (txtSupplier.Text == "" && txtDescription.Text == "" && txtContractNumber.Text == "")
            {
                MessageBox.Show($"Gelieve al de velden correct in te vullen!");
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            lstTotalDeliveries.Items.Add( $"-{contractNumber} - {supplier} - {descriptionMaterial} - {quantity}");
            CountDeliveries();
            ClearUserInput();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteAllActions();
        }

        private void BtnEndOfTheDay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ontvangen leveringen : {deliveries}");
        }

        private void btnDeleteCurrentAction_Click(object sender, RoutedEventArgs e)
        {
            DeleteCurrentAction();
        }

        private void DeleteCurrentAction()
        {
            txtContractNumber.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
            txtSupplier.Text = "";
            lblOverview.Content = "";
        }

        private void DeleteAllActions()
        {
            txtSupplier.Text = null;
            txtQuantity.Text = null;
            txtContractNumber.Text = null;
            txtDescription.Text = null;
            lblOverview.Content = null;
            tbkNumberOfDeliveries.Text = "0";
            lstTotalDeliveries.Items.Clear();
            txtSupplier.Focus();

        }

        private void CountDeliveries()
        {           
            deliveries = 0;

            foreach (var item in lstTotalDeliveries.Items)
            {
                
                deliveries ++;
            }

            tbkNumberOfDeliveries.Text = deliveries.ToString();
            
        }

        private void ClearUserInput()
        {
            txtSupplier.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
            txtContractNumber.Text = "";
            txtSupplier.Focus();
            lblOverview.Content = null;
        }

    }
}
