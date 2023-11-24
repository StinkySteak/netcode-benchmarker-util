using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StinkySteak.NetcodeBenchmark
{
    public class BaseGUIGame : MonoBehaviour
    {
        [SerializeField] private Button _buttonStartServer;
        [SerializeField] private Button _buttonStartClient;

        [Space]
        [SerializeField] protected TMP_Text _textLatency;
        [SerializeField] private float _updateLatencyTextInterval = 1f;
        private SimulationTimer.SimulationTimer _timerUpdateLatencyText;

        private void Start()
        {
            _buttonStartServer.onClick.AddListener(StartServer);
            _buttonStartClient.onClick.AddListener(StartClient);
        }

        protected virtual void StartClient() { }

        protected virtual void StartServer() { }


        private void LateUpdate()
        {
            if (!_timerUpdateLatencyText.IsExpiredOrNotRunning()) return;

            UpdateNetworkStats();
            _timerUpdateLatencyText = SimulationTimer.SimulationTimer.CreateFromSeconds(_updateLatencyTextInterval);
        }

        protected virtual void UpdateNetworkStats() { }
    }
}