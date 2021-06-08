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
            "ChFHYW1lQ29tbWFuZC5wcm90bxIFTXNnUEIaFEdhbWVSb29tUGxheWVyLnBy",
            "b3RvGg1HYW1lRGVmLnByb3RvIksKGEdhbWVDb21tYW5kX0NyZWF0ZVBsYXll",
            "chIvCgxtX3BsYXllckluZm8YASABKAsyGS5Nc2dQQi5HYW1lUm9vbVBsYXll",
            "ckluZm8iVAoWR2FtZUNvbW1hbmRfUGxheWVyTW92ZRIpCgptX21vdmVUeXBl",
            "GAEgASgOMhUuTXNnUEIuUGxheWVyTW92ZVR5cGUSDwoHbV9iSnVtcBgCIAEo",
            "CCKTAQoPR2FtZUNvbW1hbmRJbmZvEhIKCm1fcGxheWVySWQYASABKA0SNwoO",
            "bV9jcmVhdGVQbGF5ZXIYAiABKAsyHy5Nc2dQQi5HYW1lQ29tbWFuZF9DcmVh",
            "dGVQbGF5ZXISMwoMbV9wbGF5ZXJNb3ZlGAMgASgLMh0uTXNnUEIuR2FtZUNv",
            "bW1hbmRfUGxheWVyTW92ZSJcCg5HYW1lQ29tbWFuZFMyQxIUCgxtX2ZyYW1l",
            "SW5kZXgYASABKA0SNAoUbV9sc3RHYW1lQ29tbWFuZEluZm8YAiADKAsyFi5N",
            "c2dQQi5HYW1lQ29tbWFuZEluZm8iLgoWR2FtZUNvbW1hbmRSZXRyaWV2ZUMy",
            "UxIUCgxtX2ZyYW1lSW5kZXgYASABKA0qLwoOUGxheWVyTW92ZVR5cGUSCAoE",
            "U1RPUBAAEggKBExFRlQQARIJCgVSSUdIVBACYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::MsgPB.GameRoomPlayerReflection.Descriptor, global::MsgPB.GameDefReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::MsgPB.PlayerMoveType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommand_CreatePlayer), global::MsgPB.GameCommand_CreatePlayer.Parser, new[]{ "MPlayerInfo" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommand_PlayerMove), global::MsgPB.GameCommand_PlayerMove.Parser, new[]{ "MMoveType", "MBJump" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommandInfo), global::MsgPB.GameCommandInfo.Parser, new[]{ "MPlayerId", "MCreatePlayer", "MPlayerMove" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommandS2C), global::MsgPB.GameCommandS2C.Parser, new[]{ "MFrameIndex", "MLstGameCommandInfo" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameCommandRetrieveC2S), global::MsgPB.GameCommandRetrieveC2S.Parser, new[]{ "MFrameIndex" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  ///玩家移动
  /// </summary>
  public enum PlayerMoveType {
    [pbr::OriginalName("STOP")] Stop = 0,
    [pbr::OriginalName("LEFT")] Left = 1,
    [pbr::OriginalName("RIGHT")] Right = 2,
  }

  #endregion

  #region Messages
  /// <summary>
  ///创建玩家
  /// </summary>
  public sealed partial class GameCommand_CreatePlayer : pb::IMessage<GameCommand_CreatePlayer> {
    private static readonly pb::MessageParser<GameCommand_CreatePlayer> _parser = new pb::MessageParser<GameCommand_CreatePlayer>(() => new GameCommand_CreatePlayer());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameCommand_CreatePlayer> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameCommandReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_CreatePlayer() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_CreatePlayer(GameCommand_CreatePlayer other) : this() {
      mPlayerInfo_ = other.mPlayerInfo_ != null ? other.mPlayerInfo_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_CreatePlayer Clone() {
      return new GameCommand_CreatePlayer(this);
    }

    /// <summary>Field number for the "m_playerInfo" field.</summary>
    public const int MPlayerInfoFieldNumber = 1;
    private global::MsgPB.GameRoomPlayerInfo mPlayerInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.GameRoomPlayerInfo MPlayerInfo {
      get { return mPlayerInfo_; }
      set {
        mPlayerInfo_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameCommand_CreatePlayer);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameCommand_CreatePlayer other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(MPlayerInfo, other.MPlayerInfo)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (mPlayerInfo_ != null) hash ^= MPlayerInfo.GetHashCode();
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
      if (mPlayerInfo_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(MPlayerInfo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (mPlayerInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MPlayerInfo);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameCommand_CreatePlayer other) {
      if (other == null) {
        return;
      }
      if (other.mPlayerInfo_ != null) {
        if (mPlayerInfo_ == null) {
          MPlayerInfo = new global::MsgPB.GameRoomPlayerInfo();
        }
        MPlayerInfo.MergeFrom(other.MPlayerInfo);
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
          case 10: {
            if (mPlayerInfo_ == null) {
              MPlayerInfo = new global::MsgPB.GameRoomPlayerInfo();
            }
            input.ReadMessage(MPlayerInfo);
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameCommand_PlayerMove : pb::IMessage<GameCommand_PlayerMove> {
    private static readonly pb::MessageParser<GameCommand_PlayerMove> _parser = new pb::MessageParser<GameCommand_PlayerMove>(() => new GameCommand_PlayerMove());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameCommand_PlayerMove> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameCommandReflection.Descriptor.MessageTypes[1]; }
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
      mBJump_ = other.mBJump_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommand_PlayerMove Clone() {
      return new GameCommand_PlayerMove(this);
    }

    /// <summary>Field number for the "m_moveType" field.</summary>
    public const int MMoveTypeFieldNumber = 1;
    private global::MsgPB.PlayerMoveType mMoveType_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.PlayerMoveType MMoveType {
      get { return mMoveType_; }
      set {
        mMoveType_ = value;
      }
    }

    /// <summary>Field number for the "m_bJump" field.</summary>
    public const int MBJumpFieldNumber = 2;
    private bool mBJump_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool MBJump {
      get { return mBJump_; }
      set {
        mBJump_ = value;
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
      if (MBJump != other.MBJump) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MMoveType != 0) hash ^= MMoveType.GetHashCode();
      if (MBJump != false) hash ^= MBJump.GetHashCode();
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
        output.WriteRawTag(8);
        output.WriteEnum((int) MMoveType);
      }
      if (MBJump != false) {
        output.WriteRawTag(16);
        output.WriteBool(MBJump);
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
      if (MBJump != false) {
        size += 1 + 1;
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
      if (other.MBJump != false) {
        MBJump = other.MBJump;
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
            MMoveType = (global::MsgPB.PlayerMoveType) input.ReadEnum();
            break;
          }
          case 16: {
            MBJump = input.ReadBool();
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
      mCreatePlayer_ = other.mCreatePlayer_ != null ? other.mCreatePlayer_.Clone() : null;
      mPlayerMove_ = other.mPlayerMove_ != null ? other.mPlayerMove_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandInfo Clone() {
      return new GameCommandInfo(this);
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

    /// <summary>Field number for the "m_createPlayer" field.</summary>
    public const int MCreatePlayerFieldNumber = 2;
    private global::MsgPB.GameCommand_CreatePlayer mCreatePlayer_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.GameCommand_CreatePlayer MCreatePlayer {
      get { return mCreatePlayer_; }
      set {
        mCreatePlayer_ = value;
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
      if (!object.Equals(MCreatePlayer, other.MCreatePlayer)) return false;
      if (!object.Equals(MPlayerMove, other.MPlayerMove)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MPlayerId != 0) hash ^= MPlayerId.GetHashCode();
      if (mCreatePlayer_ != null) hash ^= MCreatePlayer.GetHashCode();
      if (mPlayerMove_ != null) hash ^= MPlayerMove.GetHashCode();
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
      if (mCreatePlayer_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(MCreatePlayer);
      }
      if (mPlayerMove_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(MPlayerMove);
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
      if (mCreatePlayer_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MCreatePlayer);
      }
      if (mPlayerMove_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MPlayerMove);
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
      if (other.MPlayerId != 0) {
        MPlayerId = other.MPlayerId;
      }
      if (other.mCreatePlayer_ != null) {
        if (mCreatePlayer_ == null) {
          MCreatePlayer = new global::MsgPB.GameCommand_CreatePlayer();
        }
        MCreatePlayer.MergeFrom(other.MCreatePlayer);
      }
      if (other.mPlayerMove_ != null) {
        if (mPlayerMove_ == null) {
          MPlayerMove = new global::MsgPB.GameCommand_PlayerMove();
        }
        MPlayerMove.MergeFrom(other.MPlayerMove);
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
            if (mCreatePlayer_ == null) {
              MCreatePlayer = new global::MsgPB.GameCommand_CreatePlayer();
            }
            input.ReadMessage(MCreatePlayer);
            break;
          }
          case 26: {
            if (mPlayerMove_ == null) {
              MPlayerMove = new global::MsgPB.GameCommand_PlayerMove();
            }
            input.ReadMessage(MPlayerMove);
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
      mFrameIndex_ = other.mFrameIndex_;
      mLstGameCommandInfo_ = other.mLstGameCommandInfo_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandS2C Clone() {
      return new GameCommandS2C(this);
    }

    /// <summary>Field number for the "m_frameIndex" field.</summary>
    public const int MFrameIndexFieldNumber = 1;
    private uint mFrameIndex_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint MFrameIndex {
      get { return mFrameIndex_; }
      set {
        mFrameIndex_ = value;
      }
    }

    /// <summary>Field number for the "m_lstGameCommandInfo" field.</summary>
    public const int MLstGameCommandInfoFieldNumber = 2;
    private static readonly pb::FieldCodec<global::MsgPB.GameCommandInfo> _repeated_mLstGameCommandInfo_codec
        = pb::FieldCodec.ForMessage(18, global::MsgPB.GameCommandInfo.Parser);
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
      if (MFrameIndex != other.MFrameIndex) return false;
      if(!mLstGameCommandInfo_.Equals(other.mLstGameCommandInfo_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MFrameIndex != 0) hash ^= MFrameIndex.GetHashCode();
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
      if (MFrameIndex != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(MFrameIndex);
      }
      mLstGameCommandInfo_.WriteTo(output, _repeated_mLstGameCommandInfo_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MFrameIndex != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MFrameIndex);
      }
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
      if (other.MFrameIndex != 0) {
        MFrameIndex = other.MFrameIndex;
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
          case 8: {
            MFrameIndex = input.ReadUInt32();
            break;
          }
          case 18: {
            mLstGameCommandInfo_.AddEntriesFrom(input, _repeated_mLstGameCommandInfo_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameCommandRetrieveC2S : pb::IMessage<GameCommandRetrieveC2S> {
    private static readonly pb::MessageParser<GameCommandRetrieveC2S> _parser = new pb::MessageParser<GameCommandRetrieveC2S>(() => new GameCommandRetrieveC2S());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameCommandRetrieveC2S> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameCommandReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandRetrieveC2S() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandRetrieveC2S(GameCommandRetrieveC2S other) : this() {
      mFrameIndex_ = other.mFrameIndex_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameCommandRetrieveC2S Clone() {
      return new GameCommandRetrieveC2S(this);
    }

    /// <summary>Field number for the "m_frameIndex" field.</summary>
    public const int MFrameIndexFieldNumber = 1;
    private uint mFrameIndex_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint MFrameIndex {
      get { return mFrameIndex_; }
      set {
        mFrameIndex_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameCommandRetrieveC2S);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameCommandRetrieveC2S other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MFrameIndex != other.MFrameIndex) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MFrameIndex != 0) hash ^= MFrameIndex.GetHashCode();
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
      if (MFrameIndex != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(MFrameIndex);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MFrameIndex != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(MFrameIndex);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameCommandRetrieveC2S other) {
      if (other == null) {
        return;
      }
      if (other.MFrameIndex != 0) {
        MFrameIndex = other.MFrameIndex;
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
            MFrameIndex = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
