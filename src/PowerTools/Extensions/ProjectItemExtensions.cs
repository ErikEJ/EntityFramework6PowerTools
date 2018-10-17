// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.DbContextPackage.Extensions
{
    internal static class ProjectItemExtensions
    {
        public static string GetDefaultNamespace(this ProjectItem projectItem)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var project = projectItem.ContainingProject;
            var namespaceParts = new Stack<string>();

            var parent = projectItem.Collection.Parent;
            while (parent != project)
            {
                var parentProjectItem = (ProjectItem) parent;

                namespaceParts.Push(parentProjectItem.Name);

                parent = parentProjectItem.Collection.Parent;
            }

            namespaceParts.Push(project.GetRootNamespace());

            return string.Join(".", namespaceParts);
        }
    }
}