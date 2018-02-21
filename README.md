# UFaceOSC

OSC message parser for FaceOSC

## Platforms

- MacOS

## Requirement

- [uOSC](https://github.com/hecomi/uOSC)

## Installation

Download the latest .unitypackage from [Release page](https://github.com/endoh0509/UFaceOSC/releases) and import it to your Unity project.

## Usage

```cs
using System.Collections;
using UnityEngine;
using uOSC;
using UFaceOSC;

public class main : MonoBehaviour {
  private FaceOSC.Parser faceOscParser;
  
  void Start()
  {
    faceOscParser = new UFaceOSC.Parser();
    var server = GetComponent <uOscServer>();
    server.onDataReceived.AddListener(OnDataReceived);
  }

  void OnDataReceived(Message message)
  {
    faceOscParser.SetData(message.address, message.values);
    Vector2[] rawPoints = faceOscParser.GetRaw().GetPoints();
    UFaceOSC.Face face = faceOscParser.GetFace();
    Debug.Log(Face.found);
  }
}
```

License
-------
The MIT License (MIT)

Copyright (c) 2018 enkatsu

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
