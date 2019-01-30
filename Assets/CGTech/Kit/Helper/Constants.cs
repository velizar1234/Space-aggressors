using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anglia.CGTech.CKit.Helper
{
    /// <summary>
    /// Static class defining Menu path constants
    /// </summary>
    public static class MN
    {
        private const string CK = "Construction Kit/";
        public const string VAR = CK + "Variable/";
        public const string BooleanVariable = VAR + "Boolean";
        public const string IntegerVariable = VAR + "Integer";
        public const string FloatVariable = VAR + "Float";
        public const string VectorVariable = VAR + "Vector";
        public const string StringVariable = VAR + "String";
        public const string ColorVariable = VAR + "Color";
        public const string GameObjectVariable = VAR + "GameObject";
        public const string RigidbodyVariable = VAR + "RigidBody";

        public const string STOR = VAR + "Store/";
        public const string STORE_BOOL_VARIABLE = STOR + "Boolean";
        public const string StoreIntegerVariable = STOR + "Integer";
        public const string STORE_FLOAT_VARIABLE = STOR + "Float";
        public const string StoreVectorVariable = STOR + "Vector";
        public const string StoreStringVariable = STOR + "String";
        public const string StoreColorVariable = STOR + "Color";
        public const string StoreGameObjectVariable = STOR + "GameObject";

        public const string EV = CK + "Event/";
        public const string EachFrame = EV + "Frame Update";
        public const string EveryNTimes = EV + "Every N Times";
        public const string Collision = EV + "Collision";
        public const string EventLink = EV + "Link";
        public const string Timer = EV + "Timer";
        public const string Startup = EV + "Start";
        public const string CanvasButtonClick = EV + "Canvas Button Click";
        public const string FixedUpdate = EV + "Physics Update";

        public const string CTRL = CK + "Control Function/";
        public const string If = CTRL + "If";
        public const string Merge = CTRL + "Merge";
        public const string Loop = CTRL + "Loop";

        public const string LOGIC = CK + "Logic/";
        public const string COMP = LOGIC + "Compare/";
        public const string BooleanLogic = LOGIC + "Boolean Logic (And-Or-Not)";
        public const string CompareIntegers = COMP + "Integers";
        public const string ObExists = LOGIC + "Object Exists";
        public const string FN_COMPARE_FLOAT = COMP + "Floats";
        public const string FN_COMPARE_GOB = COMP + "GameObjects";
        public const string FN_COMPARE_STR = COMP + "Strings";

        public const string CONV = CK + "Convert/";
        public const string FloatToInt = CONV + "Float to Integer";
        public const string FloatToColor = CONV + "Float to Color";
        public const string IntToFloat = CONV + "Integer to Float";
        public const string BoolToCommand = CONV + "Boolean to Event";
        public const string VectorToFloat = CONV + "Vector to Float";

        public const string MATH = CK + "Math/";
        public const string ScaleVector = MATH + "Scale (multiply) a Vector";
        public const string VectorAddition = MATH + "Vector Addition";
        public const string VECTOR_LERP = MATH + "Vector Lerp";
        public const string FN_ONE_OVER_N = MATH + "1 over n";
        public const string FN_SCALE_FLOAT = MATH + "Scale (multiply) floats";
        public const string FN_ADD_FLOAT = MATH + "Add floats together";
        public const string FN_ADD_INT = MATH + "Add integers together";
        public const string FN_NEG_INT = MATH + "Negate Integer";

        public const string DISC = CK + "Discover/";
        public const string GetPosition = DISC + "Position";
        public const string RayCast = DISC + "Ray Cast";
        public const string FIND_OBJECT = DISC + "Find Object";
        public const string DS_GOB_BOOL = DISC + "Find Boolean";
        public const string DS_GOB_INT = DISC + "Find Integer Value";
        public const string DS_GOB_RB = DISC + "Find Rigidbody";

        public const string INP = CK + "Input/";
        public const string THIS_GAME_OBJECT = INP + "[Import] Game Object";
        public const string PARENT_GAME_OBJECT = INP + "[Import] Parent Game Object";
        public const string ROOT_GAME_OBJECT = INP + "[Import] Root Game Object";

        public const string EFF = CK + "Effect/";
        public const string SET_POSITION = EFF + "Set Position";
        public const string SET_ROTATION = EFF + "Set Rotation";
        public const string SET_SCALE = EFF + "Set Scale";
        public const string FN_CREATE_INSTANCE = EFF + "Create Instance";
        public const string FN_DESTROY = EFF + "Destroy Object";

        public const string OUT = CK + "Output/";
        public const string SET_VALUE_VECTOR = OUT + "Set Value of Vector";

        public const string UI = CK + "UI/";
        public const string FN_CONCAT_STRING = UI + "Concatenate Strings";
        public const string LOGIC_BLOCK = UI + "Logic Block";

        public const string HELP = CK + "Helper/";
        public const string COMMENT = HELP + "Comment";
    }

    /// <summary>
    /// Static class defining Warning Message constants
    /// </summary>
    public static class WM
    {
        #region Warning Messages

        public const string IN_NULL = "One or more inputs to {0} on {1} need to be set.";
        public const string IN_NO_TGT_FOUND = "Unable to locate target for {0} on {1}";
        public const string IN_NO_SRC_FOUND = "No matching output on {0} for {1} on {2} ({3} expected).";
        public const string IN_FN_SOURCE_CLASH = "Function source overrides variable source on StoreInteger";
        public const string BOOL_MODE_UNSUPPORTED = "Unsupported Boolean Mode {0} in InitialisationTrigger on {1}";
        public const string MODE_UNSUPPORTED = "Unsupported Mode {0} in {1} on {2}";
        public const string DEPRECATED = "The {0} component has been superceded by {1}, please change to use this new class.";
        public const string DUMMY_TEXT = "This text should not be visible.";
        public const string NO_SUMMARY = "No SummaryAttribute found on type: {0}";
        public const string NO_ATTRIBUTE = "No Attribute found on field {0} type: {1}";
        public const string NO_OVERRIDE = "No Override for {0} found on field {1} type: {2}";
        public const string ATTACH_MODE_UNSUPPORTED = "Unsupported Attachment Mode {0} in {1} on {2}";
        public const string DIVIDE_BY_ZERO = "An attempt was made to divide by zero in {0} on {1}";
        public const string DUAL_INPUT = "Variable both a target of a function and given a source (Use one only).\nSource will be overridden.";
        public const string TAR_MISSING_COMPONENT = "Target Location (Game Object) does not contain a component of the expected type\n{0}";
        public const string TAR_FIND_UNDER = "Looking for target in {0}.";
        public const string TAR_TARGET_FOUND = "Target found on {0}.";
        #endregion
    }

    /// <summary>
    /// Static class defining Heading/Summary constants
    /// </summary>
    public static class HD
    {
        #region Component Summary
        public const string COMMENT = "Developer comment, for information only";
        public const string FN_BLOCK = "Re-usable Function Block";
        public const string STARTUP = "Event fires when this object starts working (level load or instantiation).";
        public const string LINK = "A linking object mainly used for layout purposes.";
        public const string IF = "Branches to one or other section of code depending on a boolean value.";
        public const string MERGE = "End a branching section of code by linking all event paths to this component.";
        public const string STORE_GOB = "Saves the value of a game object to a variable.";
        public const string STORE_STR = "Saves the value of a string to a variable.";
        public const string STORE_INT = "Saves the value of an integer to a variable.";
        public const string STORE_FLOAT = "Saves the value of a float to a variable.";
        public const string STORE_BOOL = "Saves the value of a Boolean to a variable.";
        public const string STORE_VEC = "Saves the value of a vector to a variable.";
        public const string EV_EACH_FRAME = "Sends a Command Signal each frame of the game.";
        public const string EV_EACH_FIXED = "Sends a Command Signal each physics step of the game.";
        public const string FN_FRAME_COUNTER = "Counts incoming events and fires onwards after a set number.";
        public const string FN_NORM_VEC = "Normalises a source vector to a length of 1.";
        public const string BOOL_STORE = "Stores and outputs a Boolean (True/False) value.";
        public const string FLOAT_STORE = "Stores and outputs a Floating Point (single precision decimal, eg 3.1412) value.";
        public const string GOB_STORE = "Stores and outputs a Game Object (e.g. from ExtractGameObject).";
        public const string INT_STORE = "Stores and outputs an Integer (whole number, eg 3) value.";
        public const string INT_RESULT = "Retrieves an Integer Result from a function";
        public const string STR_STORE = "Stores and outputs a String (text) value.";
        public const string VC2_STORE = "Stores and outputs a Vector (2D, xy) value.";
        public const string VC3_STORE = "Stores and outputs a Vector (3D, xy) value.";
        public const string VARIABLE = "\nSource should be [None] if this is a target of a Store X function.";
        public const string VC2_VAR = "Stores and outputs a Vector (2D, xy) value.";
        public const string RB2_VAR = "Stores and outputs a RigidBody2D value.";
        public const string RAY_VAR = "Stores and outputs a 2D Ray (origin & direction) value.";
        public const string GOS_2_VEC = "Retrieves a vector from a Game Object source.";
        public const string BOOL_2_SIGNAL = "Converts a boolean value (or changes) into a Command Signal.";
        public const string BOOL_2_TRG = "Converts changes in a boolean value to a boolean that can be used as a trigger.";
        public const string FLOAT_2_INT = "Converts a float value into an integer.";
        public const string INT_2_FLOAT = "Converts an integer value into a float.";
        public const string FLOAT_2_VEC = "Converts two float values into a vector.";
        public const string GOB_2_GOS = "Converts a GameObject to a GameObjectSource for use in Kit processes.";
        public const string RAYCAST = "Fires an infinite Ray into the scene to see what 2D colliders are in the way.";
        public const string TIMER = "Counts time when active until a duration is reached, outputs true when this occurs.";
        public const string TIMER_ELAPSED = "Companion component to Timer.  Output value is the elapsed time as a Float.";
        public const string FN_BOOL = "Combines multiple Boolean values according to the selected binary operation.";
        public const string FN_COMPARE = "Compares two input values according to the operation requested";
        public const string FN_EQUAL = "Compares two input values returning true if they are equal";
        public const string FN_OBJEXIST = "Returns true if the input source has a reference to a Game Object";
        public const string FN_CLAMP = "Returns the value of the source restricted to be above the lower boundary and below the upper boundary values";
        public const string FN_ADD = "Adds together the value of all inputs";
        public const string FN_SCALE_VC2 = "Scales (multiplies) a 2D Vector by a float";
        public const string FN_SCALE_FLOAT = "Scales (multiplies) two or more floats together (e.g. A x B x C)";
        public const string FN_ONE_OVER_N = "Inverts (1/input) the input value.  Use with ScaleFloat to do division";
        public const string FN_NEG_FLOAT = "Returns the negative (input x -1) value of the input.  Use with FloatAddition for subtraction";
        public const string FN_LERP_COL = "Interpolates (LERPs) between three color values.  A built in timer animates the transition.";
        public const string FN_LERP_VEC = "Interpolates (LERPs) between two vectors.";
        public const string FN_CONCAT_STR = "Concatenate several strings together into one";
        public const string EXT_GOB_2_INT = "The value of the integer store (if any) on the game object identified by the source.";
        public const string EXT_GOB_2_RB = "A reference to the Rigidbody2D (if any) on the game object identified by the source.";
        public const string EXT_GOB_2_BOOL = "The value of the Boolean store (if any) on the game object identified by the source.";
        public const string GOB_2_STR = "Converts a GameObject to one of it's string values";
        public const string SET_VALUE = "Selects between the default and 'if true' values based on boolean source connected";
        public const string EF_SET_VEL = "Sets the velocity of a Rigidbody2D";
        public const string EF_SET_POS = "Sets the position of a GameObject";
        public const string EF_SET_COLOR = "Sets the colour of a target component";
        public const string EF_SET_SCL = "Sets the scale of a GameObject's transform";
        public const string EF_SET_TAG = "Sets the tag property of a GameObject to a given string";
        public const string EF_POINT = "Calculates the Angle around the z-axis to point the affected object at the target";
        public const string EF_LOAD_SCENE = "Loads a different scene into the game when triggered.";
        public const string LOOP = "Repeats a process counting up from one number to another.";
        public const string ITER_TRG = "Returns true each time the attached Loop counts up.";
        public const string ARR_LENGTH = "Companion component. Returns the length of the array store on the same GameObject.";
        public const string ARR_GOB = "List (array) of game object references.";
        public const string INIT_TRG = "A trigger value (boolean) indicating when the object is first created or run.";
        public const string INP_BUTTON = "Returns true when a specified button press is detected.";
        public const string INP_CANV_BTN = "A component that can be triggered from the Canvas Interface (Usually a button).\n"
                                           + "Link the OnClick() event on the button to OnClick() method of this component.";
        public const string INP_AXIS = "Looks up the value of a specified axis (between -1 and 1)";
        public const string DET_COLL = "Detects a collision between this object and another. Output is the other GameObject in the collision.";
        public const string FRAME_TIME = "Returns the duration of the previous frame in seconds.";
        public const string BUFF_INT = "Outputs the value of an integer source, delayed by one frame.";
        public const string BUFF_FLOAT = "Outputs the value of a float source, delayed by one frame.";
        public const string BUFF_BOOL = "Outputs the value of a Boolean source, delayed by one frame.";
        public const string BUFF_STRING = "Outputs the value of a string source, delayed by one frame.";
        public const string BUFF_GOB = "Outputs the value of a GameObject source, delayed by one frame.";
        public const string GOB_FROM_ARR = "Returns an element of a GameObjectArray, as specified by an index value.";
        public const string EFF_ROTATION = "Sets the rotation of a target object.";
        public const string EFF_CREATE = "Spawns an instance of a prefab or other game object.";
        public const string FN_TRANS_2_VEC = "Extract a vector from a transform.";
        public const string FN_FIND_OBJ_WNAME = "Attempts to locate an object at runtime by name, and outputs a reference to that object.";
        public const string MOUSE_LOCATION = "Returns the location of the mouse in the game world as a vector.";
        public const string RANDOM = "Creates a random number between 0 and 1";
        public const string DESTROY = "Deletes a specified Game Object and children from the world.";
        public const string MOVE_KINEM = "Moves a Game Object in a direction and speed specified, continuously.";
        public const string PLAY_ANIM = "Plays the animation in an Animation component when triggered.";
        public const string PLAY_SOUND = "Plays the sound in an Audio Source component when triggered.";
        public const string PLAY_PARTICLE = "Plays the Particle Effect in a Particle System component when triggered.";
        public const string DISP_FLOAT = "Displays the value of a float on a Canvas (GUI) Text component.";
        public const string DISP_FLOAT_FILL = "Displays the value of a float setting the fill property of a Filled Sprite";
        public const string DISP_INT = "Displays the value of an integer on a Canvas (GUI) Text component.";
        public const string DISP_IMAGE = "Controls the visibility of a Canvas (GUI) Image component.";
        public const string DISP_TEXT = "Controls the visibility of a Canvas (GUI) Text component.";
        public const string DISP_OBJECT = "Controls the Active status of a GameObject.";
        public const string FN_INT_DIV = "Performs integer division and can return either the result or the remainder.";
        public const string FN_RESET_GRID = "Adjusts a vector to the nearest position on a rectangular grid";
        public const string COL_STORE = "Stores and outputs a Color Value (RGBA)";
        public const string FN_FLOAT_2_COL = "Converts four floating point values to a colour (as HSVA)";
        public const string LOGIC_BLOCK = "Design-time element to draw a container around related child objects.";
        public const string GET_VEL = "Gets the velocity of a 2D Rigidbody";
        public const string FN_SIN = "The trigonometric Sine function.";
        public const string FN_COS = "The trigonometric Cosine function.";
        public const string FN_TAN = "The trigonometric Tangent function.";
        public const string FN_ASIN = "The trigonometric Inverse Sine function.";
        public const string FN_ACOS = "The trigonometric Inverse Cosine function.";
        public const string FN_ATAN = "The trigonometric Inverse Tangent function.";

        public const string EF_END = "Stops execution of the program.\nThis only works in compiled versions.";
        public const string FN_NEG_INT = "Return the negative value of an integer (1 => -1)";
        #endregion
    }

    /// <summary>
    /// Static class defining Construction Kit Structure constants
    /// </summary>
    public static class CS
    {
        public const string INPUTS = "Inputs";
        public const string INPUT = "Input";
        public const string OUTPUT = "Output";
        public const string SETTING = "Settings";
        public const string DEFAULT = "Unclassified";
        public const string TIMING = "Timing";
        public const string GRID_SIZE = "CKitGridSize";

        #region Tips

        public const string TIP_SCALE_MOTION = "Useful for scaling calculations of motion.";
        public const string LAT_SPREAD = "Lateral Spread";


        #endregion

        public static string FillValues(string message, params string[] args)
        {
            string result = message;
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    result = result.Replace("{" + i + "}", args[i]);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Static class defining ToolTip message constants
    /// </summary>
    public static class TT
    {
        // New Tooltip Constant Format Rules
        // GROUP_TYPE_NAME
        // Where GROUP in [IN, OUT, AFF, EV, ST, GEN]
        //       TYPE in [INT, FLOAT, VEC, BOOL, GOB, KIT, STR, GEN]
        #region Input Tooltips
        public const string COMMENT = "Comment text";
        public const string IN_KIT_FUNC = "Function component as a source for this value";
        public const string EV_CMD = "The command signal for this component";
        public const string IN_STR_SCENE = "The name of the scene to load.  This scene must be included in the build settings.";
        public const string IN_BOOL_ADDITIVE = "Whether the scene should be loaded without unloading the current scene.";
        public const string IN_FLOAT_DEG = "The input angle in Degrees.";
        public const string IN_BOOL = "A Boolean source value which can be used to trigger further decisions or actions";
        public const string IN_BOOL_NEW = "A Boolean source value which when true causes a new random number to be created";
        public const string IN_BOOL_ARR = "A list of input values to combine by the selected operation.  Only the first will be used for NOT.";
        public const string IN_BOOL_INC = "If [None], The loop will run automatically.  If linked, counting up happens each time the value is true.";
        public const string IN_BOOL_SWI = "A Boolean source value to switch between the default and new values";
        public const string IN_BOOL_ONOFF = "A Boolean source value used to switch on (true) or off (false)";
        public const string IN_BOOL_SET = "When this source is present and true, the output value will update to the source value (if present)";
        public const string IN_INT_COUNT = "The number to count up to";
        public const string IN_COL = "The color to use for this.";
        public const string IN_COL1 = "The color to use at the start of the lerp";
        public const string IN_COL2 = "The color to use at mid-point of the lerp";
        public const string IN_COL3 = "The color to use at the end of the lerp";
        public const string IN_FACTOR = "A float value between 0 and 1 as a factor (f) for the process";
        public const string IN_VEC0 = "The vector to use at the start of the lerp (f=0)";
        public const string IN_VEC1 = "The vector to use at the end of the lerp (f=1)";
        public const string IN_VEC_RAY = "A vector source specifying the length and direction of the ray";
        public const string IN_RAY = "A ray value specifying the origin and direction of the ray";
        public const string IN_TGT_CAM = "The camera to calculate the mouse position from.";
        public const string ST_CURSOR_LOCK = "Set to prevent cursor leaving game window in compiled versions";
        public const string IN_BOOL_DEST = "If set and true, triggers the destruction of the target object.";
        public const string IN_TRG_PLAY = "When true, triggers the target effect to play.";
        public const string IN_TGT_COMP = "The target component to be affected.";
        public const string IN_FILL_MAX = "The value that should correspond to 100% filled on the Sprite.";
        public const string IN_SPC_X = "The size of the grid in the x-direction";
        public const string IN_SPC_Y = "The size of the grid in the y-direction";

        #endregion

        #region Setting Tooltips

        public const string ST_IGN_AT_START = "Whether the Source value should be ignored on the first frame.";
        public const string ST_LERP_SPEED = "";
        public const string ST_STR_NAME = "The name (case sensitive) of the object to be located at run-time.";
        public const string ST_UNSMOOTH = "Tick to use unsmoothed input values";
        public const string ST_DELAY = "Time in seconds to wait before the effect happens.";
        public const string ST_FORMAT_CODE = "Code to be applied to format the output of the conversion ToString()";
        public const string ST_INT_DIV_MODE = "Which result of integer division should be output.";
        public const string ST_ALLOW_CHANGE = "Set to true to allow changes to the input value to be updated to the target.";
        public const string ST_GIZMO_DRAW = "Draw mode to use for Gizmo elements";
        public const string ST_GIZMO_HIDE = "Hide gizmo elements";
        public const string ST_COLOR = "Color to apply to the target element.";
        public const string ST_RESET_PHYS = "Set true to reset the physics of the object being positioned.";

        #endregion

        #region General ToolTips

        public const string NEWLINE = "\n";
        public const string DEBUG = "**Note: Property visible for debugging purposes only.**";
        public const string VERSION = "The current version number of the Construction Kit";
        public const string VER_RECT = "The rectangle to display the version number on the screen.";
        public const string IN_STORE_SOURCE = "If left as [None], the store will always have the Current Value set.  If linked, the value of the source will be held in this component.";
        public const string IN_COMP_SOURCE = "The source component for the process.";
        public const string OUT_CURRENT_VAL = "The value currently being output by this component";
        public const string SIGN_VALUE = "Sign of the input value";
        public const string VAR_SIGNAL = "Command signal used to set the current value to the value of Source (Continuous update if [None])";
        public const string IN_GEN_OPTION_A = "\n[Choose one source option]";
        #endregion

        #region Output Tooltips
        public const string TODO = "[Placeholder] This tooltip needs to be written";
        public const string AFF_TGT_LOC = "A value identifying a game object containing the variable to be updated.";
        public const string AFF_INT_VAR = "The integer variable in which to store the value";
        public const string AFF_FLOAT_VAR = "The float variable in which to store the value";
        public const string IN_STR_ARR_TAG = "A list of tags to filter by. A zero length list will return any object hit";
        public const string IN_TAG_STR = "A string source specifying the tag to apply.  This value must match a previously created tag in the engine.";
        public const string IN_ACT_BOOL = "If present (not [None]) the process will only run whilst the value of this object is true";
        public const string IN_TRG_BOOL = "If present (not [None]) the process will only run once the value of this object is true";
        public const string IN_RST_BOOL = "If left as [None], the process will not reset. If linked the process will reset when the input value is true.";
        public const string IN_FLOAT = "A floating point value as input to the operation.";
        public const string IN_FLOAT_DUR = "The time, in seconds, to complete the component's cycle.";
        public const string IN_FLOAT_ROTX = "Optional parameter for rotation around X axis (0 if [none])";
        public const string IN_FLOAT_ROTY = "Optional parameter for rotation around Y axis (0 if [none])";
        public const string IN_FLOAT_ROTZ = "Optional parameter for rotation around Z axis (0 if [none])";
        public const string IN_FLOAT_X = "The value for the X co-ordinate of the output vector.";
        public const string IN_FLOAT_Y = "The value for the Y co-ordinate of the output vector.";
        public const string IN_FLOAT_HUE = "The value for the Hue of the output color (0-1).";
        public const string IN_FLOAT_SAT = "The value for the Saturation of the output color (0-1).";
        public const string IN_FLOAT_VAL = "The value for the Value of the output color (0-1).";
        public const string IN_FLOAT_ALPHA = "The value for the Alpha (transparency) of the output color (0-1).";

        public const string IN_GOS_ROOT = "If set, restricts to search within the children of the object specified.";

        public const string ELAPSED = "The current elapsed time.";


        public const string IN_GOB_ARR = "An array of GameObject values to select from.";
        public const string IN_GOB_AFF = "The GameObject to be affected.";
        public const string IN_INT = "An integer value as input to the operation.";
        public const string IN_INT_NUM = "An integer value for the number to be divided.";
        public const string IN_INT_DIV = "An integer value to divide the other input by.";
        public const string IN_INDEX = "An integer value for the index of the desired element.";
        public const string IN_STR = "A string value as input to the operation.";
        public const string IN_VEC = "A vector value as input to the operation.";
        public const string IN_VEC_VEL = "A vector value for the velocity.  A change in this value will update the motion";
        public const string DEF_VAL = "The default output value.";
        public const string IFF_VAL = "The output value if the boolean input is true.";
        public const string COMP_THRE = "How close do the input values have to be to count as equal.";
        public const string COMP_MODE = "What comparison should result in an output value of true.";
        public const string LOGIC_MODE = "Which logical operation is performed on the inputs.";
        public const string LOGIC_MODE_1 = "\n[And]\tReturns true if all input values are true";
        public const string LOGIC_MODE_2 = "\n[Or]\tReturns true if any input value is true";
        public const string LOGIC_MODE_3 = "\n[Xor]\tReturns true if only one input value is true";
        public const string LOGIC_MODE_4 = "\n[Not]\tReturns the opposite of the first input value";

        public const string BOOL_MODE = "How will the input value be processed to give the output";
        public const string BOOL_MODE_1 = "\n[OnTrue]\tOutput is true only as the input changes to true.";
        public const string BOOL_MODE_2 = "\n[Continuous]Output is true when the input is true.";
        public const string BOOL_MODE_3 = "\n[OnFalse]\tOutput is true only as the input changes to false.";
        public const string BOOL_MODE_4 = "\n[Once]\tOutput is true when the input is true.  The output remains true even if the input changes.";
        public const string BOOL_MODE_5 = "\n[Inverted]\tOutput is false when the input is true and vice versa. ";

        public const string EFF_GOS = "A source identifying the game object to be affected.";

        public const string AXIS_MODE = "Which dimension should be used for the comparison. Other differences will be ignored.";

        public const string TRANS_EXT_MODE = "Which vector will be extracted from the target.";

        public const string ATTACH_MODE = "Which GameObject should be used as the input.";
        public const string ATTACH_MODE_1 = "\n[Target] mode uses the object linked to the Target property";
        public const string ATTACH_MODE_2 = "\n[Parent] mode uses the parent of this object";
        public const string ATTACH_MODE_3 = "\n[This] mode uses the GameObject the component is attached to";
        public const string ATTACH_MODE_4 = "\n[Root] mode uses the top-most parent object to which this one is connected";

        public const string IN_GOS = "A Game Object source (Kit component) which may or may not contain a reference to a GameObject.";
        public const string TGT_GOS = "A Game Object source (Kit component) identifying the game object to be processed";
        public const string TGT_GOB = "The game object to be processed";
        public const string TGT_RB2 = "The RigidBody2D to be affected";

        public const string IN_PREFAB = "The prefab to be spawned.";
        public const string IN_INT_COPIES = "The number of copies to create. 1 if [None].";
        public const string TGT_SPRITE = "The target sprite for the change in color.";
        public const string MODE_F2I = "How the input is rounded to a whole number.";
        public const string BOUND_UP = "The upper bound for the value.";
        public const string BOUND_LOW = "The lower bound for the value.";
        public const string IN_ADD_ARR = "A list of input values to be added together.";
        public const string IN_SCALE_ARR = "A list of input values to be multiplied together.";
        public const string VEC_NORM = "Should the output vector be normalised (length = 1).";
        public const string MODE_STR = "The choice of string value to be returned.";
        public const string IN_INT_FROM = "The integer value (number) to start counting from.";
        public const string IN_INT_TO = "The integer value (number) to count up to.";
        public const string IN_LOOP = "The Loop component to be monitored";
        public const string AXIS_NAME = "The name (case sensitive) of the button axis in the Input Manager to monitor.";
        public const string IN_VEC_LOC = "The location to spawn the new object at.";
        public const string IN_TRG = "Triggers the spawning of the new object(s)";
        public const string IN_COMP_MODE = "The comparison applied to the input values to result in the output value being true.";

        #endregion
    }

    /// <summary>
    /// Static class defining Information Message constants
    /// </summary>
    public class IM
    {
        public const string CONST_MODE = "Value is a constant.";
        public const string CONT_MODE = "Continuously updating to input(s).";
        public const string VAR_MODE = "Operating as a variable.";
        public const string VAR_MODE_UPDATE = "Operating as a variable. Updating Now.";
    }

    public enum GizmoDrawFrame
    {
        Undefined = 0,
        Wireframe,
        Solid
    }



}

