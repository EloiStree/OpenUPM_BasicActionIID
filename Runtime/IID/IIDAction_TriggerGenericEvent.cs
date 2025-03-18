


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
/// <summary>
/// I am a class that contain generic data that can be push by receiving integer or index integer.
/// </summary>
/// <typeparam name="T"></typeparam>
[System.Serializable]
public class IIDAction_TriggerGenericEvent<T> : I_IID_TriggerFromIndexIntegerAndInteger
{
    public UnityEvent<T> m_onPush = new UnityEvent<T>();
    public List<STRUCT_IndexInt2Generic<T>> m_indexIntegerActions = new List<STRUCT_IndexInt2Generic<T>>();
    public List<STRUCT_Int2Generic<T>> m_anyIntegerActions = new List<STRUCT_Int2Generic<T>>();

    public void TriggerFromInteger(int index)
    {
        TriggerFromIndexInteger(0, index);
    }

    public void TriggerFromIndexInteger(int index, int integer)
    {
        if (m_indexIntegerActions!=null)
            foreach (STRUCT_IndexInt2Generic<T> action in m_indexIntegerActions)
            {
                if (action.m_index == index && action.m_integer == integer)
                {
                    if (m_onPush != null && action.m_data != null)
                        m_onPush.Invoke(action.m_data);
                }
            }
        if (m_anyIntegerActions != null)
            foreach (STRUCT_Int2Generic<T> action in m_anyIntegerActions)
            {
                if (action.m_integer == integer)
                {
                    if (m_onPush != null && action.m_data!=null)
                        m_onPush.Invoke(action.m_data);
                }
            }
    }

    public void TriggerFromIID(STRUCT_IndexIntegerDate iid)
    {
        TriggerFromIID(iid);
    }
    public void TriggerFromIID(STRUCT_ReceivedIID iid)
    {
        TriggerFromIID(iid);
    }
    public void TriggerFromIID(I_IID_IndexIntegerDateGet iid)
    {
        if (iid == null) return;
        TriggerFromIndexInteger(iid.GetIndex(), iid.GetInteger());
    }
    public void TriggerFromIID(I_IID_IndexIntegerGet iid)
    {
        if (iid == null) return;
        TriggerFromIndexInteger(iid.GetIndex(), iid.GetInteger());
    }
    public void TriggerFromIID(I_IID_IntegerGet iid)
    {
        if (iid == null) return;
        TriggerFromInteger(iid.GetInteger());
    }

    public void Clear()
    {
        m_indexIntegerActions.Clear();
        m_anyIntegerActions.Clear();
    }
    

    public void AppendValue(int index, T value)
    {
        STRUCT_Int2Generic<T> s = new STRUCT_Int2Generic<T>();
        s.m_integer = index;
        s.m_data = value;
        m_anyIntegerActions.Add(s);
    }

    public void AppendValue(int index, int integer, T value)
    {
        STRUCT_IndexInt2Generic<T> s = new STRUCT_IndexInt2Generic<T>();
        s.m_index = index;
        s.m_integer = integer;
        s.m_data = value;
        m_indexIntegerActions.Add(s);
    }


    public void DistinctIntegerInAnyList()
    {
        m_anyIntegerActions = m_anyIntegerActions
            .GroupBy(s => s.m_integer ) // Group by the integer
            .Select(g => g.First())   // Select the first item from each group
            .ToList();                // Convert the result back to a list
   
        m_indexIntegerActions = m_indexIntegerActions
            .GroupBy(s => new { s.m_index, s.m_integer }) // Group by both index and integer
            .Select(g => g.First())                      // Select the first item from each group
            .ToList();                                   // Convert the result back to a list
    }


}


























