using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Common
{
    public class PluginResponse
    {
        public PluginResponse()
        {

        }

        public PluginResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public PluginResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public PluginResponse(bool success, string message, string errorMessage)
        {
            Success = success;
            Message = message;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Gets or sets a value indication whether succedd
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data 
        /// </summary>
        public string Data { get; set; }


        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    }
}
