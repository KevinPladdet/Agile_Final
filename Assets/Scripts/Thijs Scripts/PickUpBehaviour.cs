using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item
{
    public string Name;
    public GameObject GameObjectItem;

    public item(GameObject GameObject_Item)
    {
        GameObjectItem = GameObject_Item;
        Name = GameObject_Item.name.ToLower();
    }
    public void Drop(Vector3 DropPlace)
    {
        GameObject instantiatedItem = GameObject.Instantiate(GameObjectItem, DropPlace, Quaternion.identity);
        GameObjectItem = null;
        Name = null;
    }
}
public class PickUpBehaviour : MonoBehaviour
{
    static public item ItemHolding;
    // Update is called once per frame
    private void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.tag == "Item")
        {
            ItemHolding = new item(Collision.gameObject);
            Destroy(Collision.gameObject);
            Debug.Log(ItemHolding.Name);
            ItemHolding.Drop(new Vector3(0,0,0));
        } 
    }

}

