using System.Collections;
using UnityEngine;
public class PlayerCombat : MonoBehaviour
{
    // Ссылка на префаб лазера
    [SerializeField] private GameObject laser;
    // Расстояние от игрока до точки появления лазера
    [SerializeField] private float laserOffset;
    // Время между выстрелами
    [SerializeField] private float laserCooldown;
    private Transform _player;
    private bool _canShoot = true;
    private void Start()
    {
        _player = GetComponent<Transform>();
    }
    /// <summary>
    /// Создаёт лазер
    /// </summary>
    public void Shoot()
    {
        if (_canShoot)
        {
            // Запуск таймера
            StartCoroutine(Cooldown());
            // Высчитываем позицию корабля
            float posX = _player.position.x + (Mathf.Cos ((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * - laserOffset);
            float posY = _player.position.y + (Mathf.Sin ((transform.localEulerAngles.z - 90) * Mathf.Deg2Rad) * - laserOffset);
            // Создаём лазер на этой позиции
            Instantiate(laser, new Vector2(posX, posY), _player.rotation);
        }
    }
    /// <summary>
    /// Перезарядка лазера
    /// </summary>
    /// <returns></returns>
    IEnumerator Cooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(laserCooldown);
        _canShoot = true;
    }
}

