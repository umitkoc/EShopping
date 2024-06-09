namespace Catalog.Core.Specs;

public class Pagination<T> where T:class
{
    public Pagination(int index, int size, long count, IReadOnlyList<T>? data)
    {
        Index = index;
        Size = size;
        Count = count;
        Data = data;
    }

    public int Index { get; set; }
    public int Size { get; set; }
    public long Count { get; set; }
    public IReadOnlyList<T>? Data { get; set; }

    public Pagination()
    {
        
    }
}