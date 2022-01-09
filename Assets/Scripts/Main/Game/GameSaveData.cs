using System;
using System.Collections.Generic;

namespace Main.Game
{
	[Serializable]
	public class GameSaveData
	{
		public uint a;
		public uint b;
		public string c;
		public List<string> d;

		public GameSaveData(uint a, uint b, string c, List<string> d)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
		}
	}
}