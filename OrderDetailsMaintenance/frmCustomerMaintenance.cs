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
        //Navya Gupta
        private void btnFind_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text.Trim();
            Customer customer = _context.Customers.Find(id);
            // When the find button is clicked, if the customer exists the text fields will be populated with the customer's details

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
        //Navya Gupta
        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text.Trim();

            var customer = _context.Customers.Find(id);
            // if there is a customer with that ID, the values are assigned to the properties, updates the customers list, and saves the changes
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
        //Navya Gupta
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}