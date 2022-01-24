using UnityEngine;
public class EnemyController : MonoBehaviour
{
    private int _hp = 3; 
    private EnemyMovement _movement;
    private GameManager _manager;
    /// <summary>
    /// Получение координат игрока
    /// </summary>
    private void OnEnable()
    {
        _movement = GetComponent<EnemyMovement>();
    }
    /// <summary>
    /// Движение к игроку
    /// </summary>
    private void Update()
    {
        _movement.Move();
    }
    /// <summary>
    /// Вызывается при соприкосновении с лазером
    /// </summary>
    public void Hit(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Метод, получающий ссылку на менеджер и игрока
    /// </summary>
    /// <param name="player"> Ссылка на компонент Transform игрока </param>
    /// <param name="gameManager"> Ссылка на игровой менеджер</param>
   public void OnSpawn(Transform player, GameManager gameManager)
    {
        _movement.Player = player;
        _manager = gameManager; 
    }
    /// <summary>
    /// Вызывается при уничтожении объекта
    /// </summary>
    private void OnDestroy()
    {
        _manager.OnEnemyDie();
    }
    /// <summary>
    /// Вызывается при соприкосновении с игроком
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Hit();
            Destroy(gameObject);
        }
    }
}
