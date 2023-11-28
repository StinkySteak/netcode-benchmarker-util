using UnityEngine;

namespace StinkySteak.NetcodeBenchmark
{
    [System.Serializable]
    public struct SinMoveYWrapper : IMoveWrapper
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minAmplitude;
        [SerializeField] private float _maxAmplitude;
        [SerializeField] private float _randomMultiplier;

        private Vector3 _initialPosition;

        private float _speed;
        private float _amplitude;

        public static SinMoveYWrapper CreateDefault()
        {
            SinMoveYWrapper wrapper = new();
            wrapper._minSpeed = 0.5f;
            wrapper._maxSpeed = 1f;
            wrapper._minAmplitude = 0.5f;
            wrapper._maxAmplitude = 1f;
            wrapper._randomMultiplier = 5f;

            return wrapper;
        }

        public void NetworkStart(Transform transform)
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);
            _amplitude = Random.Range(_minAmplitude, _maxAmplitude);
            _initialPosition = GenerateRandomPosition();
        }

        private Vector3 GenerateRandomPosition()
        {
            return new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
                ) * _randomMultiplier;
        }

        public void NetworkUpdate(Transform transform)
        {
            float sin = Mathf.Sin(Time.time * _speed) * _amplitude;

            transform.position = _initialPosition + (Vector3.up * sin);
        }
    }
}