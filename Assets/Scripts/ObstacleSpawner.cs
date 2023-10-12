using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject Obstacle;
    [SerializeField] float SpawnTimer = 2;

    [Header("Size Randomization Properties")]
    [SerializeField] bool HasRandomSize = true;
    [Range(0.1f, 2f)][SerializeField] float RandomSizeMinRange = 0.1f;
    [Range(0.1f, 2f)][SerializeField] float RandomSizeMaxRange = 0.1f;

    [Header("Spawn Offset Properties")]
    [SerializeField] bool HasRandomSpawnOffset = true;
    [SerializeField] Vector3 SpawnOffset = Vector3.zero;
    [SerializeField] Vector2 RandomOffsetMinRange = Vector2.zero;
    [SerializeField] Vector2 RandomOffsetMaxRange = Vector2.zero;

    float _spawnCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Obstacle == null)
            Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        _spawnCounter += Time.deltaTime;

        if (_spawnCounter >= SpawnTimer)
        {
            if (HasRandomSpawnOffset)
            {
                Vector2 randomOffset = new Vector2(Random.Range(RandomOffsetMinRange.x, RandomOffsetMaxRange.x), Random.Range(RandomOffsetMinRange.y, RandomOffsetMaxRange.y));
                SpawnOffset = new Vector3(randomOffset.x, randomOffset.y, transform.position.z);
            }

            if (HasRandomSize)
            {
                float randomSize = Random.Range(RandomSizeMinRange, RandomSizeMaxRange);
                Obstacle.transform.localScale = new Vector3(randomSize, randomSize, Obstacle.transform.localScale.z);
            }

            Instantiate(Obstacle, transform.position + SpawnOffset, Quaternion.identity, transform);

            _spawnCounter = 0;
        }
    }

    private void OnDisable()
    {
        Obstacle.transform.localScale = Vector3.one;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, RandomOffsetMinRange);
        Gizmos.DrawWireCube(transform.position, RandomOffsetMaxRange);
    }
}
