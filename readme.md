# Voter - demo #

## Popis ##
Ukázková aplikace v .NET technologii.
Propojení ASP.NET MVC aplikace s IoT zařízením.

Aplikace slouží ke správě kampaní - anket a jejich otázkám. V první verzi umožňuje volby Ano/Ne.
Následně lze celou kampaň spustit, web zobrazí otázku a k ní graf.

Graf se automaticky obnovuje během hlasování.

## Hardware ##

Zařízení bylo postaveno na desce WeMos D1 ESP8266 WiFi Board.
Nejde tedy o Arduino desku, jen využívá layout Arduina Uno!

### Schéma zapojení ###

![Schéma](Arduino/schema_bb.png?raw=true)

### Seznam součástek ###

<table>

  <thead>
   <tr>
    <th>Label</th>
    <th>Part Type</th>
    <th>Properties</th>
    </tr>
  </thead>
  <tbody>
  <tr>
    <td>LED1</td>
    <td>RGB LED (com. cathode, rgb)</td>
    <td class="props">polarity common cathode; rgb RGB; pouzdro 5 mm [THT]; pin order rgb</td>
</tr><tr>
    <td>R1</td>
    <td>220Ω Resistor</td>
    <td class="props">odstup pinů 400 mil; tolerance ±5%; odpor 220Ω; bands 4; pouzdro THT</td>
</tr><tr>
    <td>R2</td>
    <td>1kΩ Resistor</td>
    <td class="props">odstup pinů 400 mil; tolerance ±5%; odpor 1kΩ; bands 4; pouzdro THT</td>
</tr><tr>
    <td>S1</td>
    <td>Pushbutton</td>
    <td class="props">pouzdro [THT]</td>
</tr><tr>
    <td>S2</td>
    <td>Pushbutton</td>
    <td class="props">pouzdro [THT]</td>
</tr><tr>
    <td>WeMos D1 R1</td>
    <td>WeMos D1 R2</td>
    <td class="props">varianta D1 R2</td>
</tr>
  </tbody>
</table>
<h2>Shopping List</h2>
<table>
  <thead>
	<tr>
    <th>Amount</th>
    <th>Part Type</th>
    <th>Properties</th>
    </tr>
  </thead>
  <tbody>
<tr>
    <td>1</td>
    <td>RGB LED (com. cathode, rgb)</td>
    <td class="props">polarity common cathode; rgb RGB; pouzdro 5 mm [THT]; pin order rgb</td>
</tr><tr>
    <td>1</td>
    <td>220Ω Resistor</td>
    <td class="props">odstup pinů 400 mil; tolerance ±5%; odpor 220Ω; bands 4; pouzdro THT</td>
</tr><tr>
    <td>1</td>
    <td>1kΩ Resistor</td>
    <td class="props">odstup pinů 400 mil; tolerance ±5%; odpor 1kΩ; bands 4; pouzdro THT</td>
</tr><tr>
    <td>2</td>
    <td>Pushbutton</td>
    <td class="props">pouzdro [THT]</td>
</tr><tr>
    <td>1</td>
    <td>WeMos D1 R2</td>
    <td class="props">varianta D1 R2</td>
</tr>
  </tbody>
</table>

 - [seznam součástek](Arduino/schema_bom.html)

Schéma bylo vytvořeno pomocí aplikace Fritzing.

## Použité zdroje ##
 - [chartjs](https://www.chartjs.org/)
   - Grafy v aplikace
 - [SignalR](https://dotnet.microsoft.com/apps/aspnet/real-time)
   - realtime komunikace mezi webem a webovou aplikací
 - [ASP.NET MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)
   - webový framework technologie .NET
 - [Arduino ESP8266 příklady](https://github.com/esp8266/Arduino)
   - inspirace pro stavbu HW prototypu
 - [vali-admin](https://pratikborsadiya.in/blog/vali-admin/)
   - grafika pro web

## Struktura složek ##
 - Arduino
   - zdrojové kódy pro HW prototyp
 - Db
   - SQL skripty pro přípravu MSSQL DB
 - Design
   - grafický návrh v HTML/CSS/JS
 - Powershell
   - Pomocné skripty (např. simulátor HW)
 - Voter
   - zdrojoké kódy webové aplikace

## Kontakty ##
 - [Skeleton Software](https://www.skeleton.cz/)
 - [lorenzo.cz](https://lorenzo.cz/)