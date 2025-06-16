﻿using System.Collections.Generic;

namespace EXIFRemover.Core
{
    public class JPGMarkers 
    { 
            public HashSet<byte> markers = new HashSet<byte>()
            {
              //0xD8, — Маркер начала изображения. Далее маркеры сегментов APP0-APP15 + COM
                0xE1,
                0xE2,
                0xE3,
                0xE4,
                0xE3,
                0xE4,
                0xE5,
                0xE6,
                0xE7,
                0xE8,
                0xE9,
                0xEA,
                0xEB,
                0xEC,
                0xED,
                0xEE,
                0xEF,
                0xFE,
              //0xD9 — Маркер конца изображения.
            };
    }
}
