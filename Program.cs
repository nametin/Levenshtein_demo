List<string> words = new List<string> { "kitten", "sitting", "saturday", "sunday", "rosettacode", "raisethysword" };


int[,] distances = CalculateLevenshteinDistances(words);

for (int i = 0; i < words.Count; i++)
{
    for (int j = 0; j < words.Count; j++)
    {
        Console.Write(distances[i, j] + " ");
    }
    Console.WriteLine();
}


static int[,] CalculateLevenshteinDistances(List<string> words)
{
    int count = words.Count;
    int[,] distances = new int[count, count];

    int distance;
    for (int i = 0; i < count; i++)
    {
        for (int j = 0; j < count; j++)
        {
            if (i == j)
                distances[i, j] = 0;
             else if (j < i)
            {
            distances[i, j] = distances[j, i];
            }
            else{
                distance = LevenshteinDistance(words[i], words[j]);
                distances[i, j] = distance;
                distances[j, i] = distance;
            }
        }
    }

    return distances;
}

static int LevenshteinDistance(string s, string t)
{
    int n = s.Length;
    int m = t.Length;
    int[,] d = new int[n + 1, m + 1];

    if (n == 0)
        return m;
    if (m == 0)
        return n;

    for (int i = 0; i <= n; d[i, 0] = i++) { }
    for (int j = 0; j <= m; d[0, j] = j++) { }

    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= m; j++)
        {
            int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

            d[i, j] = Math.Min(
                Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                d[i - 1, j - 1] + cost);
        }
    }
    return d[n, m];
}
