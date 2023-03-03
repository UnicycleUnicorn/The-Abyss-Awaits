using Microsoft.Xna.Framework;

namespace The_Abyss_Awaits.potion;

public class Potion {
    private readonly string _closest;
    private readonly Color _color;
    private readonly double _similarity;

    public Potion(string closest, double similarity, Color color) {
        _closest = closest;
        _similarity = similarity;
        _color = color;
    }

    public override string ToString() {
        return $"{_similarity} {_closest} - {_color}";
    }

    public override bool Equals(object? obj) {
        if (obj == null || obj.GetType() != typeof(Potion)) return false;
        var pot = (Potion)obj;
        return Math.Abs(_similarity - pot._similarity) < 0.001 && _closest == pot._closest;
    }

    public override int GetHashCode() {
        return _closest.GetHashCode() + _similarity.GetHashCode();
    }
}