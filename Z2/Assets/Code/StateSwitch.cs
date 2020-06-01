using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Z2
{
    public class StateSwitch : MonoBehaviour
    {
        public Component switchableComponent;
        public Sprite[] sprites;
        protected ISwitchable switchableElement;
        protected bool state = false;
        protected SpriteRenderer spriteRenderer;

        // Start is called before the first frame update
        void Start()
        {
            if (!(switchableComponent is ISwitchable))
            {
                Debug.LogError("Not Switchable!");
            }
            else
            {
                switchableElement = (ISwitchable)switchableComponent;
            }
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collision detected with tag: " + collision.tag);
            if (collision.gameObject.CompareTag("Player"))
            {
                SwapSprite();
                Debug.Log("Execute switch!");
                switchableElement.Switch();
            }
        }
        void SwapSprite()
        {
            if (state)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                spriteRenderer.sprite = sprites[1];
            }
            state = !state;
        }
    }
}