namespace Anglia.CGTech.CKit.Helper
{


    public enum BooleanBehaviour
    {
        Undefined = 0,
        OnTrue,
        Continuous,
        OnFalse,
        Once,
        Inverted
    }

    public enum BooleanLogicMode
    {
        Undefined = 0,
        And,
        Or,
        Xor,
        Not
    }

    public enum GameObjectKeyString
    {
        Undefined = 0,
        Tag,
        Name
    }

    public enum AxesOfComparison
    {
        Undefined = 0,
        X,
        Y,
        Distance
    }

    public enum FloatIntConversion
    {
        Undefined = 0,
        Floor,
        Ceiling,
        Round
    }

    public enum IntegerDivisionMode
    {
        Undefined = 0,
        Division,
        Remainder
    }

    public enum Comparisons
    {
        Undefined = 0,
        ALessThanB,
        AGreaterThanB,
        AEqualsB,
        AApproximatelyB
    }

    public enum AttachmentMode
    {
        Undefined = 0,
        This,
        Target,
        Parent,
        Root
    }

    
}
