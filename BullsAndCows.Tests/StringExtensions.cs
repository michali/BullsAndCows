﻿using System.Collections.Generic;

namespace BullsAndCows.Tests
{
    public static class StringExtensions
    {
        public static bool AllCharsUnique(this string input)
        {
            var h = new HashSet<char>(input);

            return h.Count == input.Length;
        }
    }
}