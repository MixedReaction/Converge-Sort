/// <summary>
/// Sorts the elements in an entire one-dimensional array of 32-bit
/// integers.
/// </summary>
/// <param name="array">
/// The one-dimensional array of 32-bit integers to be sorted.
/// </param>
/// <remarks>
/// Uses an unstable double-ended selection sort algorithm.
/// </remarks>
/// <exception cref="ArgumentNullException">
/// Thrown when <paramref name="array"/> is null.
/// </exception>
public static void ConvergeSort(int[] array)
{
    if (array == null)
        throw new ArgumentNullException(
            message: "Value cannot be null.",
            paramName: nameof(array));

    if (array.Length == 1)
        return;

    int cycles = array.Length / 2,
        startPoint = 0,
        endPoint = array.Length - 1;

    for (int cycle = 0; cycle < cycles; cycle++)
    {
        int minValue = array[startPoint],
            minValueIndex = startPoint,
            maxValue = minValue,
            maxValueIndex = startPoint;

        for (int i = startPoint; i <= endPoint; i++)
        {
            int value = array[i];

            if (value < minValue)
            {
                minValue = value;
                minValueIndex = i;
            }
            else if (value > maxValue)
            {
                maxValue = value;
                maxValueIndex = i;
            }
        }

        if (minValueIndex != startPoint)
        {
            array[minValueIndex] = array[startPoint];
            array[startPoint] = minValue;
        }

        if (maxValueIndex == startPoint)
            maxValueIndex = minValueIndex;

        if (maxValueIndex != endPoint)
        {
            array[maxValueIndex] = array[endPoint];
            array[endPoint] = maxValue;
        }

        startPoint++;
        endPoint--;
    }
}
