﻿namespace CleanBinCommands
{
    using System;

    /// <summary>
    /// Helper class that exposes all GUIDs used across VS Package.
    /// </summary>
    internal sealed partial class PackageGuids
    {
        public const string guidCleanCommandsPackageString = "f1dcc2f3-4efd-4579-9566-b29ef5f54d2a";
        public static Guid guidCleanCommandsPackage = new Guid(guidCleanCommandsPackageString);

        public const string guidCleanProjectCommandPackageCmdSetString = "a16645a7-f9c7-48c0-9dab-92afd47265c4";
        public static Guid guidCleanProjectCommandPackageCmdSet = new Guid(guidCleanProjectCommandPackageCmdSetString);

        public const string guidCleanSolutionCommandPackageCmdSetString = "a16645a7-f9c7-48c0-9dab-92afd47265c5";
        public static Guid guidCleanSolutionCommandPackageCmdSet = new Guid(guidCleanSolutionCommandPackageCmdSetString);

        public const string guidCleanSolutionWithoutPackagesCommandPackageCmdSetString = "a16645a7-f9c7-48c0-9dab-92afd47265c6";
        public static Guid guidCleanSolutionWithoutPackagesCommandPackageCmdSet = new Guid(guidCleanSolutionWithoutPackagesCommandPackageCmdSetString);

        public const string guidCleanSolutionFolderCommandPackageCmdSetString = "a16645a7-f9c7-48c0-9dab-92afd47265c7";
        public static Guid guidCleanSolutionFolderCommandPackageCmdSet = new Guid(guidCleanSolutionFolderCommandPackageCmdSetString);
    }
    /// <summary>
    /// Helper class that encapsulates all CommandIDs uses across VS Package.
    /// </summary>
    internal sealed partial class PackageIds
    {
        public const int CleanProjectCommandMenuGroup = 0x1020;
        public const int CleanProjectCommandId = 0x0100;
        public const int CleanSolutionCommandMenuGroup = 0x1021;
        public const int CleanSolutionCommandId = 0x0101;
        public const int CleanSolutionWithoutPackagesCommandMenuGroup = 0x1022;
        public const int CleanSolutionWithoutPackagesCommandId = 0x0102;

        public const int CleanSolutionFolderCommandMenuGroup = 0x1023;
        public const int CleanSolutionFolderCommandId = 0x0103;
    }
}