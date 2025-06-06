﻿[System.Serializable]
public class IndexInt2Generic<T>: I_IID_IndexIntegerGetSet, I_IID_DataHolderGetSet<T>
{
    public T m_data;
    public int m_index;
    public int m_integer;

    public void GetIndex(out int index) => index = m_index;
    public int GetIndex() { return m_index; }

    public void GetInteger(out int value) => value = m_integer;
    public int GetInteger() { return m_integer; }

    public void GetData(out T data) => data = m_data;
    public T GetData() { return m_data; }

    public void SetData(T data) => m_data = data;
    public void SetIndex(int index) => m_index = index;
    public void SetInteger(int value) => m_integer = value;
}


























