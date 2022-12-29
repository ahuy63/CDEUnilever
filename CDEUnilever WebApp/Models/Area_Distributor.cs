namespace CDEUnilever_WebApp.Models
{
    public class Area_Distributor
    {
        public int ID { get; set; }
        public int Id_Area { get; set; }
        public Area? Area { get; set; }
        public int Id_Distributor { get; set; }
        public Distributor? Distributor { get; set; }
    }
}
