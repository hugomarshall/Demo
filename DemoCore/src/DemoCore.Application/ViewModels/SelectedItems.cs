namespace DemoCore.Application.ViewModels
{
    public class SelectedItems
    {
        public int Id { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }
        public bool Assigned { get; set; }
        public string NameComponent { get; set; }
    }

    public class SelectedItemWithValue
    {
        public SelectedItemWithValue(string nameComponent)
        {
            NameComponent = nameComponent;
        }
        public int Id { get; set; }
        public string DescriptionEN { get; set; }
        public string DescriptionPT { get; set; }
        public string Value { get; set; }
        public string NameComponent { get; private set; }
    }
}
