using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Z2
{
    public class DoorController : MonoBehaviour, ISwitchable
    {
        public Sprite openedDoor;
        public Sprite closedDoor;
        public bool isOpen;
        public GameObject otherExit;
        public Text text;

        private SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            SetSprite();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void ISwitchable.Switch()
        {
            Debug.Log("XXXXXXXXXXXXXXXXXXXXXXXXXX");
            isOpen = !isOpen;
            SetSprite();
        }

        void SetSprite()
        {
            if (isOpen)
            {
                spriteRenderer.sprite = openedDoor;
            }
            else
            {
                spriteRenderer.sprite = closedDoor;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isOpen && collision.gameObject.CompareTag("Player"))
            {
                text.text = "Radosny koniec przygody!";
                collision.gameObject.transform.position = otherExit.transform.position;
            }
        }
    }
}
