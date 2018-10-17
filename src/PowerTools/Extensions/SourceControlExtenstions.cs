// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using EnvDTE;
using Microsoft.DbContextPackage.Utilities;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.DbContextPackage.Extensions
{
    internal static class SourceControlExtensions
    {
        public static bool CheckOutItemIfNeeded(this SourceControl sourceControl, string itemName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            DebugCheck.NotNull(sourceControl);
            DebugCheck.NotEmpty(itemName);

            if (sourceControl.IsItemUnderSCC(itemName) && !sourceControl.IsItemCheckedOut(itemName))
                return sourceControl.CheckOutItem(itemName);

            return false;
        }
    }
}