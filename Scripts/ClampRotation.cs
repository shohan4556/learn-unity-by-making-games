  public float ClampRotation_0_360(float eulerAngles) {
        float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
        if (result < 0) {
            result += 360f;
        }
        return result;
    }
    
