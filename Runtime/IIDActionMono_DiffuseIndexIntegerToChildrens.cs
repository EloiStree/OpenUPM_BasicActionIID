


using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IIDActionMono_DiffuseIndexIntegerToChildrens : MonoBehaviour, I_IID_TriggerFromIndexIntegerAndInteger
{

    public Transform m_root;
    public List<MonoBehaviour> m_compatible = new List<MonoBehaviour>();
    
    [Header("Debug Index Integer")]
    public int m_ii_index;
    public int m_ii_integer;
    [Header("Debug Integer")]
    public int m_i_integer;

    private void Reset()
    {
        m_root = transform;
    }
    public void Awake()
    {
        Refresh();
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        MonoBehaviour[] childrens = m_root.GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour child in childrens)
        {
           
                if (child is I_IID_TriggerFromIndexIntegerAndInteger)
                {
                    m_compatible.Add(child);
                }
            
        }
        m_compatible = m_compatible.Distinct().ToList();
        m_compatible.Remove(this);
    }

    public void TriggerFromIndexInteger(int index, int integer)
    {
        m_ii_index = index;
        m_ii_integer = integer;

        foreach (Component comp in m_compatible)
        {
            if (comp && comp is I_IID_TriggerFromIndexIntegerAndInteger)
            {
                (comp as I_IID_TriggerFromIndexIntegerAndInteger).TriggerFromIndexInteger(index, integer);
            }
        }
    }

    public void TriggerFromInteger(int index)
    {
        m_i_integer = 0;
        foreach (Component comp in m_compatible)
        {
            if (comp && comp is I_IID_TriggerFromIndexIntegerAndInteger)
            {
                (comp as I_IID_TriggerFromIndexIntegerAndInteger).TriggerFromInteger(index);
            }
        }
    }
}


























