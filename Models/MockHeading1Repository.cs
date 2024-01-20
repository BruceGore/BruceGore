using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



/*
namespace mvccore.Models
{
    public class MockHeading1Repository : IHeading1Repository
    {

        private List<Heading1> _heading1List;

        public MockHeading1Repository()
        {
            _heading1List = new List<Heading1>()
            {
                new Heading1() { FieldCode = 10, Heading = "Wisdom", OldNew = "O"},
                new Heading1() { FieldCode = 20, Heading = "Bible", OldNew = "N"},
                new Heading1() { FieldCode = 30, Heading = "History", OldNew = "O"}
            };
        }
        public Heading1 GetHeading(int FieldCode)
        {
            return _heading1List.FirstOrDefault(e => e.FieldCode == FieldCode);
        }
    }

    public class MockCommandmentsRepository : ICommandmentsRepository
    {
        private List<Commandments> _commandmentsList;

        public MockCommandmentsRepository()
        {
            _commandmentsList = new List<Commandments>()
           {

                new Commandments() {ID = 1, Number = 1, Text = "First Commandment"},
                new Commandments() {ID = 2, Number = 2, Text = "Second Commandment"},
                new Commandments() {ID = 3, Number = 3, Text = "Third Commandment"}
            };
        }
        public Commandments GetCommandments(int ID)
        {
            return _commandmentsList.FirstOrDefault(e => e.ID == ID);
        }

        public IEnumerable<Commandments> GetAllCommandments()
        {
            return _commandmentsList;
        }

        public Commandments Add(Commandments command)
        {
            command.ID = _commandmentsList.Max(e => e.ID) + 1;
            _commandmentsList.Add(command);
            return command;
        }




    }
}

*/