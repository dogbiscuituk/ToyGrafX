// <copyright file="GPUStatus.cs" company="John M Kerr">
// Copyright (c) John M Kerr. All rights reserved.
// </copyright>

namespace ToyGraf.Engine.Types
{
    using System;

    [Flags]
    public enum GPUStatus
    {
        OK = 0,
        Error = 1,
        Warning = 2
    }
}
