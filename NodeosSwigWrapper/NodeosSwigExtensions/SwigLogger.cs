using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeosSwigWrapper.NodeosSwigExtensions
{
    /// <summary>
    /// inherits and overrides SwigLoggerBase and it's virtual methods invoked by nodeos deep_mind_swig_hander
    /// implicitly casts SwigDataWrapper-Objects to byte[] while copying the memory used
    /// value-types are passed by value so no copy needed
    /// after calling SwigLogProcessor any memory is now managed by C# instead of C++
    /// </summary>
    public class SwigLogger : SwigLoggerBase
    {
        private SwigLogProcessor _swigLogProcessor;

        public SwigLogger(SwigLogProcessor swigLogProcessor) : base()
        {
            _swigLogProcessor = swigLogProcessor;
        }

        public override void OnDeepMindVersion(string name, uint major, uint minor)
        {
            Debug.WriteLine($"CSharp OnDeepMindVersion {name} {major} {minor}");
            _swigLogProcessor.OnDeepMindVersion(name, major, minor);
        }

        public override void OnAbidumpStart(uint block_num, ulong global_sequence_num)
        {
            Debug.WriteLine($"CSharp OnAbidumpStart {block_num} {global_sequence_num}");
            _swigLogProcessor.OnAbidumpStart(block_num, global_sequence_num);
        }

        public override void OnAbidumpAbi(ulong name, SwigDataWrapper abi_data)
        {
            Debug.WriteLine($"CSharp OnAbidumpStart {name} {abi_data.size} bytes");
            _swigLogProcessor.OnAbidumpAbi(name, abi_data);
        }

        public override void OnAbidumpEnd()
        {
            Debug.WriteLine($"CSharp OnAbidumpEnd");
            _swigLogProcessor.OnAbidumpEnd();
        }

        public override void OnStartBlock(uint start_block)
        {
            Debug.WriteLine($"CSharp OnStartBlock {start_block}");
            _swigLogProcessor.OnStartBlock(start_block);
        }

        public override void OnAcceptedBlock(uint num, SwigDataWrapper blk)
        {
            Debug.WriteLine($"CSharp OnAcceptedBlock {num} {blk.size}");
            _swigLogProcessor.OnAcceptedBlock(num, blk);
        }

        public override void OnSwitchForks(SwigDataWrapper from_id, SwigDataWrapper to_id)
        {
            _swigLogProcessor.OnSwitchForks(from_id, to_id);
        }

        public override void OnError(SwigDataWrapper id, SwigDataWrapper trx)
        {
            _swigLogProcessor.OnError(id, trx);
        }

        public override void OnOnblock(SwigDataWrapper id, SwigDataWrapper trx)
        {
            Debug.WriteLine($"CSharp OnOnblock {id} bytes {trx} bytes");
            _swigLogProcessor.OnOnblock(id, trx);
        }

        public override void OnAppliedTransaction(uint block_num, SwigDataWrapper traces)
        {
            Debug.WriteLine($"CSharp OnAppliedTransaction {block_num} {traces} bytes");
            _swigLogProcessor.OnAppliedTransaction(block_num, traces);
        }

        public override void OnAddRamCorrection(uint action_id, long correction_id, string event_id, ulong payer, ulong delta)
        {
            _swigLogProcessor.OnAddRamCorrection(action_id, correction_id, event_id, payer, delta);
        }

        public override void OnInputAction(uint action_id)
        {
            _swigLogProcessor.OnInputAction(action_id);
        }

        public override void OnRequireRecipient(uint action_id)
        {
            _swigLogProcessor.OnRequireRecipient(action_id);
        }

        public override void OnSendInline(uint action_id)
        {
            _swigLogProcessor.OnSendInline(action_id);
        }

        public override void OnSendContextFreeInline(uint action_id)
        {
            _swigLogProcessor.OnSendContextFreeInline(action_id);
        }

        public override void OnCancelDeferred(byte qual, uint action_id, ulong sender, SwigDataWrapper sender_id, ulong payer, uint published,
            uint delay, uint expiration, SwigDataWrapper trx_id, SwigDataWrapper trx)
        {
            _swigLogProcessor.OnCancelDeferred(qual, action_id, sender, sender_id, payer, published, delay, expiration, trx_id, trx);
        }

        public override void OnSendDeferred(byte qual, uint action_id, ulong sender, SwigDataWrapper sender_id, ulong payer, uint published,
            uint delay, uint expiration, SwigDataWrapper trx_id, SwigDataWrapper trx)
        {
            _swigLogProcessor.OnSendDeferred(qual, action_id, sender, sender_id, payer, published, delay, expiration, trx_id, trx);
        }

        public override void OnCreateDeferred(byte qual, uint action_id, ulong sender, SwigDataWrapper sender_id, ulong payer, uint published,
            uint delay, uint expiration, SwigDataWrapper trx_id, SwigDataWrapper trx)
        {
            _swigLogProcessor.OnCreateDeferred(qual, action_id, sender, sender_id, payer, published, delay, expiration, trx_id, trx);
        }

        public override void OnFailDeferred(uint action_id)
        {
            _swigLogProcessor.OnFailDeferred(action_id);
        }

        public override void OnCreateTable(uint action_id, ulong code, ulong scope, ulong table, ulong payer)
        {
            _swigLogProcessor.OnCreateTable(action_id, code, scope, table, payer);
        }

        public override void OnRemoveTable(uint action_id, ulong code, ulong scope, ulong table, ulong payer)
        {
            _swigLogProcessor.OnRemoveTable(action_id, code, scope, table, payer);
        }

        public override void OnDbStoreI64(uint action_id, ulong payer, ulong table_code, ulong scope, ulong table_name, ulong primkey,
            SwigDataWrapper ndata)
        {
            _swigLogProcessor.OnDbStoreI64(action_id, payer, table_code, scope, table_name, primkey, ndata);
        }

        public override void OnDbUpdateI64(uint action_id, ulong payer, ulong table_code, ulong scope, ulong table_name, ulong primkey,
            SwigDataWrapper odata, SwigDataWrapper ndata)
        {
            _swigLogProcessor.OnDbUpdateI64(action_id, payer, table_code, scope, table_name, primkey, odata, ndata);
        }

        public override void OnDbRemoveI64(uint action_id, ulong payer, ulong table_code, ulong scope, ulong table_name, ulong primkey,
            SwigDataWrapper odata)
        {
            _swigLogProcessor.OnDbRemoveI64(action_id, payer, table_code, scope, table_name, primkey, odata);
        }

        public override void OnRamEvent(uint action_id, string event_id, string family, string operation, string legacy_tag, ulong payer,
            ulong new_usage, long delta)
        {
            _swigLogProcessor.OnRamEvent(action_id, event_id, family, operation, legacy_tag, payer, new_usage, delta);
        }

        public override void OnCreatePermission(uint action_id, long permission_id, SwigDataWrapper data)
        {
            _swigLogProcessor.OnCreatePermission(action_id, permission_id, data);
        }

        public override void OnModifyPermission(uint action_id, long permission_id, SwigDataWrapper opdata, SwigDataWrapper npdata)
        {
            _swigLogProcessor.OnModifyPermission(action_id, permission_id, opdata, npdata);
        }

        public override void OnRemovePermission(uint action_id, long permission_id, SwigDataWrapper data)
        {
            _swigLogProcessor.OnRemovePermission(action_id, permission_id, data);
        }
    }

}
