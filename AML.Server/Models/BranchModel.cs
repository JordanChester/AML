namespace AML.Server.Models
{
    public class BranchModel
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public BranchModel(int branchId, string name, string location)
        {
            BranchId = branchId;
            Name = name;
            Location = location;
        }
    }
}
