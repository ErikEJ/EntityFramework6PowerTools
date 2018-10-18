// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using JetBrains.Annotations;
using System.Diagnostics;

namespace Microsoft.DbContextPackage.Utilities
{
    internal static class DebugCheck
    {
        [Conditional("DEBUG")]
        [ContractAnnotation("halt <= value : null")]
        [AssertionMethod]
        public static void NotNull<T>([NotNull, NoEnumeration]T value) where T : class
        {
            Debug.Assert(value != null);
        }

        [Conditional("DEBUG")]
        public static void NotEmpty(string value)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(value));
        }
    }
}