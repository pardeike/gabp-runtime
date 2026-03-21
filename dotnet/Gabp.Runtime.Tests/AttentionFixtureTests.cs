using Xunit;

namespace Gabp.Runtime.Tests
{
    public class AttentionFixtureTests
    {
        [Fact]
        public void DeserializesAttentionCurrentFixture()
        {
            var json = SessionFixtureTests.LoadValidFixture("007_attention_current_response.json");
            var response = GabpJson.Deserialize<AttentionCurrentResponse>(json);

            Assert.NotNull(response.Result);
            Assert.NotNull(response.Result!.Attention);
            Assert.Equal("attn_7", response.Result.Attention!.AttentionId);
            Assert.False(response.Result.Attention.Blocking);
        }

        [Fact]
        public void DeserializesAttentionOpenedEventFixture()
        {
            var json = SessionFixtureTests.LoadValidFixture("008_attention_opened_event.json");
            var envelope = GabpJson.Deserialize<GabpEventEnvelope<GabpAttention>>(json);

            Assert.Equal(GabpProtocol.AttentionOpenedChannel, envelope.Channel);
            Assert.True(envelope.Payload.Blocking);
            Assert.True(envelope.Payload.StateInvalidated);
            Assert.Equal("attn_8", envelope.Payload.AttentionId);
        }

        [Fact]
        public void DeserializesAttentionAckFixture()
        {
            var json = SessionFixtureTests.LoadValidFixture("009_attention_ack_response.json");
            var response = GabpJson.Deserialize<AttentionAckResponse>(json);

            Assert.NotNull(response.Result);
            Assert.False(response.Result!.Acknowledged);
            Assert.Equal("attn_missing", response.Result.AttentionId);
            Assert.NotNull(response.Result.CurrentAttention);
            Assert.Equal("attn_9", response.Result.CurrentAttention!.AttentionId);
        }
    }
}
