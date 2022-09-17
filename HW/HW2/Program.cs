// <copyright file="Program.cs" company="Aidan Griffin">
// Copyright (c) Washington State University. All rights reserved.
// </copyright>

namespace HW2NS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new DistinctIntForm());
        }
    }
}