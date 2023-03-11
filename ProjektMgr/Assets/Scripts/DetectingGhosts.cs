using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingGhosts : MonoBehaviour
{
    public AudioSource ghostMoan;

    public AudioSource shot;
    public AudioSource ghostHit;
    public AudioSource charge;
    public AudioSource locked;

    private GameObject player;
    private GameObject gameManager;

    private bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        ghostMoan.volume = 0f;
        
    }
    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(player.transform.position, player.transform.up, 50f);
        if (hit.collider != null)
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Ghost")
            {
                ghostMoan.volume = 1 / (hit.distance + 0.1f);

                if (Input.GetKeyDown("space") && gameManager.GetComponent<PlayerStatus>().DoHasGun())
                {
                    if(!cooldown)
                    {
                        ghostHit.Play(); 
                        shot.Play();

                        hit.transform.gameObject.GetComponent<GhostCollision>().GetShot();

                        cooldown = true;
                        StartCoroutine(GunCooldown());
                    }
                    else
                    {
                        locked.Play();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown("space") && gameManager.GetComponent<PlayerStatus>().DoHasGun())
                {

                    if (!cooldown)
                    {
                        cooldown = true;
                        shot.Play();

                        StartCoroutine(GunCooldown());
                    }
                    else
                    {
                        locked.Play();
                    }

                }

                ghostMoan.volume = 0f;
            }

        }
        else //this almost never happens
        {
            if (Input.GetKeyDown("space") && gameManager.GetComponent<PlayerStatus>().DoHasGun())
            {
                if (!cooldown)
                {
                    cooldown = true;
                    shot.Play();

                    StartCoroutine(GunCooldown());
                }
                else
                {
                    locked.Play();
                }

            }
            ghostMoan.volume = 0f;

        }
    }

    IEnumerator GunCooldown()
    {
        yield return new WaitForSeconds(1.15f);
        charge.Play();
        yield return new WaitForSeconds(.475f);

        cooldown = false;
    }

    public void KillGhost()
    {
        //sound of ghost dying or sth
    }
}
