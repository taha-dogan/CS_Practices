using AppointmentMaker.Models;
using AppointmentMaker.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentMaker.Controllers
{
    public class AppointmentController : Controller
    {
        static List<CustomerAppointmentViewModel> customerAppointment = new List<CustomerAppointmentViewModel>();
        
        public IActionResult Index()
        {
            return View(customerAppointment);
        }

        public IActionResult Create()
        {
            return View();
        
        }

        public IActionResult Details(CustomerAppointmentViewModel model)
        {
            customerAppointment.Add(model);
            return View("Details", model);
        }

        public IActionResult SeeAppointmentDetails(string nameOfAppointment)
        {
            var actualAppointment = customerAppointment.FirstOrDefault(a => a.appointment.PatientName == nameOfAppointment);
            if(actualAppointment != null)
            {
                return View(actualAppointment);
            }
            return View("Index");
        }
    }
}
