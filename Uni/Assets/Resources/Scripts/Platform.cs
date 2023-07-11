using UnityEditor.Experimental.GraphView;
using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour 
{
    public GameObject[] obstacles;
    public PlayerController playerController;


    private bool stepped = false;

    public void OnEnable()
    {
        playerController = GetComponent<PlayerController>();  
        
        stepped = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 5) == 0)
            {

                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player") && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }


    }

}