namespace CDEUnilever_WebApp.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DistributorQty { get; set; }

        public ICollection<User>? Users { get; set; }
        public ICollection<Distributor>? Distributors { get; set; }
    }
}
