namespace ScheduleManager.Data.Entities
{
    public class Exception : Event
    {
        public int ExceptionId { get; set; }

        public int ScheduleId { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
