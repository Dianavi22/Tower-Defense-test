using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
      [SerializeField]
    private Transform enemyPrefab;
    [SerializeField]

    private Transform _spawnPoint;
    [SerializeField]
    private float timeBetweenWaves = 5.5f;
    [SerializeField]
    private Text _waveCountdownTimer;
    private float _countdown = 5f;

    private int _waveIndex = 0;

    void Update()
    {
        if(_countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }
        _countdown-= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);
        _waveCountdownTimer.text = string.Format("{0:00.00}", _countdown);
    }
    IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, _spawnPoint.position,_spawnPoint.rotation);
    }


}
