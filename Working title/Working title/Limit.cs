using System;

namespace Working_title
{
    public class Limit
    {
        private float MyMaxLimit;
        private float MyMinLimit;

        public float MaxLimit => MyMaxLimit;
        public float MinLimit => MyMinLimit;

        public Limit(float maxLimit)
        {
            MyMaxLimit = maxLimit;
        }

        public Limit(float maxLimit, float minLimit)
        {
            MyMaxLimit = maxLimit;
            MyMinLimit = minLimit;
        }

        public float GetWithinLimit(float value)
        {
            if (value > MyMaxLimit)
            {
                return MyMaxLimit;
            }
            if (value < MyMinLimit)
            {
                return MyMinLimit;
            }
            return value;
        }

        public void SetMaxLimit(float maxLimit)
        {
            MyMaxLimit = maxLimit;
        }

        public float RandomFloatWithinLimit()
        {
            float RandomFloat = (float) new Random().NextDouble()*MyMaxLimit;
            return RandomFloat >= MyMinLimit ? RandomFloat : MyMinLimit;
        }

        public int RandomIntWithinLimit()
        {
            return (int)RandomFloatWithinLimit();
        }
    }
}