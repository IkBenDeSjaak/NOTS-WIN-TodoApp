namespace TodoClient.Models
{
    public class TodoItem
    {
        private int _id;
        private string _title;
        private string _description;
        private bool _isComplete;

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public bool IsComplete { get => _isComplete; set => _isComplete = value; }
    }
}
