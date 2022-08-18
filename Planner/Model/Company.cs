using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Company
    {
        public int Id { get; private set; }
        public String Name { get; private set; }
        public String PhoneNumber { get; private set; }
        public String Adress { get; private set; }

        public Company(int id, string name, string phoneNumber, string adress)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Adress = adress ?? throw new ArgumentNullException(nameof(adress));
        }

        public override bool Equals(object obj)
        {
            var company = obj as Company;
            return company != null &&
                   Id == company.Id &&
                   Name == company.Name &&
                   PhoneNumber == company.PhoneNumber &&
                   Adress == company.Adress;
        }

        public override int GetHashCode()
        {
            var hashCode = -2108633181;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Adress);
            return hashCode;
        }
    }
}
