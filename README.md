#  ASCII ART IN C&#35;
>![image](https://github.com/Kishou-Arima/ASCII_Art_in_CSharp/assets/62903411/b3fe9c41-17a1-4349-bf9c-1c24c113e749)
First Version

------------

## Inspiration?
> [AlexJMercer](https://github.com/AlexJMercer) made a Console Application in C++ that took video from webcam and changed it into ASCII Art {[Linkie over here](https://github.com/AlexJMercer/ASCII_Art)} (kudos for it!). That got me thinking, If something like this was possible in C++, wouldn&#39;t it be possible in C# too?
Taking a look into it, OpenCV works with C, C++ and python and more. But has no native support in C#.

## Solution?
> Enter `OpenCVSharp4`, a wrapper basically, that allows Open CV to run with C#. A few documentations and debugs later, the current (1st) version started to run.

## How it works?
> It is a bit slower version as it preprocesses each frame into grayscale. Grayscale has just a single variable; its `intensity` or its level of how close to black or white a pixel is. This just makes it easier to encode it in ASCII format, by assigning a certain intensity to a certain character.

## How to run?
> - Open Visual Studio, make sure you have the dependencies: `.NET 6.0(LTS)+`, C# support and `OpenCVSharp4` dependencies installed.
- Git clone the repo, and from the `Nuget Package Manager`, install `OpenCVSharp4`.
- Run the Project.
***or***
Just load up the Release(once it is released)

## Notes ⚠️
> You are free to use the code for your own use. If you spot any issues, just open up an issue and if you wish to, you can contribute to it :)
