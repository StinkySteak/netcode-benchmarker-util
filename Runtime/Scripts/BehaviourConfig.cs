using UnityEngine;

namespace StinkySteak.NetcodeBenchmark
{
    [CreateAssetMenu(fileName = nameof(BehaviourConfig), menuName = "Netcode Benchmark/Behaviour Config")]
    public class BehaviourConfig : ScriptableObject
    {
        [SerializeField] private SinMoveYWrapper _sinYMove;
        [SerializeField] private SinRandomMoveWrapper _sinAllAxisMove;
        [SerializeField] private WanderMoveWrapper _wanderMove;

        private void Reset()
        {
            _sinYMove = SinMoveYWrapper.CreateDefault();
            _sinAllAxisMove = SinRandomMoveWrapper.CreateDefault();
            _wanderMove = WanderMoveWrapper.CreateDefault();
        }

        public void ApplyConfig(ref SinMoveYWrapper wrapper)
        {
            wrapper = _sinYMove;
        }

        public void ApplyConfig(ref SinRandomMoveWrapper wrapper)
        {
            wrapper = _sinAllAxisMove;
        }

        public void ApplyConfig(ref WanderMoveWrapper wrapper)
        {
            wrapper = _wanderMove;
        }
    }
}