
namespace ASP_NET_DEMO_EXPERIMENT.Models
{
    public class VocabViewModel
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Definition { get; set; }

        public VocabViewModel()
        {
            Id = -1;
            Word = "";
            Definition = "";
        }

        public VocabViewModel(int id, string word, string def)
        {
            Id = id;
            Word = word;
            Definition = def;
        }
        

    }
}