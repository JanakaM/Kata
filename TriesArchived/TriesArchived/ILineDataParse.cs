namespace TriesArchived
{
    public interface ILineDataParse
    {
        string GetName(string lineData);
        int GetKills(string lineData);
        int GetArchived(string lineData);
    }
}