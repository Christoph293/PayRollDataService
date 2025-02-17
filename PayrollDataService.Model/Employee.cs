namespace PayrollDataService.Model
{
    public class Employee : AddressableDBEntity
    {
        public int ID { get; set; }

        public int BusinessAssociate { get; set; }

        public IList<int> Locations { get; set; }


    }
}
