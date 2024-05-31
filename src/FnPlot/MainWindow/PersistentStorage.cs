using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace FnPlot {

	public class PersistentStorage {

		private static readonly string s_folder =
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KsWare", "FnPlot");
		
		public static void Save(PersistentStorage storage) {
			Debug.Assert(storage != null, $"Argument '{nameof(storage)}' must not be null.");

			if (!Directory.Exists(s_folder)) Directory.CreateDirectory(s_folder);
			var filePath = Path.Combine(s_folder, "luv.dat");
			using var writer = new StreamWriter(filePath);
			using var jsonWriter = new JsonTextWriter(writer);
			var serializer = new JsonSerializer {
				Formatting = Formatting.Indented
			};
			serializer.Serialize(jsonWriter, storage);
		}

		public static PersistentStorage Load() {
			var filePath = Path.Combine(s_folder, "luv.dat");
			if (!File.Exists(filePath)) return new PersistentStorage();
			using var reader = new StreamReader(filePath);
			using var jsonReader = new JsonTextReader(reader);
			var serializer = new JsonSerializer();
			return serializer.Deserialize<PersistentStorage>(jsonReader);
		}

		// ------------------------------------------------------------------------------------------- //

		public string Function { get; set; }
		public List<string> Parameters { get; set; } = new List<string>();
		public string Theme { get; set; } = "Light.Blue"; // "Dark.Blue"
	}

}