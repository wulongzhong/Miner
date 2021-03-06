// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: UserverHeartBeat.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MsgPB {

  /// <summary>Holder for reflection information generated from UserverHeartBeat.proto</summary>
  public static partial class UserverHeartBeatReflection {

    #region Descriptor
    /// <summary>File descriptor for UserverHeartBeat.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UserverHeartBeatReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZVc2VydmVySGVhcnRCZWF0LnByb3RvEgVNc2dQQiI7ChZVc2VyU2VydmVy",
            "SGVhcnRCZWF0QzJTEhIKCm1fcGxheWVySWQYASABKA0SDQoFbV9rZXkYAiAB",
            "KAMiGAoWVXNlclNlcnZlckhlYXJ0QmVhdFMyQyI+ChtVc2VyU2VydmVyUm9v",
            "bUhlYXJ0QmVhdFJTMlMSEAoIbV9yb29tSUQYASABKA0SDQoFbV9rZXkYAiAB",
            "KAMiHQobVXNlclNlcnZlclJvb21IZWFydEJlYXRTMlJTYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.UserServerHeartBeatC2S), global::MsgPB.UserServerHeartBeatC2S.Parser, new[]{ "MPlayerId", "MKey" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.UserServerHeartBeatS2C), global::MsgPB.UserServerHeartBeatS2C.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.UserServerRoomHeartBeatRS2S), global::MsgPB.UserServerRoomHeartBeatRS2S.Parser, new[]{ "MRoomID", "MKey" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.UserServerRoomHeartBeatS2RS), global::MsgPB.UserServerRoomHeartBeatS2RS.Parser, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class UserServerHeartBeatC2S : pb::IMessage<UserServerHeartBeatC2S> {
    private static readonly pb::MessageParser<UserServerHeartBeatC2S> _parser = new pb::MessageParser<UserServerHeartBeatC2S>(() => new UserServerHeartBeatC2S());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserServerHeartBeatC2S> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.UserverHeartBeatReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerHeartBeatC2S() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerHeartBeatC2S(UserServerHeartBeatC2S other) : this() {
      mPlayerId_ = other.mPlayerId_;
      mKey_ = other.mKey_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerHeartBeatC2S Clone() {
      return new UserServerHeartBeatC2S(this);
    }

    /// <summary>Field number for the "m_playerId" field.</summary>
    public const int MPlayerIdFieldNumber = 1;
    private uint mPlayerId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint MPlayerId {
      get { return mPlayerId_; }
      set {
        mPlayerId_ = value;
      }
    }

    /// <summary>Field number for the "m_key" field.</summary>
    public const int MKeyFieldNumber = 2;
    private long mKey_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long MKey {
      get { return mKey_; }
      set {
        mKey_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UserServerHeartBeatC2S);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UserServerHeartBeatC2S other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MPlayerId != other.MPlayerId) return false;
      if (MKey != other.MKey) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MPlayerId != 0) hash ^= MPlayerId.GetHashCode();
      if (MKey != 0L) hash ^= MKey.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (MPlayerId != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(MPlayerId);
      }
      if (MKey != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(MKey);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MPlayerId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MPlayerId);
      }
      if (MKey != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(MKey);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UserServerHeartBeatC2S other) {
      if (other == null) {
        return;
      }
      if (other.MPlayerId != 0) {
        MPlayerId = other.MPlayerId;
      }
      if (other.MKey != 0L) {
        MKey = other.MKey;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            MPlayerId = input.ReadUInt32();
            break;
          }
          case 16: {
            MKey = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  public sealed partial class UserServerHeartBeatS2C : pb::IMessage<UserServerHeartBeatS2C> {
    private static readonly pb::MessageParser<UserServerHeartBeatS2C> _parser = new pb::MessageParser<UserServerHeartBeatS2C>(() => new UserServerHeartBeatS2C());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserServerHeartBeatS2C> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.UserverHeartBeatReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerHeartBeatS2C() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerHeartBeatS2C(UserServerHeartBeatS2C other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerHeartBeatS2C Clone() {
      return new UserServerHeartBeatS2C(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UserServerHeartBeatS2C);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UserServerHeartBeatS2C other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UserServerHeartBeatS2C other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class UserServerRoomHeartBeatRS2S : pb::IMessage<UserServerRoomHeartBeatRS2S> {
    private static readonly pb::MessageParser<UserServerRoomHeartBeatRS2S> _parser = new pb::MessageParser<UserServerRoomHeartBeatRS2S>(() => new UserServerRoomHeartBeatRS2S());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserServerRoomHeartBeatRS2S> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.UserverHeartBeatReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerRoomHeartBeatRS2S() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerRoomHeartBeatRS2S(UserServerRoomHeartBeatRS2S other) : this() {
      mRoomID_ = other.mRoomID_;
      mKey_ = other.mKey_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerRoomHeartBeatRS2S Clone() {
      return new UserServerRoomHeartBeatRS2S(this);
    }

    /// <summary>Field number for the "m_roomID" field.</summary>
    public const int MRoomIDFieldNumber = 1;
    private uint mRoomID_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint MRoomID {
      get { return mRoomID_; }
      set {
        mRoomID_ = value;
      }
    }

    /// <summary>Field number for the "m_key" field.</summary>
    public const int MKeyFieldNumber = 2;
    private long mKey_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long MKey {
      get { return mKey_; }
      set {
        mKey_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UserServerRoomHeartBeatRS2S);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UserServerRoomHeartBeatRS2S other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MRoomID != other.MRoomID) return false;
      if (MKey != other.MKey) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MRoomID != 0) hash ^= MRoomID.GetHashCode();
      if (MKey != 0L) hash ^= MKey.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (MRoomID != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(MRoomID);
      }
      if (MKey != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(MKey);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MRoomID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MRoomID);
      }
      if (MKey != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(MKey);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UserServerRoomHeartBeatRS2S other) {
      if (other == null) {
        return;
      }
      if (other.MRoomID != 0) {
        MRoomID = other.MRoomID;
      }
      if (other.MKey != 0L) {
        MKey = other.MKey;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            MRoomID = input.ReadUInt32();
            break;
          }
          case 16: {
            MKey = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  public sealed partial class UserServerRoomHeartBeatS2RS : pb::IMessage<UserServerRoomHeartBeatS2RS> {
    private static readonly pb::MessageParser<UserServerRoomHeartBeatS2RS> _parser = new pb::MessageParser<UserServerRoomHeartBeatS2RS>(() => new UserServerRoomHeartBeatS2RS());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserServerRoomHeartBeatS2RS> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.UserverHeartBeatReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerRoomHeartBeatS2RS() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerRoomHeartBeatS2RS(UserServerRoomHeartBeatS2RS other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserServerRoomHeartBeatS2RS Clone() {
      return new UserServerRoomHeartBeatS2RS(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UserServerRoomHeartBeatS2RS);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UserServerRoomHeartBeatS2RS other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UserServerRoomHeartBeatS2RS other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
