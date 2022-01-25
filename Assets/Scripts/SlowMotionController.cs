using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlowMotionController : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }
    /// <summary>
    /// Запускает корутину
    /// </summary>
    public void Defeat()
    {
        StartCoroutine(Slowmotion());
    }
    /// <summary>
    /// Замедляет время, а затем перезапускает сцену
    /// </summary>
    /// <returns></returns>
    IEnumerator Slowmotion()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(.3f);
        Time.timeScale = .15f;
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(0);
    }
}
