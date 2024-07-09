namespace AsparagusApp.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int asparaguscount { get; set; }
        public DateTime lastasparagusdate { get; set; }
    }
}
