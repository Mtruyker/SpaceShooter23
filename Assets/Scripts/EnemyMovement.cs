using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    private Transform _player; // Компонент находится на игроке
    private Transform _enemy;
    /// <summary>
    /// Свойство для передачи компонента Transform
    /// </summary>
    public Transform Player
    {
        set
        {
            _player = value;
            Debug.Log(_player);
        }
    }
    void Start()
    {
        _enemy = GetComponent<Transform>();
    }
    /// <summary>
    /// Двигает противника в сторону игрока
    /// </summary>
    public void Move()
    {
        Vector3 direction = _player.position - _enemy.position;
        _enemy.position += direction.normalized * speed * Time.deltaTime;
        float angle = Mathf.Atan2(_enemy.position.y - _player.position.y, _enemy.position.x - _player.position.x) * Mathf.Rad2Deg;
        // Поворачиваем игрока
        _enemy.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
