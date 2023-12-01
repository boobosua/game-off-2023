using System.Collections.Generic;
using UnityEngine;

namespace Scaleton
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)] private float _spawnRangeX = 2f;
        [SerializeField, Range(1f, 30f)] private float _spawnTimer = 5f;
        [SerializeField] private List<GameObject> _enemyTypes;

        private float _spawnTimeCounter;

        private void Start()
        {
            _spawnTimeCounter = _spawnTimer;
        }

        private void Update()
        {
            if (_spawnTimeCounter <= 0f)
            {
                SpawnRandom();
                _spawnTimeCounter = _spawnTimer;
            }
            else
            {
                _spawnTimeCounter -= Time.deltaTime;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + _spawnRangeX, transform.position.y, transform.position.z));
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - _spawnRangeX, transform.position.y, transform.position.z));
        }

        private void SpawnRandom()
        {
            if (_enemyTypes == null) return;

            var pos = new Vector2(Random.Range(transform.position.x - _spawnRangeX, transform.position.x + _spawnRangeX), transform.position.y);

            Instantiate(_enemyTypes[0], pos, Quaternion.identity);
        }
    }


}

