using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Preference.Models;

namespace Preference.Hubs
{
    /// <summary>
    /// The IssueHub class.
    /// </summary>
    public class IssueHub : Hub
    {
        /// <summary>
        /// Method to propagate the data change (WebSocket).
        /// </summary>
        /// <param name="issue"><c>issue</c> are the new issue's data.</param>
        public async Task SendIssue(Issue issue)
        {
            await Clients.Others.SendAsync("ReceiveIssue", issue);
        }
    }
}