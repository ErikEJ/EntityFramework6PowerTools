// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using Microsoft.DbContextPackage.Utilities;

namespace Microsoft.DbContextPackage.Extensions
{
    // ReSharper disable once InconsistentNaming
    internal static class IEnumerableOfEdmSchemaErrorExtensions
    {
        public static void HandleErrors(this IEnumerable<EdmSchemaError> errors, string message)
        {
            DebugCheck.NotNull(errors);

            // ReSharper disable PossibleMultipleEnumeration
            if (errors.HasErrors()) throw new EdmSchemaErrorException(message, errors);
            // ReSharper restore PossibleMultipleEnumeration
        }

        private static bool HasErrors(this IEnumerable<EdmSchemaError> errors)
        {
            DebugCheck.NotNull(errors);

            return errors.Any(e => e.Severity == EdmSchemaErrorSeverity.Error);
        }
    }
}