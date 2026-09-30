using OrderDetailsMaintenance.Models.DataLayer;

namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        private NorthwindContext _context = new NorthwindContext();
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text.Trim();
            Customer customer = _context.Customers.Find(id);

            if (customer != null)
            {
                txtCustomerId.Text = customer.CustomerId;
                txtAddress.Text = customer.Address;
                txtCity.Text = customer.City;
                txtCountry.Text = customer.Country;
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text.Trim();

            var customer = _context.Customers.Find(id);

            if (customer != null)
            {
                customer.ContactName = txtContact.Text;
                customer.Address = txtAddress.Text;
                customer.City = txtCity.Text;
                customer.Country = txtCountry.Text;

                _context.Customers.Update(customer);
                _context.SaveChanges();

                MessageBox.Show("Customer updated successfully.");
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}