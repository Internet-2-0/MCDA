namespace MCDA_APP.Model.Api.Reuse
{
    public class ResultObject
    {
        public List<object>? kinda_similar { get; set; }
        public List<object>? very_similar { get; set; }
        public List<object>? perfect_similarity { get; set; }
    }
}