using Unity.VisualScripting;
using UnityEngine;


    public class QuestGiver : MonoBehaviour
    {

        public Quest quest;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                quest.isAccepted = true;
            }

        }
    }
