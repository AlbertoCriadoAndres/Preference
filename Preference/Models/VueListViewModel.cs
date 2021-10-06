using System.Collections.Generic;

namespace Preference.Models
{

    /// <summary>
    /// The VueListViewModel class (ViewModel).
    /// </summary>
    public class VueListViewModel
    {

        /// <summary>
        /// Property <c>Issues</c> represents a issues's list.
        /// </summary>
        public List<Issue> Issues;

        /// <summary>
        /// Property <c>Severities</c> represents a severities's list.
        /// </summary>
        public List<Severity> Severities;

        /// <summary>
        /// Property <c>Statuses</c> represents a statuses's list.
        /// </summary>
        public List<Status> Statuses;

    }
}
