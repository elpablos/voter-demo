#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClient.h>

#define RED_BTN 12
#define BLUE_BTN 14
#define RED_LED D4
#define GREEN_LED D3
#define BLUE_LED D2

ESP8266WiFiMulti WiFiMulti;

// vytvoření proměnných s názvem WiFi sítě a heslem
const char* nazevWifi = "TODO";
const char* hesloWifi = "TODO";
int canSend = 0;
char* color = "";

void setup() {
  Serial.begin(9600);
  Serial.println("Setup");

  pinMode(RED_BTN, INPUT);
  pinMode(BLUE_BTN, INPUT);

  pinMode(RED_LED, OUTPUT);
  pinMode(GREEN_LED, OUTPUT);
  pinMode(BLUE_LED, OUTPUT);


  for (uint8_t t = 4; t > 0; t--) {
    Serial.printf("[SETUP] WAIT %d...\n", t);
    Serial.flush();
    delay(1000);
  }

  // WiFi.begin(nazevWifi, hesloWifi);
  WiFi.mode(WIFI_STA);
  WiFiMulti.addAP(nazevWifi, hesloWifi);
  
  while (WiFi.status() != WL_CONNECTED) {
    digitalWrite(GREEN_LED, HIGH);
    delay(500);
    digitalWrite(GREEN_LED, LOW);
    Serial.print(".");
  }
    Serial.println("");

  attachInterrupt(RED_BTN, redButtonPressed, RISING);
  attachInterrupt(BLUE_BTN, blueButtonPressed, RISING);

  Serial.println("Ready");
  digitalWrite(RED_LED, LOW);
  digitalWrite(GREEN_LED, HIGH);
  digitalWrite(BLUE_LED, LOW);
}

void send(char* c) {
  color = c;
  canSend = 1;
}

void loop() {
  // put your main code here, to run repeatedly:
  if (canSend==1) {

    Serial.print("Send...");
    Serial.println(color);
    // wait for WiFi connection
    if ((WiFiMulti.run() == WL_CONNECTED)) {
  
      WiFiClient client;
      HTTPClient http;
  
      Serial.print("[HTTP] begin...\n");
      if (http.begin(client, "http://jigsaw.w3.org/HTTP/connection.html")) {  // HTTP
  
  
        Serial.print("[HTTP] GET...\n");
        // start connection and send HTTP header
        int httpCode = http.GET();
  
        // httpCode will be negative on error
        if (httpCode > 0) {
          // HTTP header has been send and Server response header has been handled
          Serial.printf("[HTTP] GET... code: %d\n", httpCode);
  
          // file found at server
          if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
            String payload = http.getString();
            Serial.println(payload);
          }
        } else {
          Serial.printf("[HTTP] GET... failed, error: %s\n", http.errorToString(httpCode).c_str());
        }
  
        http.end();
      } else {
        Serial.printf("[HTTP} Unable to connect\n");
      }
    }

    canSend = 0;
  }
  
  delay(1000);
}

void redButtonPressed() {
  Serial.println("redButtonPressed");
  int button = digitalRead(RED_BTN);
  Serial.println(button);
  if(button == HIGH)
  {
    digitalWrite(RED_LED, HIGH);
    digitalWrite(GREEN_LED, LOW);
    digitalWrite(BLUE_LED, LOW);

    send("red");
  }
  return;
}

void blueButtonPressed() {
  Serial.println("blueButtonPressed");
  int button = digitalRead(BLUE_BTN);
  Serial.println(button);
  if(button == HIGH)
  {
    digitalWrite(RED_LED, LOW);
    digitalWrite(GREEN_LED, LOW);
    digitalWrite(BLUE_LED, HIGH);

    send("blue");
  }
  return;
}
