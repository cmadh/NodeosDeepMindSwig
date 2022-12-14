//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.1
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public partial class StringVector : global::System.IDisposable, global::System.Collections.IEnumerable, global::System.Collections.Generic.IList<string>
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal StringVector(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(StringVector obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~StringVector() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NodeosSwigModulePINVOKE.delete_StringVector(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public StringVector(global::System.Collections.IEnumerable c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (string element in c) {
      this.Add(element);
    }
  }

  public StringVector(global::System.Collections.Generic.IEnumerable<string> c) : this() {
    if (c == null)
      throw new global::System.ArgumentNullException("c");
    foreach (string element in c) {
      this.Add(element);
    }
  }

  public bool IsFixedSize {
    get {
      return false;
    }
  }

  public bool IsReadOnly {
    get {
      return false;
    }
  }

  public string this[int index]  {
    get {
      return getitem(index);
    }
    set {
      setitem(index, value);
    }
  }

  public int Capacity {
    get {
      return (int)capacity();
    }
    set {
      if (value < size())
        throw new global::System.ArgumentOutOfRangeException("Capacity");
      reserve((uint)value);
    }
  }

  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsSynchronized {
    get {
      return false;
    }
  }

  public void CopyTo(string[] array)
  {
    CopyTo(0, array, 0, this.Count);
  }

  public void CopyTo(string[] array, int arrayIndex)
  {
    CopyTo(0, array, arrayIndex, this.Count);
  }

  public void CopyTo(int index, string[] array, int arrayIndex, int count)
  {
    if (array == null)
      throw new global::System.ArgumentNullException("array");
    if (index < 0)
      throw new global::System.ArgumentOutOfRangeException("index", "Value is less than zero");
    if (arrayIndex < 0)
      throw new global::System.ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
    if (count < 0)
      throw new global::System.ArgumentOutOfRangeException("count", "Value is less than zero");
    if (array.Rank > 1)
      throw new global::System.ArgumentException("Multi dimensional array.", "array");
    if (index+count > this.Count || arrayIndex+count > array.Length)
      throw new global::System.ArgumentException("Number of elements to copy is too large.");
    for (int i=0; i<count; i++)
      array.SetValue(getitemcopy(index+i), arrayIndex+i);
  }

  public string[] ToArray() {
    string[] array = new string[this.Count];
    this.CopyTo(array);
    return array;
  }

  global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator() {
    return new StringVectorEnumerator(this);
  }

  global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator() {
    return new StringVectorEnumerator(this);
  }

  public StringVectorEnumerator GetEnumerator() {
    return new StringVectorEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class StringVectorEnumerator : global::System.Collections.IEnumerator
    , global::System.Collections.Generic.IEnumerator<string>
  {
    private StringVector collectionRef;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public StringVectorEnumerator(StringVector collection) {
      collectionRef = collection;
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public string Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return (string)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object global::System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = collectionRef[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new global::System.InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
        currentIndex = -1;
        currentObject = null;
    }
  }

  public void Clear() {
    NodeosSwigModulePINVOKE.StringVector_Clear(swigCPtr);
  }

  public void Add(string x) {
    NodeosSwigModulePINVOKE.StringVector_Add(swigCPtr, x);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  private uint size() {
    uint ret = NodeosSwigModulePINVOKE.StringVector_Size(swigCPtr);
    return ret;
  }

  private uint capacity() {
    uint ret = NodeosSwigModulePINVOKE.StringVector_Capacity(swigCPtr);
    return ret;
  }

  private void reserve(uint n) {
    NodeosSwigModulePINVOKE.StringVector_Reserve(swigCPtr, n);
  }

  public StringVector() : this(NodeosSwigModulePINVOKE.new_StringVector__SWIG_0(), true) {
  }

  public StringVector(StringVector other) : this(NodeosSwigModulePINVOKE.new_StringVector__SWIG_1(StringVector.getCPtr(other)), true) {
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public StringVector(int capacity) : this(NodeosSwigModulePINVOKE.new_StringVector__SWIG_2(capacity), true) {
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  private string getitemcopy(int index) {
    string ret = NodeosSwigModulePINVOKE.StringVector_Getitemcopy(swigCPtr, index);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private string getitem(int index) {
    string ret = NodeosSwigModulePINVOKE.StringVector_Getitem(swigCPtr, index);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void setitem(int index, string val) {
    NodeosSwigModulePINVOKE.StringVector_Setitem(swigCPtr, index, val);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public void AddRange(StringVector values) {
    NodeosSwigModulePINVOKE.StringVector_AddRange(swigCPtr, StringVector.getCPtr(values));
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public StringVector GetRange(int index, int count) {
    global::System.IntPtr cPtr = NodeosSwigModulePINVOKE.StringVector_GetRange(swigCPtr, index, count);
    StringVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringVector(cPtr, true);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Insert(int index, string x) {
    NodeosSwigModulePINVOKE.StringVector_Insert(swigCPtr, index, x);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public void InsertRange(int index, StringVector values) {
    NodeosSwigModulePINVOKE.StringVector_InsertRange(swigCPtr, index, StringVector.getCPtr(values));
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveAt(int index) {
    NodeosSwigModulePINVOKE.StringVector_RemoveAt(swigCPtr, index);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveRange(int index, int count) {
    NodeosSwigModulePINVOKE.StringVector_RemoveRange(swigCPtr, index, count);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public static StringVector Repeat(string value, int count) {
    global::System.IntPtr cPtr = NodeosSwigModulePINVOKE.StringVector_Repeat(value, count);
    StringVector ret = (cPtr == global::System.IntPtr.Zero) ? null : new StringVector(cPtr, true);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reverse() {
    NodeosSwigModulePINVOKE.StringVector_Reverse__SWIG_0(swigCPtr);
  }

  public void Reverse(int index, int count) {
    NodeosSwigModulePINVOKE.StringVector_Reverse__SWIG_1(swigCPtr, index, count);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetRange(int index, StringVector values) {
    NodeosSwigModulePINVOKE.StringVector_SetRange(swigCPtr, index, StringVector.getCPtr(values));
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Contains(string value) {
    bool ret = NodeosSwigModulePINVOKE.StringVector_Contains(swigCPtr, value);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int IndexOf(string value) {
    int ret = NodeosSwigModulePINVOKE.StringVector_IndexOf(swigCPtr, value);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int LastIndexOf(string value) {
    int ret = NodeosSwigModulePINVOKE.StringVector_LastIndexOf(swigCPtr, value);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Remove(string value) {
    bool ret = NodeosSwigModulePINVOKE.StringVector_Remove(swigCPtr, value);
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}
