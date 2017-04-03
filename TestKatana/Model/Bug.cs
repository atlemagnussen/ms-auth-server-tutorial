namespace TestKatana.Model
{
    public class Bug
    {
        public Bug(int id, string state)
        {
            Id = id;
            State = state;
        }
        public int Id { get; set; }
        public string State { get; set; }
    }
}