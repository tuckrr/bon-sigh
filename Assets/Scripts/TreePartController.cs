using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePartController : MonoBehaviour
{
    public enum Part  {Trunk, Branch, Leaf };

    public Part myType;
    public bool Correct = true;
    // Update is called once per frame
    public void Cut()
    {
        switch (myType)
        {
            case Part.Leaf:
                Debug.Log("Falling Leaf!");
                gameObject.AddComponent<Rigidbody2D>();
                GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                gameObject.layer = LayerMask.NameToLayer("Falling");
                break;
            case Part.Branch:
                Debug.Log("Cutting Branch!");
                // activate the child, destroy self
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.AddComponent<Rigidbody2D>();
                }
                SetChildrenLayer(transform, LayerMask.NameToLayer("Falling"));
                transform.DetachChildren();
                Destroy(gameObject);
                break;
            case Part.Trunk:
                // probably do nothing here? create some particles? change to branch?
                break;
        }
    }

    void SetChildrenLayer(Transform tr, int layer)
    {
        for (int i = 0; i < tr.childCount; i++)
        {
            tr.GetChild(i).gameObject.layer = layer;
            SetChildrenLayer(tr.GetChild(i), layer);
        }
    }
}
