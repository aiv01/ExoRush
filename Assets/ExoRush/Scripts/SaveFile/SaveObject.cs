[System.Serializable]
public class SaveObject
{
    public SaveObject()
    {
        currency = 0;
        powerUpIndexes = new int[6];
        leaderboard = new int[10];
    }

    public SaveObject(int _currency, int[] _powerUpIndexes, int[] _leaderboard)
    {
        currency = _currency;
        powerUpIndexes = _powerUpIndexes;
        leaderboard = _leaderboard;
    }

    public int currency;
    public int[] powerUpIndexes;
    public int[] leaderboard;
    public string[] lbNames;
    public int score;

    public SaveObject()
    {
        currency = 0;
        powerUpIndexes = new int[6];
        leaderboard = new int[10];
        lbNames = new string[10];
        score = 0;
        for(int i = 0; i < leaderboard.Length; i++)
        {
            leaderboard[i] = 0;
            lbNames[i] = "John Doe";
        }
    }
}
