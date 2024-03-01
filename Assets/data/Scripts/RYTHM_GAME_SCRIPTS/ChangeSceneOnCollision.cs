using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("demolition-ball"))
        {
            Invoke("ChangeScene", 6f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("StartScreen");
    }
}