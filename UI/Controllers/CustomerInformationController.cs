using Microsoft.AspNetCore.Mvc;
using Models.Model;
using System.Diagnostics;
using UI.Models;
using UI.Services;

namespace UI.Controllers
{
    public class CustomerInformationController : Controller
    {
        private readonly CustomerDataService _dataService;
        private static List<Country> _countries = new List<Country>();
        public CustomerInformationController(CustomerDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<IActionResult> Index(CustomerInformationViewModel civm,
            bool customerCreated = false, bool customerUpdated = false, bool customerDeleted = false,
            bool goTo = false, int goToId = 0,
            bool edit = false, int editId = 0)
        {
            if (_countries.Count() == 0) _countries = await _dataService.GetAllCountriesAsync();
            var vm = new CustomerInformationViewModel();

            if (customerCreated || customerUpdated || customerDeleted)
            {
                List<Customer> customers = await _dataService.GetAllCustomersAsync();
                //_countries = await _dataService.GetAllCountriesAsync();
                vm.Customers = customers;
                vm.Countries = _countries;

                if(customerCreated)ViewBag.Message = "Customer Created Successfully";
                else if(customerUpdated) ViewBag.Message = "Customer Updated Successfully";
                else ViewBag.Message = "Customer Deleted Successfully";
            }
            else if(goTo)
            {
                List<Customer> customers = await _dataService.GetAllCustomersAsync();
                //_countries = await _dataService.GetAllCountriesAsync();
                vm.Customers = customers;
                vm.Countries = _countries;

                vm.State = 2;
                vm.ChosenCustomer = await _dataService.GetCustomerByIdAsync(goToId);

                var stream = new MemoryStream(vm.ChosenCustomer.CustomerPhoto);
                vm.Img = new FormFile(stream, 0, vm.ChosenCustomer.CustomerPhoto.Length, $"{vm.ChosenCustomer.CustomerName}", $"{vm.ChosenCustomer.CustomerName}");
            }
            else if (edit)
            {
                List<Customer> customers = await _dataService.GetAllCustomersAsync();
                //_countries = await _dataService.GetAllCountriesAsync();
                vm.Customers = customers;
                vm.Countries = _countries;

                vm.State = 1;
                vm.ChosenCustomer = await _dataService.GetCustomerByIdAsync(editId);

                var stream = new MemoryStream(vm.ChosenCustomer.CustomerPhoto);
                vm.Img = new FormFile(stream, 0, vm.ChosenCustomer.CustomerPhoto.Length, $"{vm.ChosenCustomer.CustomerName}", $"{vm.ChosenCustomer.CustomerName}");
            }
            else
            {
                List<Customer> customers = await _dataService.GetAllCustomersAsync();
                //_countries = await _dataService.GetAllCountriesAsync();
                vm.Customers = customers;
                vm.Countries = _countries;
            }         
            return View("Index", vm);
        }
        public IActionResult GoToCustomer(int id) => RedirectToAction("Index",new { goTo = true, goToId = id});

        [HttpPost]
        public async Task<IActionResult> SaveCustomer(CustomerInformationViewModel civm)
        {
            if(civm.State == 1)
            {
                if(civm.ChosenCustomer.CustomerPhoto == null)
                {
                    Customer temp = await _dataService.GetCustomerByIdAsync(civm.ChosenCustomer.Id);
                    civm.ChosenCustomer.CustomerPhoto = temp.CustomerPhoto;
                    var stream = new MemoryStream(civm.ChosenCustomer.CustomerPhoto);
                    civm.Img = new FormFile(stream, 0, civm.ChosenCustomer.CustomerPhoto.Length, $"{civm.ChosenCustomer.CustomerName}", $"{civm.ChosenCustomer.CustomerName}");
                }
            }
            for(int i =0;i<civm.ChosenCustomer.CustomerAddresses.Count();i++)
            {
                if (string.IsNullOrEmpty(civm.ChosenCustomer.CustomerAddresses[i].CustomerAddress1))
                {
                    var customerAddress = civm.ChosenCustomer.CustomerAddresses[i];
                    civm.ChosenCustomer.CustomerAddresses.Remove(customerAddress);
                    i--;
                }
            }
            civm.ChosenCustomer.Country = _countries.Where(x => x.CountryName == civm.ChosenCustomer.Country.CountryName).FirstOrDefault();

            if (civm.State == 0)
            {
                await _dataService.CreateCustomerAsync(civm.ChosenCustomer);
                return RedirectToAction("Index", new { customerCreated = true });
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    civm.Img.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    civm.ChosenCustomer.CustomerPhoto = fileBytes;
                    //string s = Convert.ToBase64String(fileBytes);
                }
                await _dataService.UpdateCustomerAsync(civm.ChosenCustomer);
                return RedirectToAction("Index", new { customerUpdated = true });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(int id)=> RedirectToAction("Index", new { edit = true, editId = id });
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _dataService.DeleteCustomerAsync(id);
            return RedirectToAction("Index", new { customerDeleted = true });
        }
    }
}