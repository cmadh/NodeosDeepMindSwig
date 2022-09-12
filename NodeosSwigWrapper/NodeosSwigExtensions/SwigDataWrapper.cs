using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public partial class SwigDataWrapper
{
    /// <summary>
    /// implicit cast operator from SwigDataWrapper to Span<byte>
    /// </summary>
    /// <param name="swigDataWrapper"></param>
    public static implicit operator ReadOnlyMemory<byte>(SwigDataWrapper swigDataWrapper)
    {
        var buffer = new byte[swigDataWrapper.size];
        unsafe
        {
            fixed (byte* p = buffer)
            {
                var ptr = (IntPtr)p;
                // Copy unmanaged C++ owned memory to managed C# owned memory
                Buffer.MemoryCopy(SWIGTYPE_p_unsigned_char.getCPtr(swigDataWrapper.data).Handle.ToPointer(),
                    ptr.ToPointer(), swigDataWrapper.size, swigDataWrapper.size);
            }
        }

        return buffer;
    }
}
