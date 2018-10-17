// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.DbContextPackage.Utilities;
using Microsoft.VisualStudio.ComponentModelHost;

namespace Microsoft.DbContextPackage.Extensions
{
    // ReSharper disable once InconsistentNaming
    internal static class IComponentModelExtensions
    {
        public static object GetService(this IComponentModel componentModel, Type serviceType)
        {
            DebugCheck.NotNull(componentModel);
            DebugCheck.NotNull(serviceType);

            return typeof(IComponentModel).GetMethod("GetService")
                ?.MakeGenericMethod(serviceType)
                .Invoke(componentModel, null);
        }
    }
}