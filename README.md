# PFAB.AsciiArt

## Summary

Implementation of [Programming Projects for Advanced Beginners #1: ASCII art](https://robertheaton.com/2018/06/12/programming-projects-for-advanced-beginners-ascii-art/)

## Usage

Call from command line with following parameters
|Short   |Long                    |Function
|-----   |----                    |--------
|*s*     |source                  |Source of image to be processed. [file, webcam]
|*b*     |brightnessCalculation   |Brightness calculation mode. [average, lightness, luminosity]
|*c*     |colorMode               |Color mode. [default, matrix, color]
|*i*     |invertedMode            |Inverted brightness calculation.
|*p*     |path                    |Path to the image that would be processed to ASCII.
|*h*     |help                    |Display help message.

## Example

```console
.\PFAB.AsciiArt.Runner.exe --brightnessCalculation lightness --source file --path .\ascii-pineapple.jpg --colorMode color
```

![ASII Art Pineapple](https://raw.githubusercontent.com/Kolejarz/PFAB.AsciiArt/assets/PFAB.AsciiArt.Runner/assets/ascii.png "Pineapple")
