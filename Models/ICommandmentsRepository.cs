using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mvccore.Models
{
    public interface ICommandmentsRepository
    {
        Commandments GetCommandments(int ID);

        IEnumerable<Commandments> GetAllCommandments();

        Commandments Add(Commandments command);

    }
}