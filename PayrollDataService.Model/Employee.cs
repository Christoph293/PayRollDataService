namespace PayrollDataService.Model
{
    public class Employee : AddressableDBEntity
    {

        public int BusinessAssociate { get; set; }

        public IList<int> Locations { get; set; }


    }
}
