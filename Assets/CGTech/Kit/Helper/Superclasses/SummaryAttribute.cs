using System;

namespace Anglia.CGTech.CKit.Helper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SummaryAttribute : Attribute
    {
        private string m_summary;

        public string Summary
        {
            get
            {
                return m_summary;
            }

            set
            {
                m_summary = value;
            }
        }

        public SummaryAttribute(string summaryText)
        {
            m_summary = summaryText;
        }

        public string LookUpCode()
        {
            return ("SUM_");
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public abstract class CKitFieldAttribute : Attribute
    {
        private string m_linkName = "m_currentValue";
        public string LinkName
        {
            get
            {
                return m_linkName;
            }

            set
            {
                m_linkName = value;
            }
        }

        private string m_tooltip;
        private Required m_optionStatus;


        public Required OptionStatus
        {
            get
            {
                return m_optionStatus;
            }

            set
            {
                m_optionStatus = value;
            }
        }

        public string Tooltip
        {
            get
            {
                return m_tooltip;
            }

            set
            {
                m_tooltip = value;
            }
        }

        public abstract string LookUpCode();



        public CKitFieldAttribute(Required optional, string tooltip)
        {
            m_tooltip = tooltip;

            m_optionStatus = optional;
        }

        public CKitFieldAttribute(string tooltip)
        {
            m_tooltip = tooltip;
            m_optionStatus = Required.Optional;
        }

        public CKitFieldAttribute() : base()
        {
        }
    }

    public class InputAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "IN_";
        }

        private Type m_matchingType = typeof(object);

        public Type MatchingType
        {
            get
            {
                return m_matchingType;
            }


        }



        public InputAttribute(Required optional, string tooltip)
            : base(optional, tooltip)
        {
        }

        public InputAttribute(string tooltip)
            : base(tooltip)
        {
        }

        public InputAttribute(string tooltip, Type matchingType) : base(tooltip)
        {
            m_matchingType = matchingType;

        }

        public InputAttribute() : base()
        {

        }

    }

    public class PrefabAttribute : InputAttribute
    {
        public PrefabAttribute(string tooltip) : base(tooltip) { }
    }

    public class DynamicInputAttribute : InputAttribute
    {
        int m_codeNumber = 0;
        public DynamicInputAttribute(string tooltip, int code) : base(tooltip)
        {
            m_codeNumber = code;
        }

        public int CodeNumber
        {
            get
            {
                return m_codeNumber;
            }


        }
    }

    public class OptionAttribute : InputAttribute
    {
        int m_codeNumber = 0;
        public OptionAttribute(string tooltip, int code) : base(tooltip)
        {
            m_codeNumber = code;
        }

        public int CodeNumber
        {
            get
            {
                return m_codeNumber;
            }

        }
    }

    public class SelectionAttribute : IgnoreAttribute
    {
        int m_codeNumber = 0;
        public SelectionAttribute(int code) : base()
        {
            m_codeNumber = code;
        }

        public int CodeNumber
        {
            get
            {
                return m_codeNumber;
            }
        }
    }

    public class CommandAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "CMD_";
        }

        public CommandAttribute()
            : base(TT.EV_CMD)
        {
        }
    }

    public class SettingAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "SET_";
        }

        public SettingAttribute(Required optional, string tooltip)
            : base(optional, tooltip)
        {
        }

        public SettingAttribute(string tooltip)
            : base(tooltip)
        {
        }

        public SettingAttribute() : base() { }
    }

    public class OutputAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "OUT_";
        }

        public OutputAttribute(Required optional, string tooltip)
            : base(optional, tooltip)
        {
        }

        public OutputAttribute(string tooltip)
            : base(tooltip)
        {
        }

        public OutputAttribute() : base()
        {
        }
    }

    /// <summary>
    /// Mark a field to be ignored by the Kit custom inspector builder.
    /// A field without an attribute will trigger a warning as it may be missing one by accident.
    /// </summary>
    public class IgnoreAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "IGN_";
        }
        public IgnoreAttribute() : base("") { }
    }

    public class AffectsAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "AFF_";
        }

        private Type m_type;

        public Type MatchingType
        {
            get
            {
                return m_type;
            }
        }

        public AffectsAttribute(Required optional, string tooltip)
            : base(optional, tooltip)
        {
        }

        public AffectsAttribute(string tooltip)
            : base(tooltip)
        {
        }

        public AffectsAttribute(string tooltip, Type type)
            : base(tooltip)
        {
            this.m_type = type;
        }
    }

    public class DebugAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "DBG_";
        }

        public DebugAttribute(Required optional, string tooltip)
            : base(optional, tooltip)
        {
        }

        public DebugAttribute(string tooltip)
            : base(tooltip)
        {
        }
    }

    public class DeprecatedAttribute : SummaryAttribute
    {
        public DeprecatedAttribute(Type type) : base("DEPRECATED component: use " + type.Name)
        {

        }
    }

    public class MessageAttribute : CKitFieldAttribute
    {
        public override string LookUpCode()
        {
            return "MSG_";
        }

        public MessageAttribute()
            : base(Required.Optional, "")
        {
        }
    }

    public enum Required
    {
        Optional,
        Maybe,
        Compulsory
    }
}
