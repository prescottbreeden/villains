namespace LoginRegistration.Models
{
  public class VillainEvilGroup: DataModel
  {
    public int VillainEvilGroupId { get; set; }
    public int VillainId { get; set; }
    public int EvilGroupId { get; set; }

    // Navigation properties
    public EvilGroup EvilGroup { get; set; }
    public Villain Villain { get; set; }
  }
}