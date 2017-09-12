﻿using System;
using System.IO;

namespace Carbon.Css.Tests
{
    public class FixtureBase
    {
        public FileInfo GetTestFile(string name)
        {
            var b = new DirectoryInfo(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;

            var c = Path.Combine(b, "data", name);

            // throw new Exception(c);


            return new FileInfo(c);
        }
    }
}
