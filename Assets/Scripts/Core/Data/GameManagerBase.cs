using System;
using UnityEngine;
using Core.Utilities;
using UnityEngine.Audio;
using System.Collections.Generic;
using Main.Game;

namespace Core.Data
{
	public abstract class GameManagerBase<TGameManager, TDataStore> : PersistentSingleton<TGameManager>
		where TDataStore : GameDataStoreBase, new()
		where TGameManager : GameManagerBase<TGameManager, TDataStore>
	{
		const string k_SavedGameFile = "save";

		public float x;

		public bool y;

		public string z;

		protected JsonSaver<TDataStore> m_DataSaver;

		protected TDataStore m_DataStore;

		protected override void Awake()
		{
			base.Awake();
			LoadData();
		}

		protected void LoadData()
		{
#if UNITY_EDITOR
			m_DataSaver = new JsonSaver<TDataStore>(k_SavedGameFile);
#else
			m_DataSaver = new EncryptedJsonSaver<TDataStore>(k_SavedGameFile);
#endif

			try
			{
				if (!m_DataSaver.Load(out m_DataStore))
				{
					m_DataStore = new TDataStore();
					SaveData();
				}
			}
			catch (Exception)
			{
				Debug.Log("Failed to load data, resetting");
				m_DataStore = new TDataStore();
				SaveData();
			}
		}

		protected virtual void SaveData()
		{
			m_DataSaver.Save(m_DataStore);
		}
	}
}