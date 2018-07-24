﻿using System;
using System.Diagnostics;
using System.IO;

namespace Saplin.StorageSpeedMeter
{
    public class SequentialReadTest : SequentialTest
    {
        public SequentialReadTest(FileStream file, int blockSize, long totalBlocks = 0) : base(file, blockSize, totalBlocks)
        {
            
        }

        public override string Name { get => "Sequential read" + " [" + blockSize / 1024 + "Kb] block"; }

        protected override void DoOperation(byte[] buffer, Stopwatch sw)
        {
            sw.Restart();
            file.Read(buffer, 0, blockSize);
            sw.Stop();
        }

        protected override byte[] InitBuffer()
        {
            if (file.Length < blockSize) throw new ArgumentException("File size cant be less than block size");

            if (totalBlocks == 0) totalBlocks = (int)(file.Length / blockSize);

            var buffer = new byte[blockSize];
            return buffer;
        }
    }
}
