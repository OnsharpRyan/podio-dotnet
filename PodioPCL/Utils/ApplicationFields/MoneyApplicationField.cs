﻿using Newtonsoft.Json.Linq;
using PodioPCL.Models;
using System.Collections.Generic;

namespace PodioPCL.Utils.ApplicationFields
{
	/// <summary>
	/// Class MoneyApplicationField.
	/// </summary>
    public class MoneyApplicationField : ApplicationField
    {
        private IEnumerable<string> _allowedCurrencies;
		/// <summary>
		/// List of allowed currencies.
		/// <para>The currencies must be a valid ISO 3166-1 currency (http://en.wikipedia.org/wiki/ISO_3166-1_alpha-3) represented by 3 letters in uppercase.</para>
		/// </summary>
		/// <value>The allowed currencies.</value>
        public IEnumerable<string> AllowedCurrencies
        {
            get
            {
                if (_allowedCurrencies == null)
                {
                    _allowedCurrencies = this.GetSettingsAs<string>("allowed_currencies");
                }
                return _allowedCurrencies;
            }
            set
            {
                InitializeFieldSettings();
                this.InternalConfig.Settings["allowed_currencies"] = value != null ? JToken.FromObject(value) : null;
            }
        }
    }
}
