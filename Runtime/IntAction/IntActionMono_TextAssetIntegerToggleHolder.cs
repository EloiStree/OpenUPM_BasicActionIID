using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
namespace Eloi.IntAction
{
    public interface I_ContainsCollectionOfIntegerActionId
    {
        public void GetIntActionIdCollection(out IEnumerable<IntActionId> integerActionIdList);
        public void SetIntActionIdCollection(IEnumerable<IntActionId> integerActionIdList);
        public void SetIntActionIdCollectionWithParams(params IntActionId[] integerActionIdList);
        public void SetIntActionIdCollectionWithParams(params int[] integerActionIdList);
    }
    public interface I_ContainsOneIntegerActionId { 
    
        public void GetIntActionId(out IntActionId integerActionId);
        public void SetIntActionId(IntActionId integerActionId);
        public void SetIntActionId(int integerActionId);
    }

    public interface I_ContainsTogglePairOfIntegerActionId {

        public void GetIntActionIdTrue(out IntActionId integerActionId);
        public void GetIntActionIdFalse(out IntActionId integerActionId);
        public void SetIntActionIdTrue(IntActionId integerActionId);
        public void SetIntActionIdFalse(IntActionId integerActionId);
        public void SetIntActionIdTrue(int integerActionId);
        public void SetIntActionIdFalse(int integerActionId);
    }






    /// <summary>
    /// Lot of code need to store a toggle value true/on and false/off 
    /// </summary>
    public class IntActionMono_TextAssetIntegerToggleHolder : MonoBehaviour
    {

        [Tooltip("Will auto fill MonoBehaviour with I_ContainsTogglePairOfIntegerActionId")]
        public GameObject[] m_targetsToAutoFill;
        public UnityEvent<int> m_onIntegerActionTrueLoaded;
        public UnityEvent<int> m_onIntegerActionFalseLoaded;

        public IntAction_TextAssetIntegerHolder m_actionAsIntegerTrue;
        public IntAction_TextAssetIntegerHolder m_actionAsIntegerFalse;
        public bool m_pushIntegerAtAwake = true;

        [ContextMenu("Push integer action")]
        public void PushIntegerActions()
        {
            LoadValueAndDescription();
            if (m_actionAsIntegerTrue != null)
            {
                m_actionAsIntegerTrue.GetAsInt(out int valueIsTrue);
                m_onIntegerActionTrueLoaded?.Invoke(valueIsTrue);
            }
            if (m_actionAsIntegerFalse != null)
            {
                m_actionAsIntegerFalse.GetAsInt(out int valueIsFalse);
                m_onIntegerActionFalseLoaded?.Invoke(valueIsFalse);
            }

            if (m_targetsToAutoFill != null)
            {
                //For every target
                foreach (GameObject target in m_targetsToAutoFill)
                {
                    //For every MonoBehaviour except this one
                    foreach (var component in target.GetComponents<MonoBehaviour>())
                    {
                        if (component == this) continue;
                        if (component is I_ContainsTogglePairOfIntegerActionId integerActionId)
                        {
                            integerActionId.SetIntActionIdTrue(m_actionAsIntegerTrue.GetAsIntActionId());
                            integerActionId.SetIntActionIdFalse(m_actionAsIntegerFalse.GetAsIntActionId());
                        }
                    }
                }
            }


        }

        public void Reset()
        {
            m_targetsToAutoFill = new GameObject[] { this.gameObject };
        }

        [ContextMenu("Load Value and description")]
        public void LoadValueAndDescription()
        {

            if (m_actionAsIntegerTrue != null)
            {
                m_actionAsIntegerTrue.LoadValueAndDescription();
            }
            if (m_actionAsIntegerFalse != null)
            {
                m_actionAsIntegerFalse.LoadValueAndDescription();
            }
        }
        public void Awake()
        {
            if (m_pushIntegerAtAwake)
            {
                PushIntegerActions();
            }
        }
    }
}