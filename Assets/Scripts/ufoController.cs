using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoController : MonoBehaviour
{
    [SerializeField] GameObject letter1;
    [SerializeField] GameObject letter2;
    [SerializeField] GameObject letter3;

    [SerializeField] Vector3 letterPos;

    [SerializeField] characterController characterController;

    [SerializeField] bool isCreatable = true;

    [SerializeField] GameObject animUFo;

    public float zOffset = 0;
    private Animator anim;
    private float moveSpeed;
    void Start()
    {
        anim = animUFo.GetComponent<Animator>();

        moveSpeed = characterController.moveSpeed;
        InvokeRepeating("createLetter", 0f, 5f);
        InvokeRepeating("stopInstantiate", 10f, 10f);
        letter1.tag = "targetLetter";
    }

    // Update is called once per frame
    void Update()
    {
        movement();

    }

    void movement()
    {
        Vector3 ileriHareket = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += ileriHareket;
    }

    void createLetter()
    {
        if (isCreatable)
        {
            int i = Random.RandomRange(1, 4);
            if (i == 1)
            {
                instantiateLetter(letter1, -3);
                instantiateLetter(letter3, 0);
                instantiateLetter(letter2, 3);

            }
            if (i == 2)
            {
                instantiateLetter(letter1, 0);
                instantiateLetter(letter3, -3);
                instantiateLetter(letter2, 3);


            }
            if (i == 3)
            {
                instantiateLetter(letter1, 3);
                instantiateLetter(letter3, -3);
                instantiateLetter(letter2, 0);


            }

        }

    }


    void stopInstantiate()
    {
        int i = Random.RandomRange(0, 2);
        if (i == 0)
        {
            anim.SetTrigger("ArkayaDon");
            isCreatable = false;
        }
    }


    void instantiateLetter(GameObject letter, float x)
    {
        GameObject instantiatedLetter = Instantiate(letter);
        instantiatedLetter.transform.position = new Vector3(x, letterPos.y, transform.position.z + zOffset);
        Destroy(instantiatedLetter, 7f);
    }
}
