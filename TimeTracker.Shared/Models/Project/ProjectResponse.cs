using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Shared.Entities;

namespace TimeTracker.Shared.Models.Project
{
    public record struct ProjectResponse(string Id, string Name);
}
