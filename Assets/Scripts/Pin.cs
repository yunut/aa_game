using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 10f;
    private bool isPinned = false;

    private bool isLaunched = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isPinned && isLaunched)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPinned = true;
        if (other.gameObject.tag == "Target")
        {
            //GameObject childObject = transform.Find("Square").gameObject;

            GameObject childObject = transform.GetChild(0).gameObject;
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            childSprite.enabled = true;

            transform.SetParent(other.gameObject.transform);

            GameManager.instance.DecreaseGoal();
        }
        else if (other.gameObject.tag == "Pin")
        {
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch()
    {
        isLaunched = true;
    }
}
