using Sorschia.Processes;
using Sorschia.Teams.Data;

namespace Sorschia.Teams.Proccesses
{
    internal abstract class DbRequestBase : DbRequestBase<TeamsContext>
    {
        protected DbRequestBase(TeamsContext context) : base(context)
        {
        }
    }
}
