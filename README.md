# BlazorAppDebugTest

Dieses Beispiel zeigt, wie man in einem C#-WebAssembly-Projekt debugfähig die Komponente SkiaSharp einsetzt.

Folgende NuGet-Abhängigkeiten wurden dem Standard-Client-Projekt hinzugefügt:

- SkiaSharp
- SkiaSharp.NativeAssets.WebAssembly

In diesem Projekt geht es darum, im Browser PDF mit SkiaSharp zu erzeugen. Es ist keine Interaktivität notwendig. Dadurch bleibt das Beispiel einfach, weil u.a. kein Multithreading notwendig ist.

## Nachbildung Windows-GDI

Zusätzlich wurde das Projekt generiert, um eine C#-API zu bauen, die möglichst nahe am Windows-GDI liegt. Damit soll die Portierung einer mit den MFC in C++ implementierten Druckfunktionalität erleichtert werden. Aktuell funktioniert das mit einer ähnlichen Lösung bereits für das RTF-Rendering. Der Ansatz in diesem Projekt soll das GDI noch generischer abbilden, damit auch der Druck von Formularen leichter portiert werden kann.
