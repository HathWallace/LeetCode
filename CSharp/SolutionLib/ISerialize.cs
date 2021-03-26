namespace SolutionLib
{
    public interface ISerialize<T>
    {
        string Serialize(T obj);

        T Deserialize(string data);

    }
}