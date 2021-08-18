using common;

namespace wServer.networking.packets.incoming
{
    public class ForgeItem : IncomingMessage
    {
        public int type { get; set; }
        public ObjectSlot slot1 { get; set; }
        public ObjectSlot slot2 { get; set; }
        public ObjectSlot slot3 { get; set; }
        public ObjectSlot slot4 { get; set; }
        public ObjectSlot slot5 { get; set; }
        public ObjectSlot slot6 { get; set; }
        public ObjectSlot slot7 { get; set; }
        public ObjectSlot slot8 { get; set; }
        public ObjectSlot slot9 { get; set; }

        public override PacketId ID => PacketId.FORGEITEM;
        public override Packet CreateInstance() { return new ForgeItem(); }

        protected override void Read(NReader rdr)
        {
            type = rdr.ReadInt32();
            slot1 = ObjectSlot.Read(rdr);
            slot2 = ObjectSlot.Read(rdr);
            slot3 = ObjectSlot.Read(rdr);
            slot4 = ObjectSlot.Read(rdr);
            slot5 = ObjectSlot.Read(rdr);
            slot6 = ObjectSlot.Read(rdr);
            slot7 = ObjectSlot.Read(rdr);
            slot8 = ObjectSlot.Read(rdr);
            slot9 = ObjectSlot.Read(rdr);
        }

        protected override void Write(NWriter wtr)
        {
            slot1.Write(wtr);
            slot2.Write(wtr);
            slot3.Write(wtr);
            slot4.Write(wtr);
            slot5.Write(wtr);
            slot6.Write(wtr);
            slot7.Write(wtr);
            slot8.Write(wtr);
            slot9.Write(wtr);
        }
    }
}
