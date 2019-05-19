using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleManager.Models
{
    // See: https://fullcalendar.io/docs/event-object
    public class FullCalendarEvent
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "groupId")]
        public string GroupId { get; set; }

        [JsonProperty(PropertyName = "allDay")]
        public bool AllDay { get; set; }

        [JsonProperty(PropertyName = "start")]
        public DateTime Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public DateTime End { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = "Untitled Event";

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "classNames")]
        public List<string> ClassNames { get; set; }

        [JsonProperty(PropertyName = "editable")]
        public bool Editable { get; set; }

    }
}
