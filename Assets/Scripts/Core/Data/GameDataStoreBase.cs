using System.Collections.Generic;

namespace Core.Data
{
	/// <summary>
	/// Base game data store for GameManager to save, containing only data for saving volumes
	/// </summary>
	public abstract class GameDataStoreBase : IDataStore
	{
		public float a = 1.3f;

		public float b = 4.2f;

		public string c = "howdy, partner!";

		public List<string> d = new List<string>(new string[] { "element1", "element2", "element3" });

		/// <summary>
		/// Called just before we save
		/// </summary>
		public abstract void PreSave();

		/// <summary>
		/// Called just after load
		/// </summary>
		public abstract void PostLoad();
	}
}