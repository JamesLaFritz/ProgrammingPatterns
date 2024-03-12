#region Header

// UpdateLobbyOptionsBuilder.cs
// 
// From [Warped Imagination](https://www.youtube.com/@WarpedImagination)

#endregion

using System.Collections.Generic;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

namespace BuilderPattern
{
    public class UpdateLobbyOptionsFluentBuilder
    {
        private readonly Dictionary<string, DataObject> m_data = new();

        public UpdateLobbyOptionsFluentBuilder AddPublicData(string key, string value,
            DataObject.IndexOptions index = default)
        {
            m_data.Add(key, new DataObject(DataObject.VisibilityOptions.Public, value, index));
            return this;
        }

        public UpdateLobbyOptionsFluentBuilder AddMemberData(string key, string value,
            DataObject.IndexOptions index = default)
        {
            m_data.Add(key, new DataObject(DataObject.VisibilityOptions.Member, value, index));
            return this;
        }

        public UpdateLobbyOptionsFluentBuilder AddPrivateData(string key, string value,
            DataObject.IndexOptions index = default)
        {
            m_data.Add(key, new DataObject(DataObject.VisibilityOptions.Private, value, index));
            return this;
        }

        public UpdateLobbyOptions Build()
        {
            return new UpdateLobbyOptions { Data = m_data };
        }
    }
}