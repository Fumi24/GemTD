using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreFab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        waveCountdownText.text = "New Wave In: " + Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incomming!");
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPreFab, spawnPoint.position, spawnPoint.rotation);
    }
}
