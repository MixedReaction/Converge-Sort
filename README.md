# Converge Sort
A stable double-ended selection sort algorithm.

## How It Works
Converge sort works by iterating over the elements of a collection as subsequences. The starting and ending point is determined by the algorithm on every cycle. Cycles can be described as a set of iterations. For every cycle, the starting and ending points of the subsequence are increased or reduced by one. This helps avoid iterating over elements that have already been sorted. For every iteration, both the smallest and largest elements are found and their position in the collection are stored. Using this information, we are able to swap or skip elements when sorting.

## Example
This example aims to provide an in-depth step-by-step process of the algorithm working on a collection of integers.

The set of data will be <b>`5, 2, 4, 1, 3`</b>.

As stated above, the algorithm will work on the set of data in a series of cycles. For every cycle, there are a series of iterations over the set of data it is permited to work on.

<b>The total number of cycles to be performed on the collection can be solved for by dividing the size of the collection in half using a simple floor function.</b>  

<b><i>cycles = (x / 2) - ((x / 2) mod 1)</i></b>  
```csharp
cycles = Math.Floor(x / 2);
````  
Where <b><i>`x`</i></b> is the size of the collection.

For every cycle, the smallest and largest element is found and its position in the collection is also stored. It is worth mentioning that only elements in bold are able to be scanned, in order to avoid comparing already sorted elements.

<b>`5 2 4 1 3`</b>

As we can see, the smallest element is 1 and its position is 3. The largest element is 5 and its position is also 0.
After we have identified the smallest and largest elements, we can now swap them with the elements at the beginning and end of the collection. Let's start with moving the smallest element to the beginning of the collection.

<b>`1 2 4 5 3`</b>  

Notice how 1 has been swapped with 5. This may seem like normal behaviour, but it is actually very problematic. From above, our largest elements position is 0 which is now a value of 1 instead of 5. Now when it's the largest values turn to be swapped, it will swap 1 with 3. In order to avoid this, we must check if the largest values position is the cycles starting point. If so, the largest values position must be updated to reflect the changes. However, we will never have to perform such a check on the smallest value, since it will always be sorted first.

`1`<b>`2 4 3`</b>`5`  

As cycles progress, the number of subsequential elements we are able to iterate over decrease. The starting point increases and the ending point decreases, both by one.

<b>The number of iterations required to sort the data on a specific cycle can be solved for by using:</b>  

<b><i>iterations = (x + 2) - (c * 2)</i></b>  

Where <b><i>`x`</i></b> is the the size of the collection and <b><i>`c`</i></b> is the cycle.  

⚠ <b><i>Please note that cycles start at '1'. If you wish for cycles to start at '0' when performing calculations you can alternatively use:</i></b>  

<b><i>iterations = x - (c * 2)</i></b>  

We can now see that only the values 2, 4, and 3 are able to be compared. Our smallest value is 2 and its position is 1, while our largest value is 4 and its position is 4. Let's begin by swapping the lowest value.

`1`<b>`2 4 3`</b>`5`  

Not much has changed here since the lowest value is already in the correct position. Because of this, the lowest value is skipped and we move on to swapping the largest value.

`1 2 3 4 5`

Notice how none of the elements are in bold, signifying that no iterations can take place. This is because we have finished the final cycle. The algorithm knows that the data will be ordered correctly on the final cycle so no further operations are executed. Please note how the algorithm sorts both sides of the collection from outside to inside, meeting each other in the middle. This is how the algorithms name was chosen.

<b>It is also worth mentioning that we are able to determine the total amount of iterations required to sort the data by using:</b>  

<b><i>total = (x - 2) + 2<sup>n</sup></i></b>  
```csharp
total = (x - 2) + Math.Pow(2, Math.Floor(x / 2));
```
Where <b><i>`x`</i></b> is the size of the collection and <b><i>`n`</i></b> is the total number of cycles.
