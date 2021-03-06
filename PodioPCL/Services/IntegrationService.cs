﻿using PodioPCL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodioPCL.Services
{
	/// <summary>
	/// Class IntegrationService.
	/// </summary>
	public class IntegrationService
	{
		private Podio _podio;
		/// <summary>
		/// Initializes a new instance of the <see cref="IntegrationService"/> class.
		/// </summary>
		/// <param name="currentInstance">The current instance.</param>
		public IntegrationService(Podio currentInstance)
		{
			_podio = currentInstance;
		}

		/// <summary>
		/// Creates a new integration on the app.
		/// <para>Podio API Reference: https://developers.podio.com/doc/integrations/create-integration-86839 </para>
		/// </summary>
		/// <param name="appId"></param>
		/// <param name="type">The type of integration, see the area for available types</param>
		/// <param name="silent">True if updates should be silent, false otherwise</param>
		/// <param name="config">The configuration of the integration, which depends on the above type,</param>
		/// <returns></returns>
		public int CreateIntegration(int appId, string type, bool silent, dynamic config)
		{
			string url = string.Format("/integration/{0}", appId);
			dynamic requestData = new
			{
				type = type,
				silent = silent,
				config = config
			};
			dynamic response = _podio.PostAsync<dynamic>(url, requestData);
			return (int)response["integration_id"];
		}

		/// <summary>
		/// Deletes the integration from the given app.
		/// <para>Podio API Reference: https://developers.podio.com/doc/integrations/delete-integration-86876 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <returns>Task.</returns>
		public Task DeleteIntegration(int appId)
		{
			string url = string.Format("/integration/{0}", appId);
			return _podio.DeleteAsync<dynamic>(url);
		}

		/// <summary>
		/// Returns the fields available from the configuration.
		/// <para>Podio API Reference: https://developers.podio.com/doc/integrations/get-available-fields-86890 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <returns>Task&lt;List&lt;IntegrationAvailableAppField&gt;&gt;.</returns>
		public Task<List<IntegrationAvailableAppField>> GetAvailableFields(int appId)
		{
			string url = string.Format("/integration/{0}/field/", appId);
			return _podio.GetAsync<List<IntegrationAvailableAppField>>(url);
		}

		/// <summary>
		/// Returns the integration with the given id.
		/// <para>Podio API Reference: https://developers.podio.com/doc/integrations/get-integration-86821 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <returns>Task&lt;Integration&gt;.</returns>
		public Task<Integration> GetIntegration(int appId)
		{
			string url = string.Format("/integration/{0}", appId);
			return _podio.GetAsync<Integration>(url);
		}

		/// <summary>
		/// Refreshes the integration. This will update all items in the background.
		/// <para>Podio API Reference: https://developers.podio.com/doc/integrations/refresh-integration-86987 </para>
		/// </summary>
		/// <param name="appId"></param>
		public Task RefreshIntegration(int appId)
		{
			string url = string.Format("/integration/{0}/refresh", appId);
			return _podio.PostAsync<dynamic>(url);
		}

		/// <summary>
		/// Updates the configuration of the integration. The configuration depends on the type of integration.
		/// <para>Podio API Reference: https://developers.podio.com/doc/integrations/update-integration-86843 </para>
		/// </summary>
		/// <param name="appId"></param>
		/// <param name="silent"></param>
		/// <param name="config"></param>
		public Task UpdateIntegration(int appId, bool? silent, dynamic config)
		{
			string url = string.Format("/integration/{0}", appId);
			dynamic requestData = new
			{
				silent = silent,
				config = config
			};
			return _podio.PutAsync<dynamic>(url, requestData);
		}

		/// <summary>
		/// Updates the mapping between the fields of the app and the fields available from the integration.
		/// <para>Podio API Reference: https://developers.podio.com/doc/integrations/update-integration-mapping-86865 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <param name="fields">Field id and the external id for the given field id</param>
		/// <returns>Task.</returns>
		public Task UpdateIntegrationMapping(int appId, Dictionary<int, string> fields)
		{
			string url = string.Format("/integration/{0}/mapping", appId);
			return _podio.PutAsync<dynamic>(url, fields);
		}
	}
}
