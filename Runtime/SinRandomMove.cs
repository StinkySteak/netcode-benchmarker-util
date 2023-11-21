using UnityEngine;

namespace StinkySteak.NetcodeBenchmark
{
    public class SinRandomMove
    {
        [SerializeField] private float _minSpeed = 1;
        [SerializeField] private float _maxSpeed = 1;
        [SerializeField] private float _amplitude = 1;

        private Vector3 _targetPosition;
        private Vector3 _initialPosition;

        private float _speed;

        public void NetworkStart()
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);
            _targetPosition = GenerateRandomDirection();
        }

        private Vector3 GenerateRandomDirection()
        {
            return new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
                );
        }

        public void NetworkUpdate(Transform transform)
        {
            float sin = Mathf.Sin(Time.time * _speed) * _amplitude;

            transform.position = _initialPosition + (_targetPosition * sin);
        }
    }
}