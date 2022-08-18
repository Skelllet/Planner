using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Fertilizers
    {
        public int Id { get; private set; }
        public String Name { get; private set; }
        public int Count { get; private set; }
        public Storage Storage { get; private set; }

        public Fertilizers(int id, string name, int count, Storage storage)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Count = count;
            Storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public override bool Equals(object obj)
        {
            return obj is Fertilizers fertilizers &&
                   Id == fertilizers.Id &&
                   Name == fertilizers.Name &&
                   Count == fertilizers.Count &&
                   EqualityComparer<Storage>.Default.Equals(Storage, fertilizers.Storage);
        }

        public override int GetHashCode()
        {
            var hashCode = 588999200;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Storage>.Default.GetHashCode(Storage);
            return hashCode;
        }
    }
}
