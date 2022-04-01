using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateRevives : MonoBehaviour
{
    public TextMeshProUGUI totalRevivesText;

    public void revivesUpdate()
    {
        FindObjectOfType<gameOverMenu>().revivesUpdate();
    }


}
