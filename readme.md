# Voter - demo #

## Popis ##
Ukázková aplikace v .NET technologii.
Propojení ASP.NET MVC aplikace s IoT zařízením.

Aplikace slouží ke správě kampaní - anket a jejich otázkám. V první verzi umožňuje volby Ano/Ne.
Následně lze celou kampaň spustit, web zobrazí otázku a k ní graf.

Graf se automaticky obnovuje během hlasování.

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