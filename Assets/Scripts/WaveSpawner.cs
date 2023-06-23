using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public Wave[] waves;
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
        if(EnemiesAlive > 0)
        {
            return;
        }

        if(_countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            return;
        }
        _countdown-= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);
        _waveCountdownTimer.text = string.Format("{0:00.00}", _countdown);
    }
    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
        Wave wave = waves[_waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        _waveIndex++;

        if(_waveIndex == waves.Length)
        {
            Debug.Log("LEVEL COMPLETE");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnPoint.position,_spawnPoint.rotation);
        EnemiesAlive++;
    }


}
