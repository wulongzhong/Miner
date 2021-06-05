// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GameRoomData.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MsgPB {

  /// <summary>Holder for reflection information generated from GameRoomData.proto</summary>
  public static partial class GameRoomDataReflection {

    #region Descriptor
    /// <summary>File descriptor for GameRoomData.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GameRoomDataReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJHYW1lUm9vbURhdGEucHJvdG8SBU1zZ1BCGhRHYW1lUm9vbVBsYXllci5w",
            "cm90bxoNR2FtZURlZi5wcm90byKkAQoTR2FtZVJvb21QbGF5ZXJDYWNoZRIv",
            "CgxtX3BsYXllckluZm8YASABKAsyGS5Nc2dQQi5HYW1lUm9vbVBsYXllcklu",
            "Zm8SIQoJbV9sYXN0UG9zGAIgASgLMg4uTXNnUEIuVmVjdG9yMhImCg5tX2xh",
            "c3RWZWxvY2l0eRgDIAEoCzIOLk1zZ1BCLlZlY3RvcjISEQoJbV9kaXJMZWZ0",
            "GAQgASgIImEKE0dhbWVSb29tRGF0YVN5bmNTMkMSFAoMbV9mcmFtZUluZGV4",
            "GAEgASgNEjQKEG1fbHN0Q2FjaGVQbGF5ZXIYAiADKAsyGi5Nc2dQQi5HYW1l",
            "Um9vbVBsYXllckNhY2hlYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::MsgPB.GameRoomPlayerReflection.Descriptor, global::MsgPB.GameDefReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameRoomPlayerCache), global::MsgPB.GameRoomPlayerCache.Parser, new[]{ "MPlayerInfo", "MLastPos", "MLastVelocity", "MDirLeft" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::MsgPB.GameRoomDataSyncS2C), global::MsgPB.GameRoomDataSyncS2C.Parser, new[]{ "MFrameIndex", "MLstCachePlayer" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GameRoomPlayerCache : pb::IMessage<GameRoomPlayerCache> {
    private static readonly pb::MessageParser<GameRoomPlayerCache> _parser = new pb::MessageParser<GameRoomPlayerCache>(() => new GameRoomPlayerCache());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameRoomPlayerCache> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameRoomDataReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerCache() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerCache(GameRoomPlayerCache other) : this() {
      mPlayerInfo_ = other.mPlayerInfo_ != null ? other.mPlayerInfo_.Clone() : null;
      mLastPos_ = other.mLastPos_ != null ? other.mLastPos_.Clone() : null;
      mLastVelocity_ = other.mLastVelocity_ != null ? other.mLastVelocity_.Clone() : null;
      mDirLeft_ = other.mDirLeft_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomPlayerCache Clone() {
      return new GameRoomPlayerCache(this);
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

    /// <summary>Field number for the "m_lastPos" field.</summary>
    public const int MLastPosFieldNumber = 2;
    private global::MsgPB.Vector2 mLastPos_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.Vector2 MLastPos {
      get { return mLastPos_; }
      set {
        mLastPos_ = value;
      }
    }

    /// <summary>Field number for the "m_lastVelocity" field.</summary>
    public const int MLastVelocityFieldNumber = 3;
    private global::MsgPB.Vector2 mLastVelocity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::MsgPB.Vector2 MLastVelocity {
      get { return mLastVelocity_; }
      set {
        mLastVelocity_ = value;
      }
    }

    /// <summary>Field number for the "m_dirLeft" field.</summary>
    public const int MDirLeftFieldNumber = 4;
    private bool mDirLeft_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool MDirLeft {
      get { return mDirLeft_; }
      set {
        mDirLeft_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameRoomPlayerCache);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameRoomPlayerCache other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(MPlayerInfo, other.MPlayerInfo)) return false;
      if (!object.Equals(MLastPos, other.MLastPos)) return false;
      if (!object.Equals(MLastVelocity, other.MLastVelocity)) return false;
      if (MDirLeft != other.MDirLeft) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (mPlayerInfo_ != null) hash ^= MPlayerInfo.GetHashCode();
      if (mLastPos_ != null) hash ^= MLastPos.GetHashCode();
      if (mLastVelocity_ != null) hash ^= MLastVelocity.GetHashCode();
      if (MDirLeft != false) hash ^= MDirLeft.GetHashCode();
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
      if (mLastPos_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(MLastPos);
      }
      if (mLastVelocity_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(MLastVelocity);
      }
      if (MDirLeft != false) {
        output.WriteRawTag(32);
        output.WriteBool(MDirLeft);
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
      if (mLastPos_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MLastPos);
      }
      if (mLastVelocity_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MLastVelocity);
      }
      if (MDirLeft != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameRoomPlayerCache other) {
      if (other == null) {
        return;
      }
      if (other.mPlayerInfo_ != null) {
        if (mPlayerInfo_ == null) {
          MPlayerInfo = new global::MsgPB.GameRoomPlayerInfo();
        }
        MPlayerInfo.MergeFrom(other.MPlayerInfo);
      }
      if (other.mLastPos_ != null) {
        if (mLastPos_ == null) {
          MLastPos = new global::MsgPB.Vector2();
        }
        MLastPos.MergeFrom(other.MLastPos);
      }
      if (other.mLastVelocity_ != null) {
        if (mLastVelocity_ == null) {
          MLastVelocity = new global::MsgPB.Vector2();
        }
        MLastVelocity.MergeFrom(other.MLastVelocity);
      }
      if (other.MDirLeft != false) {
        MDirLeft = other.MDirLeft;
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
          case 18: {
            if (mLastPos_ == null) {
              MLastPos = new global::MsgPB.Vector2();
            }
            input.ReadMessage(MLastPos);
            break;
          }
          case 26: {
            if (mLastVelocity_ == null) {
              MLastVelocity = new global::MsgPB.Vector2();
            }
            input.ReadMessage(MLastVelocity);
            break;
          }
          case 32: {
            MDirLeft = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GameRoomDataSyncS2C : pb::IMessage<GameRoomDataSyncS2C> {
    private static readonly pb::MessageParser<GameRoomDataSyncS2C> _parser = new pb::MessageParser<GameRoomDataSyncS2C>(() => new GameRoomDataSyncS2C());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameRoomDataSyncS2C> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MsgPB.GameRoomDataReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomDataSyncS2C() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomDataSyncS2C(GameRoomDataSyncS2C other) : this() {
      mFrameIndex_ = other.mFrameIndex_;
      mLstCachePlayer_ = other.mLstCachePlayer_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameRoomDataSyncS2C Clone() {
      return new GameRoomDataSyncS2C(this);
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

    /// <summary>Field number for the "m_lstCachePlayer" field.</summary>
    public const int MLstCachePlayerFieldNumber = 2;
    private static readonly pb::FieldCodec<global::MsgPB.GameRoomPlayerCache> _repeated_mLstCachePlayer_codec
        = pb::FieldCodec.ForMessage(18, global::MsgPB.GameRoomPlayerCache.Parser);
    private readonly pbc::RepeatedField<global::MsgPB.GameRoomPlayerCache> mLstCachePlayer_ = new pbc::RepeatedField<global::MsgPB.GameRoomPlayerCache>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::MsgPB.GameRoomPlayerCache> MLstCachePlayer {
      get { return mLstCachePlayer_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameRoomDataSyncS2C);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameRoomDataSyncS2C other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MFrameIndex != other.MFrameIndex) return false;
      if(!mLstCachePlayer_.Equals(other.mLstCachePlayer_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MFrameIndex != 0) hash ^= MFrameIndex.GetHashCode();
      hash ^= mLstCachePlayer_.GetHashCode();
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
      mLstCachePlayer_.WriteTo(output, _repeated_mLstCachePlayer_codec);
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
      size += mLstCachePlayer_.CalculateSize(_repeated_mLstCachePlayer_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameRoomDataSyncS2C other) {
      if (other == null) {
        return;
      }
      if (other.MFrameIndex != 0) {
        MFrameIndex = other.MFrameIndex;
      }
      mLstCachePlayer_.Add(other.mLstCachePlayer_);
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
            mLstCachePlayer_.AddEntriesFrom(input, _repeated_mLstCachePlayer_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
