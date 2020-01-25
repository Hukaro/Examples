using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{

    public Image fadePlane;
    public GameObject gameOverUI;
    public GameObject gameJoustecksUI;

    void Start()
    {
        FindObjectOfType<Player>().OnDeath += OnGameOver;
    }

    void OnGameOver()
    {
        gameJoustecksUI.SetActive(false);
        gameOverUI.SetActive(true);
        StartCoroutine(Fade(Color.clear, Color.black, 1));
    }
    IEnumerator Fade(Color from, Color to, float time)
    {
        float speed = 1 / time;
        float persent = 0;

        while (persent < 1)
        {
            persent += Time.deltaTime * speed;
            fadePlane.color = Color.Lerp(from, to, persent);
            yield return null;
        }
    }

    // UI Input
    public void StartNewGame()
    {
        Application.LoadLevel("GamingScene");
    }
}