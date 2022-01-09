using System.IO;
using UnityEngine;

namespace Core.Data
{
	public class JsonSaver<T> : FileSaver<T> where T : IDataStore
	{
		public JsonSaver(string filename)
			: base(filename)
		{
		}

		public override void Save(T data)
		{
			string json = JsonUtility.ToJson(data);
            using StreamWriter writer = GetWriteStream();
            writer.Write(json);
        }

		public override bool Load(out T data)
		{
			if (!File.Exists(m_Filename))
			{
				data = default;
				return false;
			}

			using (StreamReader reader = GetReadStream())
			{
				data = JsonUtility.FromJson<T>(reader.ReadToEnd());
			}

			return true;
		}
	}
}