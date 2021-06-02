using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PerLinNoiseGenerate {
    public struct RandomInfo {
        public int index;
        public int value;
    }

    public class RandomInfoIComparer : IComparer {
        public int Compare(object x, object y) {
            RandomInfo l = (RandomInfo)x;
            RandomInfo r = (RandomInfo)y;
            if (l.value < r.value) {
                return -1;
            } else if (l.value > r.value) {
                return 1;
            }

            return 0;
        }
    }

    const int m_length = 16384;
    const int m_lengthIndex = m_length - 1;

    //private int[] m_oldPerm = { 151,160,137,91,90,15,                 // Hash lookup table as defined by Ken Perlin.  This is a randomly
    //131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,    // arranged array of all numbers from 0-255 inclusive.
    //190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
    //88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
    //77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
    //102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
    //135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
    //5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
    //223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
    //129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
    //251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
    //49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
    //138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
    //};

    private int[] m_arrayPermutation;                                                    // floatd permutation to avoid overflow

    public PerLinNoiseGenerate(int seed) {
        System.Random rand = new System.Random(seed);

        RandomInfo[] arrayRandomInfo = new RandomInfo[m_length];

        for(int i = 0; i < m_length; ++i) {
            arrayRandomInfo[i].index = i;
            arrayRandomInfo[i].value = rand.Next();
        }
        Array.Sort(arrayRandomInfo, new RandomInfoIComparer());


        m_arrayPermutation = new int[m_length * 2];
        for (int x = 0; x < m_length * 2; x++) {
            m_arrayPermutation[x] = arrayRandomInfo[x % m_length].index;
        }
    }

    public float OctavePerlin(float x, float y, int octaves = 4, float persistence = 0.25f) {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;  // Used for normalizing result to 0.0 - 1.0
        for (int i = 0; i < octaves; i++) {
            total += perlinNoise(x * frequency, y * frequency) * amplitude;

            maxValue += amplitude;

            amplitude *= persistence;
            frequency *= 2;
        }

        return total / maxValue;
    }

    public float perlinNoise(float x, float y) {
        int xi = (int)x & m_lengthIndex;
        int yi = (int)y & m_lengthIndex;

        float xf = x - (int)x;
        float yf = y - (int)y;

        float u = fade(xf);
        float v = fade(yf);

        int p1 = m_arrayPermutation[m_arrayPermutation[xi] + inc(yi)];
        int p3 = m_arrayPermutation[m_arrayPermutation[xi] + yi];
        int p2 = m_arrayPermutation[m_arrayPermutation[inc(xi)] + inc(yi)];
        int p4 = m_arrayPermutation[m_arrayPermutation[inc(xi)] + yi];

        float x1 = lerp(grad(p1, xf, yf - 1.0f), grad(p2, xf - 1.0f, yf - 1.0f), u);
        float x2 = lerp(grad(p3, xf, yf), grad(p4, xf - 1.0f, yf), u);

        x1 += 0.75f;
        x2 += 0.75f;

        return lerp(x2, x1, v);
    }

    public static float lerp(float a, float b, float t) {
        return a + t * (b - a);
    }

    public static float grad(int hash, float x, float y) {
        switch (hash & 0x7) {
            case 0x0: return (x * 1) + (y * -2);
            case 0x1: return (x * 1) + (y * 2);
            case 0x2: return (x * -1) + (y * -2);
            case 0x3: return (x * -1) + (y * 2);
            case 0x4: return (x * 2) + (y * 1);
            case 0x5: return (x * 2) + (y * -1);
            case 0x6: return (x * -2) + (y * 1);
            case 0x7: return (x * -2) + (y * -1);
            default: return 0;
        }
    }

    public static float fade(float t) {
        return t * t * t * (t * (t * 6 - 15) + 10);         // 6t^5 - 15t^4 + 10t^3
    }

    public int inc(int num) {
        num++;
        return num & m_lengthIndex;
    }
}