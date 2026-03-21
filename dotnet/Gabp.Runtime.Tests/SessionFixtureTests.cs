using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Gabp.Runtime.Tests
{
    public class SessionFixtureTests
    {
        [Fact]
        public void DeserializesSessionHelloFixture()
        {
            var json = LoadValidFixture("001_session_hello.json");
            var request = GabpJson.Deserialize<SessionHelloRequest>(json);

            Assert.Equal(GabpProtocol.EnvelopeVersion, request.Version);
            Assert.Equal("550e8400-e29b-41d4-a716-446655440000", request.Id);
            Assert.Equal(GabpProtocol.RequestType, request.Type);
            Assert.Equal(GabpProtocol.SessionHelloMethod, request.Method);
            Assert.Equal("a1b2c3d4e5f6789012345678901234567890abcdef", request.Params!.Token);
            Assert.Equal("1.0.0", request.Params.BridgeVersion);
            Assert.Equal("linux", request.Params.Platform);
            Assert.Equal("550e8400-e29b-41d4-a716-446655440001", request.Params.LaunchId);
            Assert.Null(request.Params.ClientInfo);
        }

        [Fact]
        public void RoundTripsSessionWelcomeFixture()
        {
            var json = LoadValidFixture("002_session_welcome.json");
            var response = GabpJson.Deserialize<SessionWelcomeResponse>(json);
            var roundTrip = GabpJson.Deserialize<SessionWelcomeResponse>(GabpJson.Serialize(response));

            Assert.Equal(GabpProtocol.EnvelopeVersion, roundTrip.Version);
            Assert.Equal("550e8400-e29b-41d4-a716-446655440000", roundTrip.Id);
            Assert.Equal(GabpProtocol.ResponseType, roundTrip.Type);
            Assert.NotNull(roundTrip.Result);
            Assert.Equal("test-mod", roundTrip.Result!.AgentId);
            Assert.Equal("TestGame", roundTrip.Result.App.Name);
            Assert.Equal("1.0", roundTrip.Result.App.Version);
            Assert.Equal("1.0", roundTrip.Result.SchemaVersion);
            Assert.Single(roundTrip.Result.Capabilities.Methods);
            Assert.Empty(roundTrip.Result.Capabilities.Events);
            Assert.Empty(roundTrip.Result.Capabilities.Resources);
            Assert.Equal("session/hello", roundTrip.Result.Capabilities.Methods[0]);
            Assert.Null(roundTrip.Error);
        }

        [Fact]
        public void DeserializesToolsCallFixture()
        {
            var json = LoadValidFixture("003_tools_call.json");
            var request = GabpJson.Deserialize<ToolsCallRequest>(json);

            Assert.Equal(GabpProtocol.ToolsCallMethod, request.Method);
            Assert.Equal("test/tool", request.Params.Name);
            Assert.NotNull(request.Params.Arguments);
            Assert.Equal("value1", request.Params.Arguments!["param1"]?.Value<string>());
            Assert.Equal(42, request.Params.Arguments["param2"]?.Value<int>());
        }

        [Fact]
        public void DeserializesEventFixture()
        {
            var json = LoadValidFixture("004_event_message.json");
            var envelope = GabpJson.Deserialize<GabpEventEnvelope<JObject>>(json);

            Assert.Equal(GabpProtocol.EventType, envelope.Type);
            Assert.Equal("test/event", envelope.Channel);
            Assert.Equal(1, envelope.Sequence);
            Assert.Equal("test event payload", envelope.Payload["data"]?.Value<string>());
        }

        [Fact]
        public void DeserializesErrorFixture()
        {
            var json = LoadValidFixture("005_error_response.json");
            var response = GabpJson.Deserialize<GabpResponseEnvelope<object>>(json);

            Assert.NotNull(response.Error);
            Assert.Null(response.Result);
            Assert.Equal(-32601, response.Error!.Code);
            Assert.Equal("Method not found", response.Error.Message);
            Assert.NotNull(response.Error.Data);
            Assert.Equal("unknown/method", response.Error.Data!["method"]?.Value<string>());
        }

        [Fact]
        public void RoundTripsToolsListFixture()
        {
            var json = LoadValidFixture("006_tools_list_response.json");
            var response = GabpJson.Deserialize<ToolsListResponse>(json);
            var roundTrip = GabpJson.Deserialize<ToolsListResponse>(GabpJson.Serialize(response));

            Assert.NotNull(roundTrip.Result);
            Assert.Single(roundTrip.Result!.Tools);
            Assert.Equal("inventory/get", roundTrip.Result.Tools[0].Name);
            Assert.Equal("Get Inventory", roundTrip.Result.Tools[0].Title);
            Assert.Equal("object", roundTrip.Result.Tools[0].InputSchema["type"]?.Value<string>());
            Assert.Equal("object", roundTrip.Result.Tools[0].OutputSchema["type"]?.Value<string>());
        }

        internal static string LoadValidFixture(string fileName)
        {
            var path = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    "../../../../../testdata/gabp",
                    RuntimeMetadata.TargetGabpSchemaVersion,
                    "conformance/valid",
                    fileName));

            return File.ReadAllText(path);
        }
    }
}
