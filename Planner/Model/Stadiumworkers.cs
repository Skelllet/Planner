using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Stadiumworkers
    {

        public int Id { get; private set; }
        public String LastName { get; private set; }
        public String FirstName { get; private set; }
        public String MiddleName { get; private set; }
        public String PhoneNumber { get; private set; }
        public String Login { get; private set; }
        public String Password { get; private set; }
        public Post Post { get; private set; }
        public Field Field { get; private set; }

        public Stadiumworkers(int id, string lastName, string firstName, string middleName, string phoneNumber, string login, string password, Post post, Field field)
        {
            Id = id;
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Post = post ?? throw new ArgumentNullException(nameof(post));
            Field = field ?? throw new ArgumentNullException(nameof(field));
        }

        public override bool Equals(object obj)
        {
            var stadiumworkers = obj as Stadiumworkers;
            return stadiumworkers != null &&
                   Id == stadiumworkers.Id &&
                   LastName == stadiumworkers.LastName &&
                   FirstName == stadiumworkers.FirstName &&
                   MiddleName == stadiumworkers.MiddleName &&
                   PhoneNumber == stadiumworkers.PhoneNumber &&
                   Login == stadiumworkers.Login &&
                   Password == stadiumworkers.Password &&
                   EqualityComparer<Post>.Default.Equals(Post, stadiumworkers.Post) &&
                   EqualityComparer<Field>.Default.Equals(Field, stadiumworkers.Field);
        }

        public override int GetHashCode()
        {
            var hashCode = -1757594819;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiddleName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Login);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<Post>.Default.GetHashCode(Post);
            hashCode = hashCode * -1521134295 + EqualityComparer<Field>.Default.GetHashCode(Field);
            return hashCode;
        }
    }
}
