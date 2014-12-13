﻿using Newtonsoft.Json.Linq;
using PodioPCL.Models;
using System.Collections.Generic;

namespace PodioPCL.Models.ItemFields
{
	public class ImageItemField : ItemField
	{
		private List<FileAttachment> _images;

		public IEnumerable<FileAttachment> Images
		{
			get
			{
				return this.valuesAs<FileAttachment>(_images);
			}
		}

		public IEnumerable<int> FileIds
		{
			set
			{
				ensureValuesInitialized();
				foreach (var fileId in value)
				{
					var jobject = new JObject();
					jobject["value"] = fileId;
					this.Values.Add(jobject);
				}
			}
		}
		public int FileId
		{
			set
			{
				ensureValuesInitialized();

				var jobject = new JObject();
				jobject["value"] = value;
				this.Values.Add(jobject);

			}
		}
	}
}
