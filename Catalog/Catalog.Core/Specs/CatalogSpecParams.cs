namespace Catalog.Core.Specs;

public class CatalogSpecParams
{
   private const int MaxPage = 70;
   public int Index { get; set; } = 1;
   private int _size = 10;
   public int Size { get=>_size; set=>_size=(value>MaxPage)?MaxPage:value; }
   public string? BrandId { get; set; }
   public string? TypeId { get; set; }
   public string? Sort { get; set; }
   public string? Search { get; set; }
}