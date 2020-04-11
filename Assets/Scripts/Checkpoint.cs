using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material triggered;

    public GameObject Halo;
    public GameObject Halo_triggered;

    private float bottom_y;
    private GameObject[] Halos = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
        PlayerPrefs.DeleteAll();

        bottom_y = gameObject.transform.position.y - 0.2f;

        for (int i = 0; i < Halos.Length; i++)
        {
            Halos[i] = Instantiate(Halo);
            Halos[i].transform.SetPositionAndRotation(
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + i * 0.2f, gameObject.transform.position.z),
                gameObject.transform.rotation
                );
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Halos.Length; i++)
        {
            Halos[i].transform.position += new Vector3(0, 0.001f, 0);
            if (Halos[i].transform.position.y >= bottom_y + 0.7f)
            {
                Halos[i].transform.position -= new Vector3(0, 0.8f, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetFloat("pos_x", gameObject.transform.position.x);
        PlayerPrefs.SetFloat("pos_y", gameObject.transform.position.y);
        gameObject.GetComponent<MeshRenderer>().material = triggered;

        for (int i = 0; i < Halos.Length; i++)
        {
            Destroy(Halos[i]);
            Halos[i] = Instantiate(Halo_triggered);
            Halos[i].transform.SetPositionAndRotation(
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + i * 0.2f, gameObject.transform.position.z),
                gameObject.transform.rotation
                );
        }
    }

}
