using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private PlayerMovement _movement;
    private PlayerRotation _rotation;
    private PlayerCombat _combat;
    /// <summary> 
    /// Получаем значения компонентов в приватные поля
    /// </summary>
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rotation = GetComponent<PlayerRotation>();
        _combat = GetComponent<PlayerCombat>();
        GameManager.PlayerTransform = GetComponent<Transform>();
    }

    /// <summary>
    /// Вызываем методы каждый кадр
    /// </summary>
    private void Update()
    {
        GetInputValues();
        _movement.Movement(new Vector2(_horizontal, _vertical));
        _rotation.Rotation();
        if (Input.GetMouseButton(0))
        {
            _combat.Shoot();
        }
    }
    /// <summary>
    /// Получаем значения осей ввода
    /// </summary>
    void GetInputValues()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
    }
}
