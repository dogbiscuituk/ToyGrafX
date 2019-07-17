namespace ToyGrafX.Expressions
{
    using System;

    public static class Functions
    {
#pragma warning disable IDE1006 // Naming Styles

        public static double abs(double x) => Math.Abs(x);

        public static float abs(float x) => Math.Abs(x);
        public static Vector3 abs(Vector3 x) => new Vector3();

        public static double acos(double x) => Math.Acos(x);
        public static double acosh(double x) => Math.Log(x + Math.Sqrt(x * x - 1));
        public static double asin(double x) => Math.Asin(x);
        public static double asinh(double x) => Math.Log(x + Math.Sqrt(x * x + 1));
        public static double atan(double x) => Math.Atan(x);
        public static double atan(double y, double x) => Math.Atan2(y, x);
        public static double atanh(double x) => Math.Log((1 + x) / (1 - x)) / 2;
        public static double ceil(double x) => Math.Ceiling(x);
        public static double clamp(double x, double y, double z) => Math.Min(Math.Max(x, y), z);
        public static double cos(double x) => Math.Cos(x);
        public static double cosh(double x) => Math.Cosh(x);
        public static double exp(double x) => Math.Exp(x);
        public static double exp2(double x) => Math.Exp(x * Math.Log(2));
        public static double floor(double x) => Math.Floor(x);
        public static double fract(double x) => x - Math.Floor(x);
        public static double inversesqrt(double x) => 1 / Math.Sqrt(x);
        public static double log(double x) => Math.Log(x);
        public static double log2(double x) => Math.Log(x) / Math.Log(2);
        public static double max(double x, double y) => Math.Max(x, y);
        public static double min(double x, double y) => Math.Min(x, y);
        public static double mix(double x, double y, double z) => x * (1 - z) + y * z;
        public static double mod(double x, double y) => x - y * Math.Floor(x / y);
        public static double pow(double x, double y) => Math.Pow(x, y);
        public static double round(double x) => Math.Round(x);
        //public static double roundEven(double x) => Math.RoundEven(x);
        public static double sign(double x) => Math.Sign(x);
        public static double sin(double x) => Math.Sin(x);
        public static double sinh(double x) => Math.Sinh(x);
        public static double sqrt(double x) => Math.Sqrt(x);
        public static double tan(double x) => Math.Tan(x);
        public static double tanh(double x) => Math.Tanh(x);
        //public static double trunc(double x) => Math.Trunc(x);

#pragma warning restore IDE1006 // Naming Styles
    }
}
