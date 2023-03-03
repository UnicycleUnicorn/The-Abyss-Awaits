namespace The_Abyss_Awaits.util;

public class IntRange {
    public int Max;
    public int Min;

    public IntRange(int min, int max) {
        Max = max;
        Min = min;
    }

    public IntRange(int num) {
        Max = num;
        Min = num;
    }

    public int GenerateRandom(Random random) {
        return random.Next(Min, Max);
    }
}