using UnityEngine;
public class PlayerRotation : MonoBehaviour
{
    private Transform _player; //Компонент Transform игрока
    private Camera _camera;
    /// <summary>
    /// Получаем значения компонентов в приватные поля
    /// </summary>
    private void Start()
    {
        _player = GetComponent<Transform>();
        _camera = Camera.main;
    }
    /// <summary>
    /// Метод поворачивает игрока к курсору мыши
    /// </summary>
    public void Rotation()
    {
        // Получаем координаты курсора
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        // Находим угол между кораблём и курсором
        float angle = Mathf.Atan2(_player.position.y - mousePosition.y, _player.position.x - mousePosition.x) * Mathf.Rad2Deg;
        // Поворачиваем игрока
        _player.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
