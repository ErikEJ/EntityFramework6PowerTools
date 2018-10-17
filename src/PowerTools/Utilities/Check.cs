// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using JetBrains.Annotations;
using System;

namespace Microsoft.DbContextPackage.Utilities
{
    internal static class Check
    {
        [ContractAnnotation("halt <= value : null")]
        [AssertionMethod]
        public static T NotNull<T>([NotNull, NoEnumeration]T value, [InvokerParameterName]string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
    }
}