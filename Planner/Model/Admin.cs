using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Admin
    {
        public int Id { get; private set; }
        public String LastName { get; private set; }
        public String FirstName { get; private set; }
        public String MiddleName { get; private set; }
        public String PhoneNumber { get; private set; }
        public String Login { get; private set; }
        public String Password { get; private set; }

        public Admin(int id, string lastName, string firstName, string middleName, string phoneNumber, string login, string password)
        {
            Id = id;
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public override bool Equals(object obj)
        {
            var admin = obj as Admin;
            return admin != null &&
                   Id == admin.Id &&
                   LastName == admin.LastName &&
                   FirstName == admin.FirstName &&
                   MiddleName == admin.MiddleName &&
                   PhoneNumber == admin.PhoneNumber &&
                   Login == admin.Login &&
                   Password == admin.Password;
        }

        public override int GetHashCode()
        {
            var hashCode = 1948500423;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiddleName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Login);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
