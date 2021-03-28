using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Логика перезапуска уровня
/// </summary>
public class Restart : MonoBehaviour
{
    /// <summary>
    /// Перезапускает SampleScene
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
