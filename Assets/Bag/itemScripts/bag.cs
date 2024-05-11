using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Bag", menuName = "Bag/New Bag")]
public class bag : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
