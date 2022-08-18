using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Model
{
    public class Field
    {

        public int Id { get; private set; }
        public String Name { get; private set; }
        public DateTime WorkingHoursTimeStart { get; private set; }
        public DateTime WorkingHoursTimeFinish { get; private set; }
        public String StadiumAdress { get; private set; }
        public Admin Admin { get; private set; }


        public Field(int id, string name, DateTime workingHoursTimeStart, DateTime workingHoursTimeFinish, string stadiumAdress, Admin admin)
        {
            Id = id;
            Name = name;
            WorkingHoursTimeStart = workingHoursTimeStart;
            WorkingHoursTimeFinish = workingHoursTimeFinish;
            StadiumAdress = stadiumAdress;
            Admin = admin;
        }

        public override bool Equals(object obj)
        {
            return obj is Field field &&
                   Id == field.Id &&
                   Name == field.Name &&
                   WorkingHoursTimeStart == field.WorkingHoursTimeStart &&
                   WorkingHoursTimeFinish == field.WorkingHoursTimeFinish &&
                   StadiumAdress == field.StadiumAdress &&
                   EqualityComparer<Admin>.Default.Equals(Admin, field.Admin);
        }

        public override int GetHashCode()
        {
            var hashCode = -1981348433;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + WorkingHoursTimeStart.GetHashCode();
            hashCode = hashCode * -1521134295 + WorkingHoursTimeFinish.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StadiumAdress);
            hashCode = hashCode * -1521134295 + EqualityComparer<Admin>.Default.GetHashCode(Admin);
            return hashCode;
        }
    }
}
