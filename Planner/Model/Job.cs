using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Job
    {

        public int Id { get; private set; }
        public String Name { get; private set; }
        public Boolean IsDone { get; private set; }
        public DateTime TimeIsDone { get; private set; }
        public DateTime TimeConstraints { get; private set; }
        public Stadiumworkers Stadiumworkers { get; private set; }

        public Job(int id, string name, bool isDone, DateTime timeIsDone, DateTime timeConstraints, Stadiumworkers stadiumworkers)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsDone = isDone;
            TimeIsDone = timeIsDone;
            TimeConstraints = timeConstraints;
            Stadiumworkers = stadiumworkers ?? throw new ArgumentNullException(nameof(stadiumworkers));
        }

        public override bool Equals(object obj)
        {
            var job = obj as Job;
            return job != null &&
                   Id == job.Id &&
                   Name == job.Name &&
                   IsDone == job.IsDone &&
                   TimeIsDone == job.TimeIsDone &&
                   TimeConstraints == job.TimeConstraints &&
                   EqualityComparer<Stadiumworkers>.Default.Equals(Stadiumworkers, job.Stadiumworkers);
        }

        public override int GetHashCode()
        {
            var hashCode = 1948491570;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + IsDone.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeIsDone.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeConstraints.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Stadiumworkers>.Default.GetHashCode(Stadiumworkers);
            return hashCode;
        }
    }
}
