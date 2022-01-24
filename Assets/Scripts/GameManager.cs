using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _countOfEnemies = 0; // Число противников
    [SerializeField] private int enemiesPerWave = 4; // Число противников в волне
    [SerializeField] private GameObject enemy; 
    [SerializeField] private Transform player;
    private void Start()
    {
        SpawnEnemies();
    }
    /// <summary>
    /// Считает количество живых противников
    /// Если противники кончились — создаёт ещё одну волну
    /// </summary>
    public void OnEnemyDie()
    {
        _countOfEnemies--;
        if (_countOfEnemies <= 0)
        {
            SpawnEnemies();
        }
    }
    /// <summary>
    /// Метод создаёт противников на случайном отадлении от игрока
    /// </summary>
    void SpawnEnemies()
    {
        _countOfEnemies = enemiesPerWave;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            float randDistance = Random.Range(10,25);
            float randDir = Random.Range(0,360);
            float posX = player.position.x + (Mathf.Cos(randDir * Mathf.Deg2Rad) * randDistance);
            float posY = player.position.y + (Mathf.Sin(randDir * Mathf.Deg2Rad) * randDistance);
            GameObject spawnedEnemy = Instantiate(enemy, new Vector3(posX, posY, 0), Quaternion.identity);
            // Передача противнику ссылок на игрока и менеджер
            spawnedEnemy.GetComponent<EnemyController>().OnSpawn(player, this);
        }
        enemiesPerWave++;
    }
}
