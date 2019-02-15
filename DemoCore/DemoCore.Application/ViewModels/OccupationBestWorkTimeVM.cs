namespace DemoCore.Application.ViewModels
{
    public class OccupationBestWorkTimeVM
    {
        public int Id { get; private set; }
        public int BestWorkTimeId { get; set; }
        public BestWorkTimeVM BestWorkTime { get; set; }
        public int OccupationId { get; set; }
        public OccupationVM Occupation { get; set; }
    }
}
