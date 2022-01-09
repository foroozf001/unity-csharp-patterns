using System.Collections.Generic;
using Core.Data;
using UnityEngine;

namespace Main.Game
{
	public sealed class GameDataStore : GameDataStoreBase
	{
		public List<GameSaveData> gameSaveData = new List<GameSaveData>();

		public override void PreSave()
		{
			Debug.Log("[GAME] Saving Game");
		}

		public override void PostLoad()
		{
			Debug.Log("[GAME] Loaded Game");
		}

		public void Add(uint a, uint b, string c, List<string> d)
		{
			gameSaveData.Add(new GameSaveData(a, b, c, d));
		}
	}
}