// Either.cs

using System;
using System.Runtime.InteropServices;

namespace Foundations.Geometry
{
    [StructLayout(LayoutKind.Explicit)]
    public struct StringOrInt32
    {
        public static readonly StringOrInt32 Undefined = default;

        [FieldOffset(0)]
        private readonly int which;

        [FieldOffset(sizeof(int))]
        private readonly String _String;

        public bool IsString => which == 1;

        public String AsString => which == 1 ? _String : throw new InvalidOperationException();

        public StringOrInt32(String value)
        {
            _Int32 = default;
            _String = value;
            which = 1;
        }

        [FieldOffset(sizeof(int))]
        private readonly Int32 _Int32;

        public bool IsInt32 => which == 2;

        public Int32 AsInt32 => which == 2 ? _Int32 : throw new InvalidOperationException();

        public StringOrInt32(Int32 value)
        {
            _String = default;
            _Int32 = value;
            which = 2;
        }
    
        public bool IsUndefined => which == 0;

        public override string ToString()
        {
            switch (which)
            {
                default:
                    return "undefined";

                case 1:
                    return _String.ToString();

                case 2:
                    return _Int32.ToString();
            }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DoubleOrSingleOrDateTime
    {
        public static readonly DoubleOrSingleOrDateTime Undefined = default;

        [FieldOffset(0)]
        private readonly int which;

        [FieldOffset(sizeof(int))]
        private readonly Double _Double;

        public bool IsDouble => which == 1;

        public Double AsDouble => which == 1 ? _Double : throw new InvalidOperationException();

        public DoubleOrSingleOrDateTime(Double value)
        {
            _Single = default;
            _DateTime = default;
            _Double = value;
            which = 1;
        }

        [FieldOffset(sizeof(int))]
        private readonly Single _Single;

        public bool IsSingle => which == 2;

        public Single AsSingle => which == 2 ? _Single : throw new InvalidOperationException();

        public DoubleOrSingleOrDateTime(Single value)
        {
            _Double = default;
            _DateTime = default;
            _Single = value;
            which = 2;
        }

        [FieldOffset(sizeof(int))]
        private readonly DateTime _DateTime;

        public bool IsDateTime => which == 3;

        public DateTime AsDateTime => which == 3 ? _DateTime : throw new InvalidOperationException();

        public DoubleOrSingleOrDateTime(DateTime value)
        {
            _Double = default;
            _Single = default;
            _DateTime = value;
            which = 3;
        }
    
        public bool IsUndefined => which == 0;

        public override string ToString()
        {
            switch (which)
            {
                default:
                    return "undefined";

                case 1:
                    return _Double.ToString();

                case 2:
                    return _Single.ToString();

                case 3:
                    return _DateTime.ToString();
            }
        }
    }

}
