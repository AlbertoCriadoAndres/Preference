
namespace Preference.Models
{

    /// <summary>
    /// The Issue class (Model).
    /// </summary>
    public class Issue
    {

        /// <summary>
        /// Property <c>Id</c> represents the issues's Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property <c>Title</c> represents the issues's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Property <c>SeverityId</c> represents the issues's severity Id.
        /// </summary>
        public int SeverityId { get; set; }

        /// <summary>
        /// Property <c>Severity</c> represents the severity (model) related to the issue.
        /// </summary>
        public Severity Severity { get; set; }

        /// <summary>
        /// Property <c>StatusId</c> represents the issues's status Id.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Property <c>Status</c> represents the status (model) related to the issue.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Property <c>Asignee</c> represents the issue's user asigned.
        /// </summary>
        public int Asignee { get; set; }

    }
}
