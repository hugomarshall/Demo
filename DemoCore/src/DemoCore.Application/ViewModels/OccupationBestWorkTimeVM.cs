namespace DemoCore.Application.ViewModels
{
    public class OccupationBestWorkTimeVM
    {
        public OccupationBestWorkTimeVM()
        {
            //BestWorkTime = new BestWorkTimeVM();
            //Occupation = new OccupationVM();
        }
        public int BestWorkTimeId { get; set; }
        public virtual BestWorkTimeVM BestWorkTime { get; set; }
        public int OccupationId { get; set; }
        public virtual OccupationVM Occupation { get; set; }
    }
}
