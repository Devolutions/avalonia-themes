namespace SampleApp.Models;

public class DataGridItem
{
  public DataGridItem(string itemType, string commonName, string accountName, string lastModified)
  {
    this.ItemType = itemType;
    this.CommonName = commonName;
    this.AccountName = accountName;
    this.LastModified = lastModified;
  }

  public string ItemType { get; set; }
  public string CommonName { get; set; }
  public string AccountName { get; set; }
  public string LastModified { get; set; }
}