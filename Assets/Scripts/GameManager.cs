using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static Transform _player;
    /// <summary>
    /// публичное свойство, хранящее положение игрока
    /// </summary>
    public static Transform PlayerTransform
    {
        get => _player;
        set => _player = value;
    }
}
