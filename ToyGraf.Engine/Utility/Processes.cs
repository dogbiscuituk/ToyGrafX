// <copyright file="Processes.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Engine.Utility
{
    using System;
    using System.Diagnostics;

    public static class Processes
    {
        public static void Launch(this string url) => Process.Start(url);
        public static void Spit(this string s) => Debug.WriteLine($"* {DateTime.Now:yyyy-MM-dd hh:mm:ss.fff} * {s}");
    }
}
