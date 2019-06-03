namespace ScheduleManager.Data.Entities
{
    public partial class Schedule : Event
    {
        public int ScheduleId { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}