using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay.Models;
using UnityEngine;

namespace BuilderPattern
{

    [System.Serializable]
    public enum EncryptionType
    {
        DTLS, // Datagram Transport Layer Security
        WSS // Web Socket Secure
    }

    public class MultiplayerService : MonoBehaviour
    {
        [SerializeField] private string m_lobbyName = "Lobby";
        [SerializeField] private int m_maxPlayers = 4;
        [SerializeField] private EncryptionType m_encryption = EncryptionType.DTLS;

        private const string k_dtlsEncryption = "dtls"; // Datagram Transport Layer Security
        private const string k_wssEncryption = "wss"; // Web Socket Secure

        private string ConnectionType => m_encryption == EncryptionType.DTLS ? k_dtlsEncryption : k_wssEncryption;
        private Allocation m_allocation;
        private Lobby m_currentLobby;

        public async Task CreateLobby(string relayJoinCode)
        {
            try
            {
                CreateLobbyOptions options = new CreateLobbyOptions
                {
                    IsPrivate = false
                };

                m_currentLobby = await LobbyService.Instance.CreateLobbyAsync(m_lobbyName, m_maxPlayers, options);
                Debug.Log($"Created lobby: {m_currentLobby.Name} with code {m_currentLobby.LobbyCode}");

                await LobbyService.Instance.UpdateLobbyAsync(m_currentLobby.Id, new UpdateLobbyOptionsFluentBuilder()
                    .AddMemberData("RelayJoinCode", relayJoinCode)
                    .AddPrivateData("ExamplePrivateData", "PrivateData")
                    .AddPublicData("ExamplePublicData", "PublicData", DataObject.IndexOptions.S1)
                    .Build());

                NetworkManager.Singleton.GetComponent<UnityTransport>()
                    .SetRelayServerData(new RelayServerData(m_allocation, ConnectionType));

                NetworkManager.Singleton.StartHost();
            }
            catch (LobbyServiceException e)
            {
                Debug.LogError($"Failed to create lobby: {e.Message}");
            }
        }
    }
}
