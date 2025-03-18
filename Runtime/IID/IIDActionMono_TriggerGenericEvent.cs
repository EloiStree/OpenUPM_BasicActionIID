


using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// I am a class that contain generic data that can be push by receiving integer or index integer.
/// </summary>
/// <typeparam name="T"></typeparam>
public class IIDActionMono_TriggerGenericEvent<T> : MonoBehaviour , I_IID_TriggerFromIndexIntegerAndInteger
{
    public IIDAction_TriggerGenericEvent<T> m_iidToActions;

    public void TriggerFromInteger(int index)
    {
        m_iidToActions.TriggerFromInteger(index);
    }
    public void TriggerFromIndexInteger(int index, int integer)
    {
        m_iidToActions.TriggerFromIndexInteger(index, integer);
    }
    public void TriggerFromIID(STRUCT_ReceivedIID iid)
    {
        m_iidToActions.TriggerFromIID(iid);
    }
    public void TriggerFromIID(STRUCT_IndexIntegerDate iid)
    {
        m_iidToActions.TriggerFromIID(iid);
    }
    public void TriggerFromIID(I_IID_IndexIntegerDateGet iid)
    {
        m_iidToActions.TriggerFromIID(iid);
    }
    public void TriggerFromIID(I_IID_IndexIntegerGet iid)
    {
        m_iidToActions.TriggerFromIID(iid);
    }
    public void TriggerFromIID(I_IID_IntegerGet iid)
    {
        m_iidToActions.TriggerFromIID(iid);
    }

    public void AppendValue(int index, int integer, T value)
    {
        m_iidToActions.AppendValue(index, integer, value);
    }
    public void AppendValue(int index, T value)
    {
        m_iidToActions.AppendValue(index, value);
    }

    [ContextMenu("Distinct Any Integer List")]
    public void DistinctIntegerInAnyList()
    {
        m_iidToActions.DistinctIntegerInAnyList();
    }
}


























