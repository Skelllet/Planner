using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Scheduleofevents
    {

        public int Id { get; private set; }
        public String Name { get; private set; }
        public DateTime DateAndTime { get; private set; }
        public Field Field { get; private set; }
        public Job Job { get; private set; }

        public Scheduleofevents(int id, string name, DateTime dateAndTime, Field field, Job job)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DateAndTime = dateAndTime;
            Field = field ?? throw new ArgumentNullException(nameof(field));
            Job = job ?? throw new ArgumentNullException(nameof(job));
        }

        public override bool Equals(object obj)
        {
            var scheduleofevents = obj as Scheduleofevents;
            return scheduleofevents != null &&
                   Id == scheduleofevents.Id &&
                   Name == scheduleofevents.Name &&
                   DateAndTime == scheduleofevents.DateAndTime &&
                   EqualityComparer<Field>.Default.Equals(Field, scheduleofevents.Field) &&
                   EqualityComparer<Job>.Default.Equals(Job, scheduleofevents.Job);
        }

        public override int GetHashCode()
        {
            var hashCode = 259302788;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + DateAndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Field>.Default.GetHashCode(Field);
            hashCode = hashCode * -1521134295 + EqualityComparer<Job>.Default.GetHashCode(Job);
            return hashCode;
        }
    }
}
