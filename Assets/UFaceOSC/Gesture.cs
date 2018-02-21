using System;
using System.Collections.Generic;
﻿using UnityEngine;

namespace UFaceOSC {
  public class Gesture {
    public Mouth mouth;
    public Eyebrow eyebrow;
    public Eye eye;
    public float jaw;
    public float nostrils;

    public void SetValues(Queue<string> queue, object[] values) {
      string first = queue.Dequeue();
      if (first == "mouth") {
        this.mouth.SetValues(queue, values);
      } else if (first == "eyebrow") {
        this.eyebrow.SetValues(queue, values);
      } else if (first == "eye") {
        this.eye.SetValues(queue, values);
      } else if (first == "jaw") {
        this.jaw = (float) values[0];
      } else if (first == "nostrils") {
        this.nostrils = (float) values[0];
      }
    }
  }
}
