using UnityEngine;
using TMPro;
public class ScoreUi : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
    }
    /// <summary>
    /// Обновляет значение компонента текст 
    /// </summary>
    private void Update()
    {
        scoreText.text = "Score: " + _gameManager.Score;
    }
}
