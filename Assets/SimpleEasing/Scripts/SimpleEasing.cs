using System;
using UnityEngine;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace SimpleEasing
{
    /// <summary>
    /// Easing function Types
    /// </summary>
    [Serializable]
    public enum EaseType : byte
    {
        InCirc, OutCirc, InOutCirc, OutInCirc,
        InCubic, OutCubic, InOutCubic, OutInCubic,
        InBack, OutBack, InOutBack, OutInBack,
        InQuint, OutQuint, InOutQuint, OutInQuint,
        InExpo, OutExpo, InOutExpo, OutInExpo,
        InSine, OutSine, InOutSine, OutInSine,
        InBounce, OutBounce, InOutBounce, OutInBounce,
        InQuad, OutQuad, InOutQuad, OutInQuad,
        InQuart, OutQuart, InOutQuart, OutInQuart,
        InElastic, OutElastic, InOutElastic, OutInElastic,
        Linear
    }

   

    public static class Ease
    {
        private static readonly Dictionary<EaseType, Func<float, float>> easingMap = new Dictionary<EaseType, Func<float, float>>()
        {
            { EaseType.InCirc, InCirc },
            { EaseType.OutCirc, OutCirc },
            { EaseType.InOutCirc, x => InOut(InCirc, OutCirc, x) },
            { EaseType.OutInCirc, x => OutIn(OutCirc, InCirc, x) },

            { EaseType.InCubic, InCubic },
            { EaseType.OutCubic, OutCubic },
            { EaseType.InOutCubic, x => InOut(InCubic, OutCubic, x) },
            { EaseType.OutInCubic, x => OutIn(OutCubic, InCubic, x) },

            { EaseType.InBack, InBack },
            { EaseType.OutBack, OutBack },
            { EaseType.InOutBack, x => InOut(InBack, OutBack, x) },
            { EaseType.OutInBack, x => OutIn(OutBack, InBack, x) },

            { EaseType.InQuint, InQuint },
            { EaseType.OutQuint, OutQuint },
            { EaseType.InOutQuint, x => InOut(InQuint, OutQuint, x) },
            { EaseType.OutInQuint, x => OutIn(OutQuint, InQuint, x) },

            { EaseType.InExpo, InExpo },
            { EaseType.OutExpo, OutExpo },
            { EaseType.InOutExpo, x => InOut(InExpo, OutExpo, x) },
            { EaseType.OutInExpo, x => OutIn(OutExpo, InExpo, x) },

            { EaseType.InSine, InSine },
            { EaseType.OutSine, OutSine },
            { EaseType.InOutSine, x => InOut(InSine, OutSine, x) },
            { EaseType.OutInSine, x => OutIn(OutSine, InSine, x) },

            { EaseType.InBounce, InBounce },
            { EaseType.OutBounce, OutBounce },
            { EaseType.InOutBounce, x => InOut(InBounce, OutBounce, x) },
            { EaseType.OutInBounce, x => OutIn(OutBounce, InBounce, x) },

            { EaseType.InQuad, InQuad },
            { EaseType.OutQuad, OutQuad },
            { EaseType.InOutQuad, InOutQuad },
            { EaseType.OutInQuad, x => OutIn(OutQuad, InQuad, x) },

            { EaseType.InQuart, InQuart },
            { EaseType.OutQuart, OutQuart },
            { EaseType.InOutQuart, InOutQuart },
            { EaseType.OutInQuart, x => OutIn(OutQuart, InQuart, x) },

            { EaseType.InElastic, InElastic },
            { EaseType.OutElastic, OutElastic },
            { EaseType.InOutElastic, InOutElastic },
            { EaseType.OutInElastic, x => OutIn(OutElastic, InElastic, x) },

            { EaseType.Linear, x => x }
        };

        /// <summary>
        /// Eased the value with the EaseType function.
        /// </summary>
        /// <param name="value">Recommended between 0 to 1</param>
        /// <param name="easeType">Easing function Type</param>
        /// <returns>Eased value</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Easing(float value, EaseType easeType)
        {
            if (easingMap.TryGetValue(easeType, out var func))
                return func(value);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InOut(Func<float, float> inFunc, Func<float, float> outFunc, float value) => value < 0.5f ? inFunc(value * 2) * 0.5f : outFunc(value * 2 - 1) * 0.5f + 0.5f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutIn(Func<float, float> outFunc, Func<float, float> inFunc, float value) => value < 0.5f ? outFunc(value * 2) * 0.5f : inFunc(value * 2 - 1) * 0.5f + 0.5f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InCirc(float value) => 1 - Mathf.Sqrt(1 - value * value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutCirc(float value) => Mathf.Sqrt(1 - (value - 1) * (value - 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InCubic(float value) => value * value * value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutCubic(float value) => (value - 1) * (value - 1) * (value - 1) + 1;

        private const float BackS = 1.70158f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InBack(float value) => value * value * ((BackS + 1) * value - BackS);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutBack(float value) => (--value) * value * ((BackS + 1) * value + BackS) + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InQuint(float value) => value * value * value * value * value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutQuint(float value) => 1 - Mathf.Pow(1 - value, 5);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InExpo(float value) => value == 0 ? 0 : Mathf.Pow(2, 10 * (value - 1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutExpo(float value) => value == 1 ? 1 : 1 - Mathf.Pow(2, -10 * value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InSine(float value) => 1 - Mathf.Cos(value * Mathf.PI / 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutSine(float value) => Mathf.Sin(value * Mathf.PI / 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InBounce(float value) => 1 - OutBounce(1 - value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutBounce(float value)
        {
            if (value < (1 / 2.75f)) return 7.5625f * value * value;
            if (value < (2 / 2.75f)) return 7.5625f * (value -= (1.5f / 2.75f)) * value + 0.75f;
            if (value < (2.5 / 2.75f)) return 7.5625f * (value -= (2.25f / 2.75f)) * value + 0.9375f;
            return 7.5625f * (value -= (2.625f / 2.75f)) * value + 0.984375f;
        }
        // Quad
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InQuad(float value) => value * value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutQuad(float value) => 1 - (1 - value) * (1 - value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InOutQuad(float value) =>
            value < 0.5f ? 2 * value * value : 1 - Mathf.Pow(-2 * value + 2, 2) / 2;

        // Quart
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InQuart(float value) => value * value * value * value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutQuart(float value) => 1 - Mathf.Pow(1 - value, 4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InOutQuart(float value) =>
            value < 0.5f ? 8 * value * value * value * value : 1 - Mathf.Pow(-2 * value + 2, 4) / 2;

        // Elastic
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InElastic(float value)
        {
            if (value == 0) return 0;
            if (value == 1) return 1;
            return -Mathf.Pow(2, 10 * value - 10) * Mathf.Sin((value * 10 - 10.75f) * (2 * Mathf.PI / 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float OutElastic(float value)
        {
            if (value == 0) return 0;
            if (value == 1) return 1;
            return Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 10 - 0.75f) * (2 * Mathf.PI / 3)) + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float InOutElastic(float value)
        {
            if (value == 0) return 0;
            if (value == 1) return 1;
            value *= 2;
            float c = (2 * Mathf.PI) / 4.5f;
            if (value < 1)
                return -0.5f * Mathf.Pow(2, 10 * (value - 1)) * Mathf.Sin((value * 10 - 10.75f) * c);
            return Mathf.Pow(2, -10 * (value - 1)) * Mathf.Sin((value * 10 - 10.75f) * c) * 0.5f + 1;
        }
    }
}