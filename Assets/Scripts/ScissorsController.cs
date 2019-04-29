using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsController : MonoBehaviour
{
    public Sprite open;
    public Sprite closed;

    private PolygonCollider2D coll;
    private SpriteRenderer sp;
    private Collider2D[] snippables;
    private ContactFilter2D cf;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<PolygonCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
        snippables = new Collider2D[16];
        cf = new ContactFilter2D();
        cf.NoFilter();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Standing"), LayerMask.NameToLayer("Falling"));
       //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Falling"), LayerMask.NameToLayer("Scissors"));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);

        if (Input.GetAxis("Fire1") > .5f)
        {
            if (sp.sprite == open)
            {
                Debug.Log("Snip!");
                sp.sprite = closed;
                int n = coll.OverlapCollider(cf, snippables);
                Debug.Log("Snip, " + n + " collisions!");
                if (n > 0)
                {
                    Collider2D cut = snippables[0];

                    for (int i = 1; i < n; i++)
                    {
                        Vector2 v1 = cut.transform.position - transform.position;
                        Vector2 v2 = snippables[i].transform.position - transform.position;
                        if (v2.magnitude < v1.magnitude)
                        {
                            cut = snippables[i];
                        }
                    }
                    Debug.Log("Calling Cut!");
                    cut.gameObject.GetComponent<TreePartController>().Cut();
                }
            }
        }
        else
        {
            sp.sprite = open;
        }
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
    }
}
