using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterPickerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> heros = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[]parahero = Resources.LoadAll<GameObject>("hero");

        heros = parahero.ToList();

        GameObject[] brackets = GameObject.FindGameObjectsWithTag("bracket");

        for (int i = 0; i < heros.Count; i++)
        {
            GameObject go = Instantiate(heros[i]);
            go.name = "hero-" + (i + 1);
            go.transform.position = new Vector3(0, 1, 0);
            go.transform.SetParent(brackets[i].transform, false);
        }

            }

    // Update is called once per frame
    void Update()
    {
        
    }
}
