using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{
    private GameObject gameManager;
    [SerializeField] private int hitPoints;

    [SerializeField] private GameObject nodeParent;
    Transform[] allChildren;
    List<GameObject> nodes = new List<GameObject>();

    public AudioSource dying;

    [SerializeField] private float speed;
    private int nodeNumber;
    private Vector3 nextNode;
    private Vector3[] positions;

    private int pos;


    void Start()
    {
        allChildren = nodeParent.GetComponentsInChildren<Transform>();
        nodeNumber = nodeParent.transform.childCount;

        if (nodeNumber >= 2)
        {
            foreach (Transform child in allChildren)
            {
                nodes.Add(child.gameObject);
            }

            positions = new Vector3[nodeNumber];

            for (int i = 0; i < nodeNumber; i++)
            {
                positions[i] = nodes[i + 1].transform.position;
            }

            pos = 1;
            nextNode = positions[pos];
        }


        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void FixedUpdate()
    {
        if (nodeNumber >= 2 && !gameManager.GetComponent<PlayerStatus>().IsPaused())
        {
            transform.position = Vector3.MoveTowards(transform.position, nextNode, Time.deltaTime * speed);

            if (transform.position == nextNode)
            {
                pos++;
                if (pos >= nodeNumber)
                {
                    pos = 0;
                    nextNode = positions[pos];
                }
                else
                {
                    nextNode = positions[pos];
                }
            }
        }

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
            gameManager.GetComponent<GameOver>().GOver();
        }
        
    }




}
