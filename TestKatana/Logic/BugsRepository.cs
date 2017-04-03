using System.Collections.Generic;
using TestKatana.Model;

namespace TestKatana.Logic
{
    public interface IBugsRepository
    {
        List<Bug> GetBugs();
    }
    public class BugsRepository
    {
        private readonly IList<Bug> _list;
        public BugsRepository()
        {
            _list = new List<Bug> { new Bug(1, "lol"), new Bug(2, "nice") };
        }
        public IList<Bug> GetBugs()
        {
            return _list;
        }

        public Bug Get(int id)
        {
            if (id == 1)
                return _list[0];
            return _list[1];
        }
    }
}