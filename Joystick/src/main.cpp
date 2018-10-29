#include <painlessMesh.h>
#include "conf.hpp"

#define EMITTER true
#define RECEIVER false
#define DEBUG_LOG false

static painlessMesh mesh;

#if EMITTER

static uint8_t previousButtons = 0xFF;

static void sendButtons()
{
	uint8_t buttons = (digitalRead(D1))
		| (digitalRead(D2) << 1)
		| (digitalRead(D3) << 2)
		| (digitalRead(D4) << 3)
		| 0x80;

	if (buttons != previousButtons)
	{
		previousButtons = buttons;

		Serial.write(buttons);

		String message{ buttons };
		mesh.sendBroadcast(message);
	}
}

static Task taskSendButtons(TASK_MILLISECOND * 10, TASK_FOREVER, &sendButtons);

#endif

static void receiveCallback(uint32_t from, String &msg)
{
#if DEBUG_LOG
	Serial.printf("Received from %u msg=%s\n", from, msg.c_str());
#endif

#if RECEIVER
	Serial.write(msg[0]);
#endif
}

#if DEBUG_LOG

static void newConnectionCallback(uint32_t nodeId)
{
	Serial.printf("New Connection, nodeId = %u\n", nodeId);
}

static void changedConnectionCallback()
{
	Serial.printf("Changed connections %s\n", mesh.subConnectionJson().c_str());
}

static void nodeTimeAdjustedCallback(int32_t offset)
{
	Serial.printf("Adjusted time %u. Offset = %d\n", mesh.getNodeTime(), offset);
}

static void delayReceivedCallback(uint32_t from, int32_t delay)
{
	Serial.printf("Delay to node %u is %d us\n", from, delay);
}

#endif

void setup()
{
	pinMode(D1, INPUT_PULLUP);
	pinMode(D2, INPUT_PULLUP);
	pinMode(D3, INPUT_PULLUP);
	pinMode(D4, INPUT_PULLUP);

	Serial.begin(115200);

	mesh.setDebugMsgTypes(ERROR | DEBUG | CONNECTION);

	mesh.init(MESH_SSID, MESH_PASSWORD, MESH_PORT);
	mesh.onReceive(&receiveCallback);

#if DEBUG_LOG
	mesh.onNewConnection(&newConnectionCallback);
	mesh.onChangedConnections(&changedConnectionCallback);
	mesh.onNodeTimeAdjusted(&nodeTimeAdjustedCallback);
	mesh.onNodeDelayReceived(&delayReceivedCallback);
#endif

#if EMITTER
	mesh.scheduler.addTask(taskSendButtons);
	taskSendButtons.enable();
#endif
}

void loop()
{
	mesh.update();
}
