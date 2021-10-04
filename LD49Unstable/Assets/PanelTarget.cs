using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTarget : MonoBehaviour
{
    public FixPanel panel;

    private void Update()
    {
        if (panel != null)
        {
            if (!panel.secured)
            {
                panel = null;
            }
        }
    }

    public void SetPanel(FixPanel fixPanel)
    {
        this.panel = fixPanel;
        fixPanel.ResetPanel(transform);
        fixPanel.PlacedBack();
    }
}
