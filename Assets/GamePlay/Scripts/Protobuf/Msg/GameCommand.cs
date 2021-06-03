// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GameCommand.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MsgPB {

  /// <summary>Holder for reflection information generated from GameCommand.proto</summary>
  public static partial class GameCommandReflection {

    #region Descriptor
    /// <summary>File descriptor for GameCommand.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GameCommandReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFHYW1lQ29tbWFuZC5wcm90bxIFTXNnUEIiQwoWR2FtZUNvbW1hbmRfUGxh",
            "eWVyTW92ZRIpCgptX21vdmVUeXBlGAIgASgOMhUuTXNnUEIuUGxheWVyTW92",
            "ZVR5cGUiKAoWR2FtZUNvbW1hbmRfUGxheWVySnVtcBIOCgZtX25vbmUYASAB",
            "KAUiwgEKD0dhbWVDb21tYW5kSW5mbxISCgptX3BsYXllcklkGAEgASgDEjEK",
            "DW1fY29tbWFuZFR5cGUYAiABKA4yGi5Nc2dQQi5HYW1lQ29tbWFuZFR5cGVF",
            "bnVtEjMKDG1fcGxheWVyTW92ZRgDIAEoCzIdLk1zZ1BCLkdhbWVDb21tYW5k",
            "X1BsYXllck1vdmUSMwoMbV9wbGF5ZXJKdW1wGAQgASgLMh0uTXNnUEIuR2Ft",
            "ZUNvbW1hbmRfUGxheWVySnVtcCJGCg5HYW1lQ29tbWFuZFMyQxI0ChRtX2xz",
            "dEdhbWVDb21tYW5kSW5mbxgBIAMoCzIWLk1zZ1BCLkdhbWVDb21tYW5kSW5m",
            "bypBChNHYW1lQ29tbWFuZFR5cGVFbnVtEggKBE5PTkUQABIPCgtQTEFZRVJf",
            "TU9WRRABEg8KC1BMQVlFUl9KVU1QEAIqLwoOUGxheWVyTW92ZVR5cGUSCAoE",
            "U1RPUBAAEggKBExFRlQQARIJCgVSSUdIVBACYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::MsgPB.GameCommandTypeEnum), typeof(global::MsgPB.PlayerMoveType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommand_PlayerMove), global::MsgPB.GameCommand_PlayerMove.Parser, new[]{ "MMoveType" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommand_PlayerJump), global::MsgPB.GameCommand_PlayerJump.Parser, new[]{ "MNone" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommandInfo), global::MsgPB.GameCommandInfo.Parser, new[]{ "MPlayerId", "MCommandType", "MPlayerMove", "MPlayerJump" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommandS2C), global::MsgPB.GameCommandS2C.Parser, new[]{ "MLstGameCommandInfo" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum GameCommandTypeEnum {
    [pbr::OriginalName("NONE")] None = 0,
    [pbr::OriginalName("PLAYER_MOVE")] PlayerMove = 1,
    [pbr::OriginalName("PLAYER_JUMP")] PlayerJump = 2,
  }

  public enum PlayerMoveType {
    [pbr::OriginalName("STOP")] Stop = 0,
    [pbr::OriginalName("LEFT")] Left = 1,
    [pbr::OriginalName("RIGHT")] Right = 2,
  }

  #endregion

  #region Messages
  public sealed partial class GameCommand_PlayerMove : pb::IMessage<GameCommand_PlayerMove> {
    private static readonly pb::MessageParser<GameCommand_PlayerMove> _parser = new pb::MessageParser<GameCommand_PlayerMove>(() => new GameCommand_PlayerMove());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameCommand_PlayerMove> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameCommandReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_PlayerMove() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_PlayerMove(GameCommand_PlayerMove other) : this() {
      mMoveType_ = other.mMoveType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_PlayerMove Clone() {
      return new GameCommand_PlayerMove(this);
    }

    /// <summary>Field number for the "m_moveType" field.</summary>
    public const int MMoveTypeFieldNumber = 2;
    private global::MsgPB.PlayerMoveType mMoveType_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.PlayerMoveType MMoveType {
      get { return mMoveType_; }
      set {
        mMoveType_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameCommand_PlayerMove);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameCommand_PlayerMove other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MMoveType != other.MMoveType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MMoveType != 0) hash ^= MMoveType.GetHashCode();
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
      if (MMoveType != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) MMoveType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MMoveType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MMoveType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameCommand_PlayerMove other) {
      if (other == null) {
        return;
      }
      if (other.MMoveType != 0) {
        MMoveType = other.MMoveType;
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
          case 16: {
            MMoveType = (global::MsgPB.PlayerMoveType) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameCommand_PlayerJump : pb::IMessage<GameCommand_PlayerJump> {
    private static readonly pb::MessageParser<GameCommand_PlayerJump> _parser = new pb::MessageParser<GameCommand_PlayerJump>(() => new GameCommand_PlayerJump());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameCommand_PlayerJump> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameCommandReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_PlayerJump() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_PlayerJump(GameCommand_PlayerJump other) : this() {
      mNone_ = other.mNone_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_PlayerJump Clone() {
      return new GameCommand_PlayerJump(this);
    }

    /// <summary>Field number for the "m_none" field.</summary>
    public const int MNoneFieldNumber = 1;
    private int mNone_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int MNone {
      get { return mNone_; }
      set {
        mNone_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameCommand_PlayerJump);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameCommand_PlayerJump other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MNone != other.MNone) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MNone != 0) hash ^= MNone.GetHashCode();
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
      if (MNone != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(MNone);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MNone != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(MNone);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameCommand_PlayerJump other) {
      if (other == null) {
        return;
      }
      if (other.MNone != 0) {
        MNone = other.MNone;
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
            MNone = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameCommandInfo : pb::IMessage<GameCommandInfo> {
    private static readonly pb::MessageParser<GameCommandInfo> _parser = new pb::MessageParser<GameCommandInfo>(() => new GameCommandInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameCommandInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameCommandReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandInfo(GameCommandInfo other) : this() {
      mPlayerId_ = other.mPlayerId_;
      mCommandType_ = other.mCommandType_;
      mPlayerMove_ = other.mPlayerMove_ != null ? other.mPlayerMove_.Clone() : null;
      mPlayerJump_ = other.mPlayerJump_ != null ? other.mPlayerJump_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandInfo Clone() {
      return new GameCommandInfo(this);
    }

    /// <summary>Field number for the "m_playerId" field.</summary>
    public const int MPlayerIdFieldNumber = 1;
    private long mPlayerId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long MPlayerId {
      get { return mPlayerId_; }
      set {
        mPlayerId_ = value;
      }
    }

    /// <summary>Field number for the "m_commandType" field.</summary>
    public const int MCommandTypeFieldNumber = 2;
    private global::MsgPB.GameCommandTypeEnum mCommandType_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.GameCommandTypeEnum MCommandType {
      get { return mCommandType_; }
      set {
        mCommandType_ = value;
      }
    }

    /// <summary>Field number for the "m_playerMove" field.</summary>
    public const int MPlayerMoveFieldNumber = 3;
    private global::MsgPB.GameCommand_PlayerMove mPlayerMove_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.GameCommand_PlayerMove MPlayerMove {
      get { return mPlayerMove_; }
      set {
        mPlayerMove_ = value;
      }
    }

    /// <summary>Field number for the "m_playerJump" field.</summary>
    public const int MPlayerJumpFieldNumber = 4;
    private global::MsgPB.GameCommand_PlayerJump mPlayerJump_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.GameCommand_PlayerJump MPlayerJump {
      get { return mPlayerJump_; }
      set {
        mPlayerJump_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameCommandInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameCommandInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MPlayerId != other.MPlayerId) return false;
      if (MCommandType != other.MCommandType) return false;
      if (!object.Equals(MPlayerMove, other.MPlayerMove)) return false;
      if (!object.Equals(MPlayerJump, other.MPlayerJump)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MPlayerId != 0L) hash ^= MPlayerId.GetHashCode();
      if (MCommandType != 0) hash ^= MCommandType.GetHashCode();
      if (mPlayerMove_ != null) hash ^= MPlayerMove.GetHashCode();
      if (mPlayerJump_ != null) hash ^= MPlayerJump.GetHashCode();
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
      if (MPlayerId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(MPlayerId);
      }
      if (MCommandType != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) MCommandType);
      }
      if (mPlayerMove_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(MPlayerMove);
      }
      if (mPlayerJump_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(MPlayerJump);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MPlayerId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(MPlayerId);
      }
      if (MCommandType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) MCommandType);
      }
      if (mPlayerMove_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MPlayerMove);
      }
      if (mPlayerJump_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MPlayerJump);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameCommandInfo other) {
      if (other == null) {
        return;
      }
      if (other.MPlayerId != 0L) {
        MPlayerId = other.MPlayerId;
      }
      if (other.MCommandType != 0) {
        MCommandType = other.MCommandType;
      }
      if (other.mPlayerMove_ != null) {
        if (mPlayerMove_ == null) {
          MPlayerMove = new global::MsgPB.GameCommand_PlayerMove();
        }
        MPlayerMove.MergeFrom(other.MPlayerMove);
      }
      if (other.mPlayerJump_ != null) {
        if (mPlayerJump_ == null) {
          MPlayerJump = new global::MsgPB.GameCommand_PlayerJump();
        }
        MPlayerJump.MergeFrom(other.MPlayerJump);
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
            MPlayerId = input.ReadInt64();
            break;
          }
          case 16: {
            MCommandType = (global::MsgPB.GameCommandTypeEnum) input.ReadEnum();
            break;
          }
          case 26: {
            if (mPlayerMove_ == null) {
              MPlayerMove = new global::MsgPB.GameCommand_PlayerMove();
            }
            input.ReadMessage(MPlayerMove);
            break;
          }
          case 34: {
            if (mPlayerJump_ == null) {
              MPlayerJump = new global::MsgPB.GameCommand_PlayerJump();
            }
            input.ReadMessage(MPlayerJump);
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameCommandS2C : pb::IMessage<GameCommandS2C> {
    private static readonly pb::MessageParser<GameCommandS2C> _parser = new pb::MessageParser<GameCommandS2C>(() => new GameCommandS2C());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameCommandS2C> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameCommandReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandS2C() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandS2C(GameCommandS2C other) : this() {
      mLstGameCommandInfo_ = other.mLstGameCommandInfo_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandS2C Clone() {
      return new GameCommandS2C(this);
    }

    /// <summary>Field number for the "m_lstGameCommandInfo" field.</summary>
    public const int MLstGameCommandInfoFieldNumber = 1;
    private static readonly pb::FieldCodec<global::MsgPB.GameCommandInfo> _repeated_mLstGameCommandInfo_codec
        = pb::FieldCodec.ForMessage(10, global::MsgPB.GameCommandInfo.Parser);
    private readonly pbc::RepeatedField<global::MsgPB.GameCommandInfo> mLstGameCommandInfo_ = new pbc::RepeatedField<global::MsgPB.GameCommandInfo>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::MsgPB.GameCommandInfo> MLstGameCommandInfo {
      get { return mLstGameCommandInfo_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameCommandS2C);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameCommandS2C other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!mLstGameCommandInfo_.Equals(other.mLstGameCommandInfo_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= mLstGameCommandInfo_.GetHashCode();
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
      mLstGameCommandInfo_.WriteTo(output, _repeated_mLstGameCommandInfo_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += mLstGameCommandInfo_.CalculateSize(_repeated_mLstGameCommandInfo_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameCommandS2C other) {
      if (other == null) {
        return;
      }
      mLstGameCommandInfo_.Add(other.mLstGameCommandInfo_);
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
          case 10: {
            mLstGameCommandInfo_.AddEntriesFrom(input, _repeated_mLstGameCommandInfo_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
