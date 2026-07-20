using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace RibbonGetStarted.Data {

    public class Customer(int id, string? firstName, string? lastName, string? country, string? city, string? address, string? phone, string? postalCode)
    {
        public Customer() : this(-1, null, null, null, null, null, null, null)
        {
        }
        public int Id { get; set; } = id;
        public string? FirstName { get; set; } = firstName;
        public string? LastName { get; set; } = lastName;
        public string? Country { get; set; } = country;
        public string? City { get; set; } = city;
        public string? Address { get; set; } = address;
        public string? Phone { get; set; } = phone;
        public string? PostalCode { get; set; } = postalCode;
        public virtual ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
        public override string ToString() => FullName;
    }
}
