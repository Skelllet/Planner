using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Storage
    {
        public int Id { get; private set; }
        public String Name { get; private set; }
        public Field Field { get; private set; }

        public Storage(int id, string name, Field field)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Field = field ?? throw new ArgumentNullException(nameof(field));
        }

        public override bool Equals(object obj)
        {
            return obj is Storage storage &&
                   Id == storage.Id &&
                   Name == storage.Name &&
                   EqualityComparer<Field>.Default.Equals(Field, storage.Field);
        }

        public override int GetHashCode()
        {
            var hashCode = 367685629;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Field>.Default.GetHashCode(Field);
            return hashCode;
        }
    }


}
