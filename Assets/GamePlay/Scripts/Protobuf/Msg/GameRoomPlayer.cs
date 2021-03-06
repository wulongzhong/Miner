// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GameRoomPlayer.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MsgPB {

  /// <summary>Holder for reflection information generated from GameRoomPlayer.proto</summary>
  public static partial class GameRoomPlayerReflection {

    #region Descriptor
    /// <summary>File descriptor for GameRoomPlayer.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GameRoomPlayerReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRHYW1lUm9vbVBsYXllci5wcm90bxIFTXNnUEIiUAoSR2FtZVJvb21QbGF5",
            "ZXJJbmZvEhIKCm1fcGxheWVySWQYASABKA0SDgoGbV9uYW1lGAIgASgJEhYK",
            "Dm1fYm9keVZpZXdEYXRhGAMgASgFImEKFkdhbWVSb29tUGxheWVyTG9naW5D",
            "MlMSEgoKbV9wbGF5ZXJJZBgBIAEoDRIzCgttX2xvZ2luVHlwZRgCIAEoDjIe",
            "Lk1zZ1BCLkdhbWVSb29tUGxheWVyTG9naW5UeXBlIlMKFkdhbWVSb29tUGxh",
            "eWVyTG9naW5TMkMSFgoObV9sb2dpblN1Y2Nlc3MYASABKAgSEgoKbV9wbGF5",
            "ZXJJZBgCIAEoDRINCgVtX2tleRgDIAEoAyotChdHYW1lUm9vbVBsYXllckxv",
            "Z2luVHlwZRIICgRQTEFZEAASCAoEVklFVxABYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::MsgPB.GameRoomPlayerLoginType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameRoomPlayerInfo), global::MsgPB.GameRoomPlayerInfo.Parser, new[]{ "MPlayerId", "MName", "MBodyViewData" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameRoomPlayerLoginC2S), global::MsgPB.GameRoomPlayerLoginC2S.Parser, new[]{ "MPlayerId", "MLoginType" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameRoomPlayerLoginS2C), global::MsgPB.GameRoomPlayerLoginS2C.Parser, new[]{ "MLoginSuccess", "MPlayerId", "MKey" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum GameRoomPlayerLoginType {
    [pbr::OriginalName("PLAY")] Play = 0,
    [pbr::OriginalName("VIEW")] View = 1,
  }

  #endregion

  #region Messages
  public sealed partial class GameRoomPlayerInfo : pb::IMessage<GameRoomPlayerInfo> {
    private static readonly pb::MessageParser<GameRoomPlayerInfo> _parser = new pb::MessageParser<GameRoomPlayerInfo>(() => new GameRoomPlayerInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameRoomPlayerInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameRoomPlayerReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerInfo(GameRoomPlayerInfo other) : this() {
      mPlayerId_ = other.mPlayerId_;
      mName_ = other.mName_;
      mBodyViewData_ = other.mBodyViewData_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerInfo Clone() {
      return new GameRoomPlayerInfo(this);
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

    /// <summary>Field number for the "m_name" field.</summary>
    public const int MNameFieldNumber = 2;
    private string mName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MName {
      get { return mName_; }
      set {
        mName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "m_bodyViewData" field.</summary>
    public const int MBodyViewDataFieldNumber = 3;
    private int mBodyViewData_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int MBodyViewData {
      get { return mBodyViewData_; }
      set {
        mBodyViewData_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameRoomPlayerInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameRoomPlayerInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MPlayerId != other.MPlayerId) return false;
      if (MName != other.MName) return false;
      if (MBodyViewData != other.MBodyViewData) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MPlayerId != 0) hash ^= MPlayerId.GetHashCode();
      if (MName.Length != 0) hash ^= MName.GetHashCode();
      if (MBodyViewData != 0) hash ^= MBodyViewData.GetHashCode();
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
      if (MName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(MName);
      }
      if (MBodyViewData != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(MBodyViewData);
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
      if (MName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MName);
      }
      if (MBodyViewData != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(MBodyViewData);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameRoomPlayerInfo other) {
      if (other == null) {
        return;
      }
      if (other.MPlayerId != 0) {
        MPlayerId = other.MPlayerId;
      }
      if (other.MName.Length != 0) {
        MName = other.MName;
      }
      if (other.MBodyViewData != 0) {
        MBodyViewData = other.MBodyViewData;
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
          case 18: {
            MName = input.ReadString();
            break;
          }
          case 24: {
            MBodyViewData = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameRoomPlayerLoginC2S : pb::IMessage<GameRoomPlayerLoginC2S> {
    private static readonly pb::MessageParser<GameRoomPlayerLoginC2S> _parser = new pb::MessageParser<GameRoomPlayerLoginC2S>(() => new GameRoomPlayerLoginC2S());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameRoomPlayerLoginC2S> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameRoomPlayerReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerLoginC2S() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerLoginC2S(GameRoomPlayerLoginC2S other) : this() {
      mPlayerId_ = other.mPlayerId_;
      mLoginType_ = other.mLoginType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerLoginC2S Clone() {
      return new GameRoomPlayerLoginC2S(this);
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

    /// <summary>Field number for the "m_loginType" field.</summary>
    public const int MLoginTypeFieldNumber = 2;
    private global::MsgPB.GameRoomPlayerLoginType mLoginType_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.GameRoomPlayerLoginType MLoginType {
      get { return mLoginType_; }
      set {
        mLoginType_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameRoomPlayerLoginC2S);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameRoomPlayerLoginC2S other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MPlayerId != other.MPlayerId) return false;
      if (MLoginType != other.MLoginType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MPlayerId != 0) hash ^= MPlayerId.GetHashCode();
      if (MLoginType != 0) hash ^= MLoginType.GetHashCode();
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
      if (MLoginType != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) MLoginType);
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
      if (MLoginType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MLoginType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameRoomPlayerLoginC2S other) {
      if (other == null) {
        return;
      }
      if (other.MPlayerId != 0) {
        MPlayerId = other.MPlayerId;
      }
      if (other.MLoginType != 0) {
        MLoginType = other.MLoginType;
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
            MLoginType = (global::MsgPB.GameRoomPlayerLoginType) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameRoomPlayerLoginS2C : pb::IMessage<GameRoomPlayerLoginS2C> {
    private static readonly pb::MessageParser<GameRoomPlayerLoginS2C> _parser = new pb::MessageParser<GameRoomPlayerLoginS2C>(() => new GameRoomPlayerLoginS2C());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameRoomPlayerLoginS2C> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameRoomPlayerReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerLoginS2C() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerLoginS2C(GameRoomPlayerLoginS2C other) : this() {
      mLoginSuccess_ = other.mLoginSuccess_;
      mPlayerId_ = other.mPlayerId_;
      mKey_ = other.mKey_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerLoginS2C Clone() {
      return new GameRoomPlayerLoginS2C(this);
    }

    /// <summary>Field number for the "m_loginSuccess" field.</summary>
    public const int MLoginSuccessFieldNumber = 1;
    private bool mLoginSuccess_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool MLoginSuccess {
      get { return mLoginSuccess_; }
      set {
        mLoginSuccess_ = value;
      }
    }

    /// <summary>Field number for the "m_playerId" field.</summary>
    public const int MPlayerIdFieldNumber = 2;
    private uint mPlayerId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint MPlayerId {
      get { return mPlayerId_; }
      set {
        mPlayerId_ = value;
      }
    }

    /// <summary>Field number for the "m_key" field.</summary>
    public const int MKeyFieldNumber = 3;
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
      return Equals(other as GameRoomPlayerLoginS2C);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameRoomPlayerLoginS2C other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MLoginSuccess != other.MLoginSuccess) return false;
      if (MPlayerId != other.MPlayerId) return false;
      if (MKey != other.MKey) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MLoginSuccess != false) hash ^= MLoginSuccess.GetHashCode();
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
      if (MLoginSuccess != false) {
        output.WriteRawTag(8);
        output.WriteBool(MLoginSuccess);
      }
      if (MPlayerId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(MPlayerId);
      }
      if (MKey != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(MKey);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MLoginSuccess != false) {
        size += 1 + 1;
      }
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
    public void MergeFrom(GameRoomPlayerLoginS2C other) {
      if (other == null) {
        return;
      }
      if (other.MLoginSuccess != false) {
        MLoginSuccess = other.MLoginSuccess;
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
            MLoginSuccess = input.ReadBool();
            break;
          }
          case 16: {
            MPlayerId = input.ReadUInt32();
            break;
          }
          case 24: {
            MKey = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
