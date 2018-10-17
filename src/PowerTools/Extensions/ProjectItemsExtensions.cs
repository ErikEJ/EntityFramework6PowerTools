// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;
using EnvDTE;
using Microsoft.DbContextPackage.Utilities;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.DbContextPackage.Extensions
{
    internal static class ProjectItemsExtensions
    {
        public static ProjectItem GetItem(this ProjectItems projectItems, string name)
        {
            DebugCheck.NotNull(projectItems);
            DebugCheck.NotEmpty(name);

            return projectItems
                .Cast<ProjectItem>()
                .FirstOrDefault(
                    pi =>
                    {
                        ThreadHelper.ThrowIfNotOnUIThread();
                        return string.Equals(pi.Name, name, StringComparison.OrdinalIgnoreCase);
                    });
        }
    }
}