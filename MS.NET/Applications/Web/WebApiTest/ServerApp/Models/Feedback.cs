namespace ServerApp.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Feedback
    {
        [DataMember(Name = "from")]
        public string From { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; } 
    }
}