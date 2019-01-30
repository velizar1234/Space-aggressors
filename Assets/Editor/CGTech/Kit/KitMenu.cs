using Anglia.CGTech.CKit.Control;
using Anglia.CGTech.CKit.Conversion;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Effect;
using Anglia.CGTech.CKit.Events;
using Anglia.CGTech.CKit.Functions;
using Anglia.CGTech.CKit.Helper;
using Anglia.CGTech.CKit.Input;
using Anglia.CGTech.CKit.Maths;
using Anglia.CGTech.CKit.Output;
using Anglia.CGTech.CKit.Discovery;
using UnityEditor;
using UnityEngine;
using Anglia.CGTech.CKit.UI;

namespace Assets.Editor.CGTech.Kit
{
    //public class KitMenu : MonoBehaviour
    //{
       
    //    #region Control Functions
    //    [MenuItem(MN.If,priority = 1)]
    //    public static void MakeIfFunction()
    //    {
    //        NewGameObject<If>();
    //    }

    //    [MenuItem(MN.Merge)]
    //    public static void MakeMergeFunction()
    //    {
    //        NewGameObject<MergeControlPaths>();
    //    }

    //    [MenuItem(MN.Loop)]
    //    public static void MakeLoopFunction()
    //    {
    //        NewGameObject<Loop>();
    //    }





    //    #endregion

    //    #region Convert
    //    [MenuItem(MN.BoolToCommand)]
    //    public static void MakeBoolToEvent()
    //    {
    //        NewGameObject<BooleanToCommand>();
    //    }

    //    [MenuItem(MN.FloatToInt)]
    //    public static void MakeFloatToInteger()
    //    {
    //        NewGameObject<FloatToInt>();
    //    }

    //    [MenuItem(MN.FloatToColor)]
    //    public static void MakeFloatToColor()
    //    {
    //        NewGameObject<FloatToColor>();
    //    }

    //    [MenuItem(MN.IntToFloat)]
    //    public static void MakeIntToFloat()
    //    {
    //        NewGameObject<IntToFloat>();
    //    }
    //    #endregion

    //    #region Discovery
    //    [MenuItem(MN.GetPosition)]
    //    public static void MakeGetPosition()
    //    {
    //        NewGameObject<GetPosition>();
    //    }
    //    [MenuItem(MN.RayCast)]
    //    public static void MakeRayCast()
    //    {
    //        NewGameObject<RayCast>();
    //    }
    //    [MenuItem(MN.FIND_OBJECT)]
    //    public static void MakeFindObject()
    //    {
    //        NewGameObject<FindObjectByString>();
    //    }
    //    #endregion

    //    #region Effect Functions
    //    [MenuItem(MN.FN_CREATE_INSTANCE)]
    //    public static void MakeCreateInstance()
    //    {
    //        NewGameObject<CreateInstance>();
    //    }
    //    [MenuItem(MN.FN_DESTROY)]
    //    public static void MakeDestroyInstance()
    //    {
    //        NewGameObject<DestroyGameObject>();
    //    }
    //    [MenuItem(MN.SET_POSITION)]
    //    public static void MakeSetPosition()
    //    {
    //        NewGameObject<SetPosition>();
    //    }

    //    [MenuItem(MN.SET_ROTATION)]
    //    public static void MakeSetRotation()
    //    {
    //        NewGameObject<SetRotation>();
    //    }

    //    [MenuItem(MN.SET_SCALE)]
    //    public static void MakeSetScale()
    //    {
    //        NewGameObject<SetScale>();
    //    }

    //    [MenuItem(MN.DS_GOB_BOOL)]
    //    public static void MakeGob2Bool()
    //    {
    //        NewGameObject<GameObjectToBoolean>();
    //    }

    //    #endregion

    //    #region Events
    //    [MenuItem(MN.EachFrame)]
    //    public static void MakeEveryFrameEvent()
    //    {
    //        NewGameObject<FrameUpdate>();
    //    }

    //    [MenuItem(MN.EveryNTimes)]
    //    public static void MakeEveryNTimesEvent()
    //    {
    //        NewGameObject<EveryNTimes>();
    //    }

    //    [MenuItem(MN.Collision)]
    //    public static void MakeCollisionEvent()
    //    {
    //        NewGameObject<CollisionDetector>();
    //    }

    //    [MenuItem(MN.EventLink)]
    //    public static void MakeEventLink()
    //    {
    //        NewGameObject<EventLink>();
    //    }

    //    [MenuItem(MN.Timer)]
    //    public static void MakeTimer()
    //    {
    //        NewGameObject<Timer>();
    //    }

    //    [MenuItem(MN.Startup)]
    //    public static void MakeStartup()
    //    {
    //        NewGameObject<Loaded>();
    //    }

    //    [MenuItem(MN.CanvasButtonClick)]
    //    public static void MakeCanvasButtonInterface()
    //    {
    //        NewGameObject<InputCanvasButton>();
    //    }


    //    #endregion

    //    #region Input
    //    [MenuItem(MN.THIS_GAME_OBJECT)]
    //    public static void MakeGameObject()
    //    {
    //        NewGameObject<ThisGameObject>();
    //    }
    //    [MenuItem(MN.PARENT_GAME_OBJECT)]
    //    public static void MakeParentObject()
    //    {
    //        NewGameObject<ParentGameObject>();
    //    }
    //    [MenuItem(MN.ROOT_GAME_OBJECT)]
    //    public static void MakeRootObject()
    //    {
    //        NewGameObject<RootGameObject>();
    //    }
    //    #endregion

    //    #region Logic Functions
    //    [MenuItem(MN.BooleanLogic)]
    //    public static void MakeBooleanLogic()
    //    {
    //        NewGameObject<BooleanLogic>();
    //    }

    //    [MenuItem(MN.CompareIntegers)]
    //    public static void MakeCompareIntegers()
    //    {
    //        NewGameObject<CompareIntegers>();
    //    }


    //    [MenuItem(MN.ObExists)]
    //    public static void MakeObjectExists()
    //    {
    //        NewGameObject<ObjectExists>();
    //    }
    //    #endregion

    //    #region Output Functions
    //    [MenuItem(MN.SET_VALUE_VECTOR)]
    //    public static void MakeSetVector()
    //    {
    //        NewGameObject<SetValueOfVector>();
    //    }
    //     #endregion

    //    #region Maths
    //    [MenuItem(MN.ScaleVector)]
    //    public static void MakeScaleVector()
    //    {
    //        NewGameObject<ScaleVector>();
    //    }
    //    [MenuItem(MN.VectorAddition)]
    //    public static void MakeAddVector()
    //    {
    //        NewGameObject<VectorAddition>();
    //    }

    //    [MenuItem(MN.VECTOR_LERP)]
    //    public static void MakeLerpVector()
    //    {
    //        NewGameObject<VectorLerp>();
    //    }

    //    [MenuItem(MN.FN_ONE_OVER_N)]
    //    public static void MakeOneOverN()
    //    {
    //        NewGameObject<OneOverN>();
    //    }

    //    [MenuItem(MN.FN_SCALE_FLOAT)]
    //    public static void MakeScaleFloat()
    //    {
    //        NewGameObject<ScaleFloatingPoint>();
    //    }

    //    [MenuItem(MN.FN_ADD_INT)]
    //    public static void MakeAddInt()
    //    {
    //        NewGameObject<IntegerAddition>();
    //    }

    //    [MenuItem(MN.FN_ADD_FLOAT)]
    //    public static void MakeAddFloat()
    //    {
    //        NewGameObject<FloatAddition>();
    //    }

    //    [MenuItem(MN.FN_COMPARE_FLOAT)]
    //    public static void MakeCompareFloats()
    //    {
    //        NewGameObject<CompareFloats>();
    //    }

    //    [MenuItem(MN.FN_COMPARE_GOB)]
    //    public static void MakeCompareGobs()
    //    {
    //        NewGameObject<CompareGameObjects>();
    //    }

    //    [MenuItem(MN.FN_NEG_INT)]
    //    public static void MakeNegInt()
    //    {
    //        NewGameObject<NegativeInteger>();
    //    }
    //    #endregion

    //    #region UI
    //    [MenuItem(MN.FN_CONCAT_STRING)]
    //    public static void MakeConcatString()
    //    {
    //        NewGameObject<Concatenate>();
    //    }
    //    [MenuItem(MN.LOGIC_BLOCK)]
    //    public static void MakeLogicBlock()
    //    {
    //        NewGameObject<LogicBlock>();
    //    }
    //    #endregion

    //    #region Variables
    //    [MenuItem(MN.BooleanVariable)]
    //    public static void MakeBooleanVariable()
    //    {
    //        NewGameObject<BooleanVariable>();
    //    }

    //    [MenuItem(MN.FloatVariable)]
    //    public static void MakeFloatVariable()
    //    {
    //        NewGameObject<FloatVariable>();
    //    }

    //    [MenuItem(MN.IntegerVariable)]
    //    public static void MakeIntegerVariable()
    //    {
    //        NewGameObject<IntegerVariable>();
    //    }

    //    [MenuItem(MN.VectorVariable)]
    //    public static void MakeVectorVariable()
    //    {
    //        NewGameObject<VectorVariable>();
    //    }

    //    [MenuItem(MN.StringVariable)]
    //    public static void MakeStringVariable()
    //    {
    //        NewGameObject<StringVariable>();
    //    }

    //    [MenuItem(MN.ColorVariable)]
    //    public static void MakeColorVariable()
    //    {
    //        NewGameObject<ColorVariable>();
    //    }

    //    [MenuItem(MN.GameObjectVariable)]
    //    public static void MakeGameObjectVariable()
    //    {
    //        NewGameObject<GameObjectVariable>();
    //    }

    //    [MenuItem(MN.StoreBooleanVariable)]
    //    public static void MakeStoreBool()
    //    {
    //        NewGameObject<StoreBoolean>();
    //    }
    //    [MenuItem(MN.StoreIntegerVariable)]
    //    public static void MakeStoreInt()
    //    {
    //        NewGameObject<StoreInteger>();
    //    }
    //    #endregion


    //    /// <summary>
    //    /// Instantiate a new GameObject with a kit component of the requested type.
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    private static void NewGameObject<T>() where T : KitComponent
    //    {
    //        //bool selectionChangeOverride = Input.GetKey(KeyCode.LeftControl);
    //        GameObject parent = Selection.activeGameObject;
    //        GameObject ob = new GameObject();
    //        ob.name = "GameObject";
    //        if (parent != null)
    //        {
    //            ob.transform.parent = parent.transform;
    //        }
    //        ob.transform.localPosition = Vector3.zero;
    //        /*T component =*/ ob.AddComponent<T>();
    //        //if (!selectionChangeOverride)
    //        Selection.activeGameObject = ob;
    //    }
    //}
}
