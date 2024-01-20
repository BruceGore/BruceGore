using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace mvccore.Models
{
        public class SQLCommandmentsRepository : ICommandmentsRepository
    {
 
        private readonly AppDbContext context;

        //private List<Commandments> _commandmentsList;

        public SQLCommandmentsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Commandments GetCommandments(int ID)
        {
            return context.Commandments.Find(ID);
        }


        public IEnumerable<Commandments> GetAllCommandments()
        {
            return context.Commandments;
        }


        public Commandments Add(Commandments command)
        {

            //_commandmentsList = new List<Commandments>();
            //command.ID = _commandmentsList.Max(e => e.ID) + 1;

            command.ID = 11;
            context.Commandments.Add(command);
            context.SaveChanges();
            return command;
        }

    }

}

