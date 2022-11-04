using Models.Model;

namespace UI.Models
{
    public class CustomerInformationViewModel
    {
        private IFormFile? _img;
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public Customer ChosenCustomer { get; set; } = new Customer();
        public List<Country> Countries { get; set; } = new List<Country>();

        public IFormFile? Img
        {
            get { return _img; }
            set 
            {
                if (value != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        value.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        ChosenCustomer.CustomerPhoto = fileBytes;
                        //string s = Convert.ToBase64String(fileBytes);
                    }
                }
                _img = value; 
            }
        }
        /// <summary>
        /// Indicate the state of the page
        /// 0 = Adding new Customer
        /// 1 = Editting a customer
        /// 2 = viewing a customer
        /// </summary>
        public int State { get; set; } = 0;
    }
}
