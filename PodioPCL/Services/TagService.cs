﻿using PodioPCL.Models;
using System.Collections.Generic;
using PodioPCL.Utils;
using System.Threading.Tasks;

namespace PodioPCL.Services
{
	/// <summary>
	/// Class TagService.
	/// </summary>
    public class TagService
    {
        private Podio _podio;
		/// <summary>
		/// Initializes a new instance of the <see cref="TagService"/> class.
		/// </summary>
		/// <param name="currentInstance">The current instance.</param>
        public TagService(Podio currentInstance)
        {
            _podio = currentInstance;
        }

		/// <summary>
		/// Adds additional tags to the object. If a tag with the same text is already present, the tag will be ignored. Existing tags on the object are preserved.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/create-tags-22464 </para>
		/// </summary>
		/// <param name="refType">Type of the reference.</param>
		/// <param name="refId">The reference identifier.</param>
		/// <param name="tags">The tags.</param>
		/// <returns>Task.</returns>
		public async Task CreateTags(string refType, int refId, List<string> tags)
        {
            string url = string.Format("/tag/{0}/{1}/", refType, refId);
            await _podio.PostAsync<dynamic>(url, tags);
        }

		/// <summary>
		/// Returns the objects that are tagged with the given text on the app. The objects are returned sorted descending by the time the tag was added.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/get-objects-on-app-with-tag-22469 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <param name="text">The tag to search for.</param>
		/// <returns>Task&lt;List&lt;TaggedObject&gt;&gt;.</returns>
		public async Task<List<TaggedObject>> GetObjectsOnAppWithTag(int appId, string text)
        {
            string url = string.Format("/tag/app/{0}/search/",appId);
            var requestData = new Dictionary<string, string>()
            {
                {"text",text}
            };
            return await _podio.GetAsync<List<TaggedObject>>(url, requestData);
        }

		/// <summary>
		/// Returns the objects that are tagged with the given text on the organization. The objects are returned sorted descending by the time the tag was added.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/get-objects-on-organization-with-tag-48478 </para>
		/// </summary>
		/// <param name="orgId">The org identifier.</param>
		/// <param name="text">The text.</param>
		/// <returns>Task&lt;List&lt;TaggedObject&gt;&gt;.</returns>
		public async Task<List<TaggedObject>> GetObjectsOnOrganizationWithTag(int orgId, string text)
        {
            string url = string.Format("/tag/org/{0}/search/",orgId);
            var requestData = new Dictionary<string, string>()
            {
                {"text",text}
            };
            return await _podio.GetAsync<List<TaggedObject>>(url, requestData);
        }

		/// <summary>
		/// Returns the objects that are tagged with the given text on the space. The objects are returned sorted descending by the time the tag was added.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/get-objects-on-space-with-tag-22468 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <param name="text">The text.</param>
		/// <returns>Task&lt;List&lt;TaggedObject&gt;&gt;.</returns>
		public async Task<List<TaggedObject>> GetObjectsOnSpaceWithTag(int spaceId, string text)
        {
            string url = string.Format("/tag/space/{0}/search/", spaceId);
            var requestData = new Dictionary<string, string>()
            {
                {"text",text}
            };
            return await _podio.GetAsync<List<TaggedObject>>(url, requestData);
        }

		/// <summary>
		/// Returns the tags on the given app. This includes only items. The tags are first limited ordered by their frequency of use, and then returned sorted alphabetically.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/get-tags-on-app-22467 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <param name="limit">The maximum number of tags to return.</param>
		/// <param name="text">The tag to search for.</param>
		/// <returns>Task&lt;List&lt;Tag&gt;&gt;.</returns>
		public async Task<List<Tag>> GetTagsOnApp(int appId, int? limit = null, string text = null)
        {
            string url = string.Format("/tag/app/{0}/",appId);
            var requestData = new Dictionary<string, string>()
            {
                {"limit",limit.ToStringOrNull()},
                {"text",text}
            };
            return await _podio.GetAsync<List<Tag>>(url, requestData);
        }

		/// <summary>
		/// Returns the top tags on the app.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/get-tags-on-app-top-68485 </para>
		/// </summary>
		/// <param name="appId">The application identifier.</param>
		/// <param name="limit">The maximum number of tags to return</param>
		/// <param name="text">The tag to search for</param>
		/// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
		public async Task<List<string>> GetTagsOnAppTop(int appId, int? limit = null, string text = null)
        {
            string url = string.Format("/tag/app/{0}/top/", appId);
            var requestData = new Dictionary<string, string>()
            {
                {"limit",limit.ToStringOrNull()},
                {"text",text}
            };
            return await _podio.GetAsync<List<string>>(url, requestData);
        }

		/// <summary>
		/// Returns the tags on the given org. This includes both items and statuses on all spaces in the organization that the user is part of. The tags are first limited ordered by their frequency of use, and then returned sorted alphabetically.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/get-tags-on-organization-48473 </para>
		/// </summary>
		/// <param name="orgId">The org identifier.</param>
		/// <param name="limit">The maximum number of tags to return</param>
		/// <param name="text">The tag to search for</param>
		/// <returns>Task&lt;List&lt;Tag&gt;&gt;.</returns>
		public async Task<List<Tag>> GetTagsOnOrganization(int orgId, int? limit = null, string text = null)
        {
            string url = string.Format("/tag/org/{0}/", orgId);
            var requestData = new Dictionary<string, string>()
            {
                {"limit",limit.ToStringOrNull()},
                {"text",text}
            };
            return await _podio.GetAsync<List<Tag>>(url, requestData);
        }

		/// <summary>
		/// Returns the tags on the given space. This includes both items and statuses. The tags are first limited ordered by their frequency of use, and then returned sorted alphabetically.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/get-tags-on-space-22466 </para>
		/// </summary>
		/// <param name="spaceId">The space identifier.</param>
		/// <param name="limit">The maximum number of tags to return</param>
		/// <param name="text">The tag to search for</param>
		/// <returns>Task&lt;List&lt;Tag&gt;&gt;.</returns>
		public async Task<List<Tag>> GetTagsOnSpace(int spaceId, int? limit = null, string text = null)
        {
            string url = string.Format("/tag/space/{0}/", spaceId);
            var requestData = new Dictionary<string, string>()
            {
                {"limit",limit.ToStringOrNull()},
                {"text",text}
            };
            return await _podio.GetAsync<List<Tag>>(url, requestData);
        }

		/// <summary>
		/// Removes a single tag from an object.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/remove-tag-22465 </para>
		/// </summary>
		/// <param name="refType">Type of the reference.</param>
		/// <param name="refId">The reference identifier.</param>
		/// <param name="text">The tag to search for</param>
		/// <returns>Task.</returns>
		public async Task RemoveTag(string refType, int refId, string text)
        {
            string url = string.Format("/tag/{0}/{1}?text={2}", refType, refId,text);
            await _podio.DeleteAsync<dynamic>(url);
        }

		/// <summary>
		/// Updates the tags on the given object. Existing tags on the object will be overwritten. Use Create Tags operation to preserve existing tags.
		/// <para>Podio API Reference: https://developers.podio.com/doc/tags/update-tags-39859 </para>
		/// </summary>
		/// <param name="refType">Type of the reference.</param>
		/// <param name="refId">The reference identifier.</param>
		/// <param name="tags">The tags.</param>
		/// <returns>Task.</returns>
		public async Task UpdateTags(string refType, int refId, List<string> tags)
        {
            string url = string.Format("/tag/{0}/{1}/", refType, refId);
            await _podio.PutAsync<dynamic>(url, tags);
        }
    }
}
