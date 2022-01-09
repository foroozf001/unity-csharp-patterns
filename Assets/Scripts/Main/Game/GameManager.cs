using Core.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Game
{
	public class GameManager : GameManagerBase<GameManager, GameDataStore>
	{
		protected override void Awake()
		{
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
			base.Awake();
		}

        protected void Start()
        {
            TestSaveData();
        }

        protected void TestSaveData()
        {
			m_DataStore.Add(14, 2, "hello, world!", new List<string>(new string[] { "hello1", "hello2" }));
            SaveData();
            foreach (GameSaveData x in m_DataStore.gameSaveData)
            {
                Debug.Log(string.Format("{0},{1},{2},{3}", x.a, x.b, x.c, x.d));
            }
        }
    }
}