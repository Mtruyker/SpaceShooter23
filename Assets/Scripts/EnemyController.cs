using UnityEngine;
public class EnemyController : MonoBehaviour
{
    private int _hp = 3; 
    private EnemyMovement _movement;
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
}
