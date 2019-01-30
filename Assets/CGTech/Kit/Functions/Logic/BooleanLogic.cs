using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.BooleanLogic)]
    [Summary(HD.FN_BOOL)]
    public class BooleanLogic : BooleanValue
    {
        [SerializeField]
        [Setting(TT.LOGIC_MODE + TT.LOGIC_MODE_1 + TT.LOGIC_MODE_2 + TT.LOGIC_MODE_3 + TT.LOGIC_MODE_4)]
        private BooleanLogicMode m_logicMode = BooleanLogicMode.And;
        [SerializeField]
        [Input(TT.IN_BOOL_ARR)]
        protected BooleanValue[] m_sources;



        public override bool Fetch()
        {

            m_currentValue = false;
            if (m_sources.Length > 0)
            {
                bool result = false;
                bool firstValueSet = false;
                for (int i = 0; i < m_sources.Length; i++)
                {
                    GenericDataSource<bool> currentSource = m_sources[i];
                    if (currentSource != null)
                    {
                        bool currentValue = currentSource.Fetch();
                        if (firstValueSet)
                        {
                            switch (m_logicMode)
                            {
                                case BooleanLogicMode.And:
                                    result = result & currentValue;
                                    break;
                                case BooleanLogicMode.Or:
                                    result = result | currentValue;
                                    break;
                                case BooleanLogicMode.Xor:
                                    result = result ^ currentValue;
                                    break;
                            }
                        }
                        else
                        {
                            firstValueSet = true;
                            if (m_logicMode == BooleanLogicMode.Not)
                            {
                                result = !currentValue;
                            }
                            else
                            {
                                result = currentValue;
                            }
                        }
                    }
                }
                m_currentValue = result;


            }
            return m_currentValue;
        }


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessPassive;
            }
        }


    }
}
