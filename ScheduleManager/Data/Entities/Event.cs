using EWSoftware.PDI;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleManager.Data.Entities
{
    public class Event
    {
        public Event()
        {
            Frequency = RecurFrequency.Weekly;
            Interval = 1;
            RepeatsIndefinitely = true;
        }

        [Required]
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsAllDay { get; set; }

        public bool IsDeleted { get; set; }

        // Recurrence properties

        public RecurFrequency Frequency { get; set; }

        public int Interval { get; set; }

        public bool IsOnWeekdays { get; set; }

        public DateTime? RecurUntil { get; set; }

        public bool RepeatsIndefinitely { get; set; }

        public bool CanOccurOnHolidays { get; set; }

        public virtual DateTimeCollection GetInstancesBetween(DateTime startDate, DateTime endDate)
        {
            var r = new Recurrence
            {
                StartDateTime = StartDate,
                Frequency = Frequency,
                CanOccurOnHoliday = CanOccurOnHolidays
            };

            if (!RepeatsIndefinitely)
            {
                if (RecurUntil == null)
                {
                    throw new ArgumentNullException();
                }

                r.RecurUntil = (DateTime)RecurUntil;
            }

            if (IsOnWeekdays)
            {
                r.RecurEveryWeekday();
            }
            else
            {
                r.Interval = Interval;
            }

            return r.InstancesBetween(startDate, endDate);
        }
    }
}