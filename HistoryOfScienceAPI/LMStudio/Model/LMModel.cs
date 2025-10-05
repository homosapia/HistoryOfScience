namespace HistoryOfScienceAPI.LMStudio.Model
{
    public class LMModelList
    {
        public List<LMModel> data { get; set; }
    }

    public class LMModel
    {
        public string id { get; set; }
        public string owned_by { get; set; }
    }
}
