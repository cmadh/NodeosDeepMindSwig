//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.1
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public partial class NodeosSwig : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal NodeosSwig(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NodeosSwig obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~NodeosSwig() {
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
          NodeosSwigModulePINVOKE.delete_NodeosSwig(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public int Start(int argc, StringVector argv, SwigLoggerBase swig_logger) {
    int ret = NodeosSwigModulePINVOKE.NodeosSwig_Start(swigCPtr, argc, StringVector.getCPtr(argv), SwigLoggerBase.getCPtr(swig_logger));
    if (NodeosSwigModulePINVOKE.SWIGPendingException.Pending) throw NodeosSwigModulePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public NodeosSwig() : this(NodeosSwigModulePINVOKE.new_NodeosSwig(), true) {
  }

}
