using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject player, currPlayer;
    public Vector3 initialPosition;
    private static GameController _instance;
    public bool userHasWon = false;

    public static GameController Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(player != null)
        {
            initialPosition = player.transform.position;
            currPlayer = Instantiate(player, new Vector3(9.5f, -1f, 23.1f), Quaternion.identity);

        }
    }

    public void RestartPlayer()
    {
        if (userHasWon)
        {
            Destroy(currPlayer);
            userHasWon = false;
            GameObject.Find("EndText").GetComponent<Text>().text = "";
            currPlayer = Instantiate(player, new Vector3(initialPosition.x, -initialPosition.y, initialPosition.z), Quaternion.identity);
        }
        else {
            if (player && !currPlayer)
            {
                GameObject.Find("EndText").GetComponent<Text>().text = "";
                currPlayer = Instantiate(player, new Vector3(initialPosition.x, -initialPosition.y, initialPosition.z), Quaternion.identity);
            }
        }

        //Finally
        Time.timeScale = 1.0f;
    }
}
