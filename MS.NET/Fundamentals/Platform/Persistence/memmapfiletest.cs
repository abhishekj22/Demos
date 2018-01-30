using System;
using System.IO;
using System.IO.MemoryMappedFiles;

static class Program
{
	public static void Main(string[] args)
	{
		using(MemoryMappedFile mapping = MemoryMappedFile.CreateFromFile(args[0]))
		{
			using(MemoryMappedViewAccessor view = mapping.CreateViewAccessor())
			{
				FileInfo fi = new FileInfo(args[0]);
				for(long i = 0, j = fi.Length - 1; i < j; ++i, j--)
				{
					byte ib = view.ReadByte(i);
					byte jb = view.ReadByte(j);
					view.Write(i, jb);
					view.Write(j, ib);
				}
			}
		}
	}
}