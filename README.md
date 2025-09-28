# BlazorAppDebugTest

Dieses Beispiel zeigt, wie man in einem C#-WebAssembly-Projekt debugfähig die Komponente SkiaSharp einsetzt.

Folgende NuGet-Abhängigkeiten müssen dem Client-Projekt hinzugefügt werden:

- SkiaSharp
- SkiaSharp.NativeAssets.WebAssembly

In diesem Projekt geht es darum, im Browser PDF mit SkiaSharp zu erzeugen. Es ist keine Interaktivität notwendig. Dadurch bleibt das Beispiel einfach, weil u.a. kein Multithreading notwendig ist.
