using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnPlayerDefeated;
    private float _horizontal;
    private float _vertical;
    private int _hp = 5;
    private PlayerMovement _movement;
    private PlayerRotation _rotation;
    [SerializeField] private GameObject expolison;
    private PlayerCombat _combat;
    /// <summary> 
    /// Получаем значения компонентов в приватные поля
    /// </summary>
    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _rotation = GetComponent<PlayerRotation>();
        _combat = GetComponent<PlayerCombat>();
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
    public void Hit()
    {
        _hp--;
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(expolison, transform.position, Quaternion.identity);
            OnPlayerDefeated.Invoke();
        }
    }
}
