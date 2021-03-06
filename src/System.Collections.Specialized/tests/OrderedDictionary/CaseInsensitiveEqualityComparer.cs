// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;

namespace System.Collections.Specialized.Tests
{
    internal sealed class CaseInsensitiveEqualityComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            if (x == y) return true;
            if (x == null || y == null) return false;

            String sa = x as String;
            if (sa != null)
            {
                String sb = y as String;
                if (sb != null)
                {
                    return sa.Equals(sb, StringComparison.CurrentCultureIgnoreCase);
                }
            }
            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            string s = obj as string;
            if (s != null)
            {
                return s.ToUpper().GetHashCode();
            }
            return obj.GetHashCode();
        }
    }
}