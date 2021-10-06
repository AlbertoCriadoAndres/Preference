using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Preference.Data;
using System;
using System.Linq;

namespace Preference.Models
{
    /// <summary>
    /// The SeedData class.
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// Method to initialize data.
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new PreferenceContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PreferenceContext>>());

            //Check existing data
            if (!context.Status.Any() && !context.Severity.Any() && !context.Issue.Any())
            {

                //Add Statuses
                context.Status.AddRange(
                    new Status
                    {
                        Description = "TODO",
                    },
                    new Status
                    {
                        Description = "DOING",
                    },
                    new Status
                    {
                        Description = "DONE",
                    }
                );

                //Add Severities
                context.Severity.AddRange(
                    new Severity
                    {
                        Description = "Low",
                    },
                    new Severity
                    {
                        Description = "Medium",
                    },
                    new Severity
                    {
                        Description = "High",
                    }
                );

                //Add Issues
                context.Issue.AddRange(
                    new Issue
                    {
                        Title = "Issue 1",
                        Severity = context.Severity.Local.Single(s => s.Description == "Low"),
                        Status = context.Status.Local.Single(s => s.Description == "TODO"),
                        Asignee = 1,

                    },
                    new Issue
                    {
                        Title = "Issue 2",
                        Severity = context.Severity.Local.Single(s => s.Description == "Medium"),
                        Status = context.Status.Local.Single(s => s.Description == "DOING"),
                        Asignee = 1,

                    },
                    new Issue
                    {
                        Title = "Issue 3",
                        Severity = context.Severity.Local.Single(s => s.Description == "Medium"),
                        Status = context.Status.Local.Single(s => s.Description == "DOING"),
                        Asignee = 2,

                    },
                    new Issue
                    {
                        Title = "Issue 4",
                        Severity = context.Severity.Local.Single(s => s.Description == "High"),
                        Status = context.Status.Local.Single(s => s.Description == "DONE"),
                        Asignee = 3,

                    }
                );

                //Save data
                context.SaveChanges();
            }
        }
    }
}
