using Anglia.CGTech.CKit.Data;
using UnityEngine;

namespace Anglia.CGTech.CKit.Helper.Superclasses
{
    public class AdditionComponent<T,J>  : FunctionKitComponent where T: GenericDataSource<J>
    {
        [Input(TT.IN_ADD_ARR)]
        [SerializeField]
        protected T[] Sources ;

        [SerializeField]
        [Output]
        protected J m_currentValue = default(J);

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            m_currentValue = Calculate();
            SendCommandSignal();
        }

        protected J Calculate()
        {
            J result = default(J) ;
            for (int i = 0; i < Sources.Length; i++)
            {
                if (Sources[i] != null)
                {
                    
                    result =  Sources[i].Add(result);
                }
            }
            m_currentValue = result;
            return result;
        }
    }
}
