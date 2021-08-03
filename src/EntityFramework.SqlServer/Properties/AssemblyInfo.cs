// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;

#if MDS
[assembly: AssemblyDefaultAlias("EntityFramework.Microsoft.SqlServer.dll")]
#else
[assembly: AssemblyDefaultAlias("EntityFramework.SqlServer.dll")]
#endif
