﻿using Newtonsoft.Json;
using PodioPCL.Utils.Serialization;

namespace PodioPCL.Utils
{
	internal class JSONSerializer
	{
		public static string Serilaize(object entity)
		{
			var settings = new JsonSerializerSettings();
			settings.NullValueHandling = NullValueHandling.Ignore;

			return JsonConvert.SerializeObject(entity, settings);
		}

		public static T Deserilaize<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json, new JsonConverter[] { new NestedDictionaryConverter() });
		}
	}
}
