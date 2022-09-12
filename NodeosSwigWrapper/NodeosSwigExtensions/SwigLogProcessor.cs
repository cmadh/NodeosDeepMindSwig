using System.Collections.Concurrent;
using System.Xml.Linq;

namespace NodeosSwigWrapper.NodeosSwigExtensions
{
    public class SwigLogProcessor
    {
        public enum ET : byte
        {
            DeepMindVersion,
            AbidumpStart,
            AbidumpAbi,
            AbidumpEnd,
            StartBlock,
            AcceptedBlock,
            SwitchForks,
            Error,
            OnBlock,
            AppliedTransaction,
            AddRamCorrection,
            InputAction,
            RequireRecipiend,
            SendInline,
            ContextFreeInline,
            CancelDeferred,
            SendDeferred,
            CreateDeferred,
            FailDeferred,
            CreateTable,
            RemoveTable,
            DbStoreI64,
            DbUpdateI64,
            DbRemoveI64,
            RamEvent,
            CreatePermission,
            ModifyPermission,
            RemovePermission
        }

        public class DeepMindEvent
        {

            public ET EventType;
            public object EventData;

            public DeepMindEvent(ET eventType, object eventData)
            {
                EventData = eventData;
                EventType = eventType;
            }
        }

        ConcurrentQueue<DeepMindEvent> _queue = new();

        public void OnDeepMindVersion(string name, uint major, uint minor)
        {
            _queue.Enqueue(new DeepMindEvent(ET.DeepMindVersion, new DeepMindVersion(name, major, minor)));
        }

        public void OnAbidumpStart(uint blockNum, ulong globalSequenceNum)
        {
            _queue.Enqueue(new DeepMindEvent(ET.AbidumpStart, new AbidumpStart(blockNum, globalSequenceNum)));
        }

        public void OnAbidumpAbi(ulong name, ReadOnlyMemory<byte> abiData)
        {
            _queue.Enqueue(new DeepMindEvent(ET.AbidumpAbi, new AbidumpAbi(name, abiData)));
        }

        public void OnAbidumpEnd()
        {
            _queue.Enqueue(new DeepMindEvent(ET.AbidumpEnd, new AbidumpEnd()));
        }

        public void OnStartBlock(uint startBlock)
        {
            _queue.Enqueue(new DeepMindEvent(ET.StartBlock, new StartBlock(startBlock)));
        }

        public void OnAcceptedBlock(uint num, ReadOnlyMemory<byte> blk)
        {
            _queue.Enqueue(new DeepMindEvent(ET.AcceptedBlock, new AcceptedBlock(num, blk)));
        }

        public void OnSwitchForks(ReadOnlyMemory<byte> fromId, ReadOnlyMemory<byte> toId)
        {
            _queue.Enqueue(new DeepMindEvent(ET.SwitchForks, new SwitchForks(fromId, toId)));
        }

        public void OnError(ReadOnlyMemory<byte> id, ReadOnlyMemory<byte> trx)
        {
            _queue.Enqueue(new DeepMindEvent(ET.Error, new Error(id, trx)));
        }

        public void OnOnblock(ReadOnlyMemory<byte> id, ReadOnlyMemory<byte> trx)
        {
            _queue.Enqueue(new DeepMindEvent(ET.OnBlock, new OnBlock(id, trx)));
        }

        public void OnAppliedTransaction(uint blockNum, ReadOnlyMemory<byte> traces)
        {
            _queue.Enqueue(new DeepMindEvent(ET.AppliedTransaction, new AppliedTransaction(blockNum, traces)));
        }

        public void OnAddRamCorrection(uint actionId, long correctionId, string eventId, ulong payer, ulong delta)
        {
            _queue.Enqueue(new DeepMindEvent(ET.AddRamCorrection, new AddRamCorrection(actionId, correctionId, eventId, payer, delta)));
        }

        public void OnInputAction(uint actionId)
        {
            _queue.Enqueue(new DeepMindEvent(ET.InputAction, new InputAction(actionId)));
        }

        public void OnRequireRecipient(uint actionId)
        {
            _queue.Enqueue(new DeepMindEvent(ET.RequireRecipiend, new RequireRecipiend(actionId)));
        }

        public void OnSendInline(uint actionId)
        {
            _queue.Enqueue(new DeepMindEvent(ET.SendInline, new SendInline(actionId)));
        }

        public void OnSendContextFreeInline(uint actionId)
        {
            _queue.Enqueue(new DeepMindEvent(ET.ContextFreeInline, new ContextFreeInline(actionId)));
        }

        public void OnCancelDeferred(byte qual, uint actionId, ulong sender, ReadOnlyMemory<byte> senderId, ulong payer, uint published,
            uint delay, uint expiration, ReadOnlyMemory<byte> trxId, ReadOnlyMemory<byte> trx)
        {
            _queue.Enqueue(new DeepMindEvent(ET.CancelDeferred, new CancelDeferred(qual, actionId, sender, senderId, payer, published, delay, expiration, trxId, trx)));
        }

        public void OnSendDeferred(byte qual, uint actionId, ulong sender, ReadOnlyMemory<byte> senderId, ulong payer, uint published,
            uint delay, uint expiration, ReadOnlyMemory<byte> trxId, ReadOnlyMemory<byte> trx)
        {
            _queue.Enqueue(new DeepMindEvent(ET.SendDeferred, new SendDeferred(qual, actionId, sender, senderId, payer, published, delay, expiration, trxId, trxId)));
        }

        public void OnCreateDeferred(byte qual, uint actionId, ulong sender, ReadOnlyMemory<byte> senderId, ulong payer, uint published,
            uint delay, uint expiration, ReadOnlyMemory<byte> trxId, ReadOnlyMemory<byte> trx)
        {
            _queue.Enqueue(new DeepMindEvent(ET.CreateDeferred, new CreateDeferred(qual, actionId, senderId, senderId, payer, published, delay, expiration, trxId, trx)));
        }

        public void OnFailDeferred(uint actionId)
        {
            _queue.Enqueue(new DeepMindEvent(ET.FailDeferred, new FailDeferred(actionId)));
        }

        public void OnCreateTable(uint actionId, ulong code, ulong scope, ulong table, ulong payer)
        {
            _queue.Enqueue(new DeepMindEvent(ET.CreateTable, new CreateTable(actionId, code, scope, table, payer)));
        }

        public void OnRemoveTable(uint actionId, ulong code, ulong scope, ulong table, ulong payer)
        {
            _queue.Enqueue(new DeepMindEvent(ET.RemoveTable, new RemoveTable(actionId, code, scope, table, payer)));
        }

        public void OnDbStoreI64(uint actionId, ulong payer, ulong tableCode, ulong scope, ulong tableName, ulong primkey,
            ReadOnlyMemory<byte> ndata)
        {
            _queue.Enqueue(new DeepMindEvent(ET.DbStoreI64, new DbStoreI64(actionId, payer, tableCode, scope, tableName, primkey)));
        }

        public void OnDbUpdateI64(uint actionId, ulong payer, ulong tableCode, ulong scope, ulong tableName, ulong primkey,
            ReadOnlyMemory<byte> odata, ReadOnlyMemory<byte> ndata)
        {
            _queue.Enqueue(new DeepMindEvent(ET.DbUpdateI64, new DbUpdateI64(actionId, payer, tableCode, scope, tableName, primkey, odata, ndata)));
        }

        public void OnDbRemoveI64(uint actionId, ulong payer, ulong tableCode, ulong scope, ulong tableName, ulong primkey,
            ReadOnlyMemory<byte> odata)
        {
            _queue.Enqueue(new DeepMindEvent(ET.DbRemoveI64, new DbRemoveI64(actionId, payer, tableCode, scope, tableName, primkey)));
        }

        public void OnRamEvent(uint actionId, string eventId, string family, string operation, string legacyTag, ulong payer,
            ulong newUsage, long delta)
        {
            _queue.Enqueue(new DeepMindEvent(ET.RamEvent, new RamEvent(actionId, eventId, family, operation, legacyTag, payer, newUsage, delta)));
        }

        public void OnCreatePermission(uint actionId, long permissionId, ReadOnlyMemory<byte> data)
        {
            _queue.Enqueue(new DeepMindEvent(ET.CreatePermission, new CreatePermission(actionId, permissionId, data)));
        }

        public void OnModifyPermission(uint actionId, long permissionId, ReadOnlyMemory<byte> opdata, ReadOnlyMemory<byte> npdata)
        {
            _queue.Enqueue(new DeepMindEvent(ET.ModifyPermission, new ModifyPermission(actionId, permissionId, opdata, npdata)));
        }

        public void OnRemovePermission(uint actionId, long permissionId, ReadOnlyMemory<byte> data)
        {
            _queue.Enqueue(new DeepMindEvent(ET.RemovePermission, new RemovePermission(actionId, permissionId, data)));
        }
    }

    public record DbStoreI64(uint ActionId, ulong Payer, ulong TableCode, ulong Scope, ulong TableName, ulong Primkey);

    public record RemoveTable(uint ActionId, ulong Code, ulong Scope, ulong Table, ulong Payer);

    public record CreateTable(uint ActionId, ulong Code, ulong Scope, ulong Table, ulong Payer);

    public record FailDeferred(uint ActionId);

    public record CreateDeferred(byte Qual, uint ActionId, ReadOnlyMemory<byte> SenderId, ReadOnlyMemory<byte> Bytes, ulong Payer, uint Published, uint Delay, uint Expiration, ReadOnlyMemory<byte> TrxId, ReadOnlyMemory<byte> Trx);

    public record SendDeferred(byte Qual, uint ActionId, ulong Sender, ReadOnlyMemory<byte> SenderId, ulong Payer, uint Published, uint Delay, uint Expiration, ReadOnlyMemory<byte> TrxId, ReadOnlyMemory<byte> Bytes);

    public record CancelDeferred(byte Qual, uint ActionId, ulong Sender, ReadOnlyMemory<byte> SenderId, ulong Payer, uint Published, uint Delay, uint Expiration, ReadOnlyMemory<byte> TrxId, ReadOnlyMemory<byte> Trx);

    public record ContextFreeInline(uint ActionId);

    public record RequireRecipiend(uint ActionId);

    public record SendInline(uint ActionId);

    public record InputAction(uint ActionId);

    public record AddRamCorrection(uint ActionId, long CorrectionId, string EventId, ulong Payer, ulong Delta);

    public record AppliedTransaction(uint BlockNum, ReadOnlyMemory<byte> Traces);

    public record OnBlock(ReadOnlyMemory<byte> Id, ReadOnlyMemory<byte> Trx);

    public record Error(ReadOnlyMemory<byte> Id, ReadOnlyMemory<byte> Trx);

    public record SwitchForks(ReadOnlyMemory<byte> FromId, ReadOnlyMemory<byte> ToId);

    public record DbUpdateI64(uint ActionId, ulong Payer, ulong TableCode, ulong Scope, ulong TableName, ulong Primkey, ReadOnlyMemory<byte> Odata, ReadOnlyMemory<byte> Ndata);

    public record DbRemoveI64(uint ActionId, ulong Payer, ulong TableCode, ulong Scope, ulong TableName, ulong Primkey);

    public record RemovePermission(uint ActionId, long PermissionId, ReadOnlyMemory<byte> Data);

    public record ModifyPermission(uint ActionId, long PermissionId, ReadOnlyMemory<byte> Opdata, ReadOnlyMemory<byte> Npdata);

    public record RamEvent(uint ActionId, string EventId, string Family, string Operation, string LegacyTag, ulong Payer, ulong NewUsage, long Delta);

    public record CreatePermission(uint ActionId, long PermissionId, ReadOnlyMemory<byte> Data);

    public record AcceptedBlock(uint Num, ReadOnlyMemory<byte> Blk);

    public record StartBlock(uint U);

    public record AbidumpEnd;

    public record AbidumpAbi(ulong Name, ReadOnlyMemory<byte> AbiData);

    public record AbidumpStart(uint BlockNum, ulong GlobalSequenceNum);

    public record DeepMindVersion(string Name, uint Major, uint Minor);
}