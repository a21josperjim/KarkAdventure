using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Animator animator;
    public GameObject[] hearts;
    private int life;
  


    private Vector2 respawnPosition = new Vector2(-2.1f, -0.4f); 
    private bool isDamaged = false;
    
    private void Start()
    {
        life = hearts.Length;
    }

    private void CheckLife()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene("GameOver");
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            RespawnPlayer();
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        transform.position = respawnPosition; 
    }

   public void PlayerDamaged()
    {
        if (isDamaged)
        return;
    life--;
    isDamaged = true;
    CheckLife();
    StartCoroutine(ResetDamageState());
    }  
    private IEnumerator ResetDamageState()
{
    yield return new WaitForSeconds(0.5f);
    isDamaged = false;
}

}
