using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{
    private GameObject gameManager;
    [SerializeField] private int hitPoints;

    public AudioSource dying;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public int GetHp()
    {
        return hitPoints;
    }

    public void SetHp(int hp)
    {
        hitPoints = hp;
    }

    public void GetShot()
    {
        if(hitPoints > 0)
        {
            hitPoints--;
        }
        else
        {
            Debug.Log("already dead");
        }

        if(hitPoints == 0)
        {
            gameManager.GetComponent<DetectingGhosts>().KillGhost();
            gameManager.GetComponent<GhostCounting>().SubGhost();
            dying.Play();
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Player")
        {
            Debug.Log("Collision");
        }
        
    }




}
