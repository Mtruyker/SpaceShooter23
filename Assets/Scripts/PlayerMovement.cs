using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float _currentSpeed;
    private Vector2 _lastDirection;
    private Transform _player;
    /// <summary>
    /// Получаем значение компонента Transform
    /// </summary>
    private void Start()
    {
        _player = GetComponent<Transform>();
    }
    /// <summary>
    /// Метод двигает корабль
    /// </summary>
    /// <param name="inputValues"> Направление движения корабля </param>
    public void Movement(Vector2 inputValues)
    {
        if (inputValues.magnitude > 0) //Длина вектора должна быть больше 0
        {
            _currentSpeed = speed;
            _lastDirection = inputValues;
        }
        Move(_currentSpeed);
    }
    /// <summary>
    /// Меняет положение корабля и имитирует его инерцию
    /// </summary>
    /// <param name="playerSpeed"> текущая скорость корабля </param>
    void Move(float playerSpeed)
    {
        _player.transform.Translate(_lastDirection * Time.deltaTime * playerSpeed);
        _currentSpeed *= 0.9f;
    }
}
