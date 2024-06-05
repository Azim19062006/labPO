namespace LABPO
{
    public interface Interface
    {
        int Size { get; }
        double[] Coefficients { get; }
        Complex[] FindSqrt();
    }
}